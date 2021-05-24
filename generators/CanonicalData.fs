module Generators.CanonicalData

open System
open System.IO
open Serilog
open LibGit2Sharp
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Options

type CanonicalDataCase = 
    { Input: Map<string, JToken>
      Expected: JToken
      Property: string
      Properties: Map<string, JToken>
      Description: string
      DescriptionPath: string list }

type CanonicalData = 
    { Exercise: string
      Cases: CanonicalDataCase list }

let private ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
let private ProblemSpecificationsBranch = "main";
let private ProblemSpecificationsRemote = "origin";
let private ProblemSpecificationsRemoteBranch = ProblemSpecificationsRemote + "/" + ProblemSpecificationsBranch;

let private probSpecsDir options =
    let defaultProbSpecsDir =
        let appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        Path.Combine(appDataDirectory, "exercism", "problem-specifications")
        
    Option.defaultValue defaultProbSpecsDir options.ProbSpecsDir 

let private cloneRepository options =
    Log.Debug("Cloning problem-specifications repository...")
    Repository.Clone(ProblemSpecificationsGitUrl, probSpecsDir options) |> ignore
    Log.Debug("Problem-specifications repository cloned.")

let private updateToLatestVersion options =
    Log.Debug("Updating problem-specifications latest version...");

    use repository = new Repository(probSpecsDir options)
    Commands.Fetch(repository, ProblemSpecificationsRemote, Seq.empty, FetchOptions(), null)

    let remoteBranch = repository.Branches.[ProblemSpecificationsRemoteBranch];
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

    let createCanonicalDataFromJToken (jToken: JToken) =
        { Exercise = jToken.["exercise"].Value<string>()
          Cases = createCanonicalDataCasesFromJToken jToken }

    override _.WriteJson(_: JsonWriter, _: obj, _: JsonSerializer) = failwith "Not supported"

    override _.ReadJson(reader: JsonReader, _: Type, _: obj, _: JsonSerializer) =
        let jToken = JToken.ReadFrom(reader)
        createCanonicalDataFromJToken jToken :> obj

    override _.CanConvert(objectType: Type) = objectType = typeof<CanonicalData>

let private convertCanonicalData canonicalDataContents = 
    let converter = CanonicalDataConverter()
    JsonConvert.DeserializeObject<CanonicalData>(canonicalDataContents, converter)

let private canonicalDataFile options exercise = 
    Path.Combine(probSpecsDir options, "exercises", exercise, "canonical-data.json")

let private readCanonicalData options exercise = 
    canonicalDataFile options exercise
    |> File.ReadAllText

let parseCanonicalData options = 
    downloadData options 

    fun exercise ->
        exercise
        |> readCanonicalData options 
        |> convertCanonicalData