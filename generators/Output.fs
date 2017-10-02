module Generators.Output

open System
open System.Collections.Generic
open System.IO
open System.Reflection
open FSharp.Reflection
open DotLiquid
open DotLiquid.FileSystems
open Newtonsoft.Json.Linq
open Input

let indent value = sprintf "    %s" value

let parenthesize value = sprintf "(%s)" value

let escapeSpecialCharacters (str: string) =
    str.Replace("\n", "\\n")
       .Replace("\t", "\\t")
       .Replace("\r", "\\r")
       .Replace("\"", "\\\"")

let formatCollection formatString collection =
    collection
    |> String.concat "; "
    |> sprintf formatString

let formatList sequence = formatCollection "[%s]" sequence

let formatArray sequence = formatCollection "[|%s|]" sequence

let formatSequence sequence = formatCollection "seq {%s}" sequence

let formatString str = 
    str
    |> escapeSpecialCharacters
    |> sprintf "\"%s\""

let formatBool b = if b then "true" else "false"

let formatDateTime (dateTime: DateTime) = 
    if (dateTime.TimeOfDay = TimeSpan.Zero) then
        sprintf "DateTime(%d, %d, %d)" dateTime.Year dateTime.Month dateTime.Day
    else
        sprintf "DateTime(%d, %d, %d, %d, %d, %d)" dateTime.Year dateTime.Month dateTime.Day dateTime.Hour dateTime.Minute dateTime.Second

let formatTimeSpan (timeSpan: TimeSpan) = 
    sprintf "TimeSpan(%d, %d, %d)" timeSpan.Hours timeSpan.Minutes timeSpan.Seconds

let normalizeJArray (jArray: JArray): obj list =
    let toBoxedList seq = 
        seq
        |> Seq.map box 
        |> List.ofSeq

    if (jArray.Count = 0) then
        []
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Integer)) then
        jArray.Values<int>() |> toBoxedList
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Float)) then
        jArray.Values<float>() |> toBoxedList
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Boolean)) then
        jArray.Values<bool>() |> toBoxedList
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.String)) then
        jArray.Values<string>() |> toBoxedList
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Date)) then
        jArray.Values<DateTime>() |> toBoxedList
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.TimeSpan)) then
        jArray.Values<TimeSpan>() |> toBoxedList
    else if (jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Object)) then
        jArray.Children() |> Seq.map (fun jObject -> jObject.ToObject<Dictionary<string, obj>>()) |> toBoxedList
    else    
        jArray.Values<obj>() |> toBoxedList

let formatToken (jToken: JToken) =
    match jToken.Type with
    | JTokenType.Integer  -> jToken.ToObject<int>()      |> string
    | JTokenType.Float    -> jToken.ToObject<float>()    |> string
    | JTokenType.Boolean  -> jToken.ToObject<bool>()     |> formatBool
    | JTokenType.String   -> jToken.ToObject<string>()   |> formatString
    | JTokenType.Date     -> jToken.ToObject<DateTime>() |> formatDateTime
    | JTokenType.TimeSpan -> jToken.ToObject<TimeSpan>() |> formatTimeSpan
    | _ -> string jToken

let formatJArray (jArray: JArray) =
    jArray
    |> normalizeJArray
    |> sprintf "%A"

let formatTuple tuple = sprintf "%A" tuple

let formatRecord record = sprintf "%A" record

let rec formatValue (value: obj) =
    match value with
    | :? string as s -> formatString s
    | :? bool as b -> formatBool b
    | :? DateTime as dateTime -> formatDateTime dateTime
    | :? JArray as jArray -> formatJArray jArray
    | :? JToken as jToken -> formatToken jToken
    | _ when FSharpType.IsTuple (value.GetType()) -> formatTuple value
    | _ when FSharpType.IsRecord (value.GetType()) -> formatRecord value
    | _ -> string value

let formatOption noneTest (value: obj) =
    if noneTest value then 
        "None" 
    else
        sprintf "Some %s" (formatValue value)

let formatNullableToOption (value: obj) = formatOption isNull value

type OutputFilter() =
    static member Format (input: string) = formatValue input

    static member Indent (input: string) = indent input

let private fileSystem = EmbeddedFileSystem(Assembly.GetExecutingAssembly(), "")
Template.RegisterFilter(OutputFilter().GetType())
Template.FileSystem <- fileSystem :> DotLiquid.FileSystems.IFileSystem

let private registrations = Dictionary<_,_>()
let rec private registerTypeTree ty =
    if registrations.ContainsKey ty then ()
    elif FSharpType.IsRecord ty then
        let properties = ty.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
        Template.RegisterSafeType(ty, [| for p in properties -> p.Name |])
        registrations.[ty] <- true
        for p in properties do registerTypeTree p.PropertyType
    elif ty.IsGenericType then
        let t = ty.GetGenericTypeDefinition()
        if t = typedefof<seq<_>> || t = typedefof<list<_>> then
            registrations.[ty] <- true
            registerTypeTree (ty.GetGenericArguments().[0])
        elif t = typedefof<IDictionary<_,_>> || t = typedefof<Map<_,_>> then
            registrations.[ty] <- true
            registerTypeTree (ty.GetGenericArguments().[0])
            registerTypeTree (ty.GetGenericArguments().[1])
        elif t = typedefof<option<_>> then
            Template.RegisterSafeType(ty, [|"Value"; "IsSome"; "IsNone";|])
            registrations.[ty] <- true
            registerTypeTree (ty.GetGenericArguments().[0])
        elif ty.IsArray then          
            registrations.[ty] <- true
            registerTypeTree (ty.GetElementType())
    else 
        let properties = ty.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
        Template.RegisterSafeType(ty, [| for p in properties -> p.Name |])
        registrations.[ty] <- true
        for p in properties do registerTypeTree p.PropertyType

let renderInlineTemplate template value =
    value.GetType() |> registerTypeTree

    let parsedTemplate = Template.Parse template
    parsedTemplate.Render(Hash.FromAnonymousObject(value))

let renderPartialTemplate templateName value =
    let template = sprintf "{%% include \"%s\" %%}" templateName
    renderInlineTemplate template value