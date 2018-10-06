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

type ExerciseVersionStatus =
        | UpToDate
        | OutDated of string * string * string
        
let private checkOutdated options =
    Log.Information("Checking for outdated test classes...")
    
    let parseCanonicalData' = parseCanonicalData options
    
    let e = createExercises options
    let gens = e |> List.choose (fun ex ->
        match ex with
        | Generator g -> Some g
        | _ -> None
    )
    let results = gens |> List.map (fun ge ->
        let cData = parseCanonicalData' ge.Name
//            printfn "cdata version %s" cData.Version
        let cDataVersion = cData.Version
        let exerciseVersion = ge.ReadVersion ()
        
        match cDataVersion,exerciseVersion with
        | c,e when c.Equals e -> UpToDate
        | c,e when c.Equals(e) |> not -> OutDated (ge.Name,c,e)
        
    )
    let numUpToDate = results |> List.where (fun s -> s = UpToDate) |> List.length
    printfn "%d exercises up to date." numUpToDate
    let outdated = results |> List.choose (fun s ->
        match s with 
        | OutDated (x,y,z) -> Some (x,y,z)
        | UpToDate -> None
    )
    printfn "%d exercises outdated / mismatched:" outdated.Length
    
    let colLen = outdated |> List.map (fun (a,_,_) -> a.Length) |> List.max
    outdated |> List.iter (fun (a,b,c) ->
        let indent = colLen - a.Length + 2
        let pad = String.replicate indent " "
        printfn "%s%s%s -> %s" a pad c b
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