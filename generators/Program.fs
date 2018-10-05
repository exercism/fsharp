module Generators.Program

open Serilog
open Exercise
open CanonicalData
open Options

let private isNotFilteredByName options (exercise: Exercise) =
    match options.Exercise with
    | Some filteredExerciseName -> filteredExerciseName = exerciseName exercise
    | None -> true
    
let private isNotFilteredByStatus options (exercise: Exercise) =
    match options.Status, exercise with
    | None, _ -> true
    | Some Status.Implemented,   Exercise.Generator _     -> true
    | Some Status.Unimplemented, Exercise.Unimplemented _ -> true
    | Some Status.MissingData,   Exercise.MissingData _   -> true
    | Some Status.Deprecated,    Exercise.Deprecated _    -> true
    | Some Status.Custom,        Exercise.Custom _        -> true
    | _ -> false

let private shouldBeIncluded options (exercise: Exercise) =
    isNotFilteredByName options exercise &&
    isNotFilteredByStatus options exercise

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
    |> List.filter (shouldBeIncluded options)
    |> function
        | [] -> Log.Warning"No exercises matched given options."
        | exercises ->
            List.iter regenerateTestClass' exercises
            Log.Information("Re-generated test classes.")

let private checkOutdated options =
    Log.Information("Checking for outdated test classes...")
    
    let parseCanonicalData' = parseCanonicalData options
    
    let e = createExercises options
    e |> List.iter (fun ex ->
        match ex with
        | Generator g -> 
            let what = g.Properties
            printfn "generator test: %s" g.Name
            let cData = parseCanonicalData' g.Name
            printfn "cdata version %s" cData.Version
            let ver = g.ReadVersion ()
            printfn "exercise version %s" ver
        | _ -> ()
    )
    ()
    

[<EntryPoint>]
let main argv = 
    Logging.setupLogger()

    match parseOptions argv with
    | Ok(options) when options.CheckOutdated ->
        checkOutdated options
        0
    | Ok(options) -> 
        regenerateTestClasses options
        0
    | Error(errors) -> 
        Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
        1