module Generators.Program

open Serilog
open Exercise
open CanonicalData
open Generators
open Options

let private isNotFilteredByName options (exercise: Exercise) =
    match options.Exercise with
    | Some filteredExerciseName -> filteredExerciseName = exerciseName exercise
    | None -> true
    

let private regenerateTestClass options =
    let parseCanonicalData' = parseCanonicalData options

    fun (exercise) ->
        match exercise with
        | Exercise.Custom custom ->
            Log.Information("{Exercise}: has customized tests", custom.Name)
        | Exercise.Unimplemented unimplemented ->
            Log.Error("{Exercise}: missing test generator", unimplemented.Name)
        | Exercise.MissingData missingData ->
            Log.Warning("{Exercise}: missing canonical data", missingData.Name)
        | Exercise.Deprecated deprecated ->
            Log.Warning("{Exercise}: deprecated", deprecated.Name)
        | Exercise.Generator generator ->
            let canonicalData = parseCanonicalData' generator.Name
            generator.Regenerate(canonicalData)
            Log.Information("{Exercise}: tests generated", generator.Name)

let private regenerateTestClasses options =
    Log.Information("Re-generating test classes...")

    let regenerateTestClass' = regenerateTestClass options
    
    createExercises options
    |> List.filter (isNotFilteredByName options)
    |> function
        | [] -> Log.Warning "No exercises matched given options."
        | exercises ->
            List.iter regenerateTestClass' exercises
            Log.Information("Re-generated test classes.")
            
            
                      

[<EntryPoint>]
let main argv = 
    Logging.setupLogger()

    match parseOptions argv with
    | Ok(options) when options.Status.IsSome && options.Exercise.IsSome -> 
        Log.Error("Can't have both -s and -e.")
        1
    | Ok(options) when options.Status.IsSome -> 
        Reporting.listExercises options
        0
    | Ok(options) -> 
        regenerateTestClasses options
        0
    | Error(errors) when errors |> Seq.contains "CommandLine.HelpRequestedError" ->
        0
    | Error(errors) -> 
        Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
        1