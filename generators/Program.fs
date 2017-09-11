open System
open CommandLine

type Options = {
  [<CommandLine.Option('e', "exercises", Required = false, 
    HelpText = "Exercises to generate (if not specified, defaults to all exercises).")>] Exercises : seq<string>;
  [<CommandLine.Option('d', "canonicaldatadirectory", Required = false, 
    HelpText = "Canonical data directory. If the directory does not exist, the canonical data will be downloaded.")>] CanonicalDataDirectory : string;
  [<CommandLine.Option('c', "cachecanonicaldata", Required = false, 
    HelpText = "Use the cached canonical data and don't update the data.")>] CacheCanonicalData : bool;
}

let run options = 
  printfn "%A" options
  0

let fail errors =
  printfn "Errors: %A\n" errors
  1

[<EntryPoint>]
let main argv =
    let result = CommandLine.Parser.Default.ParseArguments<Options>(argv)
    match result with
    | :? Parsed<Options> as parsed -> run parsed.Value
    | :? NotParsed<Options> as notParsed -> fail notParsed.Errors
    | _ -> fail "Error parsing arguments"
