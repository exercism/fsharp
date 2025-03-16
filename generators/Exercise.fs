module Generators.Exercise

open System
open System.IO
open System.Reflection
open Newtonsoft.Json.Linq
open Humanizer
open Rendering
open Serilog
open Templates
open Tests

let private AssertEmptyTemplate = "AssertEmpty"
let private AssertEqualTemplate = "AssertEqual"
let private AssertEqualWithinTemplate = "AssertEqualWithin"
let private AssertThrowsTemplate = "AssertThrows"

[<AbstractClass>]
type ExerciseGenerator() =
    // Customize rendered output
    abstract member RenderExpected : TestCase * string * JToken -> string
    abstract member RenderInput : TestCase * string * JToken -> string
    abstract member RenderArrange : TestCase -> string list
    abstract member RenderAssert : TestCase -> string list
    abstract member RenderSut : TestCase -> string
    abstract member RenderSetup : TestCase list -> string
    abstract member RenderValue : TestCase * string * JToken -> string

    // Utility methods to customize rendered output
    abstract member MapTestCase : TestCase -> TestCase
    abstract member PropertiesUsedAsSutParameter : TestCase -> string list
    abstract member PropertiesWithIdentifier : TestCase -> string list
    abstract member IdentifierTypeAnnotation: TestCase * string * JToken -> string option
    abstract member AdditionalNamespaces : string list
    abstract member AssertTemplate : TestCase -> string
    abstract member TestFileFormat: TestFileFormat
    abstract member TestMethodName : TestCase -> string
    abstract member UseFullMethodName : TestCase -> bool
    abstract member SkipTestMethod : int * TestCase -> bool

    member this.Name = this.GetType().Name.Kebaberize()
    member this.TestModuleName = $"%s{this.GetType().Name.Pascalize()}Tests"
    member this.TestedModuleName = this.GetType().Name.Pascalize()
    
    member this.ExerciseDir = Path.Combine("..", "exercises", "practice", this.Name)    
    member this.TestFilePath = Path.Combine(this.ExerciseDir, $"%s{this.TestModuleName}.fs")     

    member this.WriteToFile (contents: string) =
        Directory.CreateDirectory(Path.GetDirectoryName(this.TestFilePath)) |> ignore
        File.WriteAllText(this.TestFilePath, contents)

    member this.Regenerate(canonicalData) =
        canonicalData
        |> this.MapCanonicalData
        |> this.Render
        |> this.WriteToFile

    // Allow changes in canonical data
    member this.MapCanonicalData canonicalData = List.map this.MapTestCase canonicalData

    default _.MapTestCase testCase = testCase

    // Convert canonical data to representation used when rendering
    member this.ToTestFile (testCases: TestCase list) =
        let renderTestMethod i testCase = this.RenderTestMethod(i, testCase)

        { ExerciseName = this.Name
          TestModuleName = this.TestModuleName
          TestedModuleName = this.TestedModuleName
          Namespaces = ["FsUnit.Xunit"; "Xunit"] @ this.AdditionalNamespaces
          Methods = List.mapi renderTestMethod testCases
          Setup = this.RenderSetup testCases }

    member this.ToTestMethod (index, testCase) =
        { Skip = this.SkipTestMethod (index, testCase)
          Name = this.TestMethodName testCase
          Body = this.RenderTestMethodBody testCase }

    member this.ToTestMethodBody testCase =
        { Arrange = this.RenderArrange testCase
          Assert = this.RenderAssert testCase }

    member this.ToTestMethodBodyAssert testCase =
        { Sut = this.RenderValueOrIdentifier (testCase, "sut", testCase.Expected)
          Expected = this.RenderValueOrIdentifier (testCase, "expected", testCase.Expected) }

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

    default this.AssertTemplate testCase =
        let expectedIsArray = testCase.Expected.Type = JTokenType.Array
        let expectedIsEmpty = Seq.isEmpty testCase.Expected
        let expectedHasIdentifier = List.contains "expected" (this.PropertiesWithIdentifier testCase)

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

    member this.RenderTestMethod (index, testCase) =
        let template = this.TestMethodTemplate (index, testCase)

        (index, testCase)
        |> this.ToTestMethod
        |> renderTemplate template

    member this.RenderTestMethodBody testCase =
        let template = this.TestMethodBodyTemplate testCase

        testCase
        |> this.ToTestMethodBody
        |> renderTemplate template

    default this.TestMethodName testCase =
        match this.UseFullMethodName testCase with
        | false ->
            String.upperCaseFirst testCase.Description
        | true ->
            testCase.DescriptionPath
            |> String.concat " - "
            |> String.upperCaseFirst

    default _.RenderSetup _ = ""

    // Generic value/identifier rendering methods
    default _.RenderValue (_, _, value) = Obj.render value

    member this.RenderValueOrIdentifier (testCase, key, value) =
        let properties = this.PropertiesWithIdentifier testCase

        match List.contains key properties with
        | true  -> this.RenderIdentifier (testCase, key, value)
        | false -> this.RenderValueWithoutIdentifier (testCase, key, value)

    member this.RenderValueWithoutIdentifier (testCase, key, value) =
        match key with
        | "expected" -> this.RenderExpected (testCase, key, value)
        | "sut" -> this.RenderSut testCase
        | _  -> this.RenderInput (testCase, key, value)

    member this.RenderValueWithIdentifier (testCase, key, value) =
        let identifier = this.RenderIdentifierWithTypeAnnotation (testCase, key, value)
        let value = this.RenderValueWithoutIdentifier (testCase, key, value)
        $"let %s{identifier} = %s{value}"

    member _.RenderIdentifier (_, key, _) = String.camelize key

    member this.RenderIdentifierWithTypeAnnotation (testCase, key, value) =
        let identifier = this.RenderIdentifier (testCase, key, value)

        match this.IdentifierTypeAnnotation (testCase, key, value) with
        | Some identifierType ->
            $"%s{identifier}: %s{identifierType}"
        | None ->
            identifier

    // Canonical-data specific rendering methods
    default this.RenderExpected (testCase, key, value) = this.RenderValue (testCase, key, value)

    default this.RenderInput (testCase, key, value) = this.RenderValue (testCase, key, value)

    default this.RenderArrange testCase =
        let renderExpected prop =
            this.RenderValueWithIdentifier (testCase, prop, testCase.Expected) |> Some

        let renderSut prop =
            this.RenderValueWithIdentifier (testCase, prop, testCase.Expected) |> Some

        let renderInput prop =
            match Map.tryFind prop testCase.Input with
            | None -> None
            | Some value -> Some (this.RenderValueWithIdentifier (testCase, prop, value))

        let renderArrangeProperty prop: string option =
            match prop with
            | "expected" -> renderExpected prop
            | "sut" -> renderSut prop
            | _ -> renderInput prop

        testCase
        |> this.PropertiesWithIdentifier
        |> List.choose renderArrangeProperty

    default this.RenderAssert testCase =
        let template = this.AssertTemplate testCase

        testCase
        |> this.ToTestMethodBodyAssert
        |> renderTemplate template
        |> List.singleton

    default this.RenderSut testCase =
        let parameters = this.RenderSutParameters testCase
        let prop = this.RenderSutProperty testCase
        prop :: parameters |> String.concat " "

    member this.RenderSutParameters testCase =
        let sutParameterProperties = this.PropertiesUsedAsSutParameter testCase
        let renderSutParameter key = this.RenderSutParameter (testCase, key, Map.find key testCase.Input)

        sutParameterProperties
        |> List.map renderSutParameter

    member this.RenderSutParameter (testCase, key, value) =
        this.RenderValueOrIdentifier (testCase, key, value)

    member _.RenderSutProperty testCase = string testCase.Property

    member this.Properties testCase =
        List.append (this.PropertiesUsedAsSutParameter testCase) ["expected"]

    default _.PropertiesUsedAsSutParameter testCase =
        testCase.Input
        |> Map.toList
        |> List.map fst

    // Utility methods to customize rendered output
    default _.PropertiesWithIdentifier _ = []

    default _.IdentifierTypeAnnotation (_, _, _) = None

    default _.UseFullMethodName _ = false

    default _.AdditionalNamespaces = []

    default _.SkipTestMethod (index, _) = index > 0

let private tryCreateExerciseGenerator exerciseType =
    if typeof<ExerciseGenerator>.IsAssignableFrom(exerciseType) && typeof<ExerciseGenerator> <> exerciseType then
        Some (Activator.CreateInstance(exerciseType) :?> ExerciseGenerator)
    else
        None

let private exerciseGenerators =
    Assembly.GetEntryAssembly().GetTypes()
    |> Seq.choose tryCreateExerciseGenerator
    |> Seq.map (fun generator -> generator.Name, generator)
    |> Map.ofSeq

let private tryFindExerciseGenerator (exerciseName: string) =
    Map.tryFind exerciseName exerciseGenerators

let private runExerciseGenerator parseCanonicalData (generator: ExerciseGenerator) =
    generator.Regenerate(parseCanonicalData generator.Name)
    Log.Information("{Exercise}: updated", generator.Name)

let private runExerciseGenerators options (generators: ExerciseGenerator seq) =
    let parseCanonicalData' = findTestCases options
    Seq.iter (runExerciseGenerator parseCanonicalData') generators

let regenerateTestClass options exercise =
    match tryFindExerciseGenerator exercise with
    | Some generator ->
        runExerciseGenerators options [generator]
    | None ->
        Log.Error("Could not find generator for {Exercise} exercise", exercise)

let regenerateTestClasses options =
    runExerciseGenerators options (Map.values exerciseGenerators)