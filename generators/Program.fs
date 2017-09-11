open System
open CommandLine
open Serilog

type Options = {
  [<CommandLine.Option('e', "exercises", Required = false, 
    HelpText = "Exercises to generate (if not specified, defaults to all exercises).")>] Exercises : seq<string>;
  [<CommandLine.Option('d', "canonicaldatadirectory", Required = false, 
    HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")>] CanonicalDataDirectory : string;
  [<CommandLine.Option('c', "cachecanonicaldata", Required = false, 
    HelpText = "Use the cached canonical data and don't update the data.")>] CacheCanonicalData : bool;
}

let parseOptions argv =  
  let result = CommandLine.Parser.Default.ParseArguments<Options>(argv)
  match result with
  | :? Parsed<Options> as parsed -> Result.Ok(parsed.Value)
  | :? NotParsed<Options> as notParsed -> Result.Error(notParsed.Errors |> Seq.map string)
  | _ -> Result.Error(seq { yield "Error parsing command-line arguments" })

let setupLogger() =
  Log.Logger <- LoggerConfiguration()
      .WriteTo.LiterateConsole()
      .CreateLogger();

let regenerateTestClasses options =
  Log.Information("Re-generating test classes...")


  Log.Information("Re-generated test classes.")

[<EntryPoint>]
let main argv = 
  setupLogger()

  match parseOptions argv with
  | Result.Ok(options) -> 
    regenerateTestClasses options
    0
  | Result.Error(errors) -> 
    Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
    1