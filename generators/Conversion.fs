[<AutoOpen>]
module Generators.Conversion

open System
open Newtonsoft.Json.Linq
open System.Collections.Generic

module Option =
    let ofNonNegativeNumber (value: obj) =
        match value with
        | :? int64 as i -> if i < 0L then None else Some value
        | :? int32 as i -> if i < 0  then None else Some value
        | _ -> Some value

    let ofNonFalseBoolean (value: obj) =
        match value with
        | :? bool as b when not b -> None
        | _ -> Some value

    let ofNonErrorObject (value: obj) =
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



module List =

    let rec ofJArray (value: JArray) =
        let toBoxedList seq = 
            seq
            |> Seq.map box 
            |> List.ofSeq

        if value.Count = 0 then
            []
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Integer && JToken.isInt64 x) then
            value.Values<int64>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Integer) then
            value.Values<int>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Float) then
            value.Values<float>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Boolean) then
            value.Values<bool>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.String) then
            value.Values<string>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Date) then
            value.Values<DateTime>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.TimeSpan) then
            value.Values<TimeSpan>() |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Object) then
            value.Children() |> Seq.map (fun jObject -> jObject.ToObject<Dictionary<string, obj>>()) |> toBoxedList
        else if value.Children() |> Seq.forall (fun x -> x.Type = JTokenType.Array) then
            value.Values<JArray>() |> Seq.map ofJArray |> toBoxedList
        else    
            value.Values<obj>() |> toBoxedList    

    let ofObj (value: obj) = value :?> JArray |> ofJArray