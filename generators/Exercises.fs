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

    member this.Name = this.GetType().Name.Kebaberize()
    member this.TestModuleName = this.Name.Dehumanize() |> sprintf "%sTest"
    member this.TestedModuleName = this.Name.Dehumanize()

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
              Data = canonicalDataCase }

        renderPartial "TestMethod" parameters
        

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