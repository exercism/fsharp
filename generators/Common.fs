[<AutoOpen>]
module Generators.Common

open System
open System.Collections.Generic
open System.IO
open Serilog

type CanonicalDataCase = Dictionary<string, obj>

type CanonicalData = 
    { Exercise: string
      Version: string
      Cases: CanonicalDataCase list }

type TestMethod = 
    { Skip: bool
      Name: string
      Data: CanonicalDataCase }

type TestClass = 
    { Version: string
      ExerciseName: string
      TestModuleName: string
      TestedModuleName: string
      Namespaces: Set<string>
      Methods: string list }

let setupLogger() =
    Log.Logger <- LoggerConfiguration()
        .WriteTo.LiterateConsole()
        .CreateLogger();

module String =
    let EqualsOrdinalIgnoreCase (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)