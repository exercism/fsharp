module Generators.Formatting

open System
open System.Collections.Generic
open FSharp.Reflection
open Newtonsoft.Json.Linq
open Conversion

let parenthesizeOption value = 
    match value with
    | "None" -> value
    | _ -> String.parenthesize value

let renderString (str: string) =
    str.Replace("\n", "\\n")
       .Replace("\t", "\\t")
       .Replace("\r", "\\r")
       .Replace("\"", "\\\"")
    |> String.enquote

let renderBool b = if b then "true" else "false"

let renderDateTime (dateTime: DateTime) = 
    if dateTime.TimeOfDay = TimeSpan.Zero then
        sprintf "DateTime(%d, %d, %d)" dateTime.Year dateTime.Month dateTime.Day
    else
        sprintf "DateTime(%d, %d, %d, %d, %d, %d)" dateTime.Year dateTime.Month dateTime.Day dateTime.Hour dateTime.Minute dateTime.Second

let renderTimeSpan (timeSpan: TimeSpan) = 
    sprintf "TimeSpan(%d, %d, %d)" timeSpan.Hours timeSpan.Minutes timeSpan.Seconds

let renderJToken (jToken: JToken) =
    match jToken.Type with
    | JTokenType.Integer when JToken.isInt64 jToken -> jToken.ToObject<int64>() |> string
    | JTokenType.Integer  -> jToken.ToObject<int>()      |> string
    | JTokenType.Float    -> jToken.ToObject<float>()    |> string
    | JTokenType.Boolean  -> jToken.ToObject<bool>()     |> renderBool
    | JTokenType.String   -> jToken.ToObject<string>()   |> renderString
    | JTokenType.Date     -> jToken.ToObject<DateTime>() |> renderDateTime
    | JTokenType.TimeSpan -> jToken.ToObject<TimeSpan>() |> renderTimeSpan
    | _ -> string jToken

let renderJArray (jArray: JArray) =
    jArray
    |> List.ofJArray
    |> sprintf "%A"

let renderTuple tuple = sprintf "%A" tuple

let renderRecord record = sprintf "%A" record

let renderOption option = 
    match option with
    | None -> "None"
    | Some x -> sprintf "Some %s" x

let renderResult result = 
    match result with
    | Ok x -> sprintf "Ok %s" x
    | Error y -> sprintf "Error %s" y

let rec renderObj (value: obj) =
    match value with
    | :? string as s -> 
        renderString s
    | :? bool as b -> 
        renderBool b
    | :? DateTime as dateTime -> 
        renderDateTime dateTime
    | :? JArray as jArray -> 
        renderJArray jArray
    | :? JToken as jToken -> 
        renderJToken jToken
    | :? Option<obj> as option -> 
        option |> Option.map renderObj |> renderOption
    | :? Result<obj, obj> as result -> 
        result |> Result.map renderObj |> Result.mapError renderObj |> renderResult
    | _ when FSharpType.IsTuple (value.GetType()) -> 
        renderTuple value
    | _ when FSharpType.IsRecord (value.GetType()) -> 
        renderRecord value
    | _ -> 
        string value

let private renderCollection formatString collection =
    collection
    |> String.concat "; "
    |> sprintf formatString

let private renderMultiLineCollection (openPrefix, closePostfix) collection indentation =
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
        |> List.map (String.indent indentation)
        |> String.concat "\n"
        |> sprintf "\n%s"


let renderMultiLineListWithIndentation indentation sequence = renderMultiLineCollection ("[", "]") sequence indentation

module Option =

    let private renderMap valueMap someMap option =
        match option with
        | None -> "None"
        | Some value -> sprintf "Some %s" (valueMap value) |> someMap

    let renderString option = renderMap id id option

    let renderStringParenthesized option = renderMap id String.parenthesize option

    let render option = renderMap renderObj id option

    let renderParenthesized option = renderMap renderObj String.parenthesize option

module List =

    let render value = renderCollection "[%s]" value

    let renderMultiLine value = renderMultiLineListWithIndentation 2 value

module Array =

    let render value = renderCollection "[|%s|]" value

module Obj =

    let render value = renderObj value

    let renderEnum typeName value = 
        let enumType = String.upperCaseFirst typeName
        let enumValue = String.dehumanize (string value)
        sprintf "%s.%s" enumType enumValue   
