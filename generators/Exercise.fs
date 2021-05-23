module Generators.Exercise

open System
open System.IO
open System.Reflection
open Newtonsoft.Json.Linq
open Humanizer
open Rendering
open Serilog
open Templates
open CanonicalData

let [<Literal>] private AssertEmptyTemplate = "AssertEmpty"
let [<Literal>] private AssertEqualTemplate = "AssertEqual"
let [<Literal>] private AssertEqualWithinTemplate = "AssertEqualWithin"
let [<Literal>] private AssertThrowsTemplate = "AssertThrows"

type ExerciseGenerator() =
    // Customize rendered output
    abstract member RenderExpected : CanonicalDataCase * string * JToken -> string
    abstract member RenderInput : CanonicalDataCase * string * JToken -> string
    abstract member RenderArrange : CanonicalDataCase -> string list
    abstract member RenderAssert : CanonicalDataCase -> string list
    abstract member RenderSut : CanonicalDataCase -> string
    abstract member RenderSetup : CanonicalData -> string
    abstract member RenderValue : CanonicalDataCase * string * JToken -> string

    // Utility methods to customize rendered output
    abstract member MapCanonicalDataCase : CanonicalDataCase -> CanonicalDataCase
    abstract member PropertiesUsedAsSutParameter : CanonicalDataCase -> string list
    abstract member PropertiesWithIdentifier : CanonicalDataCase -> string list
    abstract member IdentifierTypeAnnotation: CanonicalDataCase * string * JToken -> string option
    abstract member AdditionalNamespaces : string list
    abstract member AssertTemplate : CanonicalDataCase -> string
    abstract member TestFileFormat: TestFileFormat
    abstract member TestMethodName : CanonicalDataCase -> string
    abstract member UseFullMethodName : CanonicalDataCase -> bool
    abstract member SkipTestMethod : int * CanonicalDataCase -> bool

    member this.Name = this.GetType() |> exerciseNameFromType
    member this.TestModuleName = $"%s{this.GetType().Name.Pascalize()}Tests"
    member this.TestedModuleName = this.GetType().Name.Pascalize()

    member this.TestFilePath () =
        Path.Combine("..", "exercises", "practice", this.Name, $"%s{this.TestModuleName}.fs")

    member this.WriteToFile contents =
        let testFilePath = this.TestFilePath ()

        Directory.CreateDirectory(Path.GetDirectoryName(testFilePath)) |> ignore
        File.WriteAllText(testFilePath, contents)

    member this.Regenerate(canonicalData) =
        canonicalData
        |> this.MapCanonicalData
        |> this.Render
        |> this.WriteToFile

    // Allow changes in canonical data
    member this.MapCanonicalData canonicalData =
        { canonicalData with Cases = List.map this.MapCanonicalDataCase canonicalData.Cases }

    default _.MapCanonicalDataCase canonicalDataCase = canonicalDataCase

    // Convert canonical data to representation used when rendering

    member this.ToTestFile (canonicalData: CanonicalData) =
        let renderTestMethod i canonicalDataCase = this.RenderTestMethod(i, canonicalDataCase)

        { ExerciseName = this.Name
          TestModuleName = this.TestModuleName
          TestedModuleName = this.TestedModuleName
          Namespaces = ["FsUnit.Xunit"; "Xunit"] @ this.AdditionalNamespaces
          Methods = List.mapi renderTestMethod canonicalData.Cases
          Setup = this.RenderSetup canonicalData }

    member this.ToTestMethod (index, canonicalDataCase) =
        { Skip = this.SkipTestMethod (index, canonicalDataCase)
          Name = this.TestMethodName canonicalDataCase
          Body = this.RenderTestMethodBody canonicalDataCase }

    member this.ToTestMethodBody canonicalDataCase =
        { Arrange = this.RenderArrange canonicalDataCase
          Assert = this.RenderAssert canonicalDataCase }

    member this.ToTestMethodBodyAssert canonicalDataCase =
        { Sut = this.RenderValueOrIdentifier (canonicalDataCase, "sut", canonicalDataCase.Expected)
          Expected = this.RenderValueOrIdentifier (canonicalDataCase, "expected", canonicalDataCase.Expected) }

    // Determine the templates to use when rendering
    member this.TestFileTemplate =
        match this.TestFileFormat with
        | Module -> "TestModule"
        | Class  -> "TestClass"

    member this.TestMethodTemplate (_, _) =
        match this.TestFileFormat with
        | Module -> "TestFunction"
        | Class  -> "TestMember"

    member this.TestMethodBodyTemplate _ =
        match this.TestFileFormat with
        | Module -> "TestFunctionBody"
        | Class  -> "TestMemberBody"

    default this.AssertTemplate canonicalDataCase =
        let expectedIsArray = canonicalDataCase.Expected.Type = JTokenType.Array
        let expectedIsEmpty = Seq.isEmpty canonicalDataCase.Expected
        let expectedHasIdentifier = List.contains "expected" (this.PropertiesWithIdentifier canonicalDataCase)

        if expectedIsArray && expectedIsEmpty && not expectedHasIdentifier then
            AssertEmptyTemplate
        else
            AssertEqualTemplate

    member _.RenderAssertEmpty sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertEmptyTemplate

    member _.RenderAssertEqual sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertEqualTemplate

    member _.RenderAssertEqualWithin sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertEqualWithinTemplate

    member _.RenderAssertThrows sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertThrowsTemplate

    default _.TestFileFormat = TestFileFormat.Module

    // Rendering of canonical data
    member this.Render canonicalData =
        canonicalData
        |> this.ToTestFile
        |> renderTemplate this.TestFileTemplate

    member this.RenderTestMethod (index, canonicalDataCase) =
        let template = this.TestMethodTemplate (index, canonicalDataCase)

        (index, canonicalDataCase)
        |> this.ToTestMethod
        |> renderTemplate template

    member this.RenderTestMethodBody canonicalDataCase =
        let template = this.TestMethodBodyTemplate canonicalDataCase

        canonicalDataCase
        |> this.ToTestMethodBody
        |> renderTemplate template

    default this.TestMethodName canonicalDataCase =
        match this.UseFullMethodName canonicalDataCase with
        | false ->
            String.upperCaseFirst canonicalDataCase.Description
        | true ->
            canonicalDataCase.DescriptionPath
            |> String.concat " - "
            |> String.upperCaseFirst

    default _.RenderSetup _ = ""

    // Generic value/identifier rendering methods
    default _.RenderValue (_, _, value) = Obj.render value

    member this.RenderValueOrIdentifier (canonicalDataCase, key, value) =
        let properties = this.PropertiesWithIdentifier canonicalDataCase

        match List.contains key properties with
        | true  -> this.RenderIdentifier (canonicalDataCase, key, value)
        | false -> this.RenderValueWithoutIdentifier (canonicalDataCase, key, value)

    member this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) =
        match key with
        | "expected" -> this.RenderExpected (canonicalDataCase, key, value)
        | "sut" -> this.RenderSut canonicalDataCase
        | _  -> this.RenderInput (canonicalDataCase, key, value)

    member this.RenderValueWithIdentifier (canonicalDataCase, key, value) =
        let identifier = this.RenderIdentifierWithTypeAnnotation (canonicalDataCase, key, value)
        let value = this.RenderValueWithoutIdentifier (canonicalDataCase, key, value)
        $"let %s{identifier} = %s{value}"

    member _.RenderIdentifier (_, key, _) = String.camelize key

    member this.RenderIdentifierWithTypeAnnotation (canonicalDataCase, key, value) =
        let identifier = this.RenderIdentifier (canonicalDataCase, key, value)

        match this.IdentifierTypeAnnotation (canonicalDataCase, key, value) with
        | Some identifierType ->
            $"%s{identifier}: %s{identifierType}"
        | None ->
            identifier

    // Canonical-data specific rendering methods
    default this.RenderExpected (canonicalDataCase, key, value) = this.RenderValue (canonicalDataCase, key, value)

    default this.RenderInput (canonicalDataCase, key, value) = this.RenderValue (canonicalDataCase, key, value)

    default this.RenderArrange canonicalDataCase =
        let renderExpected prop =
            this.RenderValueWithIdentifier (canonicalDataCase, prop, canonicalDataCase.Expected) |> Some

        let renderSut prop =
            this.RenderValueWithIdentifier (canonicalDataCase, prop, canonicalDataCase.Expected) |> Some

        let renderInput prop =
            match Map.tryFind prop canonicalDataCase.Input with
            | None -> None
            | Some value -> Some (this.RenderValueWithIdentifier (canonicalDataCase, prop, value))

        let renderArrangeProperty prop: string option =
            match prop with
            | "expected" -> renderExpected prop
            | "sut" -> renderSut prop
            | _ -> renderInput prop

        canonicalDataCase
        |> this.PropertiesWithIdentifier
        |> List.choose renderArrangeProperty

    default this.RenderAssert canonicalDataCase =
        let template = this.AssertTemplate canonicalDataCase

        canonicalDataCase
        |> this.ToTestMethodBodyAssert
        |> renderTemplate template
        |> List.singleton

    default this.RenderSut canonicalDataCase =
        let parameters = this.RenderSutParameters canonicalDataCase
        let prop = this.RenderSutProperty canonicalDataCase
        prop :: parameters |> String.concat " "

    member this.RenderSutParameters canonicalDataCase =
        let sutParameterProperties = this.PropertiesUsedAsSutParameter canonicalDataCase
        let renderSutParameter key = this.RenderSutParameter (canonicalDataCase, key, Map.find key canonicalDataCase.Input)

        sutParameterProperties
        |> List.map renderSutParameter

    member this.RenderSutParameter (canonicalDataCase, key, value) =
        this.RenderValueOrIdentifier (canonicalDataCase, key, value)

    member _.RenderSutProperty canonicalDataCase = string canonicalDataCase.Property

    member this.Properties canonicalDataCase =
        List.append (this.PropertiesUsedAsSutParameter canonicalDataCase) ["expected"]

    default _.PropertiesUsedAsSutParameter canonicalDataCase =
        canonicalDataCase.Input
        |> Map.toList
        |> List.map fst

    // Utility methods to customize rendered output
    default _.PropertiesWithIdentifier _ = []

    default _.IdentifierTypeAnnotation (_, _, _) = None

    default _.UseFullMethodName _ = false

    default _.AdditionalNamespaces = []

    default _.SkipTestMethod (index, _) = index > 0

let private tryCreateExerciseGenerator exerciseType =
    if typeof<ExerciseGenerator>.IsAssignableFrom(exerciseType) then
        let exerciseName = exerciseType.Name.Kebaberize()
        let exerciseGenerator = Activator.CreateInstance(exerciseType) :?> ExerciseGenerator 
        Some (exerciseName, exerciseGenerator)
    else
        None

let private generatorExercises =
    Assembly.GetEntryAssembly().GetTypes()
    |> Seq.choose tryCreateExerciseGenerator
    |> Map.ofSeq

let private tryFindGeneratorExercise (exerciseName: string) =
    generatorExercises
    |> Map.tryFind exerciseName

let regenerateTestClass options exercise =
    let parseCanonicalData' = parseCanonicalData options

    fun (exercise) ->
      ()
//        let canonicalData = parseCanonicalData' generator.Name
//        generator.Regenerate(canonicalData)
//        Log.Information(" {Exercise}: tests generated", generator.Name)

let regenerateTestClasses options =
    Log.Information("Re-generating test classes...")

    let regenerateTestClass' = regenerateTestClass options
    
//    createExercises options
//    |> List.filter (isNotFilteredByName options)
//    |> function
//        | [] -> Log.Warning "No exercises matched given options."
//        | exercises ->
//            List.iter regenerateTestClass' exercises
//            Log.Information("Re-generated test classes.")
    ()