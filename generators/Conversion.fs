[<AutoOpen>]
module Generators.Conversion

open System
open Newtonsoft.Json.Linq

module Option =
    let ofNonNegativeNumber (jToken: JToken) =
        match jToken.Type with
        | JTokenType.Integer -> if jToken.ToObject<int>() < 0 then None else Some jToken
        | _ -> Some jToken

    let ofNonFalseBoolean (jToken: JToken) =
        match jToken.Type with
        | JTokenType.Boolean -> if jToken.ToObject<bool>() then Some jToken else None
        | _ -> Some jToken

    let ofNonNull (jToken: JToken) =
        match jToken.Type with
        | JTokenType.Null -> None
        | _ -> Some jToken

    let ofNonErrorObject (jToken: JToken) =
        match jToken.SelectToken("error") |> isNull with
        | true  -> Some jToken
        | false -> None

    let ofNonEmptyString (value: string) =
        match String.IsNullOrEmpty value with
        | true  -> None
        | false -> Some value

module String =
    open Humanizer
    
    let dehumanize (str: string) = str.Dehumanize()

    let camelize (str: string) = str.Camelize()

    let upperCaseFirst (str: string) = 
        match str with
        | "" -> str
        | _  -> sprintf "%c%s" (Char.ToUpper(str.[0])) str.[1..]

    let lowerCaseFirst (str: string) = 
        match str with
        | "" -> str
        | _  -> sprintf "%c%s" (Char.ToLower(str.[0])) str.[1..]

    let replace (oldValue: string) (newValue: string) (str: string) =
        str.Replace(oldValue, newValue)    

    let toLower (str: string) = str.ToLowerInvariant()

    let indent level str =
        let oneLevelIndentation = "    "
        let indentation = String.replicate level oneLevelIndentation
        sprintf "%s%s" indentation str

    let enclose before after str = sprintf "%s%s%s" before str after

    let enquote str = enclose "\"" "\"" str

    let parenthesize str = enclose "(" ")" str

    let split (separator: string) (str: string) = str.Split(separator)

module Dict =

    let toSeq d = d |> Seq.map (fun (KeyValue(k,v)) -> (k, v))

    let toMap d = d |> toSeq |> Map.ofSeq

module Array =

    let ofObj (value: obj) = value :?> JArray |> Seq.toArray

module List =

    let ofObj (value: obj) = value :?> JArray |> Seq.toList