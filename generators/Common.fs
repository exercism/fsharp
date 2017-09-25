[<AutoOpen>]
module Generators.Common

open System
open System.IO
open Serilog

type CanonicalDataCase = Map<string, obj>

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
      Namespaces: Set<string>
      Methods: string list }

module Logging =

    let setupLogger() =
        Log.Logger <- LoggerConfiguration()
            .WriteTo.LiterateConsole()
            .CreateLogger();

module String =

    open Humanizer

    let equals (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)

    let humanize (str: string) = str.Humanize()

module Dict =

    open System.Collections.Generic

    let toSeq d = d |> Seq.map (fun (KeyValue(k,v)) -> (k, v))

    let toMap d = d |> toSeq |> Map.ofSeq

    let ofMap (m: Map<'k,'v>) = new Dictionary<'k,'v>(m) :> IDictionary<'k,'v>

    let ofList (l: ('k * 'v) list) = new Dictionary<'k,'v>(l |> Map.ofList) :> IDictionary<'k,'v>

    let ofSeq (s: ('k * 'v) seq) = new Dictionary<'k,'v>(s |> Map.ofSeq) :> IDictionary<'k,'v>