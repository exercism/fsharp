module Generators.Generators

open System
open System.Globalization
open Newtonsoft.Json.Linq
open Output
open Exercise

type Acronym() =
    inherit Exercise()

type AtbashCipher() =
    inherit Exercise()

type AllYourBase() =    
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = value |> Option.ofNonError |> formatValue

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

type Alphametics() =
    inherit Exercise()

    member this.formatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderExpected (canonicalDataCase, key, value) = this.formatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Anagram() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["candidates"]

type BeerSong() =
    inherit Exercise()

    override this.PropertiesUsedAsSutParameter canonicalDataCase = ["startBottles"; "takeDown"]

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

    override this.RenderExpected (canonicalDataCase, key, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type BinarySearch() = 
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["array"; "value"; "expected"]

    override this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) =
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

type Connect() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) =
        match string value with
        | "O" -> "(Some White)"
        | "X" -> "(Some Black)"
        | _   -> "None"

    override this.RenderInput (canonicalDataCase, key, value) =
        let lines = (value :?> JArray).ToObject<string seq>() |> List.ofSeq
        let padSize = List.last lines |> String.length

        lines        
        |> List.map (fun line -> line.PadRight(padSize) |> formatValue)
        |> formatMultiLineList

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

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

type Etl() =
    inherit Exercise()

    member this.formatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderInput (canonicalDataCase, key, value) = this.formatMap<int, List<char>> value

    override this.RenderExpected (canonicalDataCase, key, value) = this.formatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type FoodChain() =
    inherit Exercise()

    override this.PropertiesUsedAsSutParameter canonicalDataCase = ["startVerse"; "endVerse"]

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

    override this.RenderExpected (canonicalDataCase, key, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

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

type Hamming() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) = 
        value 
        |> Option.ofNonError 
        |> formatValue
        |> parenthesizeOption

type HelloWorld() =
    inherit Exercise()

type House() =
    inherit Exercise()

    override this.PropertiesUsedAsSutParameter canonicalDataCase = ["startVerse"; "endVerse"]

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

    override this.RenderExpected (canonicalDataCase, key, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

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
    
type Meetup() =
    inherit Exercise()

    override this.RenderExpected (canonicalDataCase, key, value) =
        let year  = canonicalDataCase.Properties.["year"] :?> int64 |> int
        let month = canonicalDataCase.Properties.["month"] :?> int64 |> int
        let day   = canonicalDataCase.Properties.["dayofmonth"] :?> int64 |> int
        DateTime(year, month, day) |> formatDateTime |> parenthesize

    override this.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "dayofweek" -> 
            sprintf "DayOfWeek.%s" (string canonicalDataCase.Properties.["dayofweek"])
        | "week" -> 
            sprintf "Schedule.%s" (string canonicalDataCase.Properties.["week"] |> String.upperCaseFirst)
        | _ -> 
            base.RenderInput (canonicalDataCase, key, value)

    override this.MapCanonicalDataCaseProperties (canonicalDataCase, properties) =
        properties |> Map.add "expected" null // Ensure that the "expected" key exists

    override this.PropertiesUsedAsSutParameter canonicalDataCase = 
        ["year"; "month"; "dayofweek"; "week"]

    override this.AdditionalNamespaces = [typeof<DateTime>.Namespace]

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
        |> Option.ofNonError
        |> formatValue 
        |> parenthesizeOption

type NucleotideCount() =
    inherit Exercise()

    member this.formatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderExpected (canonicalDataCase, key, value) = this.formatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type OcrNumbers() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override this.RenderExpected (canonicalDataCase, key, value) = 
        value 
        |> Option.ofNonNegativeInt 
        |> formatValue 
        |> parenthesizeOption

    override this.RenderInput (canonicalDataCase, key, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

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

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

    override this.RenderExpected (canonicalDataCase, key, value) = 
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

    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key, value with 
        | "expected", :? JArray ->
            match value :?> JArray |> Seq.isEmpty with 
            | true  -> Some "int list list option"
            | false -> None    
        | _ -> base.IdentifierTypeAnnotation (canonicalDataCase, key, value)       

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

type Poker() = 
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["input"; "expected"]

type PrimeFactors() =
    inherit Exercise()
    
    override this.RenderInput (canonicalDataCase, key, value) =
        base.RenderInput (canonicalDataCase, key, value) |> sprintf "%sL"

type Proverb() =
    inherit Exercise()

    override this.PropertiesWithIdentifier canonicalDataCase = ["input"; "expected"]

    override this.RenderExpected (canonicalDataCase, key, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList
    
    override this.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None
    
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

type Rectangles() = 
    inherit Exercise()

    member private this.GetPadding n = 
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

    override this.PropertiesWithIdentifier canonicalDataCase = ["input"]
    override this.RenderSutProperty canonicalDataCase = "rectangles"

    override this.RenderValueWithoutIdentifier (canonicalDataCase, key, value) = 
        match key with
        | "input" ->
            (value :?> JToken).ToObject<List<string>>() 
            |> List.map formatString 
            |> this.FormatList
        | _ -> 
            base.RenderValueWithoutIdentifier (canonicalDataCase, key, value)

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

type TwelveDays() =
    inherit Exercise()

    override this.PropertiesUsedAsSutParameter canonicalDataCase = ["startVerse"; "endVerse"]

    override this.PropertiesWithIdentifier canonicalDataCase = ["expected"]

    override this.RenderExpected (canonicalDataCase, key, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type TwoFer() =
    inherit Exercise()

    override this.RenderInput (canonicalDataCase, key, value) =
        value |> Option.ofObj |> formatValue |> parenthesizeOption