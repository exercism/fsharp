module Generators.Program

open Serilog
open Exercises
open Input
open Options

let regenerateTestClass options (exercise: Exercise) =
    let canonicalData = parseCanonicalData options exercise.Name
    exercise.Regenerate(canonicalData)

let regenerateTestClasses options =
    Log.Information("Re-generating test classes...")

    createExercises options.Exercises
    |> Seq.iter (regenerateTestClass options)

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