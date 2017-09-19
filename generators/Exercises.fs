module Generators.Exercises

open System
open System.Collections.Generic
open System.IO
open System.Reflection
open Humanizer
open Serilog
open Input
open Output

[<AbstractClass>]
type Exercise() =
    abstract member MapCanonicalData : CanonicalData -> CanonicalData
    abstract member Render : CanonicalData -> string
    abstract member RenderTestMethod : int -> CanonicalDataCase -> string
    abstract member RenderTestMethodBody : CanonicalDataCase -> string
    abstract member RenderExpected : obj -> string
    abstract member RenderSut : string -> CanonicalDataCase -> string
    abstract member RenderAssert : CanonicalDataCase -> string

    member this.Name = this.GetType().Name.Kebaberize()
    member this.TestModuleName = this.GetType().Name.Pascalize() |> sprintf "%sTest"
    member this.TestedModuleName = this.GetType().Name.Pascalize()

    member this.WriteToFile contents =
        let testClassPath = Path.Combine("..", "exercises", this.Name, sprintf "%s.fs" this.TestModuleName)

        Directory.CreateDirectory(Path.GetDirectoryName(testClassPath)) |> ignore
        File.WriteAllText(testClassPath, contents)

        Log.Information("Generated tests for {Exercise} exercise in {TestClassPath}", this.Name, testClassPath);

    member this.Regenerate(canonicalData) = 
        canonicalData
        |> this.MapCanonicalData
        |> this.Render
        |> this.WriteToFile

    default this.MapCanonicalData canonicalData = canonicalData

    default this.Render canonicalData =
        let parameters = 
            { Version = canonicalData.Version              
              ExerciseName = this.Name
              TestModuleName = this.TestModuleName
              TestedModuleName = this.TestedModuleName
              Namespaces = set ["FsUnit.Xunit"; "Xunit"]
              Methods = List.mapi this.RenderTestMethod canonicalData.Cases }

        renderPartial "TestClass" parameters

    default this.RenderTestMethod index canonicalDataCase = 
        let parameters = 
            { Skip = index > 0
              Name = string canonicalDataCase.["description"]
              Body = this.RenderTestMethodBody canonicalDataCase }

        renderPartial "TestMethod" parameters

    default this.RenderTestMethodBody canonicalDataCase = 
        let input = Dictionary<string, obj>(canonicalDataCase)
        input.Remove("property") |> ignore
        input.Remove("expected") |> ignore
        input.Remove("description") |> ignore

        let property = string canonicalDataCase.["property"]
        let expected = canonicalDataCase.["expected"]

        let parameters = 
            { Arrange = []
              Assert = this.RenderAssert canonicalDataCase
              Sut = this.RenderSut property input
              Expected = this.RenderExpected expected }

        renderPartial "TestMethodBody" parameters

    default this.RenderExpected expected = formatValue expected

    default this.RenderSut property input = 
        let parameters = Seq.map formatValue input.Values |> Seq.toList
        string property :: parameters |> String.concat " "

    default this.RenderAssert canonicalDataCase = "should equal"

type HelloWorld() =
    inherit Exercise()

let createExercises filteredExercises =

    let isConcreteExercise (exerciseType: Type) = 
        not exerciseType.IsAbstract && typeof<Exercise>.IsAssignableFrom(exerciseType)

    let isFilteredExercises (exerciseType: Type) =
        Seq.isEmpty filteredExercises ||
        Seq.exists (String.EqualsOrdinalIgnoreCase exerciseType.Name) filteredExercises ||
        Seq.exists (String.EqualsOrdinalIgnoreCase (exerciseType.Name.Kebaberize())) filteredExercises

    let includeExercise (exerciseType: Type) = isConcreteExercise exerciseType && isFilteredExercises exerciseType

    let assemblyTypes = Assembly.GetEntryAssembly().GetTypes()

    seq { for exerciseType in assemblyTypes do 
            if includeExercise exerciseType then 
                yield Activator.CreateInstance(exerciseType) :?> Exercise }