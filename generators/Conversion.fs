[<AutoOpen>]
module Generators.Convert

open System
open Newtonsoft.Json.Linq

module Option =
    let ofPositiveInt (value: obj) =
        match value with
        | :? int64 as i -> if i < 0L then None else Some value
        | :? int32 as i -> if i < 0  then None else Some value
        | _ -> Some value

    let ofNonFalse (value: obj) =
        match value with
        | :? bool as b when not b -> None
        | _ -> Some value

    let ofNonError (value: obj) =
        match value with
        | :? JToken as jToken -> 
            match jToken.SelectToken("error") |> isNull with
            | true  -> Some value
            | false -> None
        | _ -> Some value

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

module Dict =

    let toSeq d = d |> Seq.map (fun (KeyValue(k,v)) -> (k, v))

    let toMap d = d |> toSeq |> Map.ofSeq