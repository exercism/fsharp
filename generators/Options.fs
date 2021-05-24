module Generators.Options

open CommandLine

type CommandLineOptions =
    { [<Option('e', "exercise", Required = false, HelpText = "The exercise to generate.")>]
      Exercise : string option

      [<Option('d', "dir", Required = false, HelpText = "The directory of the problem-specifications repo. If the not specified, the repo will be downloaded.")>]
      ProbSpecsDir : string option }

type Options =
    { Exercise : string option
      ProbSpecsDir : string option      
      PracticeExercisesDir: string }

let private fromCommandLineOptions (options: CommandLineOptions) =
    { Exercise = options.Exercise
      ProbSpecsDir = options.ProbSpecsDir
      PracticeExercisesDir = System.IO.Path.Combine("..", "exercises", "practice") }

let private formatErrors errors =
    Seq.map string errors |> String.concat ", "

let parseOptions argv =
    match Parser.Default.ParseArguments<CommandLineOptions>(argv) with
    | :? Parsed<CommandLineOptions> as parsed ->
        Result.Ok(fromCommandLineOptions parsed.Value)
    | :? NotParsed<CommandLineOptions> as notParsed ->
        Result.Error(formatErrors notParsed.Errors)
    | _ ->
        failwith "Invalid parsing result"
