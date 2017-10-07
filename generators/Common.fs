[<AutoOpen>]
module Generators.Common

open System
open System.IO
open Serilog
open Newtonsoft.Json.Linq

type CanonicalDataCase = 
    { Properties: Map<string, obj>
      DescriptionPath: string list } with 
        member this.Description = string this.Properties.["description"]
        member this.Property = string this.Properties.["property"]
        member this.Expected = this.Properties.["expected"]

type CanonicalData = 
    { Exercise: string
      Version: string
      Cases: CanonicalDataCase list }

type TestMethod = 
    { Skip: bool
      Name: string
      Body: string }

type TestMethodBody = 
    { Arrange: string list  
      Assert: string }

type TestMethodBodyAssert = 
    { Sut: string
      Expected: string }

type TestClass = 
    { Version: string
      ExerciseName: string
      TestModuleName: string
      TestedModuleName: string
      Namespaces: string list
      Methods: string list }

module Logging =

    let setupLogger() =
        Log.Logger <- LoggerConfiguration()
            .WriteTo.LiterateConsole()
            .CreateLogger();

let isInt64 (value: obj) = 
    match value with 
    | :? int64 -> true 
    | _ -> false

let toOption noneTest (value: obj) =
    if noneTest value then 
        None
    else
        Some value

module String =

    open Humanizer

    let equals (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)

    let humanize (str: string) = str.Humanize()

    let camelize (str: string) = str.Camelize()

    let upperCaseFirst (str: string) = 
        match str with
        | "" -> str
        | _  -> sprintf "%c%s" (Char.ToUpper(str.[0])) str.[1..]


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