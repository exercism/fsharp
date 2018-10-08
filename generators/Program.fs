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
    
let private isOutdated (exercise: GeneratorExercise) options (parseCanonicalData':string -> CanonicalData) =
    let cData = parseCanonicalData' exercise.Name
    match cData.Version,exercise.ReadVersion() with
    | canonVersion,exerciseVersion when canonVersion.Equals exerciseVersion -> false
    | canonVersion,exerciseVersion -> true
    
let private filterByStatus options (parseCanonicalData':string -> CanonicalData) (exercise: Exercise) =
    match options.Status, exercise with
    | None, _ -> true
    | Some Status.Implemented,   Exercise.Generator _     -> true
    | Some Status.Unimplemented, Exercise.Unimplemented _ -> true
    | Some Status.MissingData,   Exercise.MissingData _   -> true
    | Some Status.Deprecated,    Exercise.Deprecated _    -> true
    | Some Status.Custom,        Exercise.Custom _        -> true
    | Some Status.Outdated,      Exercise.Generator exercise when isOutdated exercise options parseCanonicalData' -> true
    | Some Status.All,           _                        -> true
    | _ -> false

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
            
            
type SummaryTypes =
    | Custom of string
    | Unimplemented of string
    | MissingData of string
    | Deprecated of string
    | UpToDate of string
    | Outdated of string * string * string
    
let private summarizeExercise options (parseCanonicalData':string -> CanonicalData) (exercise:Exercise)  =

    match exercise with
    | Exercise.Custom custom ->                 SummaryTypes.Custom custom.Name
    | Exercise.Unimplemented unimplemented ->   SummaryTypes.Unimplemented unimplemented.Name
    | Exercise.MissingData missingData ->       SummaryTypes.MissingData missingData.Name
    | Exercise.Deprecated deprecated ->         SummaryTypes.Deprecated deprecated.Name
    | Exercise.Generator generator ->
        let cData = parseCanonicalData' generator.Name
        
        match generator.ReadVersion (), cData.Version with
        | a,b when a.Equals b ->  UpToDate generator.Name
        | a,b -> Outdated (generator.Name,a,b)
                             
let private listExercises options =
    Log.Information(sprintf "Listing exercises with status %s..." (options.Status.Value.ToString()))
    
    let parseCanonicalData' = parseCanonicalData options
    
    let allExercises = createExercises options
    
    let longestNameLength = allExercises |> List.map exerciseName |> List.map (fun e -> e.Length) |> List.max
    let indentAfter (name:string) = String.replicate (longestNameLength+2-name.Length) " "
    
    let exerciseGroups = allExercises
                            |> List.filter (filterByStatus options parseCanonicalData')
                            |> List.map (summarizeExercise options parseCanonicalData')
                            |> List.groupBy (fun x -> x.GetType())
    
    exerciseGroups |> List.iter (fun (groupType,group) ->
        let description = match group.Head with
                          | SummaryTypes.Custom _ -> "have customized tests"
                          | SummaryTypes.Unimplemented _ -> "are missing test generator"
                          | SummaryTypes.MissingData _ -> "are missing canonical data"
                          | SummaryTypes.Deprecated _ -> "are deprecated"
                          | SummaryTypes.UpToDate _ -> "are up to date"
                          | SummaryTypes.Outdated _ -> "are outdated"
                          
        Log.Information("{num} exercises {description}", group.Length, description)
        
        group |> List.iter (fun exercise -> 
            match exercise with
            | SummaryTypes.Custom name ->                   Log.Information(" {name}",name)
            | SummaryTypes.Unimplemented name ->            Log.Information(" {name}",name)
            | SummaryTypes.MissingData name ->              Log.Information(" {name}",name)
            | SummaryTypes.Deprecated name ->               Log.Information(" {name}",name)
            | SummaryTypes.UpToDate name ->                 Log.Information(" {name}",name)
            | SummaryTypes.Outdated (name,oldVer,newVer) -> Log.Information(" {name}{indent}({oldVer} -> {newVer})", name, indentAfter name, oldVer, newVer)
        )
            
        printfn ""
        
    )
    
    

[<EntryPoint>]
let main argv = 
    Logging.setupLogger()

    match parseOptions argv with
    | Ok(options) when options.Status.IsSome && options.Exercise.IsSome -> 
        Log.Error("Can't have both -s and -e.")
        1
    | Ok(options) when options.Status.IsSome -> 
        listExercises options
        0
    | Ok(options) -> 
        regenerateTestClasses options
        0
    | Error(errors) when errors |> Seq.contains "CommandLine.HelpRequestedError" ->
        0
    | Error(errors) -> 
        Log.Error("Error(s) parsing commandline arguments: {Errors}", errors)
        1