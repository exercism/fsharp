module Generators.Exercises

open System
open System.Globalization
open System.Collections.Generic
open System.IO
open System.Reflection
open Newtonsoft.Json.Linq
open Humanizer
open Serilog
open Input
open Output

let renderIdentifier typeAnnotation (canonicalDataCase: CanonicalDataCase) (key: string) value = String.camelize key

let renderIdentifierWithTypeAnnotation renderIdentifier typeAnnotation (canonicalDataCase: CanonicalDataCase) (key: string) value = 
    let identifier = renderIdentifier canonicalDataCase key value
    
    match typeAnnotation canonicalDataCase key value with
    | Some ty -> identifier |> addTypeAnnotation ty
    | None    -> identifier

let renderExpected (canonicalDataCase: CanonicalDataCase) expected = formatValue expected

let renderInput (canonicalDataCase: CanonicalDataCase) (key: string) value = formatValue value

let renderTestMethodName (canonicalDataCase: CanonicalDataCase) = 
    String.upperCaseFirst canonicalDataCase.Description

let renderFullTestMethodName (canonicalDataCase: CanonicalDataCase) = 
    canonicalDataCase.DescriptionPath
    |> String.concat " - "
    |> String.upperCaseFirst

let renderTestClass (testClass: TestClass) = renderPartialTemplate "TestClass" testClass

let renderTestMethod (testMethod: TestMethod) = renderPartialTemplate "TestMethod" testMethod

let renderTestMethodBody (testMethodBody: TestMethodBody) = renderPartialTemplate "TestMethodBody" testMethodBody

let renderArrange renderValueWithIdentifier propertiesWithIdentifier (canonicalDataCase: CanonicalDataCase) =
    let renderArrangeProperty property: string option = 
        match Map.tryFind property canonicalDataCase.Properties with
        | None -> None
        | Some value -> Some (renderValueWithIdentifier canonicalDataCase property value)

    canonicalDataCase
    |> propertiesWithIdentifier 
    |> List.choose renderArrangeProperty

let renderAssert testMethodBodyAssertTemplate (testMethodBodyAssert: TestMethodBodyAssert) = 
    renderPartialTemplate testMethodBodyAssertTemplate testMethodBodyAssert

let renderValueWithoutIdentifier renderExpected renderInput (canonicalDataCase: CanonicalDataCase) (key: string) value = 
    match key with
    | "expected" -> renderExpected canonicalDataCase value
    | _  -> renderInput canonicalDataCase key value

let renderValueOrIdentifier renderIdentifier renderValueWithoutIdentifier propertiesWithIdentifier (canonicalDataCase: CanonicalDataCase) (key: string) value =
    let properties = propertiesWithIdentifier canonicalDataCase

    match List.contains key properties with
    | true  -> renderIdentifier canonicalDataCase key value
    | false -> renderValueWithoutIdentifier canonicalDataCase key value

let renderValueWithIdentifier renderIdentifier renderValueWithoutIdentifier typeAnnotation (canonicalDataCase: CanonicalDataCase) (key: string) value = 
    let identifier = renderIdentifierWithTypeAnnotation renderIdentifier typeAnnotation canonicalDataCase key value
    let value = renderValueWithoutIdentifier canonicalDataCase key value
    sprintf "let %s = %s" identifier value    

let renderSutParameters renderValueOrIdentifier (sutParameters: CanonicalDataCase) =    
    Map.foldBack (fun key value acc -> renderValueOrIdentifier sutParameters key value :: acc) sutParameters.Properties [] 

let renderSutProperty (canonicalDataCase: CanonicalDataCase) = string canonicalDataCase.Property

let renderSut renderSutParameters renderSutProperty (canonicalDataCase: CanonicalDataCase) = 
    let parameters = renderSutParameters canonicalDataCase
    let property = renderSutProperty canonicalDataCase
    property :: parameters |> String.concat " "

let mapCanonicalDataCaseProperty (canonicalDataCase: CanonicalDataCase) (key: string) value = value 

let mapCanonicalDataCase mapCanonicalDataCaseProperty (canonicalDataCase: CanonicalDataCase) =
    { canonicalDataCase with 
        Properties = Map.map (mapCanonicalDataCaseProperty canonicalDataCase) canonicalDataCase.Properties }

let sutParameters canonicalDataCase =
    let updatedProperties = 
        canonicalDataCase.Properties
        |> Map.remove "property"
        |> Map.remove "expected"
        |> Map.remove "description"

    { canonicalDataCase with Properties = updatedProperties }        

let identifierTypeAnnotation (canonicalDataCase: CanonicalDataCase) (key: string) value = None

[<AbstractClass>]
type Exercise() =
    abstract member ToTestClass : CanonicalData -> TestClass
    abstract member ToTestMethod : int -> CanonicalDataCase -> TestMethod
    abstract member ToTestMethodBody : CanonicalDataCase -> TestMethodBody  
    abstract member ToTestMethodBodyAssert : CanonicalDataCase -> TestMethodBodyAssert  
    abstract member ToTestMethodBodyAssertTemplate : CanonicalDataCase -> string
    abstract member Render : CanonicalData -> string
    abstract member RenderTestMethod : int -> CanonicalDataCase -> string
    abstract member RenderTestMethodBody : CanonicalDataCase -> string
    abstract member RenderTestMethodName : CanonicalDataCase -> string
    abstract member RenderExpected : CanonicalDataCase -> obj -> string
    abstract member RenderInput : CanonicalDataCase -> string -> obj -> string
    abstract member RenderArrange : CanonicalDataCase -> string list
    abstract member RenderAssert : CanonicalDataCase -> string
    abstract member RenderSut : CanonicalDataCase -> string
    abstract member RenderSutParameters : CanonicalDataCase -> string list
    abstract member RenderSutProperty : CanonicalDataCase -> string
    abstract member RenderIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member RenderValueOrIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member RenderValueWithoutIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member RenderValueWithIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member SutParameters : CanonicalDataCase -> CanonicalDataCase
    abstract member MapCanonicalDataCase : CanonicalDataCase -> CanonicalDataCase
    abstract member MapCanonicalDataCaseProperty : CanonicalDataCase -> string -> obj -> obj
    abstract member PropertiesWithIdentifier : CanonicalDataCase -> string list
    abstract member IdentifierTypeAnnotation: CanonicalDataCase -> string -> obj -> string option
    abstract member AdditionalNamespaces : string list

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

    member this.MapCanonicalData canonicalData = 
        { canonicalData with Cases = List.map this.MapCanonicalDataCase canonicalData.Cases }

    default this.MapCanonicalDataCase canonicalDataCase = mapCanonicalDataCase this.MapCanonicalDataCaseProperty canonicalDataCase

    default this.MapCanonicalDataCaseProperty canonicalDataCase key value = mapCanonicalDataCaseProperty canonicalDataCase key value

    default this.ToTestClass canonicalData =
        { Version = canonicalData.Version              
          ExerciseName = this.Name
          TestModuleName = this.TestModuleName
          TestedModuleName = this.TestedModuleName
          Namespaces = ["FsUnit.Xunit"; "Xunit"] @ this.AdditionalNamespaces
          Methods = List.mapi this.RenderTestMethod canonicalData.Cases }

    default this.ToTestMethod index canonicalDataCase =         
        { Skip = index > 0
          Name = this.RenderTestMethodName canonicalDataCase
          Body = this.RenderTestMethodBody canonicalDataCase }

    default this.ToTestMethodBody canonicalDataCase =         
        { Arrange = this.RenderArrange canonicalDataCase
          Assert = this.RenderAssert canonicalDataCase }

    default this.ToTestMethodBodyAssert canonicalDataCase =         
        { Sut = this.RenderSut canonicalDataCase
          Expected = this.RenderValueOrIdentifier canonicalDataCase "expected" canonicalDataCase.Expected }

    default this.ToTestMethodBodyAssertTemplate canonicalDataCase =
        match canonicalDataCase.Expected with
        | :? JArray as jArray when jArray.Count = 0 && not (List.contains "expected" (this.PropertiesWithIdentifier canonicalDataCase)) -> "AssertEmpty"
        | _ -> "AssertEqual"

    default this.RenderExpected canonicalDataCase expected = renderExpected canonicalDataCase expected

    default this.RenderInput canonicalDataCase key value = renderInput canonicalDataCase key value
    
    default this.Render canonicalData =
        canonicalData
        |> this.ToTestClass
        |> renderTestClass

    default this.RenderTestMethod index canonicalDataCase = 
        canonicalDataCase
        |> this.ToTestMethod index
        |> renderTestMethod

    default this.RenderTestMethodBody canonicalDataCase = 
        canonicalDataCase
        |> this.ToTestMethodBody
        |> renderTestMethodBody

    default this.RenderTestMethodName canonicalDataCase = 
        renderTestMethodName canonicalDataCase

    default this.RenderArrange canonicalDataCase =
        renderArrange this.RenderValueWithIdentifier this.PropertiesWithIdentifier canonicalDataCase

    default this.RenderSut canonicalDataCase = 
        renderSut this.RenderSutParameters this.RenderSutProperty canonicalDataCase

    default this.RenderAssert canonicalDataCase = 
        let template = this.ToTestMethodBodyAssertTemplate canonicalDataCase                

        canonicalDataCase
        |> this.ToTestMethodBodyAssert
        |> renderAssert template
    
    default this.RenderSutParameters canonicalDataCase =
        canonicalDataCase
        |> this.SutParameters 
        |> renderSutParameters this.RenderValueOrIdentifier

    default this.RenderSutProperty canonicalDataCase = renderSutProperty canonicalDataCase

    default this.SutParameters canonicalDataCase = sutParameters canonicalDataCase
    
    default this.RenderIdentifier canonicalDataCase key value = renderIdentifier this.IdentifierTypeAnnotation canonicalDataCase key value

    default this.RenderValueOrIdentifier canonicalDataCase key value =
        renderValueOrIdentifier this.RenderIdentifier this.RenderValueWithoutIdentifier this.PropertiesWithIdentifier canonicalDataCase key value

    default this.RenderValueWithoutIdentifier canonicalDataCase key value = 
        renderValueWithoutIdentifier this.RenderExpected this.RenderInput canonicalDataCase key value        

    default this.RenderValueWithIdentifier canonicalDataCase key value = 
        renderValueWithIdentifier this.RenderIdentifier this.RenderValueWithoutIdentifier this.IdentifierTypeAnnotation canonicalDataCase key value

    default this.PropertiesWithIdentifier canonicalDataCase = []

    default this.IdentifierTypeAnnotation canonicalDataCase key value = identifierTypeAnnotation canonicalDataCase key value

    default this.AdditionalNamespaces = []

type Acronym() =
    inherit Exercise()

type AtbashCipher() =
    inherit Exercise()

type AllYourBase() =    
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"; "input_base"; "input_digits"; "output_base"]

    override this.RenderExpected canonicalDataCase value = value |> Option.ofObj |> formatValue

type Allergies() =
    inherit Exercise()

    let toAllergen (jToken: JToken) =  sprintf "Allergen.%s" (jToken.ToString() |> String.humanize)

    override this.RenderTestMethodBody canonicalDataCase =
        if (canonicalDataCase.Property = "allergicTo") then
            let renderAssertion (jToken: JToken) =
                let updatedProperties =
                    canonicalDataCase.Properties
                    |> Map.add "substance" (jToken.["substance"] |> toAllergen |> box)
                    |> Map.add "expected" (jToken.["result"].ToObject<bool>() |> box)

                { canonicalDataCase with Properties = updatedProperties }                
                |> this.RenderAssert
                |> indent

            canonicalDataCase.Expected :?> JArray
            |> Seq.map renderAssertion
            |> String.concat "\n"
        else
            base.RenderTestMethodBody canonicalDataCase

    override this.RenderExpected canonicalDataCase expected =     
        if (canonicalDataCase.Property = "list") then
            canonicalDataCase.Expected :?> JArray
            |> Seq.map toAllergen
            |> formatList
        else
            renderExpected canonicalDataCase expected

    override this.RenderInput canonicalDataCase key value =
        match key with
        | "substance" -> string value
        | _ -> formatValue value

type BeerSong() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

type Bob() =
    inherit Exercise()

type BookStore() =
    inherit Exercise()

    let formatFloat (value:obj) = value :?> float |> sprintf "%.2f"

    override this.RenderExpected canonicalDataCase value = formatFloat value

    override this.SutParameters canonicalDataCase =
        let sutParameters = base.SutParameters canonicalDataCase
        let updatedProperties =
            sutParameters.Properties
            |> Map.remove "targetgrouping"
            |> Map.remove "expected"
            |> Map.remove "description"

        { sutParameters with Properties = updatedProperties }

type BracketPush() =
    inherit Exercise()

type Change() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["coins"; "target"; "expected"]

    override this.MapCanonicalDataCaseProperty canonicalDataCase key value = 
        match key with 
        | "expected" -> value |> Option.ofNonNegativeInt |> box
        | _ -> mapCanonicalDataCaseProperty canonicalDataCase key value

    override this.IdentifierTypeAnnotation canonicalDataCase key value = 
        match key with 
        | "expected" -> 
            match canonicalDataCase.Properties.["target"] :?> int64 with
            | 0L -> Some "int list option"
            | _  -> None
        | _ -> None

    // override this.RenderExpected canonicalDataCase value = 
    //     let expected = renderExpected canonicalDataCase value

    //     match canonicalDataCase.Properties.["target"] :?> int64 with
    //     | 0L -> expected |> addTypeAnnotation "int list option"
    //     | _  -> expected

type CryptoSquare() =
    inherit Exercise()

type DifferenceOfSquares() =
    inherit Exercise()

type Gigasecond() =
    inherit Exercise()

    override this.RenderExpected canonicalDataCase value = value :?> DateTime |> formatDateTime |> parenthesize
 
    override this.RenderInput canonicalDataCase key value =
        match key with
        | "input" -> DateTime.Parse(string value, CultureInfo.InvariantCulture) |> formatDateTime |> parenthesize
        | _ -> renderInput canonicalDataCase key value

    override this.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type HelloWorld() =
    inherit Exercise()

type Isogram() =
    inherit Exercise()

type KindergartenGarden() =
    inherit Exercise()

    let toPlant (jToken: JToken) =  sprintf "Plant.%s" (jToken.ToString() |> String.humanize)

    override this.PropertiesWithIdentifier canonicalDataCase = ["student"; "students"; "diagram"; "expected"]

    override this.RenderExpected canonicalDataCase value = 
        value :?> JArray 
        |> Seq.map toPlant
        |> formatList

    override this.RenderSutProperty canonicalDataCase =
        match Map.containsKey "students" canonicalDataCase.Properties with
        | true  -> "plantsForCustomStudents"
        | false -> "plantsForDefaultStudents"

    override this.RenderTestMethodName canonicalDataCase =
        renderFullTestMethodName canonicalDataCase    

type Leap() =
    inherit Exercise()

type Luhn() =
    inherit Exercise()

type Minesweeper() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["input"; "expected"]

    override this.IdentifierTypeAnnotation canonicalDataCase key value = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None

    override this.RenderValueWithoutIdentifier canonicalDataCase key value =        
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatList

type Pangram() =
    inherit Exercise()

type PigLatin() =
    inherit Exercise()

type QueenAttack() =
    inherit Exercise()

    override this.RenderInput canonicalDataCase key value =
        match key with
        | "queen" ->
            let parts = 
                (value :?> JToken)
                    .SelectToken("position")
                    .ToObject<string>()
                    .TrimStart('(')
                    .TrimEnd(')')
                    .Split(',')
            formatValue (int parts.[0], int parts.[1])
        | _ -> 
            renderInput canonicalDataCase key value

type Raindrops() =
    inherit Exercise()

type RnaTranscription() =
    inherit Exercise()

    override this.RenderExpected canonicalDataCase value =
        value |> Option.ofObj |> formatValue |> backwardPipe

type RomanNumerals() =
    inherit Exercise()

type ScrabbleScore() =
    inherit Exercise()

let createExercises filteredExercises =

    let isConcreteExercise (exerciseType: Type) = 
        not exerciseType.IsAbstract && typeof<Exercise>.IsAssignableFrom(exerciseType)

    let isFilteredExercises (exerciseType: Type) =
        Seq.isEmpty filteredExercises ||
        Seq.exists (String.equals exerciseType.Name) filteredExercises ||
        Seq.exists (String.equals (exerciseType.Name.Kebaberize())) filteredExercises

    let includeExercise (exerciseType: Type) = isConcreteExercise exerciseType && isFilteredExercises exerciseType

    let assemblyTypes = Assembly.GetEntryAssembly().GetTypes()

    seq { for exerciseType in assemblyTypes do 
            if includeExercise exerciseType then 
                yield Activator.CreateInstance(exerciseType) :?> Exercise }