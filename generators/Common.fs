[<AutoOpen>]
module Generators.Common

open System
open System.IO
open CommandLine
open Serilog
open Humanizer

type Options = {
  [<CommandLine.Option('e', "exercises", Required = false, 
    HelpText = "Exercises to generate (if not specified, defaults to all exercises).")>] Exercises : seq<string>;
  [<CommandLine.Option('d', "canonicaldatadirectory", Required = false, 
    HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")>] CanonicalDataDirectory : string;
  [<CommandLine.Option('c', "cachecanonicaldata", Required = false, 
    HelpText = "Use the cached canonical data and don't update the data.")>] CacheCanonicalData : bool;
}

let private normalizeOptions options = 
    if options.CanonicalDataDirectory <> "" then
        options 
    else
        let appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
        let defaultCanonicalDataDirectory = Path.Combine(appDataDirectory, "exercism", "problem-specifications")
        { options with CanonicalDataDirectory = defaultCanonicalDataDirectory }

let parseOptions argv =  
    let result = CommandLine.Parser.Default.ParseArguments<Options>(argv)
    match result with
    | :? Parsed<Options> as parsed -> Result.Ok(normalizeOptions parsed.Value)
    | :? NotParsed<Options> as notParsed -> Result.Error(notParsed.Errors |> Seq.map string)
    | _ -> Result.Error(seq { yield "Invalid parsing result" })

let setupLogger() =
    Log.Logger <- LoggerConfiguration()
        .WriteTo.LiterateConsole()
        .CreateLogger();

let toExerciseName (exerciseType: Type) = exerciseType.Name.Kebaberize()

let toTestedModuleName (exercise: string) = exercise.Dehumanize()

let toTestModuleName (exercise: string) = sprintf "%sTest" (toTestedModuleName exercise)

module String =
    let EqualsOrdinalIgnoreCase (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)