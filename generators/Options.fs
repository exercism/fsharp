module Generators.Options

open System
open System.IO
open CommandLine

type CommandLineOptions =
    { [<Option('e', "exercise", Required = false, HelpText = "The exercise to generate.")>]
      Exercise : string option

      [<Option('d', "dir", Required = false, HelpText = "The directory of the problem-specifications repo. If the not specified, the repo will be downloaded.")>]
      ProbSpecsDir : string option }

type Options =
    { Exercise : string option
      ProbSpecsDir : string }

let defaultProbSpecsDir =
    let appDataDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
    Path.Combine(appDataDirectory, "exercism", "problem-specifications")

let private mapOptions (options: CommandLineOptions) =
    { Exercise = options.Exercise
      ProbSpecsDir = Option.defaultValue defaultProbSpecsDir options.ProbSpecsDir }
    
let parseOptions argv =
    match Parser.Default.ParseArguments<CommandLineOptions>(argv) with
    | :? Parsed<CommandLineOptions> as parsed ->
        Result.Ok(mapOptions parsed.Value)
    | :? NotParsed<CommandLineOptions> as notParsed ->
        Result.Error(Seq.map string notParsed.Errors |> String.concat ", ")
    | _ ->
        failwith "Invalid parsing result"
