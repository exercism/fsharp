module Generators.Generators

open System
open System.Globalization
open Newtonsoft.Json.Linq
open CanonicalData
open Formatting
open Rendering
open Exercise

type Acronym() =
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

    let toAllergen (jToken: JToken) =  sprintf "Allergen.%s" (jToken.ToString() |> String.dehumanize)

    let renderAllergicToAssert canonicalDataCase (jToken: JToken) =
        let substance = jToken.["substance"] |> toAllergen
        let score = canonicalDataCase.Input.["score"] :?> int64
        let sut = sprintf "allergicTo %d %s" score substance
        let expected = jToken.Value<bool>("result") |> formatBool
        
        { Sut = sut; Expected = expected }
        |> renderPartialTemplate "AssertEqual"

    override __.RenderAssert canonicalDataCase =
        match canonicalDataCase.Property with
        | "allergicTo" ->
            canonicalDataCase.Expected :?> JArray
            |> Seq.map (renderAllergicToAssert canonicalDataCase)
            |> Seq.toList
        | _ -> 
            base.RenderAssert canonicalDataCase

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

    member __.FormatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderExpected (_, _, value) = this.FormatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Anagram() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["candidates"]

type ArmstrongNumbers() =
    inherit GeneratorExercise()

type AtbashCipher() =
    inherit GeneratorExercise()

type BeerSong() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        value :?> JArray
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

type BinarySearchTree() =
    inherit GeneratorExercise()

    let rec renderAssertions previousPaths (tree: JObject) =
        let previousPath = previousPaths |> List.rev |> String.concat " |> "
        let rootPath = List.length previousPaths = 1

        let renderDataAssertions =
            let dataPath = if rootPath then "data" else "Option.map data"
            let data = tree.["data"]

            match data.Type with
            | JTokenType.Null -> 
                let expected = if rootPath then failwith "Invalid data" else "None"
                [ sprintf "%s |> %s |> should equal %s" previousPath dataPath expected ]
            | _ -> 
                let data = (data :?> JValue).ToObject<int>()
                let expected = if rootPath then string data else sprintf "(Some %d)" data
                [ sprintf "%s |> %s |> should equal %s" previousPath dataPath expected ]

        let renderNodeAssertions nodeName (node: JToken) = 
            let nodePath = if rootPath then nodeName else sprintf "Option.bind %s" nodeName

            match node.Type with
            | JTokenType.Null -> 
                [ sprintf "%s |> %s |> should equal None" previousPath nodePath ]
            | _ ->
                renderAssertions (nodePath :: previousPaths) (node :?> JObject)            

        [ renderDataAssertions
          renderNodeAssertions "left" tree.["left"] 
          renderNodeAssertions "right" tree.["right"] ]
        |> List.concat

    override __.RenderAssert canonicalDataCase = 
        match canonicalDataCase.Property with
        | "data" ->
            canonicalDataCase.Expected :?> JObject
            |> renderAssertions ["treeData"]
        | _ -> base.RenderAssert canonicalDataCase

    override __.RenderInput (_, _, value) = 
        value :?> JArray
        |> Seq.map string
        |> formatList
        |> sprintf "create %s"

    override __.RenderExpected (canonicalDataCase, key, value) = 
        match value with
        | :? JArray as jArray -> jArray |> Seq.map string |> formatList
        | _ -> base.RenderExpected (canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Bob() =
    inherit GeneratorExercise()

type BookStore() =
    inherit GeneratorExercise()

    let formatFloat (value:obj) = value :?> int64 |> (fun x -> float x / 100.0) |> sprintf "%.2f"

    override __.RenderExpected (_, _, value) = formatFloat value

    override __.PropertiesUsedAsSutParameter canonicalDataCase =
        base.PropertiesUsedAsSutParameter canonicalDataCase |> List.except ["targetgrouping"]

type Bowling() = 
    inherit GeneratorExercise()

    override __.RenderSut _ ="score game"

    override __.RenderSetup _ = 
        "let rollMany rolls game = List.fold (fun game pins -> roll pins game) game rolls"

    override __.RenderArrange canonicalDataCase =
        seq {
            let arr = (canonicalDataCase.Input.["previousRolls"] :?> JToken).ToObject<string[]>()
            yield sprintf "let rolls = %s" (formatList arr)
            if canonicalDataCase.Input.ContainsKey "roll" then
                let roll = canonicalDataCase.Input.["roll"] :?> int64
                yield sprintf "let startingRolls = rollMany rolls (newGame())" 
                yield sprintf "let game = roll %i startingRolls" roll
            else
                yield sprintf "let game = rollMany rolls (newGame())" 
        }
        |> Seq.toList

    override __.RenderExpected (_, _, value) = 
        if value :? JObject then "None" else sprintf "<| Some %s" (formatValue value)
    
type BracketPush() =
    inherit GeneratorExercise()

type Change() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        let convertToOption = if value :? JArray then Option.ofObj else Option.ofPositiveInt
        value |> convertToOption |> formatValue

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, _) =
        match key with
        | "expected" ->
            match canonicalDataCase.Input.["target"] :?> int64 with
            | 0L -> Some "int list option"
            | _  -> None
        | _ -> None

type CircularBuffer() = 
    inherit GeneratorExercise()

    override __.AdditionalNamespaces = [ "System" ]

    override __.RenderAssert _ = []

    member __.ExceptionCheck command = 
        sprintf "(fun () -> %s |> ignore) |> should throw typeof<Exception>" command 

    override this.RenderArrange canonicalDataCase = 
        seq {
            yield sprintf "let buffer1 = mkCircularBuffer %i" (canonicalDataCase.Properties.["capacity"] :?> int64)
            let operations = (canonicalDataCase.Properties.["operations"] :?> JArray)
            let mutable ind = 2
            let lastInd = operations.Count + 1 
            for op in operations do
                let dict = (op :?> JObject).ToObject<Collections.Generic.Dictionary<string, JToken>>();
                let funcName = dict.["operation"].ToObject<string>()
                match funcName with
                | "write" as operation -> 
                    let item = dict.["item"].ToObject<int>()
                    let command = sprintf "%s %i buffer%i" operation item (ind - 1)
                    match dict.ContainsKey "should_succeed", (dict.["should_succeed"].ToObject<bool>()) with
                    | true, false ->
                        yield this.ExceptionCheck command
                    | _, _ ->
                        yield sprintf "let buffer%i = %s" ind command
                | "read" as operation -> 
                    let command = sprintf "%s buffer%i" operation (ind - 1)
                    match dict.ContainsKey "should_succeed", dict.["should_succeed"].ToObject<bool>() with
                    | true, false ->
                        yield this.ExceptionCheck command
                    | _, _ -> 
                        let expected = dict.["expected"].ToObject<int64>()
                        if ind = lastInd then
                            yield sprintf "let (val%i, _) = %s" ind command
                        else
                            yield sprintf "let (val%i, buffer%i) = %s" ind ind command
                        yield sprintf "val%i |> should equal %i" ind expected
                | "overwrite" ->
                    yield sprintf "let buffer%i = forceWrite %i buffer%i" ind (dict.["item"].ToObject<int>()) (ind-1)
                | "clear" -> 
                    yield sprintf "let buffer%i = clear buffer%i" ind (ind - 1) 
                | _ -> ()
                ind <- ind + 1

        }
        |> Seq.toList

type Clock() =
    inherit GeneratorExercise()

    let createClock (value:obj) clockId =
        let clock = value :?> JObject
        let hour = clock.["hour"].ToObject<string>()
        let minute = clock.["minute"].ToObject<string>()
        sprintf "let %s = create %s %s" clockId hour minute

    member private this.RenderPropertyValue canonicalDataCase property =
        this.RenderSutParameter (canonicalDataCase, property, Map.find property canonicalDataCase.Input)

    override __.PropertiesWithIdentifier _ = ["clock1"; "clock2"]

    override __.RenderValueWithIdentifier (canonicalDataCase, key, value) =
        match key with
        | "clock1" | "clock2" -> createClock value key
        | _ -> base.RenderValueWithIdentifier (canonicalDataCase, key, value)
    
    override this.RenderArrange canonicalDataCase =
        match canonicalDataCase.Property with
        | "create" | "add" | "subtract" -> 
            let hour = this.RenderPropertyValue canonicalDataCase "hour"
            let minute = this.RenderPropertyValue canonicalDataCase "minute"
            [sprintf "let clock = create %s %s" hour minute]
        | _ -> 
            base.RenderArrange canonicalDataCase

    override this.RenderSut canonicalDataCase =
        match canonicalDataCase.Property with
        | "create" -> 
            sprintf "display clock"
        | "add" -> 
            this.RenderPropertyValue canonicalDataCase "value"
            |> sprintf "add %s clock |> display" 
        | "subtract" -> 
            this.RenderPropertyValue canonicalDataCase "value"
            |> sprintf "subtract %s clock |> display" 
        | "equal" -> 
            "clock1 = clock2" 
        | _ -> 
            base.RenderSut canonicalDataCase

type ComplexNumbers() =
    inherit GeneratorExercise()

    let renderNumber (input: JToken) =
        match string input with
        | "e"     -> "Math.E"
        | "pi"    -> "Math.PI"
        | "ln(2)" -> "(Math.Log(2.0))"
        | i when i.IndexOf('.') = -1  -> sprintf "%s.0" i
        | float   -> float
    
    let renderComplexNumber (input: JArray) =
        sprintf "(create %s %s)" (renderNumber input.[0]) (renderNumber input.[1])

    override __.RenderValue (canonicalDataCase, key, value) = 
        match value with
        | :? JArray as jArray -> renderComplexNumber jArray
        | :? int64 as i -> sprintf "%d.0" i
        | _ -> base.RenderValue (canonicalDataCase, key, value)

    override __.RenderAssert canonicalDataCase = 
        match canonicalDataCase.Expected with
        | :? JArray as jArray ->
            let renderAssertion testedFunction expected =
                { Sut = sprintf "%s sut" testedFunction; Expected = expected }
                |> renderPartialTemplate "AssertEqualWithin"

            [ jArray.[0] |> renderNumber |> renderAssertion "real"
              jArray.[1] |> renderNumber |> renderAssertion "imaginary" ]
        | _ ->
            base.RenderAssert(canonicalDataCase)

    override __.PropertiesWithIdentifier canonicalDataCase = 
        match canonicalDataCase.Expected with
        | :? JArray -> ["sut"]
        | _ -> base.PropertiesWithIdentifier canonicalDataCase

    override __.AdditionalNamespaces = [typeof<Math>.Namespace]

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

type CustomSet() = 
    inherit GeneratorExercise()

    member __.SutName = "actual"

    override __.TestMethodBodyAssertTemplate _ = "AssertEqual"

    member __.RenderSet (jToken: obj) =
        (jToken :?> JToken).ToObject<seq<string>>()
        |> formatList
        |> sprintf "CustomSet.fromList %s"

    override this.RenderSut canonicalDataCase =
        match canonicalDataCase.Property with
        | "add" | "intersection" | "difference" | "union" -> 
            sprintf "%sBool" this.SutName
        | _ -> this.SutName

    override __.RenderExpected (canonicalDataCase, _, _) =
        match canonicalDataCase.Property with
        | "add" | "intersection" | "difference" | "union" -> 
            "true"
        | _ -> formatValue canonicalDataCase.Expected

    override this.RenderArrange canonicalDataCase = 
        let arrangeLines =
            match canonicalDataCase.Property with
            | "empty" ->
                let setValue = this.RenderSet canonicalDataCase.Input.["set"]
                [ sprintf "let %s = CustomSet.isEmpty (%s)" this.SutName setValue ]
            | "add" | "contains" ->
                let methodName = 
                    match canonicalDataCase.Property with
                    | "add" -> "insert"
                    | s -> s
                let setVar = sprintf "let setValue = %s" (this.RenderSet canonicalDataCase.Input.["set"])
                let valueVar = sprintf "let element = %s" (formatValue canonicalDataCase.Input.["element"])
                let resultVar = sprintf "let %s = CustomSet.%s element setValue" this.SutName methodName 
                [ setVar; valueVar; resultVar ]
            | "intersection" | "difference" | "union" | "disjoint" | "subset" | "equal" ->
                let methodName = 
                    match canonicalDataCase.Property with
                    | "disjoint" -> "isDisjointFrom"
                    | "subset" -> "isSubsetOf"
                    | "equal" -> "isEqualTo"
                    | s -> s
                let firstSetVar = sprintf "let set1 = %s" (this.RenderSet canonicalDataCase.Input.["set1"])
                let secondSetVar = sprintf "let set2 = %s" (this.RenderSet canonicalDataCase.Input.["set2"])
                let resultVar = sprintf "let %s = CustomSet.%s set1 set2" this.SutName methodName
                [ firstSetVar; secondSetVar; resultVar ]
            | _ -> 
                [ "" ]

        match canonicalDataCase.Property with
        | "add" | "intersection" | "difference" | "union" -> 
            let expectedSetVar = sprintf "let expectedSet = %s" (this.RenderSet canonicalDataCase.Expected)
            let actualBoolVar = sprintf "let %sBool = CustomSet.isEqualTo %s expectedSet" this.SutName this.SutName
            arrangeLines @ [ expectedSetVar; actualBoolVar ]
        | _ -> arrangeLines

type Diamond() =
    inherit CustomExercise()

type DifferenceOfSquares() =
    inherit GeneratorExercise()

type Dominoes() =
    inherit GeneratorExercise()
    
    let formatAsTuple (value:obj) =
        let items = value :?> obj list
        formatTuple (List.item 0 items, List.item 1 items)

    override __.RenderInput (_, _, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatAsTuple
        |> formatList

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Etl() =
    inherit GeneratorExercise()

    member __.FormatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderInput (_, _, value) = this.FormatMap<int, List<char>> value

    override this.RenderExpected (_, _, value) = this.FormatMap<char, int> value

    override __.MapCanonicalDataCaseInput (canonicalDataCase, _) = 
        Map.empty |> Map.add "lettersByScore" (canonicalDataCase.Properties.["input"])

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type FoodChain() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        value :?> JArray
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
 
    override __.RenderInput (_, _, value) =
         DateTime.Parse(string value, CultureInfo.InvariantCulture) |> formatDateTime |> parenthesize

    override __.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type Grains() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.IdentifierTypeAnnotation (_, _, _) = Some "Result<uint64,string>"

    override __.RenderExpected (_, _, value) = 
        match string value with
        | "-1" -> "Error \"Invalid input\""
        | x    -> sprintf "Ok %sUL" x

type Grep() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderExpected (_, _, value) =
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineListWithIndentation 3

    override __.RenderSetup _ = renderPartialTemplate "Generators/GrepSetup" Map.empty<string, obj>

    override __.RenderArrange canonicalDataCase =
        base.RenderArrange canonicalDataCase @ [""; "createFiles() |> ignore"]

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key with
        | "expected" ->
            match value :?> JArray |> Seq.isEmpty with 
            | true  -> Some "string list"
            | false -> None
        | _ ->
            base.IdentifierTypeAnnotation(canonicalDataCase, key, value)        

    override __.AdditionalNamespaces = [typeof<System.IO.File>.Namespace]

    override __.TestFileFormat = TestFileFormat.Class

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
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList

type IsbnVerifier() =
    inherit GeneratorExercise()

type Isogram() =
    inherit GeneratorExercise()

type KindergartenGarden() =
    inherit GeneratorExercise()

    let toPlant (jToken: JToken) =  sprintf "Plant.%s" (jToken.ToString() |> String.dehumanize)

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
        |> Option.ofPositiveInt 
        |> formatValue 
        |> parenthesizeOption

type Leap() =
    inherit GeneratorExercise()

type ListOps() =
    inherit GeneratorExercise()

    let renderFunction (value: obj) =
        value
        |> string
        |> String.replace "(" ""
        |> String.replace ")" ""
        |> String.replace "," ""
        |> String.replace "==" "="
        |> String.replace "modulo" "%"
        |> sprintf "(fun %s)"

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "function" -> renderFunction value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.RenderTestMethodName canonicalDataCase =
        sprintf "%s %s" canonicalDataCase.Property canonicalDataCase.Description

type Luhn() =
    inherit GeneratorExercise()

type Markdown() =
    inherit GeneratorExercise()

    override __.ToTestMethod (index, canonicalDataCase) =
        { base.ToTestMethod (index, canonicalDataCase) with Skip = false }

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Matrix() =
    inherit GeneratorExercise()
    
type Meetup() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        DateTime.Parse(string value) 
        |> formatDateTime 
        |> parenthesize

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "dayofweek" -> 
            sprintf "DayOfWeek.%s" (string canonicalDataCase.Input.["dayofweek"])
        | "week" -> 
            sprintf "Week.%s" (string canonicalDataCase.Input.["week"] |> String.upperCaseFirst)
        | _ -> 
            base.RenderInput (canonicalDataCase, key, value)

    override __.PropertiesUsedAsSutParameter _ = ["year"; "month"; "week"; "dayofweek"]

    override __.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type Minesweeper() =
    inherit GeneratorExercise()

    let renderValue (value: obj) = 
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList

    override __.RenderInput (_, _, value) = renderValue value

    override __.RenderExpected (_, _, value) = renderValue value

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

    member __.FormatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderExpected (_, _, value) = this.FormatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type OcrNumbers() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofPositiveInt 
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
        let jArray = value :?> obj list
        let factors = jArray |> List.map (string >> int)
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

    override __.PropertiesUsedAsSutParameter _ = ["min"; "max"]

type PascalsTriangle() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) = 
        match value with
        | :? JArray  ->
            let formattedList = 
                value :?> JArray
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

    override __.TestMethodBodyAssertTemplate _ = "AssertEqual"
    
type PerfectNumbers() =
    inherit GeneratorExercise()

    let toClassification value = string value |> String.dehumanize

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

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Pov() = 
    inherit GeneratorExercise()

    let isNull x = match x with null -> true | _ -> false

    override __.RenderSetup _ = 
        ["let rec graphToList graph = "
         "    let right ="
         "        graph.children"
         "        |> List.sortBy (fun x -> x.value)"
         "        |> List.collect graphToList"
         "    [graph.value] @ right"
         "let mapToList graph = match graph with | Some x -> graphToList x | None -> []"
        ] |> String.concat "\n"

    member this.RenderNode (tree: obj) : string = 
        match isNull tree with
        | true -> ""
        | false ->
            let node = (tree :?> JObject).ToObject<Collections.Generic.Dictionary<string, JToken>>();
            let children = 
                if node.ContainsKey "children" then 
                    node.["children"]
                    |> Seq.map this.RenderNode
                    |> formatList
                else
                    "[]"
            let label =
                node.["label"]
                |> formatValue
            sprintf "mkGraph %s %s" label children

    override this.RenderArrange canonicalDataCase =
        seq {
            yield 
                canonicalDataCase.Properties.["tree"]
                |> this.RenderNode 
                |> sprintf "let tree = %s" 

            match canonicalDataCase.Property, isNull canonicalDataCase.Expected with
            | "fromPov", false ->
                yield 
                    canonicalDataCase.Expected
                    |> this.RenderNode 
                    |> sprintf "let expected = %s" 
            | _, _ -> ()
        }
        |> Seq.toList

    override __.RenderSut canonicalDataCase = 
        match canonicalDataCase.Property with
        | "fromPov" -> 
            let from = 
                canonicalDataCase.Properties.["from"]
                |> formatValue
            match isNull canonicalDataCase.Expected with
            | false -> sprintf "fromPOV %s tree |> mapToList " from
            | true -> sprintf "fromPOV %s tree " from
        | "pathTo" -> 
            let fromValue = 
                canonicalDataCase.Properties.["from"] 
                |> formatValue
            let toValue = 
                canonicalDataCase.Properties.["to"] 
                |> formatValue
            sprintf "tracePathBetween %s %s tree" fromValue toValue
        | _ -> ""
 
    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "fromPov" -> 
            match isNull value with 
            | true -> "None"
            | false -> sprintf "<| graphToList %s" key
        | "pathTo" -> 
            match isNull value with
            | true -> "None" 
            | false ->
                printf "%s" canonicalDataCase.Description
                canonicalDataCase.Expected :?> JArray
                |> Seq.map formatValue
                |> formatList
                |> sprintf "<| Some %s" 
        | _ -> ""

type PrimeFactors() =
    inherit GeneratorExercise()
    
    override __.RenderInput (canonicalDataCase, key, value) =
        base.RenderInput (canonicalDataCase, key, value) |> sprintf "%sL"

type ProteinTranslation() =
    inherit GeneratorExercise()

type Proverb() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderExpected (_, _, value) =
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList
    
    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None
    
type QueenAttack() =
    inherit GeneratorExercise()

    override __.MapCanonicalDataCaseExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "create" -> value :?> int64 <> -1L |> box
        | _ -> base.MapCanonicalDataCaseInputProperty (canonicalDataCase, key, value)

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

type RationalNumbers() =
    inherit GeneratorExercise()

    override __.RenderValue (canonicalDataCase, key, value) =
        match value with
        | :? JArray as jArray -> sprintf "(create %d %d)" (jArray.[0].Value<int>()) (jArray.[1].Value<int>())
        | _ -> base.RenderValue (canonicalDataCase, key, value)

    override __.TestMethodBodyAssertTemplate canonicalDataCase =
        match canonicalDataCase.Expected with
        | :? double -> "AssertEqualWithin"
        | _ -> base.TestMethodBodyAssertTemplate(canonicalDataCase)

type React() = 
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = []

    member private __.RenderCells canonicalDataCase = 
        let reactorVar = sprintf "let %s = new %s()" "reactor" "Reactor"
        let cellVars = 
            canonicalDataCase.Input.["cells"] :?> JArray
            |> Seq.map (fun (cellValue: JToken) -> 
                let cell = cellValue :?> JObject
                let cellName = cell.["name"].ToObject<string>()
                match cell.["type"].ToObject<string>() with
                | "compute" ->
                    let funBody = 
                        cell.["compute_function"].ToObject<string>().Replace ("inputs", "values.")
                    let inputParams = 
                        (cell.["inputs"].ToObject<seq<string>>() |> formatList)
                    
                    sprintf "let %s = reactor.createComputeCell %s (fun values -> %s)" cellName inputParams funBody
                | "input" -> 
                    let initialValue = cell.["initial_value"].ToObject<int64>()
                    sprintf "let %s = reactor.createInputCell %s" cellName (formatValue initialValue)
                | _ -> ""
            )
            |> Seq.toList
        [ reactorVar ] @ cellVars
     
    member private __.RenderOperations canonicalDataCase = 
        canonicalDataCase.Input.["operations"] :?> JArray
        // we can generate more than 1 line per operation
        // so we need to flatten results here
        // collect does it automatically for us 
        // and every operation should emit seq<string>
        |> Seq.collect (fun (opToken: JToken) -> 
            let op = opToken :?> JObject
            match op.["type"].ToObject<string>() with
            | "expect_cell_value" -> seq { 
                let cellName = op.["cell"].ToObject<string>()
                let expectedValue = op.["value"].ToObject<int>()
                yield sprintf "%s.Value |> should equal %i" cellName expectedValue }
            | "set_value" -> seq { 
                let cellName = op.["cell"].ToObject<string>()
                let cellValue = op.["value"].ToObject<int>()
                yield sprintf "%s.Value <- %i" cellName cellValue }
            | "add_callback" -> seq { 
                let callbackName = op.["name"].ToObject<string>()
                let cellName = op.["cell"].ToObject<string>() 
                yield sprintf "let mutable %s = []" callbackName 
                yield sprintf "let %sHandler = Handler<int>(fun _ value -> %s <- %s @ [value])" callbackName callbackName callbackName
                yield sprintf "%s.Changed.AddHandler %sHandler" cellName callbackName }
            | "expect_callback_values" -> seq {
                let callbackName = op.["callback"].ToObject<string>()
                let callbackValues = op.["values"].ToObject<string[]>()
                if callbackValues.Length = 0 then
                    yield sprintf "%s |> should equal List.empty<int>" callbackName
                else
                    yield sprintf "%s |> should equal %s" callbackName (formatList callbackValues) }
            | "remove_callback" -> seq {
                let cellName = op.["cell"].ToObject<string>()
                let callbackName = op.["name"].ToObject<string>()
                yield sprintf "%s.Changed.RemoveHandler %sHandler" cellName callbackName }
            | _ -> seq { yield "" }
        )
        |> Seq.toList

    override __.RenderAssert _ = []

    override this.RenderArrange canonicalDataCase =
        let initialVars = this.RenderCells canonicalDataCase
        let operations = this.RenderOperations canonicalDataCase
        initialVars @ operations

type Rectangles() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderInput (_, _, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

type ReverseString() =
    inherit GeneratorExercise()

type RobotSimulator() =
    inherit GeneratorExercise()

    let parseInput (input: obj) = 
        let token = input :?> JToken
        let direction = token.SelectToken "direction" |> Option.ofObj
        let position  = token.SelectToken "position"  |> Option.ofObj
        (direction, position)

    let renderDirection (value: JToken) = 
        value.ToObject<string>() |> String.upperCaseFirst

    let renderPosition (position: JToken) = 
        (position.["x"].ToObject<int>(), position.["y"].ToObject<int>()) 
        |> formatValue

    let renderRobot direction position = 
        sprintf "create %s %s" (renderDirection direction) (renderPosition position)

    let renderInput input = 
        match input with
        | None,           Some position -> renderPosition position
        | Some direction, None          -> renderDirection direction
        | Some direction, Some position -> renderRobot direction position
        | None,           None          -> failwith "No direction or position"

    override __.PropertiesWithIdentifier canonicalDataCase =
        match parseInput canonicalDataCase.Expected with
        | None,   Some _ -> ["sut"] 
        | Some _, None   -> ["sut"]
        | Some _, Some _ -> ["expected"]
        | None,   None   -> ["sut"; "expected"]

    override __.ToTestMethodBodyAssert canonicalDataCase =
        let testMethodBodyAssert = base.ToTestMethodBodyAssert(canonicalDataCase)

        match parseInput canonicalDataCase.Expected with
        | None, Some _ -> { testMethodBodyAssert with Sut = sprintf "%s.position" testMethodBodyAssert.Sut }
        | Some _, None -> { testMethodBodyAssert with Sut = sprintf "%s.direction" testMethodBodyAssert.Sut }
        | _ -> testMethodBodyAssert

    override __.RenderArrange canonicalDataCase =
        sprintf "let robot = %s" (canonicalDataCase.Properties.["input"] |> parseInput |> renderInput) :: base.RenderArrange canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value |> parseInput |> renderInput

    override __.RenderSut canonicalDataCase = 
        match canonicalDataCase.Property with
        | "create" -> "robot"
        | "turnLeft" | "turnRight" | "advance" -> sprintf "%s robot" canonicalDataCase.Property
        | "instructions" -> sprintf "instructions %s robot" (formatValue canonicalDataCase.Input.["instructions"])
        | _ -> base.RenderSut canonicalDataCase

    override __.RenderTestMethodName canonicalDataCase =
        let testMethodName = base.RenderTestMethodName canonicalDataCase

        match canonicalDataCase.Property with
        | "create" | "instructions" -> testMethodName
        | _ -> sprintf "%s %s" canonicalDataCase.Property (String.lowerCaseFirst testMethodName)

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

    override __.RenderTestMethodName canonicalDataCase =
        match canonicalDataCase.Property with
        | "consistency" -> 
            base.RenderTestMethodName canonicalDataCase
        | _ -> 
            sprintf "%s %s" canonicalDataCase.Property canonicalDataCase.Description |> String.upperCaseFirst

type RomanNumerals() =
    inherit GeneratorExercise()

type SaddlePoints() =
    inherit GeneratorExercise()

    let renderSaddlePoint (input: JObject) =
        (input.Value<int>("row"), input.Value<int>("column")) |> formatTuple

    override __.RenderInput (_, _, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatMultiLineList

    override __.RenderExpected (_, _, value) =
        (value :?> JArray).Values<JObject>()
        |> Seq.map renderSaddlePoint
        |> formatList

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Say() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofPositiveInt
        |> formatValue
        |> parenthesizeOption

    override __.RenderInput (_, _, value) = sprintf "%sL" (string value)

type ScaleGenerator() =
    inherit GeneratorExercise()

    override __.MapCanonicalDataCaseInput (canonicalDataCase, properties) =
        let input = base.MapCanonicalDataCaseInput (canonicalDataCase, properties)
        match Map.tryFind "intervals" input with
        | Some _ -> input
        | None   -> Map.add "intervals" null input

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with 
        | "intervals" -> value |> Option.ofObj |> formatValue |> parenthesizeOption
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.PropertiesUsedAsSutParameter _ = ["tonic"; "intervals"]

type ScrabbleScore() =
    inherit GeneratorExercise()

type Sieve() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        (value :?> JArray)
        |> normalizeJArray
        |> Seq.map formatValue
        |> formatList

type SecretHandshake() =
    inherit GeneratorExercise()

type SpaceAge() =
    inherit GeneratorExercise()

    override __.RenderInput (canonicalDataCase, key, value) =
        match value with
        | :? string as s -> s
        | :? int64 as i -> sprintf "%dL" i
        | _ -> base.RenderInput (canonicalDataCase, key, value)

type SpiralMatrix() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList

type Sublist() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        string value |> String.upperCaseFirst

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type SumOfMultiples() =
    inherit GeneratorExercise()

type Tournament() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderValue (_, _, value) =
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList

type TwelveDays() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList

type Transpose() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None

    override __.RenderValue (_, _, value) =
        value :?> JArray
        |> Seq.map formatValue
        |> formatMultiLineList

type Triangle() =
    inherit GeneratorExercise()

    let formatFloat (value:obj) = 
        match value with
        | :? int64 as i -> sprintf "%.1f" (float i)
        | :? int32 as i -> sprintf "%.1f" (float i)
        | :? float as f -> sprintf "%.1f" f
        | _ -> failwith "Invalid value"

    let hasUniqueTestMethodName canonicalDataCase = 
        canonicalDataCase.Description.Contains "equilateral" ||
        canonicalDataCase.Description.Contains "isosceles" ||
        canonicalDataCase.Description.Contains "scalene"

    override __.RenderTestMethodName canonicalDataCase =
        match hasUniqueTestMethodName canonicalDataCase with
        | true  -> base.RenderTestMethodName canonicalDataCase
        | false -> sprintf "%s returns %s" (String.upperCaseFirst canonicalDataCase.Property) canonicalDataCase.Description

    override __.RenderInput (_, _, value) =
        value :?> JArray
        |> normalizeJArray
        |> Seq.map formatFloat
        |> formatList

type TwoBucket() =
    inherit GeneratorExercise()

    let renderBucket (value: obj) = 
        value |> string |> String.upperCaseFirst |> sprintf "Bucket.%s"

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "startBucket" -> renderBucket value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.RenderExpected (_, _, value) =
        let jObject = value :?> JObject
        let moves       = jObject.Value<int>("moves")
        let goalBucket  = jObject.Value<string>("goalBucket") |> renderBucket
        let otherBucket = jObject.Value<int>("otherBucket")
        sprintf "{ Moves = %d; GoalBucket = %s; OtherBucket = %d }" moves goalBucket otherBucket

type TwoFer() =
    inherit GeneratorExercise()

    override __.RenderInput (_, _, value) =
        value |> Option.ofObj |> formatValue |> parenthesizeOption

type VariableLengthQuantity() = 
    inherit GeneratorExercise()

    let formatUnsignedByteList (value: obj) =
        value :?> JArray
        |> Seq.map (fun x -> x.Value<byte>() |> sprintf "0x%xuy")
        |> formatList

    let formatUnsignedIntList (value: obj) =
        value :?> JArray
        |> Seq.map (fun x -> x.Value<uint32>() |> sprintf "0x%xu")
        |> formatList

    override __.RenderInput (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "encode" -> value |> formatUnsignedIntList
        | "decode" -> value |> formatUnsignedByteList
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "encode" -> value |> formatUnsignedByteList
        | "decode" -> value |> Option.ofObj |> Option.map formatUnsignedIntList |> formatOption |> parenthesizeOption
        | _ -> base.RenderExpected (canonicalDataCase, key, value)
        
type WordCount() =
    inherit GeneratorExercise()
    member __.FormatMap<'TKey, 'TValue> (value: obj) =
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

    override this.RenderExpected (_, _, value) = this.FormatMap<string, int> value

    override __.PropertiesWithIdentifier _ = ["expected"]

type WordSearch() =
    inherit GeneratorExercise()

    let toCoordinates (value: JToken) = value.Value<int>("column"), value.Value<int>("row")

    let renderExpectedCoordinates (value: JObject) =
        formatTuple (value.Item("start") |> toCoordinates, value.Item("end") |> toCoordinates)

    let renderExpectedValue (value: JObject) =
        match isNull value with
        | true  -> "Option<((int * int) * (int * int))>.None"
        | false -> sprintf "Some (%s)" (renderExpectedCoordinates value)

    override __.RenderExpected (_, _, value) = 
        let input = value :?> JObject
        let formattedList =
            input.ToObject<Collections.Generic.Dictionary<string, JObject>>()
            |> Seq.map (fun kv -> sprintf "(%s, %s)" (formatValue kv.Key) (renderExpectedValue kv.Value))
            |> formatMultiLineList

        if (formattedList.Contains("\n")) then
            sprintf "%s\n%s" formattedList (indent 2 "|> Map.ofList")
        else   
            sprintf "%s |> Map.ofList" formattedList

    override __.RenderInput (canonicalDataCase, key, value) = 
        match key with
        | "grid" -> 
            value :?> JArray
            |> normalizeJArray
            |> Seq.map formatValue
            |> formatMultiLineList
        | _ -> 
            base.RenderInput(canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Wordy() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value |> Option.ofNonFalse |> formatValue |> parenthesizeOption

type Yacht() =
    inherit GeneratorExercise()

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "category" -> sprintf "Category.%s" (value |> string |> String.dehumanize)
        | _ -> base.RenderInput (canonicalDataCase, key, value)

type ZebraPuzzle() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = string value
