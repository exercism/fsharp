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

    override this.MapCanonicalDataCaseProperty (canonicalDataCase, key, value) = 
        match key with 
        | "expected" -> 
            match value with 
            | :? JArray -> Option.ofObj value |> box
            | _ -> value |> Option.ofNonNegativeInt |> box
        | _ -> base.MapCanonicalDataCaseProperty (canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key with 
        | "expected" -> 
            match canonicalDataCase.Properties.["target"] :?> int64 with
            | 0L -> Some "int list option"
            | _  -> None
        | _ -> None

type CryptoSquare() =
    inherit Exercise()

type DifferenceOfSquares() =
    inherit Exercise()

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

     override this.PropertiesWithIdentifier canonicalDataCase = ["digits"]

    override this.RenderExpected (canonicalDataCase, key, value) = 
        match value :?> int64 with 
        | -1L -> "None"
        | _ -> value :?> int64 |> sprintf "(Some %d)"

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
        match string value with 
        | "False" -> "None"
        | _ ->  value :?> int64 |> sprintf "(Some %d)"

type Pangram() =
    inherit Exercise()
    
type PerfectNumbers() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = 
        match value |> string with 
        | "perfect" -> "(Some Perfect)"
        | "abundant" -> "(Some Abundant)"
        | "deficient" -> "(Some Deficient)"
        | _ -> "None"

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
        value |> Option.ofObj |> formatValue |> backwardPipe

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

type RnaTranscription() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) =
        value |> Option.ofObj |> formatValue |> backwardPipe

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