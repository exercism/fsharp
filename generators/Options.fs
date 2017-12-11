module Generators.Options

open System
open System.IO
open CommandLine

type Options = {
  [<Option('e', "exercise", Required = false, 
    HelpText = "Exercise to generate (if not specified, defaults to all exercises).")>] Exercise : string;
  [<Option('d', "canonicaldatadirectory", Required = false, 
    HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")>] CanonicalDataDirectory : string;
  [<Option('s', "skipupdatecanonicaldata", Required = false,
    HelpText = "Don't update the canonical data.")>] SkipUpdateCanonicalData : bool;
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
    | _ -> Result.Error(Seq.singleton "Invalid parsing result")