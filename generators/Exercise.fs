module Generators.Exercise

open System
open System.IO
open System.Reflection
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Humanizer
open Serilog
open Formatting
open Rendering
open CanonicalData

let private exerciseNameFromType (exerciseType: Type) = exerciseType.Name.Kebaberize()

[<AbstractClass>]
type GeneratorExercise() =

    // Allow changes in canonical data
    abstract member MapCanonicalData : CanonicalData -> CanonicalData
    abstract member MapCanonicalDataCase : CanonicalDataCase -> CanonicalDataCase
    abstract member MapCanonicalDataCaseProperties : CanonicalDataCase * Map<string, obj> -> Map<string, obj>
    abstract member MapCanonicalDataCaseProperty : CanonicalDataCase * string * obj -> obj

    // Convert canonical data to representation used when rendering
    abstract member ToTestFile : CanonicalData -> TestFile
    abstract member ToTestMethod : int * CanonicalDataCase -> TestMethod
    abstract member ToTestMethodBody : CanonicalDataCase -> TestMethodBody  
    abstract member ToTestMethodBodyAssert : CanonicalDataCase -> TestMethodBodyAssert  

    // Determine the templates to use when rendering
    abstract member TestFileTemplate : string
    abstract member TestMethodTemplate : int * CanonicalDataCase -> string
    abstract member TestMethodBodyTemplate : CanonicalDataCase -> string
    abstract member TestMethodBodyAssertTemplate : CanonicalDataCase -> string
    abstract member TestFileFormat: TestFileFormat

    // Rendering of canonical data
    abstract member Render : CanonicalData -> string
    abstract member RenderTestMethod : int * CanonicalDataCase -> string
    abstract member RenderTestMethodBody : CanonicalDataCase -> string
    abstract member RenderTestMethodName : CanonicalDataCase -> string
    abstract member RenderSetup : CanonicalData -> string

    // Generic value/identifier rendering methods
    abstract member RenderValue : CanonicalDataCase * string * obj -> string
    abstract member RenderValueOrIdentifier: CanonicalDataCase * string * obj -> string
    abstract member RenderValueWithoutIdentifier: CanonicalDataCase * string * obj -> string
    abstract member RenderValueWithIdentifier: CanonicalDataCase * string * obj -> string
    abstract member RenderIdentifier: CanonicalDataCase * string * obj -> string
    abstract member RenderIdentifierWithTypeAnnotation: CanonicalDataCase * string * obj -> string

    // Canonical-data specific rendering methods
    abstract member RenderExpected : CanonicalDataCase * string * obj -> string
    abstract member RenderInput : CanonicalDataCase * string * obj -> string
    abstract member RenderArrange : CanonicalDataCase -> string list
    abstract member RenderAssert : CanonicalDataCase -> string
    abstract member RenderSut : CanonicalDataCase -> string
    abstract member RenderSutParameters : CanonicalDataCase -> string list
    abstract member RenderSutParameter : CanonicalDataCase * string * obj -> string
    abstract member RenderSutProperty : CanonicalDataCase -> string
    
    // Utility methods to customize rendered output
    abstract member Properties : CanonicalDataCase -> string list
    abstract member PropertiesUsedAsSutParameter : CanonicalDataCase -> string list
    abstract member PropertiesWithIdentifier : CanonicalDataCase -> string list
    abstract member IdentifierTypeAnnotation: CanonicalDataCase * string * obj -> string option
    abstract member UseFullMethodName : CanonicalDataCase -> bool
    abstract member AdditionalNamespaces : string list

    member this.Name = this.GetType() |> exerciseNameFromType 
    member this.TestModuleName = this.GetType().Name.Pascalize() |> sprintf "%sTest"
    member this.TestedModuleName = this.GetType().Name.Pascalize()

    member this.WriteToFile contents =
        let testFilePath = Path.Combine("..", "exercises", this.Name, sprintf "%s.fs" this.TestModuleName)

        Directory.CreateDirectory(Path.GetDirectoryName(testFilePath)) |> ignore
        File.WriteAllText(testFilePath, contents)

    member this.Regenerate(canonicalData) =
        canonicalData
        |> this.MapCanonicalData
        |> this.Render  
        |> this.WriteToFile

    // Allow changes in canonical data    

    default this.MapCanonicalData canonicalData = 
        { canonicalData with Cases = List.map this.MapCanonicalDataCase canonicalData.Cases }

    default this.MapCanonicalDataCase canonicalDataCase =
        { canonicalDataCase with 
            Properties = this.MapCanonicalDataCaseProperties (canonicalDataCase, canonicalDataCase.Properties) }

    default this.MapCanonicalDataCaseProperties (canonicalDataCase, properties) =
        properties
        |> Map.map (fun key value -> this.MapCanonicalDataCaseProperty (canonicalDataCase, key, value)) 

    default __.MapCanonicalDataCaseProperty (_, _, value) = value

    // Convert canonical data to representation used when rendering

    default this.ToTestFile canonicalData =
        let renderTestMethod i canonicalDataCase = this.RenderTestMethod(i, canonicalDataCase)

        { Version = canonicalData.Version              
          ExerciseName = this.Name
          TestModuleName = this.TestModuleName
          TestedModuleName = this.TestedModuleName
          Namespaces = ["FsUnit.Xunit"; "Xunit"] @ this.AdditionalNamespaces
          Methods = List.mapi renderTestMethod canonicalData.Cases
          Setup = this.RenderSetup canonicalData }

    default this.ToTestMethod (index, canonicalDataCase) =
        { Skip = index > 0
          Name = this.RenderTestMethodName canonicalDataCase
          Body = this.RenderTestMethodBody canonicalDataCase }

    default this.ToTestMethodBody canonicalDataCase =         
        { Arrange = this.RenderArrange canonicalDataCase
          Assert = this.RenderAssert canonicalDataCase }

    default this.ToTestMethodBodyAssert canonicalDataCase =         
        { Sut = this.RenderSut canonicalDataCase
          Expected = this.RenderValueOrIdentifier (canonicalDataCase, "expected", canonicalDataCase.Expected) }

    // Determine the templates to use when rendering

    default this.TestFileTemplate = 
        match this.TestFileFormat with
        | Module -> "TestModule"
        | Class  -> "TestClass"
    
    default this.TestMethodTemplate (_, _) =
        match this.TestFileFormat with
        | Module -> "TestFunction"
        | Class  -> "TestMember"

    default this.TestMethodBodyTemplate _ =
        match this.TestFileFormat with
        | Module -> "TestFunctionBody"
        | Class  -> "TestMemberBody"

    default this.TestMethodBodyAssertTemplate canonicalDataCase =
        match canonicalDataCase.Expected with
        | :? JArray as jArray when jArray.Count = 0 && not (List.contains "expected" (this.PropertiesWithIdentifier canonicalDataCase)) -> "AssertEmpty"
        | _ -> "AssertEqual"

    default __.TestFileFormat = TestFileFormat.Module

    // Rendering of canonical data

    default this.Render canonicalData =
        canonicalData
        |> this.ToTestFile
        |> renderPartialTemplate this.TestFileTemplate

    default this.RenderTestMethod (index, canonicalDataCase) = 
        let template = this.TestMethodTemplate (index, canonicalDataCase)

        (index, canonicalDataCase)
        |> this.ToTestMethod 
        |> renderPartialTemplate template

    default this.RenderTestMethodBody canonicalDataCase = 
        let template = this.TestMethodBodyTemplate canonicalDataCase

        canonicalDataCase
        |> this.ToTestMethodBody
        |> renderPartialTemplate template

    default this.RenderTestMethodName canonicalDataCase = 
        match this.UseFullMethodName canonicalDataCase with
        | false ->
            String.upperCaseFirst canonicalDataCase.Description
        | true -> 
            canonicalDataCase.DescriptionPath
            |> String.concat " - "
            |> String.upperCaseFirst   

    default __.RenderSetup _ = ""

    // Generic value/identifier rendering methods

    default __.RenderValue (_, _, value) = formatValue value

    default this.RenderValueOrIdentifier (canonicalDataCase, key, value) =
        let properties = this.PropertiesWithIdentifier canonicalDataCase

        match List.contains key properties with
        | true  -> this.RenderIdentifier (canonicalDataCase, key, value)
        | false -> this.RenderValueWithoutIdentifier (canonicalDataCase, key, value)

    default this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) = 
        match key with
        | "expected" -> this.RenderExpected (canonicalDataCase, key, value)
        | _  -> this.RenderInput (canonicalDataCase, key, value)

    default this.RenderValueWithIdentifier (canonicalDataCase, key, value) = 
        let identifier = this.RenderIdentifierWithTypeAnnotation (canonicalDataCase, key, value)
        let value = this.RenderValueWithoutIdentifier (canonicalDataCase, key, value)
        sprintf "let %s = %s" identifier value  

    default __.RenderIdentifier (_, key, _) = String.camelize key

    default this.RenderIdentifierWithTypeAnnotation (canonicalDataCase, key, value) = 
        let identifier = this.RenderIdentifier (canonicalDataCase, key, value)
    
        match this.IdentifierTypeAnnotation (canonicalDataCase, key, value) with
        | Some identifierType -> 
            identifier |> addTypeAnnotation identifierType
        | None -> 
            identifier

    // Canonical-data specific rendering methods

    default this.RenderExpected (canonicalDataCase, key, value) = this.RenderValue (canonicalDataCase, key, value)

    default this.RenderInput (canonicalDataCase, key, value) = this.RenderValue (canonicalDataCase, key, value)

    default this.RenderArrange canonicalDataCase =
        let renderArrangeProperty property: string option = 
            match Map.tryFind property canonicalDataCase.Properties with
            | None -> None
            | Some value -> Some (this.RenderValueWithIdentifier (canonicalDataCase, property, value))

        canonicalDataCase
        |> this.PropertiesWithIdentifier 
        |> List.choose renderArrangeProperty

    default this.RenderAssert canonicalDataCase = 
        let template = this.TestMethodBodyAssertTemplate canonicalDataCase                

        canonicalDataCase
        |> this.ToTestMethodBodyAssert
        |> renderPartialTemplate template    

    default this.RenderSut canonicalDataCase = 
        let parameters = this.RenderSutParameters canonicalDataCase
        let property = this.RenderSutProperty canonicalDataCase
        property :: parameters |> String.concat " "

    default this.RenderSutParameters canonicalDataCase =
        let sutParameterProperties = this.PropertiesUsedAsSutParameter canonicalDataCase
        let renderSutParameter key = this.RenderSutParameter (canonicalDataCase, key, Map.find key canonicalDataCase.Properties)

        sutParameterProperties
        |> List.map renderSutParameter
    
    default this.RenderSutParameter (canonicalDataCase, key, value) =
        this.RenderValueOrIdentifier (canonicalDataCase, key, value) 

    default __.RenderSutProperty canonicalDataCase = string canonicalDataCase.Property

    default this.Properties canonicalDataCase =
        List.append (this.PropertiesUsedAsSutParameter canonicalDataCase) ["expected"]

    default __.PropertiesUsedAsSutParameter canonicalDataCase = 
        canonicalDataCase.Properties
        |> Map.toList
        |> List.map fst
        |> List.except ["expected"; "property"; "description"; "comments"]
    
    // Utility methods to customize rendered output

    default __.PropertiesWithIdentifier _ = []

    default __.IdentifierTypeAnnotation (_, _, _) = None

    default __.UseFullMethodName _ = false

    default __.AdditionalNamespaces = []
    
type CustomExercise() =

    member this.Name = this.GetType().Name.Kebaberize()

type MissingDataExercise = { Name: string }

type UnimplementedExercise = { Name: string }
    
type Exercise =
    | Generator of GeneratorExercise
    | Custom of CustomExercise
    | MissingData of MissingDataExercise
    | Unimplemented of UnimplementedExercise
    
let exerciseName exercise =
    match exercise with
    | Generator generator -> generator.Name
    | Custom custom -> custom.Name
    | Unimplemented unimplemented -> unimplemented.Name
    | MissingData missingData -> missingData.Name    

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
    
let private tryFindUnimplementedExercise options exerciseName =
    match hasCanonicalData options exerciseName with
    | true  -> Unimplemented { Name = exerciseName } |> Some 
    | false -> None

let private createExercise options exerciseName =
    tryFindGeneratorExercise exerciseName
    |> Option.orElse (tryFindCustomExercise exerciseName)
    |> Option.orElse (tryFindUnimplementedExercise options exerciseName)
    |> Option.orElse (MissingData { Name = exerciseName } |> Some)

let createExercises options =
    exerciseNames
    |> List.choose (createExercise options)