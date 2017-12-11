module Generators.Formatting

open System
open System.Collections.Generic
open FSharp.Reflection
open Newtonsoft.Json.Linq

let indent level value = 
    let indentation = String.replicate level "    "
    sprintf "%s%s" indentation value

let parenthesize value = sprintf "(%s)" value

let parenthesizeOption value = 
    match value with
    | "None" -> value
    | _ -> parenthesize value

let backwardPipe value = sprintf "<| %s" value

let backwardPipeIf test value = if test value then backwardPipe value else value

let addTypeAnnotation typeAnnotation value = sprintf "%s: %s" value typeAnnotation

let escapeSpecialCharacters (str: string) =
    str.Replace("\n", "\\n")
       .Replace("\t", "\\t")
       .Replace("\r", "\\r")
       .Replace("\"", "\\\"")

let formatString str = 
    str
    |> escapeSpecialCharacters
    |> sprintf "\"%s\""

let formatBool b = if b then "true" else "false"

let formatDateTime (dateTime: DateTime) = 
    if dateTime.TimeOfDay = TimeSpan.Zero then
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

    if jArray.Count = 0 then
        []
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Integer) then
        jArray.Values<int>() |> toBoxedList
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Float) then
        jArray.Values<float>() |> toBoxedList
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Boolean) then
        jArray.Values<bool>() |> toBoxedList
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.String) then
        jArray.Values<string>() |> toBoxedList
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Date) then
        jArray.Values<DateTime>() |> toBoxedList
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.TimeSpan) then
        jArray.Values<TimeSpan>() |> toBoxedList
    else if jArray.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Object) then
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

let formatOption option = 
    match option with
    | None -> "None"
    | Some x -> sprintf "Some %s" x

let formatResult result = 
    match result with
    | Ok x -> sprintf "Ok %s" x
    | Error y -> sprintf "Error %s" y

let rec formatValue (value: obj) =
    match value with
    | :? string as s -> 
        formatString s
    | :? bool as b -> 
        formatBool b
    | :? DateTime as dateTime -> 
        formatDateTime dateTime
    | :? JArray as jArray -> 
        formatJArray jArray
    | :? JToken as jToken -> 
        formatToken jToken
    | :? Option<obj> as option -> 
        option |> Option.map formatValue |> formatOption
    | :? Result<obj, obj> as result -> 
        result |> Result.map formatValue |> Result.mapError formatValue |> formatResult
    | _ when FSharpType.IsTuple (value.GetType()) -> 
        formatTuple value
    | _ when FSharpType.IsRecord (value.GetType()) -> 
        formatRecord value
    | _ -> 
        string value

let formatCollection formatString collection =
    collection
    |> String.concat "; "
    |> sprintf formatString

let formatList sequence = formatCollection "[%s]" sequence

let formatArray sequence = formatCollection "[|%s|]" sequence

let formatSequence sequence = formatCollection "seq {%s}" sequence

let formatMultiLineCollection (openPrefix, closePostfix) collection =
    match Seq.length collection with
    | 0 -> 
        sprintf "%s%s" openPrefix closePostfix
    | 1 -> 
        sprintf "%s%s%s" openPrefix (Seq.head collection) closePostfix    
    | length -> 
        let lineIndent = String(' ', String.length openPrefix)

        let formatLine i line = 
            match i with
            | 0 -> 
                sprintf "%s %s;" openPrefix line
            | _ when i = length - 1 -> 
                sprintf "%s %s %s" lineIndent line closePostfix
            | _ ->
                sprintf "%s %s;" lineIndent line

        collection
        |> Seq.mapi formatLine
        |> Seq.toList
        |> List.map (indent 2)
        |> String.concat "\n"
        |> sprintf "\n%s"

let formatMultiLineList sequence = formatMultiLineCollection ("[", "]") sequence

let formatMultiLineArray sequence = formatMultiLineCollection ("[|", "|]") sequence

let formatMultiLineSequence sequence = formatMultiLineCollection ("seq {", "}") sequence

let formatMultiLineString strings = 
    let length = Seq.length strings
    let formatLine i line =
        match i = length - 1 with
        | true  -> line
        | false -> sprintf "%s +" line

    strings
    |> Seq.mapi formatLine
    |> Seq.toList