[<AutoOpen>]
module Generators.Common

open System
open System.Collections.Generic
open System.IO
open Serilog
open Humanizer

type CanonicalDataCase = IDictionary<string, obj>

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
      Assert: string
      Sut: string
      Expected: string }

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

let humanize (str: string) = str.Humanize()

module String =
    let EqualsOrdinalIgnoreCase (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)