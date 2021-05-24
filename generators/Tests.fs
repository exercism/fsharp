module Generators.Tests

open System
open System.IO
open Serilog
open LibGit2Sharp
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Options

type TestCase = 
    { Input: Map<string, JToken>
      Expected: JToken
      Property: string
      Properties: Map<string, JToken>
      Description: string
      DescriptionPath: string list }

let private probSpecsCloneUrl = "https://github.com/exercism/problem-specifications.git";
let private probSpecsBranch = "main";
let private probSpecsRemote = "origin";
let private probSpecsRemoteBranch = $"{probSpecsRemote}/{probSpecsBranch}";

let private probSpecsDir options =
    let defaultProbSpecsDir =
        let appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Path.Combine(appDataDirectory, "exercism", "problem-specifications")
        
    Option.defaultValue defaultProbSpecsDir options.ProbSpecsDir 

let private cloneRepository options =
    Log.Debug("Cloning problem-specifications repository...")
    Repository.Clone(probSpecsCloneUrl, probSpecsDir options) |> ignore
    Log.Debug("Problem-specifications repository cloned.")

let private updateToLatestVersion options =
    Log.Debug("Updating problem-specifications latest version...");

    use repository = new Repository(probSpecsDir options)
    Commands.Fetch(repository, probSpecsRemote, Seq.empty, FetchOptions(), null)

    let remoteBranch = repository.Branches.[probSpecsRemoteBranch];
    repository.Reset(ResetMode.Hard, remoteBranch.Tip);

    Log.Debug("Updated problem-specifications to latest version.");

let shouldCloneRepository options = options.ProbSpecsDir.IsNone && not (Directory.Exists(probSpecsDir options))

let shouldUpdateToLatestVersion options = options.ProbSpecsDir.IsNone

let private downloadData options =
    if shouldCloneRepository options then
        cloneRepository options
        
    if shouldUpdateToLatestVersion options then
        updateToLatestVersion options

type CanonicalDataConverter() =
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

    let createCanonicalDataCaseFromJToken (jToken: JToken) =
        let properties = Map.ofJToken jToken

        { Input = Map.ofJToken properties.["input"]
          Expected = properties.["expected"]
          Property = string properties.["property"]
          Properties = properties
          Description = string properties.["description"]
          DescriptionPath = createDescriptionPathFromJToken jToken }

    let rec getCanonicalDataCaseJTokens(jToken: JToken) =
        match jToken with
        | :? JArray as jArray ->
            Seq.collect getCanonicalDataCaseJTokens jArray
        | :? JObject as jObject when jObject.ContainsKey("property") ->
            Seq.singleton jObject
        | :? JObject as jObject when jObject.ContainsKey("cases") ->
            Seq.collect getCanonicalDataCaseJTokens jObject.["cases"]
        | _ -> Seq.empty

    let createCanonicalDataCasesFromJToken (jToken: JToken) =  
        jToken.["cases"]
        |> getCanonicalDataCaseJTokens
        |> Seq.map createCanonicalDataCaseFromJToken
        |> Seq.toList

    override _.WriteJson(_: JsonWriter, _: obj, _: JsonSerializer) = failwith "Not supported"

    override _.ReadJson(reader: JsonReader, _: Type, _: obj, _: JsonSerializer) =
        let jToken = JToken.ReadFrom(reader)
        createCanonicalDataCasesFromJToken jToken :> obj

    override _.CanConvert(objectType: Type) = objectType = typeof<TestCase list>

let private convertCanonicalData canonicalDataContents = 
    let converter = CanonicalDataConverter()
    JsonConvert.DeserializeObject<TestCase list>(canonicalDataContents, converter)

let private canonicalDataFile options exercise = 
    Path.Combine(probSpecsDir options, "exercises", exercise, "canonical-data.json")

let private readCanonicalData options exercise = 
    canonicalDataFile options exercise
    |> File.ReadAllText

let findTestCases options = 
    downloadData options 

    fun exercise ->
        exercise
        |> readCanonicalData options 
        |> convertCanonicalData