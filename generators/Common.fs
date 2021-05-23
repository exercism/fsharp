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

    let setupLogger() =
        Log.Logger <- LoggerConfiguration()
            .WriteTo
            .Console(outputTemplate = "{Message:lj}{NewLine}{Exception}")
            .CreateLogger()
