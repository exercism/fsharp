[<AutoOpen>]
module Generators.Common

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
    { ExerciseName: string
      TestModuleName: string
      TestedModuleName: string
      Namespaces: string list
      Methods: string list
      Setup: string }

type TestFileFormat = 
    | Module 
    | Class

module Logging =
    open Serilog

    let setup() =
        Log.Logger <- LoggerConfiguration()
            .WriteTo
            .Console(outputTemplate = "{Message:lj}{NewLine}{Exception}")
            .CreateLogger()
module Option =
    open System
    open Newtonsoft.Json.Linq
    
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
    open System
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
    open Newtonsoft.Json.Linq
    open System.Collections.Generic
    
    let values map =
        map
        |> Map.toSeq
        |> Seq.map snd

    let ofJToken<'TKey, 'TValue when 'TKey: comparison> (jToken: JToken)   =
        jToken.ToObject<Dictionary<'TKey, 'TValue>>()
        |> Seq.map (fun (KeyValue(k,v)) -> (k, v))
        |> Map.ofSeq