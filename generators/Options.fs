module Generators.Options

open System
open System.IO
open CommandLine
open CommandLine.Text

type Status = 
    | Implemented
    | Unimplemented
    | MissingData
    | Deprecated
    | Custom
    | Outdated
    | All

type CommandLineOptions =
    { [<Option('e', "exercise", Required = false, 
        HelpText = "Single exercise to generate.")>] Exercise : string;
      [<Option('s', "status", Required = false, 
        HelpText = "List exercises with the given status (nothing is generated).")>] Status : string;
      [<Option('d', "canonicaldatadirectory", Required = false, 
        HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")>] CanonicalDataDirectory : string;
      [<Option('c', "cachecanonicaldata", Required = false,
        HelpText = "Use the cached canonical data and don't update the data.")>] CacheCanonicalData : bool; 
    } with
          static member Defaults () =
              {
                Exercise = null
                Status = ""
                CanonicalDataDirectory = null
                CacheCanonicalData = false
              }
              
          [<Usage(ApplicationAlias = "dotnet run")>]
          static member Examples =
            [
                new Example("Generate all exercises", CommandLineOptions.Defaults())
                new Example("Generate the exercise named 'foobar'", {CommandLineOptions.Defaults() with Exercise = "foobar"})
                new Example("List outdated exercises", {CommandLineOptions.Defaults() with Status = "outdated"})
            ]

type Options =
    { Exercise : string option
      Status : Status option
      CanonicalDataDirectory : string
      CacheCanonicalData : bool }

let private normalizeCanonicalDataDirectory canonicalDataDirectory = 
    if not (String.IsNullOrWhiteSpace(canonicalDataDirectory)) then
        canonicalDataDirectory
    else
        let appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        let defaultCanonicalDataDirectory = Path.Combine(appDataDirectory, "exercism", "problem-specifications")
        defaultCanonicalDataDirectory
        
let private normalizeExercise exercise = Option.ofNonEmptyString exercise

let private normalizeStatus status =
    let normalizedStatus = 
        status 
        |> Option.ofNonEmptyString 
        |> Option.map String.toLower

    match normalizedStatus with
    | Some "implemented"   -> Some Implemented
    | Some "unimplemented" -> Some Unimplemented
    | Some "missingdata"   -> Some MissingData
    | Some "custom"        -> Some Custom
    | Some "deprecated"    -> Some Deprecated
    | Some "outdated"      -> Some Outdated
    | Some "all"           -> Some All
    | Some _               -> failwith "Invalid status" 
    | None                 -> None

let private mapOptions (options: CommandLineOptions) =
    { Exercise = normalizeExercise options.Exercise
      Status = normalizeStatus options.Status
      CanonicalDataDirectory = normalizeCanonicalDataDirectory options.CanonicalDataDirectory
      CacheCanonicalData = options.CacheCanonicalData }

let conflictingStatusAndExerciseParams (parsed:Parsed<CommandLineOptions>) =
    let s = parsed.Value.Status |> String.IsNullOrWhiteSpace |> not
    let e = parsed.Value.Exercise |> String.IsNullOrWhiteSpace |> not
    s && e
    
let parseOptions argv =  
    let result = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(argv)
    match result with
    | :? Parsed<CommandLineOptions> as parsed -> 
        Result.Ok(mapOptions parsed.Value)
    | :? NotParsed<CommandLineOptions> as notParsed -> 
        Result.Error(notParsed.Errors |> Seq.map string)
    | _ -> 
        failwith "Invalid parsing result"