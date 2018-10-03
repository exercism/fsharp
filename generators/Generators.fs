module Generators.Generators

open System
open System.Globalization
open Newtonsoft.Json.Linq
open CanonicalData
open Conversion
open Rendering
open Templates
open Exercise
open Generators.Common

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

    member this.RenderAllergicToAssert canonicalDataCase (jToken: JToken) =
        let substance = renderAllergenEnum jToken.["substance"]
        let score = canonicalDataCase.Input.["score"].ToObject<int>()
        let sut = sprintf "allergicTo %d %s" score substance
        let expected = jToken.Value<bool>("result") |> Bool.render
        this.RenderAssertEqual sut expected

    override this.RenderAssert canonicalDataCase =
        match canonicalDataCase.Property with
        | "allergicTo" ->
            canonicalDataCase.Expected
            |> Seq.map (this.RenderAllergicToAssert canonicalDataCase)
            |> Seq.toList
        | _ -> 
            base.RenderAssert canonicalDataCase

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "list" -> List.mapRender renderAllergenEnum canonicalDataCase.Expected
        | _ -> base.RenderExpected (canonicalDataCase, key, value)

type Alphametics() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonNull
        |> Map.renderOption<char, int>

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

    override __.RenderExpected (_, _, value) = List.renderMultiLine value

type BinarySearch() = 
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["array"; "value"; "expected"]

    override __.RenderValue (canonicalDataCase, key, value) =
        match key with
        | "array" -> Array.render value
        | "expected" ->
            value
            |> Option.ofNonNegativeNumber
            |> Option.render
        | _ ->
            base.RenderValue (canonicalDataCase, key, value)

type BinarySearchTree() =
    inherit GeneratorExercise()

    member this.RenderAssertions previousPaths (tree: JToken) =
        let previousPath = previousPaths |> List.rev |> String.concat " |> "
        let rootPath = List.length previousPaths = 1

        let renderDataAssertions =
            let dataPath = if rootPath then "data" else "Option.map data"
            let data = tree.["data"]

            match data.Type with
            | JTokenType.Null -> 
                let expected = if rootPath then failwith "Invalid data" else "None"
                [ this.RenderAssertEqual (sprintf "%s |> %s" previousPath dataPath) expected ]
            | _ -> 
                let expected = if rootPath then string data else sprintf "(Some %s)" (string data)
                [ this.RenderAssertEqual (sprintf "%s |> %s" previousPath dataPath) expected ]

        let renderNodeAssertions nodeName (node: JToken) = 
            let nodePath = if rootPath then nodeName else sprintf "Option.bind %s" nodeName

            match node.Type with
            | JTokenType.Null -> 
                [ this.RenderAssertEqual (sprintf "%s |> %s" previousPath nodePath) "None" ]
            | _ ->
                this.RenderAssertions (nodePath :: previousPaths) node

        [ renderDataAssertions
          renderNodeAssertions "left" tree.["left"] 
          renderNodeAssertions "right" tree.["right"] ]
        |> List.concat

    override this.RenderAssert canonicalDataCase = 
        match canonicalDataCase.Property with
        | "data" ->
            canonicalDataCase.Expected
            |> this.RenderAssertions ["treeData"]
        | _ -> base.RenderAssert canonicalDataCase

    override __.RenderInput (_, _, value) = 
        value
        |> List.mapRender string
        |> sprintf "create %s"

    override __.RenderExpected (canonicalDataCase, key, value) = 
        match value.Type with
        | JTokenType.Array -> value.ToObject<int list>() |> List.render
        | _ -> base.RenderExpected (canonicalDataCase, key, value)

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Bob() =
    inherit GeneratorExercise()

type BookStore() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = value.ToObject<float>() / 100.0 |> sprintf "%.2f"

    override __.PropertiesUsedAsSutParameter canonicalDataCase =
        base.PropertiesUsedAsSutParameter canonicalDataCase |> List.except ["targetgrouping"]

type Bowling() = 
    inherit GeneratorExercise()

    override __.RenderSut _ = "score game"

    override __.RenderSetup _ = 
        "let rollMany rolls game = List.fold (fun game pins -> roll pins game) game rolls"

    override __.RenderArrange canonicalDataCase =
        seq {
            let previousRolls = canonicalDataCase.Input.["previousRolls"].ToObject<int list>() |> List.render
            yield sprintf "let rolls = %s" previousRolls
            if canonicalDataCase.Input.ContainsKey "roll" then
                let roll = canonicalDataCase.Input.["roll"].ToObject<int>()
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
        value
        |> Option.ofNonNegativeNumber
        |> Option.render

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, _) =
        match key with
        | "expected" ->
            match canonicalDataCase.Input.["target"].ToObject<int>() with
            | 0 -> Some "int list option"
            | _  -> None
        | _ -> None

type CircularBuffer() = 
    inherit GeneratorExercise()

    override __.AdditionalNamespaces = [typeof<Exception>.Namespace]

    override __.RenderAssert _ = []

    member this.ExceptionCheck command = this.RenderAssertThrows command typeof<Exception>.Name

    override this.RenderArrange canonicalDataCase = 
        seq {
            yield sprintf "let buffer1 = mkCircularBuffer %i" (canonicalDataCase.Input.["capacity"].ToObject<int>())
            let operations = canonicalDataCase.Input.["operations"]
            let mutable ind = 2
            let lastInd = Seq.length operations + 1 
            for op in operations do
                let dict = (op :?> JObject).ToObject<Collections.Generic.Dictionary<string, JToken>>()
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
                        let expected = dict.["expected"].ToObject<int>()
                        if ind = lastInd then
                            yield sprintf "let (val%i, _) = %s" ind command
                        else
                            yield sprintf "let (val%i, buffer%i) = %s" ind ind command
                        yield this.RenderAssertEqual (sprintf "val%i" ind) (string expected)
                | "overwrite" ->
                    yield sprintf "let buffer%i = forceWrite %i buffer%i" ind (dict.["item"].ToObject<int>()) (ind-1)
                | "clear" -> 
                    yield sprintf "let buffer%i = clear buffer%i" ind (ind - 1) 
                | _ -> ()
                ind <- ind + 1
        } |> Seq.toList

type Clock() =
    inherit GeneratorExercise()

    let createClock (value: JToken) =
        let hour = value.["hour"].ToObject<string>()
        let minute = value.["minute"].ToObject<string>()
        sprintf "create %s %s" hour minute

    member private this.RenderPropertyValue canonicalDataCase propertyName =
        this.RenderSutParameter (canonicalDataCase, propertyName, Map.find propertyName canonicalDataCase.Input)

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
        match value.Type with
        | JTokenType.Array -> renderComplexNumber (value.ToObject<JArray>())
        | JTokenType.Integer -> sprintf "%d.0" (value.ToObject<int>())
        | _ -> base.RenderValue (canonicalDataCase, key, value)

    override this.RenderAssert canonicalDataCase = 
        match canonicalDataCase.Expected.Type with
        | JTokenType.Array ->
            let renderAssertion testedFunction expected =
                this.RenderAssertEqualWithin (sprintf "%s sut" testedFunction) expected

            [ canonicalDataCase.Expected.[0] |> renderNumber |> renderAssertion "real"
              canonicalDataCase.Expected.[1] |> renderNumber |> renderAssertion "imaginary" ]
        | _ ->
            base.RenderAssert(canonicalDataCase)

    override __.PropertiesWithIdentifier canonicalDataCase = 
        match canonicalDataCase.Expected.Type with
        | JTokenType.Array -> ["sut"]
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
        let lines = value.ToObject<string list>()
        let padSize = List.last lines |> String.length

        lines
        |> Seq.map (fun line -> line.PadRight(padSize))
        |> List.renderMultiLine

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

    member __.RenderSet (jToken: JToken) =
        jToken
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
        | _ -> Obj.render canonicalDataCase.Expected

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
                let valueVar = sprintf "let element = %s" (Obj.render canonicalDataCase.Input.["element"])
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

type DiffieHellman() =
    inherit GeneratorExercise()

    override __.RenderValue (canonicalDataCase, key, value) = 
        match canonicalDataCase.Property, value.Type with
        | _, JTokenType.Integer ->
            sprintf "%dI" (value.ToObject<int>())
        | "keyExchange", _ ->
            value.ToObject<string>().Replace(",", "").Replace("(", " ").Replace(")", "")
        | _ ->
            base.RenderValue(canonicalDataCase, key, value)

    override __.RenderArrange canonicalDataCase =
        let arrange = base.RenderArrange canonicalDataCase

        match canonicalDataCase.Property with
        | "privateKeyIsInRange" | "privateKeyIsRandom" ->
            List.append arrange ["let privateKeys = [for _ in 0 .. 10 -> privateKey p]" ]
        | _ -> arrange

    override this.RenderAssert canonicalDataCase =
        match canonicalDataCase.Property with
        | "privateKeyIsInRange" ->
            let greaterThan = canonicalDataCase.Expected.["greaterThan"].ToObject<int>()
            let lessThan = canonicalDataCase.Expected.["lessThan"].ToObject<string>()

            [ sprintf "privateKeys |> List.iter (fun x -> x |> should be (greaterThan %dI))" greaterThan;
              sprintf "privateKeys |> List.iter (fun x -> x |> should be (lessThan %s))" lessThan ]
        | "privateKeyIsRandom" -> 
            [ this.RenderAssertEqual "List.distinct privateKeys |> List.length" "(List.length privateKeys)" ]
        | "keyExchange" ->
            [ this.RenderAssertEqual "secretA" "secretB" ]
        | _ -> base.RenderAssert canonicalDataCase

    override __.MapCanonicalDataCase canonicalDataCase =
        match canonicalDataCase.Property with
        | "privateKeyIsInRange" | "privateKeyIsRandom" ->
            { canonicalDataCase with Input = Map.add "p" (JToken.Parse("7919")) canonicalDataCase.Input }
        | _ -> base.MapCanonicalDataCase canonicalDataCase

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.PropertiesUsedAsSutParameter canonicalDataCase =
        match canonicalDataCase.Property with
        | "publicKey" -> 
            ["p"; "g"; "privateKey"]
        | "secret" ->
            ["p"; "theirPublicKey"; "myPrivateKey"]
        | "keyExchange" ->
            ["p"; "g"; "alicePrivateKey"; "alicePublicKey"; "bobPrivateKey"; "bobPublicKey"; "secretA"; "secretB"]
        | _ ->
            base.PropertiesUsedAsSutParameter canonicalDataCase

type Dominoes() =
    inherit GeneratorExercise()
    
    let formatAsTuple (value: JToken) =
        let items = value.ToObject<int list>()
        Obj.render (items.[0], items.[1])

    override __.RenderInput (_, _, value) = List.mapRender formatAsTuple value

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type Etl() =
    inherit GeneratorExercise()

    override __.RenderInput (_, _, value) = Map.render<int, char list> value

    override __.RenderExpected (_, _, value) = Map.render<char, int> value

    override __.MapCanonicalDataCase canonicalDataCase = 
        { canonicalDataCase with Input = Map.empty |> Map.add "lettersByScore" (canonicalDataCase.Properties.["input"]) }

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type FoodChain() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) = List.renderMultiLine value

type Forth() =
    inherit GeneratorExercise()

    override __.PropertiesWithIdentifier _ = ["expected"]
    
    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonNull 
        |> Option.render

    override __.IdentifierTypeAnnotation (_, _, value) = 
        let isEmptyList = value |> Option.ofNonNull |> Option.map Seq.isEmpty

        match isEmptyList with 
        | Some true -> Some "int list option"
        | _ -> None

    override __.UseFullMethodName _ = true

type Gigasecond() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) =
        value.ToObject<DateTime>()
        |> DateTime.renderParenthesized
 
    override __.RenderInput (_, _, value) =
         DateTime.Parse(string value, CultureInfo.InvariantCulture)
         |> DateTime.renderParenthesized

    override __.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type GoCounting() =
    inherit GeneratorExercise()

    let renderOwner (value: JToken) = Obj.renderEnum "Owner" (string value |> String.toLower)

    let renderTerritoryPosition (value: JToken) =
        let arr = value.ToObject<int list>()
        Obj.render (arr.[0], arr.[1])

    let renderTerritory (value: JToken) = List.mapRender renderTerritoryPosition value

    let renderTerritoryWithOwner (value: JToken) =
        let owner = renderOwner value.["owner"]
        let territory = renderTerritory value.["territory"]
        sprintf "(%s, %s)" owner territory

    let renderExpectedTerritory (expected: JToken) = 
        match Option.ofNonErrorObject expected with
        | None -> "Option.None"
        | Some expected -> expected |> renderTerritoryWithOwner |> sprintf "Option.Some %s"
    
    let renderExpectedTerritories (expected: JToken) = 
        let black = sprintf "(Owner.Black, %s)" (expected.["territoryBlack"] |> renderTerritory)
        let white = sprintf "(Owner.White, %s)" (expected.["territoryWhite"] |> renderTerritory)
        let none  = sprintf "(Owner.None, %s)"  (expected.["territoryNone"]  |> renderTerritory)

        let formattedList = List.mapRenderMultiLine id [black; white; none]
        sprintf "%s\n%s" formattedList (String.indent 2 "|> Map.ofList")

    let territoryPosition (input: Map<string, JToken>) =
        let valueToInt key = input |> Map.find key |> string |> int
        let position = sprintf "{ \"x\": %d, \"y\": %d }" (valueToInt "x") (valueToInt "y")
        JToken.Parse(position)

    let mapTerritoryInput (input: Map<string, JToken>) =
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
        | "board" -> List.renderMultiLine value
        | "position" ->
            (value.SelectToken("x").ToObject<int>(), value.SelectToken("y").ToObject<int>())
            |> Obj.render
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
                if Seq.isEmpty value.["territory"] then
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

    override __.RenderExpected (_, _, value) = List.renderMultiLine value |> indentExpected

    override __.RenderSetup _ = renderTemplate "Generators/GrepSetup" Map.empty<string, obj>

    override __.RenderArrange canonicalDataCase =
        base.RenderArrange canonicalDataCase @ [""; "createFiles() |> ignore"]

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key with
        | "expected" ->
            match Seq.isEmpty value  with 
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

    override __.RenderExpected (_, _, value) = List.renderMultiLine value

type IsbnVerifier() =
    inherit GeneratorExercise()

type Isogram() =
    inherit GeneratorExercise()

type KindergartenGarden() =
    inherit GeneratorExercise()

    let renderPlantEnum value = Obj.renderEnum "Plant" value

    override __.RenderExpected (_, _, value) = List.mapRender renderPlantEnum value

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
        |> DateTime.renderParenthesized

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "dayofweek" -> Obj.renderEnum "DayOfWeek" canonicalDataCase.Input.["dayofweek"]
        | "week" -> Obj.renderEnum "Week" canonicalDataCase.Input.["week"]
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.PropertiesUsedAsSutParameter _ = ["year"; "month"; "week"; "dayofweek"]

    override __.AdditionalNamespaces = [typeof<DateTime>.Namespace]

type Minesweeper() =
    inherit GeneratorExercise()

    override __.RenderInput (_, _, value) = List.renderMultiLine value

    override __.RenderExpected (_, _, value) = List.renderMultiLine value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (_, _, value) = 
        match Seq.isEmpty value with 
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

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonErrorObject
        |> Map.renderOption<char, int>

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type OcrNumbers() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderExpected (_, _, value) = 
        value 
        |> Option.ofNonNegativeNumber 
        |> Option.renderParenthesized

    override __.RenderInput (_, _, value) = List.renderMultiLine value

type Pangram() =
    inherit GeneratorExercise()

type PalindromeProducts() =
    inherit GeneratorExercise()

    let toFactors (value: JToken) =
        sprintf "(%s, %s)" (string value.[0]) (string value.[1])

    let toPalindromeProducts (value: JToken) =
        let palindromeValue = value.Value<int>("value")
        let factors = 
            value.SelectToken("factors")
            |> List.mapRender toFactors

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
        match value.Type with
        | JTokenType.Array  ->
            let formattedList = List.renderMultiLine value

            if (formattedList.Contains("\n")) then
                sprintf "%s\n%s" formattedList (String.indent 2 "|> Some")
            else   
                sprintf "%s |> Some" formattedList
        | _ -> "None"

    override __.IdentifierTypeAnnotation (canonicalDataCase, key, value) = 
        match key, value.Type with 
        | "expected", JTokenType.Array ->
            match Seq.isEmpty value with 
            | true  -> Some "int list list option"
            | false -> None    
        | _ -> base.IdentifierTypeAnnotation (canonicalDataCase, key, value)       

    override __.AssertTemplate _ = "AssertEqual"
    
type PerfectNumbers() =
    inherit GeneratorExercise()

    let toClassification value = Obj.renderEnum "Classification" value

    override __.RenderExpected (_, _, value) = 
        value
        |> Option.ofNonErrorObject
        |> Option.map toClassification
        |> Option.renderStringParenthesized

type PhoneNumber() =
    inherit GeneratorExercise()
    
    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofNonNull
        |> Option.renderParenthesized

type PigLatin() =
    inherit GeneratorExercise()

type Poker() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

type Pov() = 
    inherit GeneratorExercise()

    let isNull (jToken: JToken) = jToken.Type = JTokenType.Null

    override __.RenderSetup _ = 
        ["let rec graphToList (graph: Graph<'a>) = "
         "    let right ="
         "        graph.children"
         "        |> List.sortBy (fun x -> x.value)"
         "        |> List.collect graphToList"
         "    [graph.value] @ right"
         "let mapToList graph = match graph with | Some x -> graphToList x | None -> []"
        ] |> String.concat "\n"

    member this.RenderNode (tree: JToken) : string = 
        match isNull tree with
        | true -> ""
        | false ->
            let node = tree.ToObject<Collections.Generic.Dictionary<string, JToken>>()
            let children = 
                if node.ContainsKey "children" then
                    List.mapRender this.RenderNode node.["children"]
                else
                    "[]"
            let label = Obj.render node.["label"]
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
            let from = Obj.render canonicalDataCase.Input.["from"]
            match isNull canonicalDataCase.Expected with
            | false -> sprintf "fromPOV %s tree |> mapToList " from
            | true -> sprintf "fromPOV %s tree " from
        | "pathTo" -> 
            let fromValue = Obj.render canonicalDataCase.Input.["from"]
            let toValue = Obj.render canonicalDataCase.Input.["to"]
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
                canonicalDataCase.Expected
                |> List.render 
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

    override __.RenderExpected (_, _, value) = List.renderMultiLine value
    
    override __.IdentifierTypeAnnotation (_, _, value) = 
        match Seq.isEmpty value with 
        | true  -> Some "string list"
        | false -> None
    
type QueenAttack() =
    inherit GeneratorExercise()

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "create" -> value.ToObject<int>() <> -1 |> Obj.render
        | _ -> base.RenderExpected (canonicalDataCase, key, value)

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "queen" | "white_queen" | "black_queen" ->
            let position = value.SelectToken("position")
            Obj.render (position.["row"].ToObject<int>(), position.["column"].ToObject<int>())
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
        match value.Type with
        | JTokenType.Array -> sprintf "(create %d %d)" (value.[0].Value<int>()) (value.[1].Value<int>())
        | _ -> base.RenderValue (canonicalDataCase, key, value)

    override __.AssertTemplate canonicalDataCase =
        match canonicalDataCase.Expected.Type with
        | JTokenType.Float -> "AssertEqualWithin"
        | _ -> base.AssertTemplate(canonicalDataCase)

type React() = 
    inherit GeneratorExercise()

    let renderCells canonicalDataCase = 
        let reactorVar = sprintf "let %s = new %s()" "reactor" "Reactor"
        let cellVars = 
            canonicalDataCase.Input.["cells"]
            |> Seq.map (fun (cellValue: JToken) -> 
                let cellName = cellValue.["name"].ToObject<string>()
                match cellValue.["type"].ToObject<string>() with
                | "compute" ->
                    let funBody = 
                        cellValue.["compute_function"].ToObject<string>().Replace ("inputs", "values.")
                    let inputParams = 
                        (cellValue.["inputs"].ToObject<string list>() |> List.mapRender id)
                    
                    sprintf "let %s = reactor.createComputeCell %s (fun values -> %s)" cellName inputParams funBody
                | "input" -> 
                    let initialValue = cellValue.["initial_value"].ToObject<int>()
                    sprintf "let %s = reactor.createInputCell %s" cellName (Obj.render initialValue)
                | _ -> ""
            )
            |> Seq.toList
        [ reactorVar ] @ cellVars

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
        if not (isNull jToken) && jToken.Type = JTokenType.Array then
            jToken.ToObject<string list>() 
            |> Seq.map (sprintf "A.CallTo(fun() -> %sHandler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore")
        else        
            Seq.empty

    let renderSetValueOperation (op: JToken) = 
        seq { 
            let cellName = op.["cell"].ToObject<string>()
            let cellValue = op.["value"].ToObject<int>()
            yield sprintf "%s.Value <- %i" cellName cellValue
            yield! renderExpectedCallbacks op.["expect_callbacks"]
            yield! renderExpectedCallbacksNotToBeCalled op.["expect_callbacks_not_to_be_called"]
        }

    let renderAddCallbackOperation (op: JToken) =
        seq { 
            let callbackName = op.["name"].ToObject<string>()
            let cellName = op.["cell"].ToObject<string>() 
            let callbackHandlerName = sprintf "%sHandler" callbackName
            yield sprintf "let %s = A.Fake<Handler<int>>()" callbackHandlerName
            yield sprintf "%s.Changed.AddHandler %s" cellName callbackHandlerName 
        }

    let renderRemoveCallbackOperation (op: JToken) =
        seq {
            let cellName = op.["cell"].ToObject<string>()
            let callbackName = op.["name"].ToObject<string>()
            yield sprintf "%s.Changed.RemoveHandler %sHandler" cellName callbackName
        }
     
    member this.RenderExpectedCellValueOperation (op: JToken) =
        seq { 
            let cellName = op.["cell"].ToObject<string>()
            let expectedValue = op.["value"].ToObject<string>()
            yield this.RenderAssertEqual (sprintf "%s.Value" cellName) expectedValue 
        }

    member this.RenderOperations canonicalDataCase = 
        canonicalDataCase.Input.["operations"]
        |> Seq.collect this.RenderOperation
        |> Seq.toList

    member this.RenderOperation (op: JToken) =
        let opType = op.["type"].ToObject<string>()
        match opType with
        | "expect_cell_value" -> this.RenderExpectedCellValueOperation op
        | "set_value" -> renderSetValueOperation op
        | "add_callback" -> renderAddCallbackOperation op
        | "remove_callback" -> renderRemoveCallbackOperation op
        | _ -> failwith "Unknown operation type"

    override __.PropertiesWithIdentifier _ = []

    override __.RenderAssert _ = []

    override this.RenderArrange canonicalDataCase =
        let initialVars = renderCells canonicalDataCase
        let operations = this.RenderOperations canonicalDataCase
        initialVars @ operations

    override __.AdditionalNamespaces = ["FakeItEasy"]

type Rectangles() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

    override __.RenderInput (_, _, value) = List.renderMultiLine value

type ReverseString() =
    inherit GeneratorExercise()

type RobotSimulator() =
    inherit GeneratorExercise()

    let parseInput (token: JToken) =
        let direction = token.SelectToken "direction" |> Option.ofObj
        let position  = token.SelectToken "position"  |> Option.ofObj
        (direction, position)

    let renderDirection (value: JToken) = Obj.renderEnum "Direction" value

    let renderPosition (position: JToken) = 
        Obj.render (position.["x"].ToObject<int>(), position.["y"].ToObject<int>())

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
            this.RenderAssertEqual (sprintf "sut.%s" prop) expected

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
        | "instructions" -> sprintf "instructions %s robot" (Obj.render canonicalDataCase.Input.["instructions"])
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

    let renderSaddlePoint (input: JToken) =
        Obj.render (input.Value<int>("row"), input.Value<int>("column"))

    override __.RenderInput (_, _, value) = List.renderMultiLine value

    override __.RenderExpected (_, _, value) = List.mapRender renderSaddlePoint value

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

type SecretHandshake() =
    inherit GeneratorExercise()

type Series() =
    inherit GeneratorExercise()
    
    override __.RenderExpected (_, _, value) =
        value 
        |> Option.ofNonErrorObject
        |> Option.renderParenthesized

type SimpleCipher() = 
    inherit GeneratorExercise()

    let normalizeText input (canonicalDataCase: CanonicalDataCase) =
        match string input with
        | "cipher.key.substring(0, plaintext.length)" ->
            sprintf "sut.Key.[0..%d]" (canonicalDataCase.Input.["plaintext"].ToObject<string>().Length - 1)
        | "cipher.key.substring(0, expected.length)" ->
            sprintf "sut.Key.[0..%d]" (canonicalDataCase.Expected.ToObject<string>().Length - 1)
        | _ ->
            Obj.render input

    override __.RenderArrange canonicalDataCase =
        match canonicalDataCase.Property with
        | "new" -> []
        | _ ->
            let key = 
                match canonicalDataCase.Input.TryFind "key" with
                | (Some x) -> Obj.render x
                | None -> ""
            [sprintf "let sut = SimpleCipher(%s)" key]

    override this.RenderAssert canonicalDataCase =
        match canonicalDataCase.Property with
        | "new" ->
            let key = Obj.render canonicalDataCase.Input.["key"]
            [this.RenderAssertThrows (sprintf "SimpleCipher(%s)" key) typeof<ArgumentException>.Name]
        | "key" ->
            let pattern = Obj.render canonicalDataCase.Expected.["match"]
            [this.RenderAssertEqual (sprintf "Regex.IsMatch(sut.Key, %s)" pattern) (Obj.render true)]
        | _ -> base.RenderAssert canonicalDataCase

    override __.RenderSut canonicalDataCase =
        match canonicalDataCase.Property with
        | "encode" ->
            sprintf "sut.Encode(%s)" (normalizeText canonicalDataCase.Input.["plaintext"] canonicalDataCase)
        | "decode" -> 
            match canonicalDataCase.Input.TryFind "plaintext" with
            | Some plaintext ->
                sprintf "sut.Decode(sut.Encode(%s))" (Obj.render plaintext)
            | None -> 
                sprintf "sut.Decode(%s)" (normalizeText canonicalDataCase.Input.["ciphertext"] canonicalDataCase)
        | _ ->
            base.RenderSut canonicalDataCase

    override __.RenderExpected (canonicalDataCase, _, value) = normalizeText value canonicalDataCase

    override __.UseFullMethodName _ = true

    override __.AdditionalNamespaces =
        [ typeof<System.Text.RegularExpressions.Regex>.Namespace;
          typeof<System.ArgumentException>.Namespace ]

type SpaceAge() =
    inherit GeneratorExercise()

    override __.RenderInput (canonicalDataCase, key, value) =
        match value.Type with
        | JTokenType.String -> value.ToObject<string>()
        | JTokenType.Integer -> sprintf "%dL" (value.ToObject<int64>())
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.AssertTemplate _ = "AssertEqualWithin"

type SpiralMatrix() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = List.renderMultiLine value

type Sublist() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = Obj.renderEnum "SublistType" value

    override this.PropertiesWithIdentifier canonicalDataCase = this.PropertiesUsedAsSutParameter canonicalDataCase

type SumOfMultiples() =
    inherit GeneratorExercise()

type Tournament() = 
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderValue (_, _, value) = List.renderMultiLine value

type TwelveDays() =
    inherit GeneratorExercise()

    override __.PropertiesUsedAsSutParameter _ = ["startVerse"; "endVerse"]

    override __.PropertiesWithIdentifier _ = ["expected"]

    override __.RenderExpected (_, _, value) = List.renderMultiLine value

type Transpose() =
    inherit GeneratorExercise()

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.IdentifierTypeAnnotation (_, _, value) = 
        match Seq.isEmpty value with 
        | true  -> Some "string list"
        | false -> None

    override __.RenderValue (_, _, value) = List.renderMultiLine value

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

    override __.RenderInput (_, _, value) = List.mapRender formatFloat value

type TwoBucket() =
    inherit GeneratorExercise()

    let renderBucket (value: JToken) = Obj.renderEnum "Bucket" value

    override this.PropertiesWithIdentifier canonicalDataCase = this.Properties canonicalDataCase

    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "startBucket" -> renderBucket value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.RenderExpected (_, _, value) =
        let moves       = value.["moves"].ToObject<int>()
        let goalBucket  = renderBucket value.["goalBucket"]
        let otherBucket = value.["otherBucket"].ToObject<int>()
        sprintf "{ Moves = %d; GoalBucket = %s; OtherBucket = %d }" moves goalBucket otherBucket

type TwoFer() =
    inherit GeneratorExercise()

    override __.RenderInput (_, _, value) =
        value
        |> Option.ofNonNull
        |> Option.renderParenthesized

type VariableLengthQuantity() = 
    inherit GeneratorExercise()

    let formatUnsignedByteList (value: JToken) =
        value.ToObject<byte list>()
        |> List.mapRender (sprintf "0x%xuy")

    let formatUnsignedIntList (value: JToken) =
        value.ToObject<uint32 list>()
        |> List.mapRender (sprintf "0x%xu")

    override __.RenderInput (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "encode" -> formatUnsignedIntList value
        | "decode" -> formatUnsignedByteList value
        | _ -> base.RenderInput (canonicalDataCase, key, value)

    override __.RenderExpected (canonicalDataCase, key, value) =
        match canonicalDataCase.Property with
        | "encode" -> formatUnsignedByteList value
        | "decode" -> 
            value
            |> Option.ofNonNull
            |> Option.map formatUnsignedIntList
            |> Option.renderStringParenthesized
        | _ -> base.RenderExpected (canonicalDataCase, key, value)
        
type WordCount() =
    inherit GeneratorExercise()

    override __.RenderExpected (_, _, value) = Map.render<string, int> value

    override __.PropertiesWithIdentifier _ = ["expected"]

type WordSearch() =
    inherit GeneratorExercise()

    let toCoordinates (value: JToken) = (value.Value<int>("column"), value.Value<int>("row"))

    let renderExpectedCoordinates (value: JObject) =
        Obj.render (value.Item("start") |> toCoordinates, value.Item("end") |> toCoordinates)

    let renderExpectedValue (value: JObject) =
        match isNull value with
        | true  -> "Option<((int * int) * (int * int))>.None"
        | false -> renderExpectedCoordinates value |> Some |> Option.renderString

    override __.RenderExpected (_, _, value) = 
        Map.mapRender (fun kv -> sprintf "(%s, %s)" (Obj.render kv.Key) (renderExpectedValue kv.Value)) value

    override __.RenderInput (canonicalDataCase, key, value) = 
        match key with
        | "grid" -> List.renderMultiLine value
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

    let dieValueToEnumName = function
        | 1 -> "One"
        | 2 -> "Two"
        | 3 -> "Three"
        | 4 -> "Four"
        | 5 -> "Five"
        | 6 -> "Six"
        | n -> failwith ("Invalid die value: " + n.ToString())

    let formatDieList (value: JToken) =
        let listValues = 
            value.ToObject<int list>()
            |> List.map dieValueToEnumName
            |> List.map (Obj.renderEnum "DieValue")
            |> String.concat "; "
        in
        "[" + listValues + "]"
    override __.RenderInput (canonicalDataCase, key, value) =
        match key with
        | "category" -> Obj.renderEnum "Category" value
        | "dice" -> formatDieList value
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

    let renderOperations (operations: JToken) =
        operations
        |> Seq.mapi (renderOperation (Seq.length operations))
        |> Seq.concat
        |> String.concat " |> "
        |> sprintf "|> %s"

    let renderTreeWithIdentifier identifier (tree: JToken) =
        tree
        |> renderTree true
        |> sprintf "let %s = %s" identifier

    let renderZipperWithIdentifier identifier (tree: JToken) =
        let renderedTree = renderTree true tree
        sprintf "let %s = fromTree (%s)" identifier renderedTree

    let renderExpectedZipperWithIdentifier identifier (tree: JToken) (operations: JToken) =
        let renderedTree = renderTree true tree
        let renderedOperations = renderOperations operations
        sprintf "let %s = fromTree (%s) %s" identifier renderedTree renderedOperations

    let renderSut (operations: JToken) =
        operations
        |> renderOperations
        |> sprintf "let sut = zipper %s"

    let renderExpected (expected: JToken) =
        match expected.["type"] |> string with
        | "int" -> 
            expected.["value"] |> string |> sprintf "let expected = %s"
        | "zipper" ->
            match expected.["initialTree"] with
            | :? JObject as jObject -> 
                renderExpectedZipperWithIdentifier "expected" jObject expected.["operations"]
            | _ -> 
                "let expected = None"
        | "tree" ->
            expected.["value"] |> renderTreeWithIdentifier "expected"
        | _ -> failwith "Unknown expected type"

    override __.RenderSetup _ = 
        [ "let subTree value left right = Some (tree value left right)"
          "let leaf value = subTree value None None" ]
        |> String.concat "\n"      

    override __.PropertiesWithIdentifier _ = ["initialTree"; "sut"; "expected"]

    override __.RenderArrange canonicalDataCase = 
        let tree = canonicalDataCase.Input.["initialTree"] |> renderZipperWithIdentifier "zipper"
        let sut = canonicalDataCase.Input.["operations"] |> renderSut
        let expected = canonicalDataCase.Expected |> renderExpected
        [tree; sut; expected]

    override __.TestMethodName canonicalDataCase = 
        base.TestMethodName canonicalDataCase |> String.replace "Set_" "Set "