module Generators.Options

open System
open System.IO
open CommandLine

type Status = 
    | Implemented
    | Unimplemented
    | MissingData
    | Custom

type CommandLineOptions = 
    { [<Option('e', "exercise", Required = false, 
        HelpText = "Exercise to generate (if not specified, defaults to all exercises).")>] Exercise : string;
      [<Option('s', "status", Required = false, 
        HelpText = "The generator status to filter on (defaults to exercises with generator).")>] Status : string;
      [<Option('d', "canonicaldatadirectory", Required = false, 
        HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")>] CanonicalDataDirectory : string;
      [<Option('c', "cachecanonicaldata", Required = false,
        HelpText = "Use the cached canonical data and don't update the data.")>] CacheCanonicalData : bool; }

type Options =
    { Exercise : string option
      Status : Status option
      CanonicalDataDirectory : string
      CacheCanonicalData : bool }

let private normalizeCanonicalDataDirectory canonicalDataDirectory = 
    if canonicalDataDirectory <> "" then
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
    | Some "all"           -> None
    | Some _               -> failwith "Invalid status" 
    | None                 -> Some Implemented

let private mapOptions (options: CommandLineOptions) =
    { Exercise = normalizeExercise options.Exercise
      Status = normalizeStatus options.Status
      CanonicalDataDirectory = normalizeCanonicalDataDirectory options.CanonicalDataDirectory
      CacheCanonicalData = options.CacheCanonicalData }

let parseOptions argv =  
    let result = CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(argv)
    match result with
    | :? Parsed<CommandLineOptions> as parsed -> 
        Result.Ok(mapOptions parsed.Value)
    | :? NotParsed<CommandLineOptions> as notParsed -> 
        Result.Error(notParsed.Errors |> Seq.map string)
    | _ -> 
        failwith "Invalid parsing result"