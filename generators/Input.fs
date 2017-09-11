module Generators.Input

open System
open System.IO
open System.Dynamic
open Serilog
open LibGit2Sharp
open Newtonsoft.Json
open Newtonsoft.Json.Linq

type CanonicalDataCase = {
    Description: string;
    Property: string;
    Properties: ExpandoObject;
}

type CanonicalData = {
    Exercise: string
    Version: string
    Cases: CanonicalDataCase list
}

[<Literal>]
let private ProblemSpecificationsGitUrl = "https://github.com/exercism/problem-specifications.git";

[<Literal>]
let private ProblemSpecificationsBranch = "master";

[<Literal>]
let private ProblemSpecificationsRemote = "origin";

[<Literal>]
let private ProblemSpecificationsRemoteBranch = ProblemSpecificationsRemote + "/" + ProblemSpecificationsBranch;

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
    cloneRepository options

    if (not options.CacheCanonicalData) then
        updateToLatestVersion options

let private readCanonicalData options exercise = 
    let exerciseCanonicalDataPath = Path.Combine(options.CanonicalDataDirectory, "exercises", exercise, "canonical-data.json")
    File.ReadAllText(exerciseCanonicalDataPath)

type CanonicalDataConverter() =
    inherit JsonConverter()

    let createCanonicalDataCaseFromJToken (jToken: JToken) =
        { Description = jToken.["description"].Value<string>()
          Property = jToken.["property"].Value<string>()
          Properties = jToken.ToObject<ExpandoObject>() }

    let createCanonicalDataCasesFromJToken (jToken: JToken) =  
        jToken.["cases"].SelectTokens("$..*[?(@.property)]")
        |> Seq.map createCanonicalDataCaseFromJToken
        |> Seq.toList

    let createCanonicalDataFromJToken (jToken: JToken) =
        { Exercise = jToken.["exercise"].Value<string>()
          Version = jToken.["version"].Value<string>()
          Cases = createCanonicalDataCasesFromJToken jToken }

    override this.WriteJson(writer: JsonWriter, value: obj, serializer: JsonSerializer) = failwith "Not supported"

    override this.ReadJson(reader: JsonReader, objectType: Type, existingValue: obj, serializer: JsonSerializer) =
        let jToken = JToken.ReadFrom(reader)
        createCanonicalDataFromJToken jToken :> obj

    override this.CanConvert(objectType: Type) = objectType = typeof<CanonicalData>

let parseCanonicalData options = 
    downloadData options

    let readCanonicalData' = readCanonicalData options
    fun exercise ->
        let canonicalDataContents = readCanonicalData' exercise
        JsonConvert.DeserializeObject<CanonicalData>(canonicalDataContents, CanonicalDataConverter())