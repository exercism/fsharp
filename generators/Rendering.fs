module Generators.Rendering

open System
open FSharp.Reflection
open Newtonsoft.Json.Linq

module String =

    let private escapeSpecialCharacters(str: string) =
        str.Replace("\n", "\\n")
           .Replace("\t", "\\t")
           .Replace("\r", "\\r")
           .Replace("\"", "\\\"")

    let render (str: string) =
        str
        |> escapeSpecialCharacters
        |> String.enquote

module Bool =    

    let render b = if b then "true" else "false"

module DateTime =

    let render (dateTime: DateTime) = 
        if dateTime.TimeOfDay = TimeSpan.Zero then
            $"DateTime(%d{dateTime.Year}, %d{dateTime.Month}, %d{dateTime.Day})"
        else
            $"DateTime(%d{dateTime.Year}, %d{dateTime.Month}, %d{dateTime.Day}, %d{dateTime.Hour}, %d{dateTime.Minute}, %d{dateTime.Second})"

    let renderParenthesized (dateTime: DateTime) = 
        dateTime
        |> render
        |> String.parenthesize

module Obj =

    let private renderJToken (jToken: JToken) =
        match jToken.Type with
        | JTokenType.Integer  -> jToken.ToObject<int64>()    |> string
        | JTokenType.Float    -> jToken.ToObject<float>()    |> string
        | JTokenType.Boolean  -> jToken.ToObject<bool>()     |> Bool.render
        | JTokenType.String   -> jToken.ToObject<string>()   |> String.render
        | JTokenType.Date     -> jToken.ToObject<DateTime>() |> DateTime.render
        | _ -> string jToken

    let private renderTuple tuple = $"%A{tuple}"

    let private renderRecord record = $"%A{record}"

    let rec private renderObj (value: obj) =
        let rec renderJArray (jArray: JArray) =
            jArray
            |> Seq.map renderObj
            |> String.concat "; "
            |> sprintf "[%s]"

        match value with
        | :? string as s -> 
            String.render s
        | :? bool as b -> 
            Bool.render b
        | :? DateTime as dateTime -> 
            DateTime.render dateTime
        | :? JArray as jArray -> 
            renderJArray jArray
        | :? JToken as jToken -> 
            renderJToken jToken
        | _ when FSharpType.IsTuple (value.GetType()) -> 
            renderTuple value
        | _ when FSharpType.IsRecord (value.GetType()) -> 
            renderRecord value
        | _ -> 
            string value

    let render value = renderObj value

    let renderEnum typeName value = 
        let enumType = String.upperCaseFirst typeName
        let enumValue = String.dehumanize (string value)
        $"%s{enumType}.%s{enumValue}"    

module Option =

    let private renderMap valueMap someMap option =
        match option with
        | None -> "None"
        | Some value -> $"Some %s{valueMap value}" |> someMap

    let renderString option = renderMap id id option

    let renderStringParenthesized option = renderMap id String.parenthesize option

    let render option = renderMap Obj.render id option

    let renderParenthesized option = renderMap Obj.render String.parenthesize option

    let renderParenthesizedString option = renderMap String.parenthesize id option

module Collection =
    let render formatString collection =
        collection
        |> String.concat "; "
        |> sprintf formatString

    let renderMultiLine openPrefix closePostfix collection =
        match Seq.length collection with
        | 0 -> 
            $"%s{openPrefix}%s{closePostfix}"
        | 1 -> 
            $"%s{openPrefix}%s{Seq.head collection}%s{closePostfix}"
        | length -> 
            let lineIndent = String(' ', String.length openPrefix)

            let formatLine i line = 
                match i with
                | 0 -> 
                    $"%s{openPrefix} %s{line};"
                | _ when i = length - 1 -> 
                    $"%s{lineIndent} %s{line} %s{closePostfix}"
                | _ ->
                    $"%s{lineIndent} %s{line};"

            collection
            |> Seq.mapi formatLine
            |> Seq.toList
            |> List.map (String.indent 2)
            |> String.concat "\n"
            |> sprintf "\n%s"

module List =

    let mapRender map value = Collection.render "[%s]" (Seq.map map value)

    let mapRenderMultiLine map value = Collection.renderMultiLine "[" "]" (Seq.map map value)

    let render value = mapRender Obj.render value

    let renderMultiLine value = mapRenderMultiLine Obj.render value

module Array =

    let renderStrings value = Collection.render "[|%s|]" value

    let render value = 
        value
        |> Seq.map Obj.render
        |> renderStrings

module Map =

    let private renderMap<'TKey, 'TValue> map suffix (value: JToken) =
        let dict = value.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>()
        let formattedList = List.mapRenderMultiLine map dict
        let whitespace = if Seq.length dict < 2 then " " else sprintf "\n%s" (String.indent 2 "")
        $"%s{formattedList}%s{whitespace}|> Map.ofList%s{suffix}"

    let mapRender<'TKey, 'TValue> map (value: JToken) =
        renderMap<'TKey, 'TValue> map "" value

    let render<'TKey, 'TValue> (value: JToken) =
        mapRender<'TKey, 'TValue> (fun kv -> Obj.render(kv.Key, kv.Value)) value

    let mapRenderOption<'TKey, 'TValue> map (option: JToken option) =
        match option with 
        | None -> "None"
        | Some value ->
            let suffix = if Seq.length value < 2 then " |> Some" else sprintf "\n%s" (String.indent 2 "|> Some")
            renderMap<'TKey, 'TValue> map suffix value

    let renderOption<'TKey, 'TValue> (option: JToken option) =
        mapRenderOption<'TKey, 'TValue> (fun kv -> Obj.render(kv.Key, kv.Value)) option
