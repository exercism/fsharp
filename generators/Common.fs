[<AutoOpen>]
module Generators.Common

open Serilog

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