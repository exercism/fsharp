module Generators.Generators

open System
open System.Globalization
open Newtonsoft.Json.Linq
open Formatting
open Exercise

type Acronym() =
    inherit GeneratorExercise()

type AtbashCipher() =
    inherit GeneratorExercise()

type AllYourBase() =    
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonError 
        |> formatValue

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Allergies() =
    inherit GeneratorExercise()

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

    override __.RenderExpected (canonicalDataCase, key, value) =     
        if (canonicalDataCase.Property = "list") then
            canonicalDataCase.Expected :?> JArray
            |> Seq.map toAllergen
            |> formatList
        else
            base.RenderExpected (canonicalDataCase, key, value)

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "substance" -> string value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

type Alphametics() =
    inherit GeneratorExercise()

    member __.formatMap<'TKey, 'TValue> (value: obj) =
        if isNull value then
            "None"
        else
            let input = value :?> JObject
            let dict = input.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>();
            let formattedList =
                dict
                |> Seq.map (fun kv -> formatTuple (kv.Key, kv.Value))
                |> formatMultiLineList

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s\n%s" formattedList (indent 2 "|> Map.ofList") (indent 2 "|> Some")
            else   
                sprintf "%s |> Map.ofList |> Some" formattedList

    override this.RenderExpected (_, _, value) = this.formatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Anagram() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["candidates"]

type ArmstrongNumbers() =
    inherit GeneratorExercise()

    override __.RenderInput (_, _, value) =
        (value :?> JToken).Value("number") 
        |> formatValue

type BeerSong() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startBottles"; "takeDown"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, key, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type BinarySearch() = 
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["array"; "value"; "expected"]

    override __.RenderValueWithoutIdentifier (canonicalDataCase, key, value) =
        match key with
        | "array" -> 
            (value :?> JToken).ToObject<string []>() |> formatArray
        | "expected" -> 
            match string value with
            | "-1" -> None |> formatOption
            | x -> Some x |> formatOption
        | _ ->
            base.RenderValueWithoutIdentifier (canonicalDataCase, key, value)

type Bob() =
    inherit GeneratorExercise()

type BookStore() =
    inherit GeneratorExercise()

    let formatFloat (value:obj) = value :?> float |> sprintf "%.2f"

    override __.RenderExpected (_, _, value) = formatFloat value

    override __.PropertiesUsedAsSutParameter canonicalDataCase =
        base.PropertiesUsedAsSutParameter canonicalDataCase |> List.except ["targetgrouping"]

type BracketPush() =
    inherit GeneratorExercise()

type Change() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        let convertToOption = if value :? JArray then Option.ofObj else Option.ofNonNegativeInt
        value |> convertToOption |> formatValue

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, _) = 
        match key with 
        | "expected" -> 
            match canonicalDataCase.Properties.["target"] :?> int64 with
            | 0L -> Some "int list option"
            | _  -> None
        | _ -> None

type Clock() =
    inherit GeneratorExercise()

    let createClock (value:obj) clockId =
        let clock = value :?> JObject
        let hour = clock.["hour"].ToObject<string>()
        let minute = clock.["minute"].ToObject<string>()
        sprintf "let %s = create %s %s" clockId hour minute

    member private this.renderPropertyValue canonicalDataCase property =
        this.RenderSutParameter (canonicalDataCase, property, Map.find property canonicalDataCase.Properties)

    override __.PropertiesWithIdentifier _ = ["clock1"; "clock2"]

    override __.RenderValueWithIdentifier (canonicalDataCase, key, value) =
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

type Connect() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        match string value with
        | "O" -> "(Some White)"
        | "X" -> "(Some Black)"
        | _   -> "None"

    override __.RenderInput (_, _, value) =
        let lines = (value :?> JArray).ToObject<string seq>() |> List.ofSeq
        let padSize = List.last lines |> String.length

        lines        
        |> List.map (fun line -> line.PadRight(padSize) |> formatValue)
        |> formatMultiLineList

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type CollatzConjecture() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofNonError 
        |> formatValue
        |> parenthesizeOption

type CryptoSquare() =
    inherit GeneratorExercise()

type DifferenceOfSquares() =
    inherit GeneratorExercise()

type Dominoes() =
    inherit GeneratorExercise()
    
    let formatAsTuple (value:obj) =
        let twoElementList = value :?> JArray |> normalizeJArray
        (twoElementList.Item 0, twoElementList.Item 1) |> string

    override __.RenderInput (_, _, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatAsTuple
        |> formatList

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Etl() =
    inherit GeneratorExercise()

    member __.formatMap<'TKey, 'TValue> (value: obj) =
        let input = value :?> JObject
        let dict = input.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>();
        let formattedList =
            dict
            |> Seq.map (fun kv -> formatTuple (kv.Key, kv.Value))
            |> formatMultiLineList

        if (formattedList.Contains("\n")) then
            sprintf "%s\n%s" formattedList (indent 2 "|> Map.ofList")
        else   
            sprintf "%s |> Map.ofList" formattedList

    override this.RenderInput (_, _, value) = this.formatMap<int, List<char>> value

    override this.RenderExpected (_, _, value) = this.formatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type FoodChain() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type Forth() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]
    
    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofObj 
        |> formatValue

    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray|> Option.ofObj |> Option.map Seq.isEmpty with 
        | Some true -> Some "int list option"
        | _ -> None

    override __.UseFullMethodName _ = true

type Gigasecond() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = value :?> DateTime |> formatDateTime |> parenthesize
 
    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "input" -> DateTime.Parse(string value, CultureInfo.InvariantCulture) |> formatDateTime |> parenthesize
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type Grains() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.IdentifierTypeAnnotation (_, _, _) = Some "Result<uint64,string>"

    override __.RenderExpected (_, _, value) = 
        match string value with
        | "-1" -> "Error \"Invalid input\""
        | x    -> sprintf "Ok %sUL" x

type Hamming() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonError 
        |> formatValue
        |> parenthesizeOption

type HelloWorld() =
    inherit GeneratorExercise()

type House() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type IsbnVerifier() =
    inherit GeneratorExercise()

type Isogram() =
    inherit GeneratorExercise()

type KindergartenGarden() =
    inherit GeneratorExercise()

    let toPlant (jToken: JToken) =  sprintf "Plant.%s" (jToken.ToString() |> String.humanize)

    override __.RenderExpected (_, _, value) = 
        value :?> JArray 
        |> Seq.map toPlant
        |> formatList

    override __.PropertiesWithIdentifier _ = ["student"; "diagram"; "expected"]

    override __.UseFullMethodName _ = true

type LargestSeriesProduct() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonNegativeInt 
        |> formatValue 
        |> parenthesizeOption

type Leap() =
    inherit GeneratorExercise()

type Luhn() =
    inherit GeneratorExercise()

type Markdown() =
    inherit GeneratorExercise()

    override __.ToTestMethod (index, canonicalDataCase) =
        { base.ToTestMethod (index, canonicalDataCase) with Skip = false }

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase
    
type Meetup() =
    inherit GeneratorExercise()

    override __.RenderExpected (canonicalDataCase, _, _) =
        let year  = canonicalDataCase.Properties.["year"] :?> int64 |> int
        let month = canonicalDataCase.Properties.["month"] :?> int64 |> int
        let day   = canonicalDataCase.Properties.["dayofmonth"] :?> int64 |> int
        DateTime(year, month, day) |> formatDateTime |> parenthesize

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "dayofweek" -> 
            sprintf "DayOfWeek.%s" (string canonicalDataCase.Properties.["dayofweek"])
        | "week" -> 
            sprintf "Schedule.%s" (string canonicalDataCase.Properties.["week"] |> String.upperCaseFirst)
        | _ -> 
            base.RenderInput (canonicalDataCase, key, value)

    override __.MapCanonicalDataCaseProperties (_, properties) =
        properties |> Map.add "expected" null // Ensure that the "expected" key exists

    override __.PropertiesUsedAsSutParameter _ = 
        ["year"; "month"; "dayofweek"; "week"]

    override this.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type Minesweeper() =
    inherit GeneratorExercise()

    override __.RenderValueWithoutIdentifier (_, _, value) =        
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None

type NthPrime() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonError
        |> formatValue 
        |> parenthesizeOption

type NucleotideCount() =
    inherit GeneratorExercise()

    member __.formatMap<'TKey, 'TValue> (value: obj) =
        match Option.ofNonError value with
        | None -> 
            "None"
        | _ ->
            let input = value :?> JObject
            let dict = input.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>();
            let formattedList =
                dict
                |> Seq.map (fun kv -> formatTuple (kv.Key, kv.Value))
                |> formatMultiLineList

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s\n%s" formattedList (indent 2 "|> Map.ofList") (indent 2 "|> Some")
            else   
                sprintf "%s |> Map.ofList |> Some" formattedList

    override this.RenderExpected (_, _, value) = this.formatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type OcrNumbers() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonNegativeInt 
        |> formatValue 
        |> parenthesizeOption

    override __.RenderInput (_, _, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type Pangram() =
    inherit GeneratorExercise()

type PalindromeProducts() =
    inherit GeneratorExercise()

    let toFactors (value: obj) = 
        let jArray = value :?> JArray
        let factors = jArray.ToObject<int list>()
        sprintf "(%A, %A)" factors.[0] factors.[1]

    let toPalindromeProducts (value: obj) =
        let jObject = value :?> JObject
        let palindromeValue = jObject.Value<int>("value")
        let factors = 
            jObject.Value<JArray>("factors") 
            |> normalizeJArray
            |> Seq.map toFactors
            |> formatList

        sprintf "(%d, %s)" palindromeValue factors

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonError
        |> Option.map toPalindromeProducts 
        |> formatOption 
        |> parenthesizeOption

    override __.PropertiesUsedAsSutParameter _ = ["input_min"; "input_max"]

type PascalsTriangle() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) = 
        match value with
        | :? JArray  ->
            let formattedList = 
                value :?> JArray
                |> normalizeJArray
                |> Seq.map formatValue
                |> formatMultiLineList

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s" formattedList (indent 2 "|> Some")
            else   
                sprintf "%s |> Some" formattedList
        | _ -> "None"

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key, value with 
        | "expected", :? JArray ->
            match value :?> JArray |> Seq.isEmpty with 
            | true  -> Some "int list list option"
            | false -> None    
        | _ -> base.IdentifierTypeAnnotation (canonicalDataCase, key, value)       

    override __.ToTestMethodBodyAssertTemplate _ = "AssertEqual"
    
type PerfectNumbers() =
    inherit GeneratorExercise()

    let toClassification value = string value |> String.humanize

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonError  
        |> Option.map toClassification 
        |> formatOption 
        |> parenthesizeOption

type PhoneNumber() =
    inherit GeneratorExercise()
    
    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofObj 
        |> formatValue
        |> parenthesizeOption

type PigLatin() =
    inherit GeneratorExercise()

type Poker() = 
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["input"; "expected"]

type PrimeFactors() =
    inherit GeneratorExercise()
    
    override __.RenderInput (canonicalDataCase, key, value) =
        base.RenderInput (canonicalDataCase, key, value) |> sprintf "%sL"

type Proverb() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["input"; "expected"]

    override __.RenderExpected (_, _, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList
    
    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None
    
type QueenAttack() =
    inherit GeneratorExercise()

    override __.MapCanonicalDataCaseProperty (canonicalDataCase, key, value) =
        match canonicalDataCase.Property, key, value with
        | "create", "expected", _ -> value :?> int64 <> -1L |> box
        | _ -> base.MapCanonicalDataCaseProperty (canonicalDataCase, key, value)

    override __.RenderInput (canonicalDataCase, key, value) =
        let parsePositionTuple (tupleValue: obj) =
            let position = (tupleValue :?> JToken).SelectToken("position")
            formatValue (position.["row"].ToObject<int>(), position.["column"].ToObject<int>())

        match key with
        | "queen" | "white_queen" | "black_queen" -> parsePositionTuple value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.PropertiesWithIdentifier _ = ["white_queen"; "black_queen"]

type RailFenceCipher() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["rails"; "msg"]

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Raindrops() =
    inherit GeneratorExercise()

type Rectangles() = 
    inherit GeneratorExercise()

    member private __.GetPadding n = 
        String.replicate n " "

    member private this.FormatList (list: List<string>) = 
        let separator = "; \n" + (this.GetPadding 8)
        let value = 
            list 
            |> String.concat separator

        if list.Length < 2 then 
            sprintf "[%s]" value
        else
            sprintf "\n%s[ %s ]" (this.GetPadding 6) value

    override __.PropertiesWithIdentifier _ = ["input"]
    override __.RenderSutProperty _ = "rectangles"

    override this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) = 
        match key with
        | "input" ->
            (value :?> JToken).ToObject<List<string>>() 
            |> List.map formatString 
            |> this.FormatList
        | _ -> 
            base.RenderValueWithoutIdentifier (canonicalDataCase, key, value)

type ReverseString() =
    inherit GeneratorExercise()

type RobotSimulator() =
    inherit GeneratorExercise()

    let resultIdentifierName = "actual"

    override __.PropertiesWithIdentifier _ = ["robot"; "property"; "expected"]

    member private __.RenderDirection (value: JToken) = 
        sprintf "%s" (value.ToObject<string>() |> String.upperCaseFirst)  

    member private __.RenderCoords (coords: JToken) = 
        (coords.["x"].ToObject<int>(), coords.["y"].ToObject<int>()) 
        |> formatValue

    member private this.DefineRobot (direction: JToken) (coords: JToken) = 
        sprintf "createRobot %s %s" (this.RenderDirection direction) (this.RenderCoords coords)

    member private __.GetRobotProperties (value : JToken) = 
        value.SelectToken("direction"), value.SelectToken("position")

    override __.RenderArrange canonicalDataCase =
        // one identifier may be empty if we only checking created object
        // we need to filter out this empty line
        base.RenderArrange canonicalDataCase
        |> List.choose (
            function
            | "" -> None
            | v -> Some v
        )

    override this.RenderValueWithoutIdentifier (_, key, value) = 
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

    override __.RenderValueWithIdentifier (canonicalDataCase, key, value) = 
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
    
    override __.RenderTestMethodName canonicalDataCase =
         // avoid duplicated method names
         // for this generator it is preferable
         // because useFullMethodName leads to very long names
         sprintf "%s - %s" canonicalDataCase.Property (canonicalDataCase.Description |> String.upperCaseFirst)

type RotationalCipher() =
    inherit GeneratorExercise()

type RnaTranscription() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value |> Option.ofObj |> formatValue |> parenthesizeOption

type RunLengthEncoding() =
    inherit GeneratorExercise()

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
    inherit GeneratorExercise()

type ScrabbleScore() =
    inherit GeneratorExercise()

type SpiralMatrix() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type TwelveDays() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type TwoFer() =
    inherit GeneratorExercise()

    override __.RenderInput (_, _, value) =
        value |> Option.ofObj |> formatValue |> parenthesizeOption