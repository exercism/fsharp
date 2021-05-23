[<AutoOpen>]
module Generators.Conversion

open System
open Newtonsoft.Json.Linq

module Option =
    let ofNonNegativeNumber (jToken: JToken) =
        match jToken.Type with
        | JTokenType.Integer -> if jToken.ToObject<int>() < 0 then None else Some jToken
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
        | _  -> $"%c{Char.ToUpper(str.[0])}%s{str.[1..]}"

    let lowerCaseFirst (str: string) = 
        match str with
        | "" -> str
        | _  -> $"%c{Char.ToLower(str.[0])}%s{str.[1..]}"

    let replace (oldValue: string) (newValue: string) (str: string) =
        str.Replace(oldValue, newValue)    

    let toLower (str: string) = str.ToLowerInvariant()

    let indent level str =
        let oneLevelIndentation = "    "
        let indentation = String.replicate level oneLevelIndentation
        $"%s{indentation}%s{str}"

    let enquote str = $"\"%s{str}\""

    let parenthesize str = $"(%s{str})"

    let split (separator: string) (str: string) = str.Split(separator)

module Map =

    open System.Collections.Generic    

    let ofJToken<'TKey, 'TValue when 'TKey: comparison> (jToken: JToken)   =
        jToken.ToObject<IDictionary<'TKey, 'TValue>>()
        |> Seq.map (fun (KeyValue(k,v)) -> (k, v))
        |> Map.ofSeq