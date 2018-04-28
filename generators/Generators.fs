module Generators.Generators

open System
open System.Globalization
open Newtonsoft.Json.Linq
open CanonicalData
open Conversion
open Formatting
open Templates
open Exercise

type Acronym() =
    inherit GeneratorExercise()

type AllYourBase() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonErrorObject
        |> Option.render

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Allergies() =
    inherit GeneratorExercise()

    let renderAllergenEnum (jToken: JToken) = Obj.renderEnum "Allergen" jToken

    let renderAllergicToAssert canonicalDataCase (jToken: JToken) =
        let substance = renderAllergenEnum jToken.["substance"]
        let score = canonicalDataCase.Input.["score"] :?> int64
        let sut = sprintf "allergicTo %d %s" score substance
        let expected = jToken.Value<bool>("result") |> Bool.render
        
        { Sut = sut; Expected = expected }
        |> renderPartialTemplate "AssertEqual"

    override __.RenderAssert canonicalDataCase =
        match canonicalDataCase.Property with
        | "allergicTo" ->
            canonicalDataCase.Expected
            |> List.ofObj
            |> List.map (renderAllergicToAssert canonicalDataCase)
        | _ -> 
            base.RenderAssert canonicalDataCase

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "list" ->
            canonicalDataCase.Expected
            |> List.ofObj
            |> List.map renderAllergenEnum
            |> List.renderStrings
        | _ -> 
            base.RenderExpected (canonicalDataCase, key, value)

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
                |> Seq.map (fun kv -> renderTuple (kv.Key, kv.Value))
                |> List.renderMultiLineStrings

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s\n%s" formattedList (String.indent 2 "|> Map.ofList") (String.indent 2 "|> Some")
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
        value
        |> List.ofObj
        |> List.map renderObj
        |> List.renderMultiLineStrings

type BinarySearch() = 
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["array"; "value"; "expected"]

    override __.RenderValue (canonicalDataCase, key, value) =
        match key with
        | "array" ->
            value
            |> Array.ofObj
            |> Array.map renderObj          
            |> Array.renderStrings
        | "expected" ->
            value
            |> Option.ofNonNegativeNumber
            |> Option.render
        | _ ->
            base.RenderValue (canonicalDataCase, key, value)

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
        value
        |> List.ofObj
        |> List.map string
        |> List.renderStrings
        |> sprintf "create %s"

    override __.RenderExpected (canonicalDataCase, key, value) = 
        match value with
        | :? JArray as jArray -> jArray |> Seq.map string |> List.renderStrings
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
            yield sprintf "let rolls = %s" (List.renderStrings arr)
            if canonicalDataCase.Input.ContainsKey "roll" then
                let roll = canonicalDataCase.Input.["roll"] :?> int64
                yield sprintf "let startingRolls = rollMany rolls (newGame())" 
                yield sprintf "let game = roll %i startingRolls" roll
            else
                yield sprintf "let game = rollMany rolls (newGame())" 
        }
        |> Seq.toList

    override __.RenderExpected (_, _, value) =
        value
        |> Option.ofNonErrorObject
        |> Option.renderParenthesized
    
type BracketPush() =
    inherit GeneratorExercise()

type Change() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        match value with
        | :? JArray ->
            value 
            |> Option.ofObj 
            |> Option.render
        | _ ->
            value 
            |> Option.ofNonNegativeNumber 
            |> Option.render

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
            yield sprintf "let buffer1 = mkCircularBuffer %i" (canonicalDataCase.Input.["capacity"] :?> int64)
            let operations = (canonicalDataCase.Input.["operations"] :?> JArray)
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

    let createClock (value:obj) =
        let clock = value :?> JObject
        let hour = clock.["hour"].ToObject<string>()
        let minute = clock.["minute"].ToObject<string>()
        sprintf "create %s %s" hour minute

    member private this.RenderPropertyValue canonicalDataCase property =
        this.RenderSutParameter (canonicalDataCase, property, Map.find property canonicalDataCase.Input)

    override __.PropertiesWithIdentifier _ = ["clock1"; "clock2"]

    override __.RenderValue (canonicalDataCase, key, value) =
        match key with
        | "clock1" | "clock2" -> createClock value
        | _ -> base.RenderValue (canonicalDataCase, key, value)
    
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
        |> List.map (fun line -> line.PadRight(padSize) |> renderObj)
        |> List.renderMultiLineStrings

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type CollatzConjecture() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value
        |> Option.ofNonErrorObject
        |> Option.renderParenthesized

type CryptoSquare() =
    inherit GeneratorExercise()

type CustomSet() = 
    inherit GeneratorExercise()

    member __.SutName = "actual"

    override __.AssertTemplate _ = "AssertEqual"

    member __.RenderSet (jToken: obj) =
        jToken
        |> List.ofObj
        |> List.render
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
        | _ -> renderObj canonicalDataCase.Expected

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
                let valueVar = sprintf "let element = %s" (renderObj canonicalDataCase.Input.["element"])
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
    
    let formatAsTuple (value: JToken) =
        let items = value :?> JArray
        renderTuple (items.[0].ToObject<int>(), items.[1].ToObject<int>())

    override __.RenderInput (_, _, value) =
        value
        |> List.ofObj
        |> List.map formatAsTuple
        |> List.renderStrings

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Etl() =
    inherit GeneratorExercise()

    member __.FormatMap<'TKey, 'TValue> (value: obj) =
        let input = value :?> JObject
        let dict = input.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>();
        let formattedList =
            dict
            |> Seq.map (fun kv -> renderTuple (kv.Key, kv.Value))
            |> List.renderMultiLineStrings

        if (formattedList.Contains("\n")) then
            sprintf "%s\n%s" formattedList (String.indent 2 "|> Map.ofList")
        else   
            sprintf "%s |> Map.ofList" formattedList

    override this.RenderInput (_, _, value) = this.FormatMap<int, List<char>> value

    override this.RenderExpected (_, _, value) = this.FormatMap<char, int> value

    override __.MapCanonicalDataCase canonicalDataCase = 
        { canonicalDataCase with Input = Map.empty |> Map.add "lettersByScore" (canonicalDataCase.Properties.["input"]) }

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type FoodChain() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        value
        |> List.ofObj
        |> List.map Obj.render
        |> List.renderMultiLineStrings

type Forth() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]
    
    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofObj 
        |> Option.render

    override __.IdentifierTypeAnnotation (_, _, value) = 
        let isEmptyList = value :?> JArray|> Option.ofObj |> Option.map Seq.isEmpty

        match isEmptyList with 
        | Some true -> Some "int list option"
        | _ -> None

    override __.UseFullMethodName _ = true

type Gigasecond() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = value :?> DateTime |> DateTime.render |> String.parenthesize
 
    override __.RenderInput (_, _, value) =
         DateTime.Parse(string value, CultureInfo.InvariantCulture) |> DateTime.render |> String.parenthesize

    override __.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type GoCounting() =
    inherit GeneratorExercise()

    let renderOwner (value: JToken) = 
        value
        |> string
        |> String.toLower
        |> String.upperCaseFirst
        |> sprintf "Owner.%s"

    let renderTerritoryPosition (value: JToken) =
        let arr = value :?> JArray
        (arr.[0].ToObject<int>(), arr.[1].ToObject<int>())
        |> renderObj

    let renderTerritory (value: JToken) = 
        value :?> JArray
        |> Seq.map renderTerritoryPosition
        |> List.renderStrings

    let renderTerritoryWithOwner (value: obj) =
        let expected = value :?> JObject
        let owner = expected.["owner"] |> renderOwner
        let territory = expected.["territory"] |> renderTerritory
        sprintf "(%s, %s)" owner territory

    let renderExpectedTerritory (value: obj) = 
        match Option.ofNonErrorObject value with
        | None -> "Option.None"
        | Some expected -> expected |> renderTerritoryWithOwner |> sprintf "Option.Some %s"
    
    let renderExpectedTerritories (value: obj) = 
        let expected = value :?> JObject
        let black = sprintf "(Owner.Black, %s)" (expected.["territoryBlack"] |> renderTerritory)
        let white = sprintf "(Owner.White, %s)" (expected.["territoryWhite"] |> renderTerritory)
        let none  = sprintf "(Owner.None, %s)"  (expected.["territoryNone"]  |> renderTerritory)

        let formattedList = List.renderMultiLineStrings [black; white; none]
        sprintf "%s\n%s" formattedList (String.indent 2 "|> Map.ofList")

    let territoryPosition (input: Map<string, obj>) =
        let valueToInt key = input |> Map.find key |> string |> int
        (valueToInt "x", valueToInt "y") |> box

    let mapTerritoryInput (input: Map<string, obj>) =
        input
        |> Map.remove "x"
        |> Map.remove "y"
        |> Map.add "position" (territoryPosition input)

    override __.MapCanonicalDataCase canonicalDataCase =
        match canonicalDataCase.Property with
        | "territory" -> { canonicalDataCase with Input = mapTerritoryInput canonicalDataCase.Input }
        | _ -> canonicalDataCase

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "board" -> 
            value
            |> List.ofObj
            |> List.renderMultiLine
        | _ -> 
            base.RenderInput (canonicalDataCase, key, value)

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "territory" -> renderExpectedTerritory value
        | "territories" -> renderExpectedTerritories value
        | _ -> base.RenderExpected(canonicalDataCase, key, value)

    override __.PropertiesWithIdentifier canonicalDataCase = base.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match canonicalDataCase.Property, key with 
        | "territory", "expected" -> 
            match Option.ofNonErrorObject value with
            | None -> None
            | Some _ ->
                if (value :?> JObject).["territory"] :?> JArray |> Seq.isEmpty then
                    Some "(Owner * (int * int) list) option"
                else
                    None            
        | _ -> None

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

    let indentExpected expected =
        expected
        |> String.split "\n" 
        |> Array.mapi (fun i part -> if i = 0 then part else String.indent 1 part)
        |> String.concat "\n"

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderExpected (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine
        |> indentExpected

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
        |> Option.ofNonErrorObject
        |> Option.renderParenthesized

type HelloWorld() =
    inherit GeneratorExercise()

type House() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine

type IsbnVerifier() =
    inherit GeneratorExercise()

type Isogram() =
    inherit GeneratorExercise()

type KindergartenGarden() =
    inherit GeneratorExercise()

    let renderPlantEnum value = Obj.renderEnum "Plant" value

    override __.RenderExpected (_, _, value) = 
        value
        |> List.ofObj
        |> List.map renderPlantEnum
        |> List.renderStrings

    override __.PropertiesWithIdentifier _ = ["student"; "diagram"; "expected"]

    override __.UseFullMethodName _ = true

type LargestSeriesProduct() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonNegativeNumber
        |> Option.renderParenthesized

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

    override __.TestMethodName canonicalDataCase =
        sprintf "%s %s" canonicalDataCase.Property canonicalDataCase.Description

type Luhn() =
    inherit GeneratorExercise()

type Markdown() =
    inherit GeneratorExercise()

    override __.SkipTestMethod (_, _) = false

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Matrix() =
    inherit GeneratorExercise()
    
type Meetup() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        DateTime.Parse(string value) 
        |> DateTime.render 
        |> String.parenthesize

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
        value
        |> List.ofObj
        |> List.map renderObj
        |> List.renderMultiLineStrings

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
        |> Option.ofNonErrorObject
        |> Option.renderParenthesized

type NucleotideCount() =
    inherit GeneratorExercise()

    member __.FormatMap<'TKey, 'TValue> (value: obj) =
        match Option.ofNonErrorObject value with
        | None -> 
            "None"
        | _ ->
            let input = value :?> JObject
            let dict = input.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>();
            let formattedList =
                dict
                |> Seq.map (fun kv -> renderTuple (kv.Key, kv.Value))
                |> List.renderMultiLineStrings

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s\n%s" formattedList (String.indent 2 "|> Map.ofList") (String.indent 2 "|> Some")
            else   
                sprintf "%s |> Map.ofList |> Some" formattedList

    override this.RenderExpected (_, _, value) = this.FormatMap<char, int> value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type OcrNumbers() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonNegativeNumber 
        |> Option.renderParenthesized

    override __.RenderInput (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine

type Pangram() =
    inherit GeneratorExercise()

type PalindromeProducts() =
    inherit GeneratorExercise()

    let toFactors (value: JToken) = 
        let jArray = value :?> JArray
        sprintf "(%s, %s)" (string jArray.[0]) (string jArray.[1])

    let toPalindromeProducts (value: obj) =
        let jObject = value :?> JObject
        let palindromeValue = jObject.Value<int>("value")
        let factors = 
            jObject.Value<obj>("factors") 
            |> List.ofObj
            |> List.map toFactors
            |> List.renderStrings

        sprintf "(%d, %s)" palindromeValue factors

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonErrorObject
        |> Option.map toPalindromeProducts
        |> Option.renderStringParenthesized

    override __.PropertiesUsedAsSutParameter _ = ["min"; "max"]

type PascalsTriangle() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) = 
        match value with
        | :? JArray  ->
            let formattedList =
                value
                |> List.ofObj       
                |> List.map Obj.render         
                |> List.renderMultiLineStrings

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s" formattedList (String.indent 2 "|> Some")
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

    override __.AssertTemplate _ = "AssertEqual"
    
type PerfectNumbers() =
    inherit GeneratorExercise()

    let toClassification value = string value |> String.dehumanize

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonErrorObject
        |> Option.map toClassification
        |> Option.renderStringParenthesized

type PhoneNumber() =
    inherit GeneratorExercise()
    
    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofObj
        |> Option.renderParenthesized

type PigLatin() =
    inherit GeneratorExercise()

type Poker() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Pov() = 
    inherit GeneratorExercise()

    let isNull x = match x with null -> true | _ -> false

    override __.RenderSetup _ = 
        ["let rec graphToList (graph: Graph<'a>) = "
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
                    |> List.renderStrings
                else
                    "[]"
            let label =
                node.["label"]
                |> renderObj
            sprintf "mkGraph %s %s" label children

    override this.RenderArrange canonicalDataCase =
        seq {
            yield 
                canonicalDataCase.Input.["tree"]
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
                canonicalDataCase.Input.["from"]
                |> renderObj
            match isNull canonicalDataCase.Expected with
            | false -> sprintf "fromPOV %s tree |> mapToList " from
            | true -> sprintf "fromPOV %s tree " from
        | "pathTo" -> 
            let fromValue = 
                canonicalDataCase.Input.["from"] 
                |> renderObj
            let toValue = 
                canonicalDataCase.Input.["to"] 
                |> renderObj
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
                |> Seq.map renderObj
                |> List.renderStrings
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
        value
        |> List.ofObj
        |> List.renderMultiLine
    
    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None
    
type QueenAttack() =
    inherit GeneratorExercise()

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "create" -> value :?> int64 <> -1L |> renderObj
        | _ -> base.RenderExpected (canonicalDataCase, key, value)

    override __.RenderInput (canonicalDataCase, key, value) =
        let parsePositionTuple (tupleValue: obj) =
            let position = (tupleValue :?> JToken).SelectToken("position")
            renderObj (position.["row"].ToObject<int>(), position.["column"].ToObject<int>())

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

    override __.AssertTemplate canonicalDataCase =
        match canonicalDataCase.Expected with
        | :? double -> "AssertEqualWithin"
        | _ -> base.AssertTemplate(canonicalDataCase)

type React() = 
    inherit GeneratorExercise()

    let renderCells canonicalDataCase = 
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
                        (cell.["inputs"].ToObject<seq<string>>() |> List.renderStrings)
                    
                    sprintf "let %s = reactor.createComputeCell %s (fun values -> %s)" cellName inputParams funBody
                | "input" -> 
                    let initialValue = cell.["initial_value"].ToObject<int64>()
                    sprintf "let %s = reactor.createInputCell %s" cellName (renderObj initialValue)
                | _ -> ""
            )
            |> Seq.toList
        [ reactorVar ] @ cellVars
     
    let renderExpectedCellValueOperation (op: JObject) =
        seq { 
            let cellName = op.["cell"].ToObject<string>()
            let expectedValue = op.["value"].ToObject<int>()
            yield sprintf "%s.Value |> should equal %i" cellName expectedValue 
        }

    let renderExpectedCallbacks (jToken: JToken) =
        match jToken with
        | :? JObject as jObject ->
            seq {
                for child in jObject.Children<JProperty>() ->
                    let callbackName = child.Name
                    let callbackValue = child.Value |> string
                    let callbackHandlerName = sprintf "%sHandler" callbackName

                    seq {
                        yield sprintf "A.CallTo(fun() -> %s.Invoke(A<obj>.``_``, %s)).MustHaveHappenedOnceExactly() |> ignore" callbackHandlerName callbackValue
                        yield sprintf "Fake.ClearRecordedCalls(%s) |> ignore" callbackHandlerName
                    }                
            } |> Seq.concat
        | _ -> Seq.empty

    let renderExpectedCallbacksNotToBeCalled (jToken: JToken) =
        match jToken with
        | :? JArray as jArray -> 
            jArray.ToObject<string list>() 
            |> Seq.map (sprintf "A.CallTo(fun() -> %sHandler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore")
        | _ -> Seq.empty

    let renderSetValueOperation (op: JObject) = 
        seq { 
            let cellName = op.["cell"].ToObject<string>()
            let cellValue = op.["value"].ToObject<int>()
            yield sprintf "%s.Value <- %i" cellName cellValue
            yield! renderExpectedCallbacks op.["expect_callbacks"]
            yield! renderExpectedCallbacksNotToBeCalled op.["expect_callbacks_not_to_be_called"]
        }

    let renderAddCallbackOperation (op: JObject) =
        seq { 
            let callbackName = op.["name"].ToObject<string>()
            let cellName = op.["cell"].ToObject<string>() 
            let callbackHandlerName = sprintf "%sHandler" callbackName
            yield sprintf "let %s = A.Fake<Handler<int>>()" callbackHandlerName
            yield sprintf "%s.Changed.AddHandler %s" cellName callbackHandlerName 
        }

    let renderRemoveCallbackOperation (op: JObject) =
        seq {
            let cellName = op.["cell"].ToObject<string>()
            let callbackName = op.["name"].ToObject<string>()
            yield sprintf "%s.Changed.RemoveHandler %sHandler" cellName callbackName
        }

    let renderOperation (op: JObject) =
        let opType = op.["type"].ToObject<string>()
        match opType with
        | "expect_cell_value" -> renderExpectedCellValueOperation op
        | "set_value" -> renderSetValueOperation op
        | "add_callback" -> renderAddCallbackOperation op
        | "remove_callback" -> renderRemoveCallbackOperation op
        | _ -> failwith "Unknown operation type"

    let renderOperations canonicalDataCase = 
        canonicalDataCase.Input.["operations"] :?> JArray
        |> Seq.cast<JObject>
        |> Seq.collect renderOperation
        |> Seq.toList

    override __.PropertiesWithIdentifier _ = []

    override __.RenderAssert _ = []

    override __.RenderArrange canonicalDataCase =
        let initialVars = renderCells canonicalDataCase
        let operations = renderOperations canonicalDataCase
        initialVars @ operations

    override __.AdditionalNamespaces = ["FakeItEasy"]

type Rectangles() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderInput (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine

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
        |> renderObj

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

    override this.RenderAssert canonicalDataCase = 
        let renderAssertWithProperty prop =
            let expected = this.RenderExpected (canonicalDataCase, "expected", canonicalDataCase.Expected)

            { Sut = sprintf "sut.%s" prop; Expected = expected }
            |> renderPartialTemplate "AssertEqual"

        match parseInput canonicalDataCase.Expected with
        | None, Some _ -> [renderAssertWithProperty "position"]
        | Some _, None -> [renderAssertWithProperty "direction"]
        | _ -> base.RenderAssert canonicalDataCase

    override __.RenderArrange canonicalDataCase =
        sprintf "let robot = %s" (canonicalDataCase.Properties.["input"] |> parseInput |> renderInput) :: base.RenderArrange canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value |> parseInput |> renderInput

    override __.RenderSut canonicalDataCase = 
        match canonicalDataCase.Property with
        | "create" -> "robot"
        | "turnLeft" | "turnRight" | "advance" -> sprintf "%s robot" canonicalDataCase.Property
        | "instructions" -> sprintf "instructions %s robot" (renderObj canonicalDataCase.Input.["instructions"])
        | _ -> base.RenderSut canonicalDataCase

    override __.TestMethodName canonicalDataCase =
        let testMethodName = base.TestMethodName canonicalDataCase

        match canonicalDataCase.Property with
        | "create" | "instructions" -> testMethodName
        | _ -> sprintf "%s %s" canonicalDataCase.Property (String.lowerCaseFirst testMethodName)

type RotationalCipher() =
    inherit GeneratorExercise()

type RnaTranscription() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value
        |> Option.ofObj
        |> Option.renderParenthesized

type RunLengthEncoding() =
    inherit GeneratorExercise()

    override this.RenderSut canonicalDataCase =
        match canonicalDataCase.Property with
        | "consistency" ->
            let parameters = this.RenderSutParameters canonicalDataCase |> String.concat " "
            sprintf "%s |> encode |> decode" parameters
        | _ -> 
            base.RenderSut canonicalDataCase

    override __.TestMethodName canonicalDataCase =
        match canonicalDataCase.Property with
        | "consistency" -> 
            base.TestMethodName canonicalDataCase
        | _ -> 
            sprintf "%s %s" canonicalDataCase.Property canonicalDataCase.Description |> String.upperCaseFirst

type RomanNumerals() =
    inherit GeneratorExercise()

type SaddlePoints() =
    inherit GeneratorExercise()

    let renderSaddlePoint (input: JObject) =
        (input.Value<int>("row"), input.Value<int>("column")) |> renderTuple

    override __.RenderInput (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine

    override __.RenderExpected (_, _, value) =
        (value :?> JArray).Values<JObject>()
        |> Seq.map renderSaddlePoint
        |> List.renderStrings

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Say() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofNonNegativeNumber
        |> Option.renderParenthesized

    override __.RenderInput (_, _, value) = sprintf "%sL" (string value)

type ScaleGenerator() =
    inherit GeneratorExercise()

    override __.MapCanonicalDataCase canonicalDataCase =
        let input = canonicalDataCase.Input
        match Map.tryFind "intervals" input with
        | Some _ -> canonicalDataCase
        | None   -> { canonicalDataCase with Input = Map.add "intervals" null input }

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with 
        | "intervals" -> 
            value 
            |> Option.ofObj
            |> Option.renderParenthesized
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.PropertiesUsedAsSutParameter _ = ["tonic"; "intervals"]

type ScrabbleScore() =
    inherit GeneratorExercise()

type Sieve() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value
        |> List.ofObj
        |> List.render

type SecretHandshake() =
    inherit GeneratorExercise()

type Series() =
    inherit GeneratorExercise()
    
    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofNonErrorObject
        |> Option.renderParenthesized

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
        value
        |> List.ofObj
        |> List.map Obj.render
        |> List.renderMultiLineStrings

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
        value
        |> List.ofObj
        |> List.renderMultiLine

type TwelveDays() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine

type Transpose() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (_, _, value) = 
        match value :?> JArray |> Seq.isEmpty with 
        | true  -> Some "string list"
        | false -> None

    override __.RenderValue (_, _, value) =
        value
        |> List.ofObj
        |> List.renderMultiLine

type Triangle() =
    inherit GeneratorExercise()

    let formatFloat (jToken: JToken) = 
        sprintf "%.1f" (jToken.ToObject<float>())

    let hasUniqueTestMethodName canonicalDataCase = 
        canonicalDataCase.Description.Contains "equilateral" ||
        canonicalDataCase.Description.Contains "isosceles" ||
        canonicalDataCase.Description.Contains "scalene"

    override __.TestMethodName canonicalDataCase =
        match hasUniqueTestMethodName canonicalDataCase with
        | true  -> base.TestMethodName canonicalDataCase
        | false -> sprintf "%s returns %s" (String.upperCaseFirst canonicalDataCase.Property) canonicalDataCase.Description

    override __.RenderInput (_, _, value) =
        value
        |> List.ofObj
        |> List.map formatFloat
        |> List.renderStrings

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
        value
        |> Option.ofObj
        |> Option.renderParenthesized

type VariableLengthQuantity() = 
    inherit GeneratorExercise()

    let formatUnsignedByteList (value: obj) =
        value :?> JArray
        |> Seq.map (fun x -> x.Value<byte>() |> sprintf "0x%xuy")
        |> List.renderStrings

    let formatUnsignedIntList (value: obj) =
        value :?> JArray
        |> Seq.map (fun x -> x.Value<uint32>() |> sprintf "0x%xu")
        |> List.renderStrings

    override __.RenderInput (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "encode" -> value |> formatUnsignedIntList
        | "decode" -> value |> formatUnsignedByteList
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "encode" -> value |> formatUnsignedByteList
        | "decode" -> 
            value
            |> Option.ofObj
            |> Option.map formatUnsignedIntList
            |> Option.renderStringParenthesized
        | _ -> base.RenderExpected (canonicalDataCase, key, value)
        
type WordCount() =
    inherit GeneratorExercise()
    member __.FormatMap<'TKey, 'TValue> (value: obj) =
        let input = value :?> JObject
        let dict = input.ToObject<Collections.Generic.Dictionary<'TKey, 'TValue>>();
        let formattedList =
            dict
            |> Seq.map (fun kv -> renderTuple (kv.Key, kv.Value))
            |> List.renderMultiLineStrings

        if (formattedList.Contains("\n")) then
            sprintf "%s\n%s" formattedList (String.indent 2 "|> Map.ofList")
        else   
            sprintf "%s |> Map.ofList" formattedList

    override this.RenderExpected (_, _, value) = this.FormatMap<string, int> value

    override __.PropertiesWithIdentifier _ = ["expected"]

type WordSearch() =
    inherit GeneratorExercise()

    let toCoordinates (value: JToken) = value.Value<int>("column"), value.Value<int>("row")

    let renderExpectedCoordinates (value: JObject) =
        renderTuple (value.Item("start") |> toCoordinates, value.Item("end") |> toCoordinates)

    let renderExpectedValue (value: JObject) =
        match isNull value with
        | true  -> "Option<((int * int) * (int * int))>.None"
        | false -> renderExpectedCoordinates value |> Some |> Option.renderString

    override __.RenderExpected (_, _, value) = 
        let input = value :?> JObject
        let formattedList =
            input.ToObject<Collections.Generic.Dictionary<string, JObject>>()
            |> Seq.map (fun kv -> sprintf "(%s, %s)" (renderObj kv.Key) (renderExpectedValue kv.Value))
            |> List.renderMultiLineStrings

        if (formattedList.Contains("\n")) then
            sprintf "%s\n%s" formattedList (String.indent 2 "|> Map.ofList")
        else   
            sprintf "%s |> Map.ofList" formattedList

    override __.RenderInput (canonicalDataCase, key, value) = 
        match key with
        | "grid" -> 
            value
            |> List.ofObj
            |> List.renderMultiLine
        | _ -> 
            base.RenderInput(canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Wordy() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofNonFalseBoolean
        |> Option.renderParenthesized

type Yacht() =
    inherit GeneratorExercise()

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "category" -> sprintf "Category.%s" (value |> string |> String.dehumanize)
        | _ -> base.RenderInput (canonicalDataCase, key, value)

type ZebraPuzzle() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = string value

type Zipper() = 
    inherit GeneratorExercise()

    let rec renderTree root (tree: JToken) =
        match tree with
        | :? JObject as jObject ->
            let value = jObject .["value"].ToObject<int>()
            let left = tree.["left"] |> renderTree false 
            let right = tree.["right"] |> renderTree false

            if root then
                sprintf "tree %d %s %s" value left right
            else
                match left, right with
                | "None", "None" -> 
                    sprintf "(leaf %d)" value
                | _ -> 
                    sprintf "(subTree %d %s %s)" value left right
        | _ -> 
            "None"

    let renderOperation count index (jToken: JToken) = 
        let operation = jToken.["operation"] |> string |> String.camelize

        match operation with
        | "value" | "toTree" -> 
            [operation]
        | "left" | "right" | "up" -> 
            if index = count - 1 then
                [operation]
            else            
                [operation; "Option.get"]
        | "setValue" -> 
            [sprintf "setValue %s" (jToken.["item"] |> string)]
        | "setLeft"| "setRight" -> 
            let expected =
                match jToken.["item"] with
                | :? JObject as subTree ->
                    Some (renderTree true subTree |> String.parenthesize)
                | _ ->
                    None

            [sprintf "%s %s" operation (Option.renderStringParenthesized expected)]            
        | _ -> failwith "Unknown operation"

    let renderOperations (operations: JArray) =
        operations
        |> Seq.mapi (renderOperation (Seq.length operations))
        |> Seq.concat
        |> String.concat " |> "
        |> sprintf "|> %s"

    let renderTreeWithIdentifier identifier (tree: JObject) =
        tree
        |> renderTree true
        |> sprintf "let %s = %s" identifier

    let renderZipperWithIdentifier identifier (tree: JObject) =
        let renderedTree = renderTree true tree
        sprintf "let %s = fromTree (%s)" identifier renderedTree

    let renderExpectedZipperWithIdentifier identifier (tree: JObject) (operations: JArray) =
        let renderedTree = renderTree true tree
        let renderedOperations = renderOperations operations
        sprintf "let %s = fromTree (%s) %s" identifier renderedTree renderedOperations

    let renderSut (operations: JArray) =
        operations
        |> renderOperations
        |> sprintf "let sut = zipper %s"

    let renderExpected (expected: JObject) =
        match expected.["type"] |> string with
        | "int" -> 
            expected.["value"] |> string |> sprintf "let expected = %s"
        | "zipper" ->
            match expected.["initialTree"] with
            | :? JObject as jObject -> 
                renderExpectedZipperWithIdentifier "expected" jObject (expected.["operations"] :?> JArray)
            | _ -> 
                "let expected = None"
        | "tree" ->
            expected.["value"] :?> JObject |> renderTreeWithIdentifier "expected"
        | _ -> failwith "Unknown expected type"

    override __.RenderSetup _ = 
        [ "let subTree value left right = Some (tree value left right)"
          "let leaf value = subTree value None None" ]
        |> String.concat "\n"      

    override __.PropertiesWithIdentifier _ = ["initialTree"; "sut"; "expected"]

    override __.RenderArrange canonicalDataCase = 
        let tree = canonicalDataCase.Input.["initialTree"] :?> JObject |> renderZipperWithIdentifier "zipper"
        let sut = canonicalDataCase.Input.["operations"] :?> JArray |> renderSut
        let expected = canonicalDataCase.Expected :?> JObject |> renderExpected
        [tree; sut; expected]

    override __.TestMethodName canonicalDataCase = 
        base.TestMethodName canonicalDataCase |> String.replace "Set_" "Set "