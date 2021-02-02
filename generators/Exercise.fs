module Generators.Exercise

open System
open System.IO
open System.Reflection
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Humanizer
open Rendering
open Templates
open CanonicalData
open Track

let [<Literal>] private AssertEmptyTemplate = "AssertEmpty"
let [<Literal>] private AssertEqualTemplate = "AssertEqual"
let [<Literal>] private AssertEqualWithinTemplate = "AssertEqualWithin"
let [<Literal>] private AssertThrowsTemplate = "AssertThrows"

let private exerciseNameFromType (exerciseType: Type) = exerciseType.Name.Kebaberize()

[<AbstractClass>]
type GeneratorExercise() =

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
    member this.TestModuleName = this.GetType().Name.Pascalize() |> sprintf "%sTests"
    member this.TestedModuleName = this.GetType().Name.Pascalize()

    member this.TestFilePath () =
        Path.Combine("..", "exercises", "practice", this.Name, sprintf "%s.fs" this.TestModuleName)

    member this.WriteToFile contents =
        let testFilePath = this.TestFilePath ()

        Directory.CreateDirectory(Path.GetDirectoryName(testFilePath)) |> ignore
        File.WriteAllText(testFilePath, contents)

    member this.Regenerate(canonicalData) =
        canonicalData
        |> this.MapCanonicalData
        |> this.Render
        |> this.WriteToFile

    member this.ReadVersion () =
        (*
            Read from the top of the file e.g.
            "// This file was auto-generated based on version 1.2.0 of the canonical data."
        *)

        this.TestFilePath ()
        |> File.ReadLines
        |> Seq.head
        |> String.split " "
        |> Seq.find (fun s -> s.[0] |> System.Char.IsDigit)

    // Allow changes in canonical data

    member this.MapCanonicalData canonicalData =
        { canonicalData with Cases = List.map this.MapCanonicalDataCase canonicalData.Cases }

    default __.MapCanonicalDataCase canonicalDataCase = canonicalDataCase

    // Convert canonical data to representation used when rendering

    member this.ToTestFile canonicalData =
        let renderTestMethod i canonicalDataCase = this.RenderTestMethod(i, canonicalDataCase)

        { Version = canonicalData.Version
          ExerciseName = this.Name
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

    member __.RenderAssertEmpty sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertEmptyTemplate

    member __.RenderAssertEqual sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertEqualTemplate

    member __.RenderAssertEqualWithin sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertEqualWithinTemplate

    member __.RenderAssertThrows sut expected =
        { Sut = sut; Expected = expected }
        |> renderTemplate AssertThrowsTemplate

    default __.TestFileFormat = TestFileFormat.Module

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

    default __.RenderSetup _ = ""

    // Generic value/identifier rendering methods

    default __.RenderValue (_, _, value) = Obj.render value

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
        sprintf "let %s = %s" identifier value

    member __.RenderIdentifier (_, key, _) = String.camelize key

    member this.RenderIdentifierWithTypeAnnotation (canonicalDataCase, key, value) =
        let identifier = this.RenderIdentifier (canonicalDataCase, key, value)

        match this.IdentifierTypeAnnotation (canonicalDataCase, key, value) with
        | Some identifierType ->
            sprintf "%s: %s" identifier identifierType
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

    member __.RenderSutProperty canonicalDataCase = string canonicalDataCase.Property

    member this.Properties canonicalDataCase =
        List.append (this.PropertiesUsedAsSutParameter canonicalDataCase) ["expected"]

    default __.PropertiesUsedAsSutParameter canonicalDataCase =
        canonicalDataCase.Input
        |> Map.toList
        |> List.map fst

    // Utility methods to customize rendered output

    default __.PropertiesWithIdentifier _ = []

    default __.IdentifierTypeAnnotation (_, _, _) = None

    default __.UseFullMethodName _ = false

    default __.AdditionalNamespaces = []

    default __.SkipTestMethod (index, _) = index > 0

type CustomExercise() =

    member this.Name = this.GetType().Name.Kebaberize()

type MissingDataExercise = { Name: string }

type UnimplementedExercise = { Name: string }

type DeprecatedExercise = { Name: string }

type Exercise =
    | Generator of GeneratorExercise
    | Custom of CustomExercise
    | MissingData of MissingDataExercise
    | Unimplemented of UnimplementedExercise
    | Deprecated of DeprecatedExercise

let exerciseName exercise =
    match exercise with
    | Generator generator -> generator.Name
    | Custom custom -> custom.Name
    | Unimplemented unimplemented -> unimplemented.Name
    | MissingData missingData -> missingData.Name
    | Deprecated deprecated -> deprecated.Name

type ConfigExercise = { Slug: string }

type Config = { Exercises: ConfigExercise[] }

let private exerciseNames =
    let configFilePath = "../config.json"
    let configFileContents = File.ReadAllText configFilePath
    let config = JsonConvert.DeserializeObject<Config>(configFileContents)

    config.Exercises
    |> Seq.map (fun exercise -> exercise.Slug)
    |> Seq.sort
    |> Seq.toList

let private isConcreteType (ty: Type) = not ty.IsAbstract

let private isGeneratorExercise (ty: Type) = typeof<GeneratorExercise>.IsAssignableFrom(ty)

let private isCustomExercise (ty: Type) = typeof<CustomExercise>.IsAssignableFrom(ty)

let private concreteAssemblyTypes =
    Assembly.GetEntryAssembly().GetTypes()
    |> Array.filter isConcreteType

let private exerciseTypeByName<'T> exerciseType =
    (exerciseNameFromType exerciseType, Activator.CreateInstance(exerciseType) :?> 'T)

let private exerciseTypesByName<'T> predicate =
    concreteAssemblyTypes
    |> Array.filter predicate
    |> Array.map exerciseTypeByName<'T>
    |> Map.ofArray

let private generatorExercises = exerciseTypesByName<GeneratorExercise> isGeneratorExercise

let private customExercises = exerciseTypesByName<CustomExercise> isCustomExercise

let private tryFindGeneratorExercise exerciseName =
    generatorExercises
    |> Map.tryFind exerciseName
    |> Option.map Generator

let private tryFindCustomExercise exerciseName =
    customExercises
    |> Map.tryFind exerciseName
    |> Option.map Custom

let private tryFindDeprecatedExercise exerciseName =
    match isDeprecated exerciseName with
    | true  -> Deprecated { Name = exerciseName } |> Some
    | false -> None

let private tryFindUnimplementedExercise options exerciseName =
    match hasCanonicalData options exerciseName with
    | true  -> Unimplemented { Name = exerciseName } |> Some
    | false -> None

let private createExercise options exerciseName =
    tryFindDeprecatedExercise exerciseName
    |> Option.orElse (tryFindGeneratorExercise exerciseName)
    |> Option.orElse (tryFindCustomExercise exerciseName)
    |> Option.orElse (tryFindUnimplementedExercise options exerciseName)
    |> Option.orElse (MissingData { Name = exerciseName } |> Some)

let createExercises options =
    exerciseNames
    |> List.choose (createExercise options)