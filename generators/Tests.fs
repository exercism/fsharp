module Generators.Tests

open System
open System.IO
open Serilog
open LibGit2Sharp
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Options
open Tomlyn
open Tomlyn.Syntax

type TestCase = 
    { Uuid: string
      Input: Map<string, JToken>
      Expected: JToken
      Property: string
      Properties: Map<string, JToken>
      Description: string
      DescriptionPath: string list }

let private probSpecsCloneUrl = "https://github.com/exercism/problem-specifications.git";
let private probSpecsBranch = "main";
let private probSpecsRemote = "origin";
let private probSpecsRemoteBranch = $"{probSpecsRemote}/{probSpecsBranch}";

let private cloneProbSpecsRepo options =
    Log.Debug("Cloning problem-specifications repository...")
    Repository.Clone(probSpecsCloneUrl, options.ProbSpecsDir) |> ignore
    Log.Debug("Problem-specifications repository cloned.")

let private resetProbSpecsRepoToLatest options =
    Log.Debug("Updating problem-specifications latest version...");

    use repository = new Repository(options.ProbSpecsDir)
    Commands.Fetch(repository, probSpecsRemote, Seq.empty, FetchOptions(), null)

    let remoteBranch = repository.Branches.[probSpecsRemoteBranch];
    repository.Reset(ResetMode.Hard, remoteBranch.Tip);

    Log.Debug("Updated problem-specifications to latest version.");

let private downloadData options =
    if not (Directory.Exists(options.ProbSpecsDir)) then
        cloneProbSpecsRepo options
        
    resetProbSpecsRepoToLatest options

type TestCaseListConverter(enabledTests: Set<string>) =
    inherit JsonConverter()
    
    let rec parentsAndSelf (currentToken: JToken) =
        let rec helper acc (token: JToken) =
            match token with
            | null -> acc
            | _ -> helper (token::acc) token.Parent

        helper [] currentToken

    let createDescriptionPathFromJToken (jToken: JToken): string list =
        let descriptionFromJToken (currentToken: JToken) =
            match currentToken.SelectToken("description") with
            | null ->  None
            | description -> Some (description.ToObject<string>())

        jToken
        |> parentsAndSelf
        |> List.choose descriptionFromJToken        
        
    let createTestCaseFromJToken (jToken: JToken) =
        let properties = Map.ofJToken jToken

        { Uuid = string properties.["uuid"]
          Input = Map.ofJToken properties.["input"]
          Expected = properties.["expected"]
          Property = string properties.["property"]
          Properties = properties
          Description = string properties.["description"]
          DescriptionPath = createDescriptionPathFromJToken jToken }

    let rec getTestCaseJTokens(jToken: JToken) =
        match jToken with
        | :? JArray as jArray ->
            Seq.collect getTestCaseJTokens jArray
        | :? JObject as jObject when jObject.ContainsKey("property") ->
            Seq.singleton jObject
        | :? JObject as jObject when jObject.ContainsKey("cases") ->
            Seq.collect getTestCaseJTokens jObject.["cases"]
        | _ -> Seq.empty

    let isEnabledTestCase (testCase: TestCase) = enabledTests.Contains(testCase.Uuid)
    
    let createTestCaseListFromJToken (jToken: JToken) =  
        jToken.["cases"]
        |> getTestCaseJTokens
        |> Seq.map createTestCaseFromJToken
        |> Seq.filter isEnabledTestCase
        |> Seq.toList

    override _.WriteJson(_: JsonWriter, _: obj, _: JsonSerializer) = failwith "Not supported"

    override _.ReadJson(reader: JsonReader, _: Type, _: obj, _: JsonSerializer) =
        let jToken = JToken.ReadFrom(reader)
        createTestCaseListFromJToken jToken :> obj

    override _.CanConvert(objectType: Type) = objectType = typeof<TestCase list>

let private parseTestCaseList canonicalDataJson enabledTests = 
    let converter = TestCaseListConverter(enabledTests)
    JsonConvert.DeserializeObject<TestCase list>(canonicalDataJson, converter)

let private canonicalDataJsonPath options exercise = 
    Path.Combine(options.ProbSpecsDir, "exercises", exercise, "canonical-data.json")

let private readCanonicalDataJson options exercise = 
    canonicalDataJsonPath options exercise
    |> File.ReadAllText
    
let private testsTomlPath options exercise = 
    Path.Combine(options.PracticeExercisesDir, exercise, ".meta", "tests.toml")

let private readTestsToml options exercise = 
    testsTomlPath options exercise
    |> File.ReadAllText

let private findEnabledTestUuids options exercise =
    let includeMissingOrTrue (table: TableSyntaxBase) =
        table.Items
        |> Seq.tryFind (fun item -> item.Key.ToString().Trim() = "include")
        |> Option.map (fun item -> item.Value.ToString().Trim() = "true")
        |> Option.defaultValue true
    
    let toml = Toml.Parse(readTestsToml options exercise)
    
    toml.Tables
    |> Seq.filter includeMissingOrTrue
    |> Seq.map (fun table -> table.Name.ToString())
    |> Set.ofSeq
    
let findTestCases options = 
    downloadData options 

    fun exercise ->
        let enabledTestUuids = findEnabledTestUuids options exercise
        let canonicalData = readCanonicalDataJson options exercise
        
        parseTestCaseList canonicalData enabledTestUuids