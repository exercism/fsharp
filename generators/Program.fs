module Generators.Program

open Serilog
open Exercise
open Input
open Options

let private regenerateTestClass options =
    let parseCanonicalData' = parseCanonicalData options

    fun (exercise: Exercise) ->
        let canonicalData = parseCanonicalData' exercise.Name
        exercise.Regenerate(canonicalData)

let private regenerateTestClasses options =
    Log.Information("Re-generating test classes...")

    let regenerateTestClass' = regenerateTestClass options
    let filteredExercise = Option.ofNonEmptyString options.Exercise

    createExercises filteredExercise
    |> Seq.iter regenerateTestClass'

    Log.Information("Re-generated test classes.")

[<EntryPoint>]
let main argv = 
    Logging.setupLogger()

    match parseOptions argv with
    | Ok(options) -> 
        regenerateTestClasses options
        0
    | Error(errors) -> 
        Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
        1