module Generators.Exercises

open System
open System.Globalization
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
    abstract member RenderSut : CanonicalDataCase -> string
    abstract member RenderSutParameters : CanonicalDataCase -> string list
    abstract member RenderAssert : CanonicalDataCase -> string
    abstract member RenderSutProperty : CanonicalDataCase -> string
    abstract member SutParameters : CanonicalDataCase -> CanonicalDataCase
    abstract member FormatValue: obj -> string

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
        let expected = canonicalDataCase.["expected"]

        let parameters = 
            { Arrange = []
              Assert = this.RenderAssert canonicalDataCase
              Sut = this.RenderSut canonicalDataCase
              Expected = this.RenderExpected expected }

        renderPartial "TestMethodBody" parameters

    default this.RenderExpected expected = this.FormatValue expected

    default this.RenderSut canonicalDataCase = 
        let parameters = this.RenderSutParameters canonicalDataCase
        let property = this.RenderSutProperty canonicalDataCase
        property :: parameters |> String.concat " "

    default this.RenderAssert canonicalDataCase = "should equal"

    default this.RenderSutParameters canonicalDataCase =
        let parameters = this.SutParameters canonicalDataCase
        parameters.Values
        |> Seq.map this.FormatValue
        |> Seq.toList

    default this.RenderSutProperty canonicalDataCase = 
        string canonicalDataCase.["property"]

    default this.SutParameters canonicalDataCase =
        let input = Dictionary<string, obj>(canonicalDataCase)
        input.Remove("property") |> ignore
        input.Remove("expected") |> ignore
        input.Remove("description") |> ignore
        input :> IDictionary<string, obj>

    default this.FormatValue value = formatValue value    

type HelloWorld() =
    inherit Exercise()

type Bob() =
    inherit Exercise()

type Leap() =
    inherit Exercise()

type Isogram() =
    inherit Exercise()

type PigLatin() =
    inherit Exercise()

type Gigasecond() =
    inherit Exercise()

    override this.FormatValue value = 
        value :?> DateTime 
        |> formatDateTime
        |> sprintf "(%s)"

    override this.SutParameters canonicalDataCase =
        [("input", DateTime.Parse(string canonicalDataCase.["input"], CultureInfo.InvariantCulture) :> obj)]
        |> dict

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