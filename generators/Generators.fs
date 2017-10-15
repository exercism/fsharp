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

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"; "input_base"; "input_digits"; "output_base"]

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
        base.PropertiesUsedAsSutParameter canonicalDataCase
        |> List.except ["targetgrouping"; "expected"; "description"]

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

    override this.PropertiesWithIdentifier canonicalDataCase = ["coins"; "target"; "expected"]

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

    override this.RenderSutProperty canonicalDataCase =
        match Map.containsKey "students" canonicalDataCase.Properties with
        | true  -> "plantsForCustomStudents"
        | false -> "plantsForDefaultStudents"

    override this.PropertiesWithIdentifier canonicalDataCase = ["student"; "students"; "diagram"; "expected"]

    override this.UseFullMethodName canonicalDataCase = true

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

    override this.PropertiesWithIdentifier canonicalDataCase = ["input"; "expected"]

    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None

type Pangram() =
    inherit Exercise()

type PigLatin() =
    inherit Exercise()

type QueenAttack() =
    inherit Exercise()

    override this.MapCanonicalDataCaseProperty (canonicalDataCase, key, value) =
        match canonicalDataCase.Property, key, value with
        | "create", "expected", _ -> value :?> int64 <> -1L |> box
        | _ -> base.MapCanonicalDataCaseProperty (canonicalDataCase, key, value)

    override this.RenderInput (canonicalDataCase, key, value) =
        let parsePositionTuple (tupleValue: obj) =
            let parts = 
                (tupleValue :?> JToken)
                    .SelectToken("position")
                    .ToObject<string>()
                    .TrimStart('(')
                    .TrimEnd(')')
                    .Split(',')
            formatValue (int parts.[0], int parts.[1])

        match key with
        | "queen" | "white_queen" | "black_queen" -> parsePositionTuple value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = ["white_queen"; "black_queen"]

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