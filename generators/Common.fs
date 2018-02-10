[<AutoOpen>]
module Generators.Common

open System
open Serilog
open Newtonsoft.Json.Linq

type TestMethod = 
    { Skip: bool
      Name: string
      Body: string }

type TestMethodBody = 
    { Arrange: string list  
      Assert: string list }

type TestMethodBodyAssert = 
    { Sut: string
      Expected: string }

type TestFile = 
    { Version: string
      ExerciseName: string
      TestModuleName: string
      TestedModuleName: string
      Namespaces: string list
      Methods: string list
      Setup: string }

type TestFileFormat = 
    | Module 
    | Class

module Logging =
    let setupLogger() =
        Log.Logger <- LoggerConfiguration()
            .WriteTo.LiterateConsole()
            .CreateLogger();

let isInt64 (value: obj) = 
    match value with 
    | :? int64 -> true 
    | _ -> false

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

    let equals (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)

    let humanize (str: string) = str.Humanize()

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

module Json =
    let rec parentsAndSelf (currentToken: JToken) =
        let rec helper acc (token: JToken) =
            match token with
            | null -> acc
            | _ -> helper (token::acc) token.Parent

        helper [] currentToken

module Dict =

    open System.Collections.Generic

    let toSeq d = d |> Seq.map (fun (KeyValue(k,v)) -> (k, v))

    let toMap d = d |> toSeq |> Map.ofSeq

    let ofMap (m: Map<'k,'v>) = new Dictionary<'k,'v>(m) :> IDictionary<'k,'v>

    let ofList (l: ('k * 'v) list) = new Dictionary<'k,'v>(l |> Map.ofList) :> IDictionary<'k,'v>

    let ofSeq (s: ('k * 'v) seq) = new Dictionary<'k,'v>(s |> Map.ofSeq) :> IDictionary<'k,'v>