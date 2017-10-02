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

[<AbstractClass>]
type Exercise() =
    abstract member ToTestClass : CanonicalData -> TestClass
    abstract member ToTestMethod : int -> CanonicalDataCase -> TestMethod
    abstract member ToTestMethodBody : CanonicalDataCase -> TestMethodBody  
    abstract member ToTestMethodBodyAssert : CanonicalDataCase -> TestMethodBodyAssert  
    abstract member Render : CanonicalData -> string
    abstract member RenderTestMethod : int -> CanonicalDataCase -> string
    abstract member RenderTestMethodBody : CanonicalDataCase -> string
    abstract member RenderExpected : CanonicalDataCase -> obj -> string
    abstract member RenderInput : CanonicalDataCase -> string -> obj -> string
    abstract member RenderArrange : CanonicalDataCase -> string list
    abstract member RenderSut : CanonicalDataCase -> string
    abstract member RenderSutParameters : CanonicalDataCase -> string list
    abstract member RenderAssert : CanonicalDataCase -> string
    abstract member RenderSutProperty : CanonicalDataCase -> string
    abstract member RenderValueOrIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member RenderValueWithoutIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member RenderValueWithIdentifier: CanonicalDataCase -> string -> obj -> string
    abstract member SutParameters : CanonicalDataCase -> CanonicalDataCase
    abstract member MapCanonicalDataCase : CanonicalDataCase -> CanonicalDataCase
    abstract member PropertiesWithIdentifier : string list

    member this.Name = this.GetType().Name.Kebaberize()
    member this.TestModuleName = this.GetType().Name.Pascalize() |> sprintf "%sTest"
    member this.TestedModuleName = this.GetType().Name.Pascalize()
    member this.RenderIdentifier key = String.camelize key

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

    default this.MapCanonicalDataCase canonicalDataCase = canonicalDataCase

    default this.ToTestClass canonicalData =
        { Version = canonicalData.Version              
          ExerciseName = this.Name
          TestModuleName = this.TestModuleName
          TestedModuleName = this.TestedModuleName
          Namespaces = set ["FsUnit.Xunit"; "Xunit"]
          Methods = List.mapi this.RenderTestMethod canonicalData.Cases }

    default this.ToTestMethod index canonicalDataCase =         
        { Skip = index > 0
          Name = canonicalDataCase.["description"] |> string |> String.humanize
          Body = this.RenderTestMethodBody canonicalDataCase }

    default this.ToTestMethodBody canonicalDataCase =         
        { Arrange = this.RenderArrange canonicalDataCase
          Assert = this.RenderAssert canonicalDataCase }

    default this.ToTestMethodBodyAssert canonicalDataCase =         
        { Sut = this.RenderSut canonicalDataCase
          Expected = this.RenderValueOrIdentifier canonicalDataCase "expected" canonicalDataCase.["expected"] }

    default this.RenderExpected canonicalDataCase expected = formatValue expected

    default this.RenderInput canonicalDataCase key value = formatValue value
    
    default this.Render canonicalData =
        canonicalData
        |> this.ToTestClass
        |> renderPartialTemplate "TestClass"

    default this.RenderTestMethod index canonicalDataCase = 
        canonicalDataCase
        |> this.ToTestMethod index
        |> renderPartialTemplate "TestMethod"

    default this.RenderTestMethodBody canonicalDataCase = 
        canonicalDataCase
        |> this.ToTestMethodBody
        |> renderPartialTemplate "TestMethodBody"

    default this.RenderArrange canonicalDataCase =
        let renderArrangeProperty property = 
            let key = property
            let value = Map.find key canonicalDataCase
            this.RenderValueWithIdentifier canonicalDataCase key value

        List.map renderArrangeProperty this.PropertiesWithIdentifier

    default this.RenderSut canonicalDataCase = 
        let parameters = this.RenderSutParameters canonicalDataCase
        let property = this.RenderSutProperty canonicalDataCase
        property :: parameters |> String.concat " "

    default this.RenderAssert canonicalDataCase = 
        let template = 
            match canonicalDataCase.["expected"] with
            | :? JArray as jArray when jArray.Count = 0 -> "AssertEmpty"
            | _ -> "AssertEqual"                      

        canonicalDataCase
        |> this.ToTestMethodBodyAssert
        |> renderPartialTemplate template
    
    default this.RenderSutParameters canonicalDataCase =
        let sutParameters = this.SutParameters canonicalDataCase
        
        Map.foldBack (fun key value acc -> this.RenderValueOrIdentifier canonicalDataCase key value :: acc) sutParameters [] 

    default this.RenderSutProperty canonicalDataCase = string canonicalDataCase.["property"]

    default this.SutParameters canonicalDataCase =
        canonicalDataCase
        |> Map.remove "property"
        |> Map.remove "expected"
        |> Map.remove "description"

    default this.RenderValueOrIdentifier canonicalDataCase key value =
        if (List.contains key this.PropertiesWithIdentifier) then
            this.RenderIdentifier key
        else
            this.RenderValueWithoutIdentifier canonicalDataCase key value

    default this.RenderValueWithoutIdentifier canonicalDataCase key value = 
        if (key = "expected") then
            this.RenderExpected canonicalDataCase value
        else            
            this.RenderInput canonicalDataCase key value

    default this.RenderValueWithIdentifier canonicalDataCase key value = 
        let identifier = this.RenderIdentifier key
        let value = this.RenderValueWithoutIdentifier canonicalDataCase key value
        sprintf "let %s = %s" identifier value

    default this.PropertiesWithIdentifier = []

type Acronym() =
    inherit Exercise()

type AtbashCipher() =
    inherit Exercise()

type AllYourBase() =    
    inherit Exercise()

    override this.PropertiesWithIdentifier = ["expected"; "input_base"; "input_digits"; "output_base"]

    override this.RenderExpected canonicalDataCase value = formatNullableToOption value    

type Allergies() =
    inherit Exercise()

    let toAllergen (jToken: JToken) =  sprintf "Allergen.%s" (jToken.ToString() |> String.humanize)

    override this.RenderTestMethodBody canonicalDataCase =
        if (string canonicalDataCase.["property"] = "allergicTo") then
            let renderAssertion (jToken: JToken) =
                canonicalDataCase
                |> Map.add "substance" (jToken.["substance"] |> toAllergen |> box)
                |> Map.add "expected" (jToken.["result"].ToObject<bool>() |> box)
                |> this.RenderAssert
                |> indent

            canonicalDataCase.["expected"] :?> JArray
            |> Seq.map renderAssertion
            |> String.concat "\n"
        else
            base.RenderTestMethodBody canonicalDataCase

    override this.RenderExpected canonicalDataCase expected =     
        if (string canonicalDataCase.["property"] = "list") then
            canonicalDataCase.["expected"] :?> JArray
            |> Seq.map toAllergen
            |> formatList
        else
            formatValue expected

    override this.RenderInput canonicalDataCase key value =
        match key with
        | "substance" -> string value
        | _ -> formatValue value

type BeerSong() =
    inherit Exercise()

    override this.PropertiesWithIdentifier = ["expected"]

type Bob() =
    inherit Exercise()

type BookStore() =
    inherit Exercise()

    let formatFloat (value:obj) = value :?> float |> sprintf "%.2f"

    override this.RenderExpected canonicalDataCase value = formatFloat value

    override this.SutParameters canonicalDataCase =
        base.SutParameters canonicalDataCase
        |> Map.remove "targetgrouping"

type BracketPush() =
    inherit Exercise()

type Change() =
    inherit Exercise()

    override this.PropertiesWithIdentifier = ["coins"; "target"; "expected"]

    override this.RenderExpected canonicalDataCase value = formatOption isInt64 value    

type CryptoSquare() =
    inherit Exercise()

type DifferenceOfSquares() =
    inherit Exercise()

type Gigasecond() =
    inherit Exercise()

    let format = formatDateTime >> parenthesize

    override this.RenderExpected canonicalDataCase value = value :?> DateTime |> format

    override this.RenderInput canonicalDataCase key value =
        match key with
        | "input" -> DateTime.Parse(string value, CultureInfo.InvariantCulture) |> format
        | _ -> formatValue value

type HelloWorld() =
    inherit Exercise()  

type Isogram() =
    inherit Exercise()  

type Leap() =
    inherit Exercise()

type Luhn() =
    inherit Exercise()

type Minesweeper() =
    inherit Exercise()

    override this.PropertiesWithIdentifier = ["input"; "expected"]

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
            string value
        | _ -> 
            formatValue value

type Raindrops() =
    inherit Exercise()

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