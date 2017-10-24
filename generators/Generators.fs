module Generators.Generators

open System
open System.Globalization
open Humanizer
open Newtonsoft.Json.Linq
open Output
open Exercise

type Acronym() =
    inherit Exercise()

type AtbashCipher() =
    inherit Exercise()

type AllYourBase() =    
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = value |> Option.ofObj |> formatValue

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

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
                |> indent 1

            canonicalDataCase.Expected :?> JArray
            |> Seq.map renderAssertion
            |> String.concat "\n"
        else
            base.RenderTestMethodBody canonicalDataCase

    override this.RenderExpected (canonicalDataCase, key, value) =     
        if (canonicalDataCase.Property = "list") then
            canonicalDataCase.Expected :?> JArray
            |> Seq.map toAllergen
            |> formatList
        else
            base.RenderExpected (canonicalDataCase, key, value)

    override this.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "substance" -> string value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

type BeerSong() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

type Bob() =
    inherit Exercise()

type BookStore() =
    inherit Exercise()

    let formatFloat (value:obj) = value :?> float |> sprintf "%.2f"

    override this.RenderExpected (canonicalDataCase, key, value) = formatFloat value

    override this.PropertiesUsedAsSutParameter canonicalDataCase =
        base.PropertiesUsedAsSutParameter canonicalDataCase |> List.except ["targetgrouping"]

type BracketPush() =
    inherit Exercise()

type Change() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) =
        let convertToOption = if value :? JArray then Option.ofObj else Option.ofNonNegativeInt
        value |> convertToOption |> formatValue

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key with 
        | "expected" -> 
            match canonicalDataCase.Properties.["target"] :?> int64 with
            | 0L -> Some "int list option"
            | _  -> None
        | _ -> None

type Clock() =
    inherit Exercise()

    let createClock (value:obj) clockId =
        let clock = value :?> JObject
        let hour = clock.["hour"].ToObject<string>()
        let minute = clock.["minute"].ToObject<string>()
        sprintf "let %s = create %s %s" clockId hour minute

    member private this.renderPropertyValue canonicalDataCase property =
        this.RenderSutParameter (canonicalDataCase, property, Map.find property canonicalDataCase.Properties)

    override this.PropertiesWithIdentifier canonicalDataCase = ["clock1"; "clock2"]

    override this.RenderValueWithIdentifier (canonicalDataCase, key, value) =
        match key with
        | "clock1" | "clock2" -> createClock value key
        | _ -> base.RenderValueWithIdentifier (canonicalDataCase, key, value)
    
    override this.RenderArrange canonicalDataCase =
        match canonicalDataCase.Property with
        | "create" | "add" -> 
            let hour = this.renderPropertyValue canonicalDataCase "hour"
            let minute = this.renderPropertyValue canonicalDataCase "minute"
            [sprintf "let clock = create %s %s" hour minute]
        | _ -> 
            base.RenderArrange canonicalDataCase

    override this.RenderSut canonicalDataCase =
        match canonicalDataCase.Property with
        | "create" -> 
            sprintf "display clock"
        | "add" -> 
            this.renderPropertyValue canonicalDataCase "add"
            |> sprintf "add %s clock |> display" 
        | "equal" -> 
            "clock1 = clock2" 
        | _ -> 
            base.RenderSut canonicalDataCase

type CryptoSquare() =
    inherit Exercise()

type DifferenceOfSquares() =
    inherit Exercise()

type Dominoes() =
    inherit Exercise()
    
    let formatAsTuple (value:obj) =
        let twoElementList = value :?> JArray |> normalizeJArray
        (twoElementList.Item 0, twoElementList.Item 1) |> string

    override this.RenderInput (canonicalDataCase, key, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatAsTuple
        |> formatList

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Gigasecond() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = value :?> DateTime |> formatDateTime |> parenthesize
 
    override this.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "input" -> DateTime.Parse(string value, CultureInfo.InvariantCulture) |> formatDateTime |> parenthesize
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override this.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type Grains() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = Some "Result<uint64,string>"

    override this.RenderExpected (canonicalDataCase, key, value) = 
        match string value with
        | "-1" -> "Error \"Invalid input\""
        | x    -> sprintf "Ok %sUL" x

type HelloWorld() =
    inherit Exercise()

type Isogram() =
    inherit Exercise()

type KindergartenGarden() =
    inherit Exercise()

    let toPlant (jToken: JToken) =  sprintf "Plant.%s" (jToken.ToString() |> String.humanize)

    override this.RenderExpected (canonicalDataCase, key, value) = 
        value :?> JArray 
        |> Seq.map toPlant
        |> formatList

    override this.PropertiesWithIdentifier canonicalDataCase = ["student"; "diagram"; "expected"]

    override this.UseFullMethodName canonicalDataCase = true

type LargestSeriesProduct() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override this.RenderExpected (canonicalDataCase, key, value) = 
        value 
        |> Option.ofNonNegativeInt 
        |> formatValue 
        |> parenthesizeOption

type Leap() =
    inherit Exercise()

type Luhn() =
    inherit Exercise()

type Minesweeper() =
    inherit Exercise()

    override this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) =        
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None

type NthPrime() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = 
        value 
        |> Option.ofNonFalse 
        |> formatValue 
        |> parenthesizeOption

type Pangram() =
    inherit Exercise()
    
type PerfectNumbers() =
    inherit Exercise()

    let toClassification value = string value |> String.humanize

    override this.RenderExpected (canonicalDataCase, key, value) = 
        value 
        |> Option.ofNonError  
        |> Option.map toClassification 
        |> formatOption 
        |> parenthesizeOption

type PascalsTriangle() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = 
        match value with
        | :? JArray  ->
            match value :?> JArray |> Seq.isEmpty  with
            | true -> "(Some ([]: int list list))"
            | false ->
                value :?> JArray
                |> normalizeJArray
                |> Seq.map formatValue
                |> formatList
                |> sprintf "(Some %s)"

        | _ -> "None"

    override this.ToTestMethodBodyAssertTemplate canonicalDataCase = "AssertEqual"

type PhoneNumber() =
    inherit Exercise()
    
    override this.RenderExpected (canonicalDataCase, key, value) =
        value 
        |> Option.ofObj 
        |> formatValue
        |> parenthesizeOption

type PigLatin() =
    inherit Exercise()

type PrimeFactors() =
    inherit Exercise()
    
    override this.RenderInput (canonicalDataCase, key, value) =
        base.RenderInput (canonicalDataCase, key, value) |> sprintf "%sL"
    
type QueenAttack() =
    inherit Exercise()

    override this.MapCanonicalDataCaseProperty (canonicalDataCase, key, value) =
        match canonicalDataCase.Property, key, value with
        | "create", "expected", _ -> value :?> int64 <> -1L |> box
        | _ -> base.MapCanonicalDataCaseProperty (canonicalDataCase, key, value)

    override this.RenderInput (canonicalDataCase, key, value) =
        let parsePositionTuple (tupleValue: obj) =
            let position = (tupleValue :?> JToken).SelectToken("position")
            formatValue (position.["row"].ToObject<int>(), position.["column"].ToObject<int>())

        match key with
        | "queen" | "white_queen" | "black_queen" -> parsePositionTuple value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = ["white_queen"; "black_queen"]

type RailFenceCipher() =
    inherit Exercise()

    override this.PropertiesUsedAsSutParameter canonicalDataCase = ["rails"; "msg"]

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Raindrops() =
    inherit Exercise()

type RobotSimulator() =
    inherit Exercise()

    let resultIdentifierName = "actual"

    override this.PropertiesWithIdentifier canonicalDataCase = ["robot"; "property"; "expected"]

    member private this.RenderDirection (value: JToken) = 
        sprintf "%s" (value.ToObject<string>() |> String.upperCaseFirst)  

    member private this.RenderCoords (coords: JToken) = 
        (coords.["x"].ToObject<int>(), coords.["y"].ToObject<int>()) 
        |> formatValue

    member private this.DefineRobot (direction: JToken) (coords: JToken) = 
        sprintf "createRobot %s %s" (this.RenderDirection direction) (this.RenderCoords coords)

    member private this.GetRobotProperties (value : JToken) = 
        value.SelectToken("direction"), value.SelectToken("position")

    override this.RenderArrange canonicalDataCase =
        // one identifier may be empty if we only checking created object
        // we need to filter out this empty line
        base.RenderArrange canonicalDataCase
        |> List.choose (
            function
            | "" -> None
            | v -> Some v
        )

    override this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) = 
        match key with
        | "robot" ->
            let input = value :?> JToken
            this.DefineRobot ("direction" |> input.SelectToken) ("position" |> input.SelectToken)
        | "expected" -> 
            // here we may need to render full robot object
            // or just coordinate/direction values
            let input = value :?> JToken
            let direction, position = this.GetRobotProperties input
            match isNull direction, isNull position with
            | true, false ->
                this.RenderCoords position
            | false, true ->
                this.RenderDirection direction
            | false, false ->
                this.DefineRobot ("direction" |> input.SelectToken) ("position" |> input.SelectToken)
            | true, true -> 
                ""
        | _ -> ""

    override this.RenderValueWithIdentifier (canonicalDataCase, key, value) = 
        match key with 
        | "property" -> 
            let action = value :?> string
            match action with 
            | "instructions" -> 
                 sprintf "let %s = simulate robot %s" resultIdentifierName (canonicalDataCase.Properties.["instructions"] |> formatValue)
            | "create" -> 
                ""
            | _ -> 
                 sprintf "let %s = %s robot" resultIdentifierName action
            
        | _ -> 
            base.RenderValueWithIdentifier (canonicalDataCase, key, value)

    override this.RenderSut canonicalDataCase = 
        match canonicalDataCase.Property with
        | "create" -> 
            "robot"
        | _ -> 
            // depends on expected value we may need to 
            // check whole robot or just one of its' properties
            let direction, position = this.GetRobotProperties (canonicalDataCase.Properties.["expected"] :?> JToken)
            match isNull direction, isNull position with
            | true, false -> 
                sprintf "%s.coordinate" resultIdentifierName
            | false, true ->
                sprintf "%s.bearing" resultIdentifierName
            | true, true -> 
                resultIdentifierName
            | false, false -> 
                match canonicalDataCase.Property with
                | "create" -> "robot"
                | _ -> resultIdentifierName
    
    override this.RenderTestMethodName canonicalDataCase =
         // avoid duplicated method names
         // for this generator it is preferable
         // because useFullMethodName leads to very long names
         sprintf "%s - %s" canonicalDataCase.Property (canonicalDataCase.Description |> String.upperCaseFirst)

type RnaTranscription() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) =
        value |> Option.ofObj |> formatValue |> parenthesizeOption

type RunLengthEncoding() =
    inherit Exercise()

    override this.RenderSut canonicalDataCase =
        match canonicalDataCase.Property with
        | "consistency" ->
            let parameters = this.RenderSutParameters canonicalDataCase |> String.concat " "
            sprintf "%s |> encode |> decode" parameters
        | _ -> 
            base.RenderSut canonicalDataCase

    override this.RenderTestMethodName canonicalDataCase =
        match canonicalDataCase.Property with
        | "consistency" -> 
            base.RenderTestMethodName canonicalDataCase
        | _ -> 
            sprintf "%s %s" canonicalDataCase.Property canonicalDataCase.Description |> String.upperCaseFirst

type RomanNumerals() =
    inherit Exercise()

type ScrabbleScore() =
    inherit Exercise()