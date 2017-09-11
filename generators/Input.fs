module Input

open System.IO
open Serilog
open LibGit2Sharp
open Newtonsoft.Json

type CanonicalDataCase = {
    Description: string;
}

type CanonicalData = {
    Exercise: string
    Version: string
    Cases: CanonicalDataCase[]
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

let parseCanonicalData options = 
    downloadData options

    let readCanonicalData' = readCanonicalData options
    fun exercise ->
        let canonicalDataContents = readCanonicalData' exercise
        JsonConvert.DeserializeObject<CanonicalData>(canonicalDataContents)

//  public class CanonicalDataCase
//     {
//         [Required]
//         public string Description { get; set; }

//         [Required]
//         public string Property { get; set; }

//         [JsonIgnore]
//         public IDictionary<string, object> Input { get; set; }

//         [JsonIgnore]
//         public IDictionary<string, object> ConstructorInput { get; set; }

//         public object Expected { get; set; }

//         [JsonIgnore]
//         public IDictionary<string, object> Properties { get; set; }

//         [JsonIgnore]
//         public bool UseVariablesForInput { get; set; }

//         [JsonIgnore]
//         public bool UseVariableForExpected { get; set; }

//         [JsonIgnore]
//         public bool UseVariablesForConstructorParameters { get; set; }

//         [JsonIgnore]
//         public bool UseVariableForTested { get; set; }

//         [JsonIgnore]
//         public TestedMethodType TestedMethodType { get; set; } = TestedMethodType.Static;

//         [JsonIgnore]
//         public Type ExceptionThrown { get; set; }
//     }

// public class CanonicalData
//     {
//         [Required]
//         public string Exercise { get; set; }

//         [Required]
//         public string Version { get; set; }

//         [JsonConverter(typeof(CanonicalDataCasesJsonConverter))]
//         public CanonicalDataCase[] Cases { get; set; }
//     }