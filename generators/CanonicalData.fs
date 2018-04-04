module Generators.CanonicalData

open System
open System.IO
open System.Collections.Generic
open Serilog
open LibGit2Sharp
open Newtonsoft.Json
open Newtonsoft.Json.Linq
open Options

type CanonicalDataCase = 
    { Input: Map<string, obj>
      Expected: obj
      Property: string
      Properties: Map<string, obj>
      Description: string
      DescriptionPath: string list }

type CanonicalData = 
    { Exercise: string
      Version: string
      Cases: CanonicalDataCase list }

let [<Literal>] private ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";
let [<Literal>] private ProblemSpecificationsBranch = "master";
let [<Literal>] private ProblemSpecificationsRemote = "origin";
let [<Literal>] private ProblemSpecificationsRemoteBranch = ProblemSpecificationsRemote + "/" + ProblemSpecificationsBranch;

let private cloneRepository options =
    if (Directory.Exists(options.CanonicalDataDirectory)) then
        ()
    else
        Log.Information("Cloning repository...")

        Repository.Clone(ProblemSpecificationsGitUrl, options.CanonicalDataDirectory) |> ignore

        Log.Information("Repository cloned.")

let private updateToLatestVersion options =
    Log.Information("Updating repository to latest version...");

    use repository = new Repository(options.CanonicalDataDirectory)
    
    Commands.Fetch(repository, ProblemSpecificationsRemote, Seq.empty, FetchOptions(), null)
    
    let remoteBranch = repository.Branches.[ProblemSpecificationsRemoteBranch];
    repository.Reset(ResetMode.Hard, remoteBranch.Tip);

    Log.Information("Updated repository to latest version.");

let private downloadData options =
    if options.CacheCanonicalData then
        ()
    else
        cloneRepository options
        updateToLatestVersion options

type CanonicalDataConverter() =
    inherit JsonConverter()

    let jTokenToMap (jToken: JToken) =
        jToken.ToObject<IDictionary<string, obj>>()
        |> Dict.toMap

    let createDescriptionPathFromJToken (jToken: JToken): string list =
        let descriptionFromJToken (currentToken: JToken) =
            match currentToken.SelectToken("description") with
            | null ->  None
            | description -> Some (description.ToObject<string>())

        jToken
        |> Json.parentsAndSelf
        |> List.choose descriptionFromJToken

    let createInputFromJToken (properties: Map<string, obj>) = 
        properties.["input"] :?> JObject
        |> jTokenToMap

    let createCanonicalDataCaseFromJToken (jToken: JToken) =
        let properties = jTokenToMap jToken

        { Input = createInputFromJToken properties
          Expected = if properties.ContainsKey "expected" then properties.["expected"] else ("" :> obj)
          Property = string properties.["property"]
          Properties = properties
          Description = string properties.["description"]
          DescriptionPath = createDescriptionPathFromJToken jToken }

    let createCanonicalDataCasesFromJToken (jToken: JToken) =  
        jToken.["cases"].SelectTokens("$..*[?(@.property)]")
        |> Seq.map createCanonicalDataCaseFromJToken
        |> Seq.toList

    let createCanonicalDataFromJToken (jToken: JToken) =
        { Exercise = jToken.["exercise"].Value<string>()
          Version = jToken.["version"].Value<string>()
          Cases = createCanonicalDataCasesFromJToken jToken }

    override __.WriteJson(_: JsonWriter, _: obj, _: JsonSerializer) = failwith "Not supported"

    override __.ReadJson(reader: JsonReader, _: Type, _: obj, _: JsonSerializer) =
        let jToken = JToken.ReadFrom(reader)
        createCanonicalDataFromJToken jToken :> obj

    override __.CanConvert(objectType: Type) = objectType = typeof<CanonicalData>

let private convertCanonicalData canonicalDataContents = 
    let converter = CanonicalDataConverter()
    JsonConvert.DeserializeObject<CanonicalData>(canonicalDataContents, converter)

let private canonicalDataFile options exercise = 
    Path.Combine(options.CanonicalDataDirectory, "exercises", exercise, "canonical-data.json")

let private readCanonicalData options exercise = 
    canonicalDataFile options exercise
    |> File.ReadAllText

let hasCanonicalData options exercise =
    canonicalDataFile options exercise
    |> File.Exists

let parseCanonicalData options = 
    downloadData options 

    fun exercise ->
        exercise 
        |> readCanonicalData options 
        |> convertCanonicalData