module Generators.Reporting

open Serilog
open CanonicalData
open Exercise
open Options
       
let private isOutdated (exercise: GeneratorExercise) options (parseCanonicalData':string -> CanonicalData) =
    // TODO: compare tests.toml with canonical data
    false
//    let canonicalData = parseCanonicalData' exercise.Name
//    match canonicalData.Version, exercise.ReadVersion() with
//    | canonicalDataVersion, exerciseVersion when canonicalDataVersion.Equals exerciseVersion -> false
//    | _ -> true

type SummaryTypes =
    | Custom of string
    | Unimplemented of string
    | MissingData of string
    | Deprecated of string
    | UpToDate of string
    | Outdated of string * string * string
    
let nameFromSummaryType = function
    | Custom n -> n
    | Unimplemented  n -> n
    | MissingData n -> n
    | Deprecated n -> n
    | UpToDate n -> n
    | Outdated (n, _, _) -> n
    
let private summarizeExercise options (parseCanonicalData':string -> CanonicalData) (exercise:Exercise)  =

    match exercise with
    | Exercise.Custom custom ->                 SummaryTypes.Custom custom.Name
    | Exercise.Unimplemented unimplemented ->   SummaryTypes.Unimplemented unimplemented.Name
    | Exercise.MissingData missingData ->       SummaryTypes.MissingData missingData.Name
    | Exercise.Deprecated deprecated ->         SummaryTypes.Deprecated deprecated.Name
    | Exercise.Generator generator ->
        let canonicalData = parseCanonicalData' generator.Name
        // TODO: use tests.toml
        UpToDate generator.Name
//        match generator.ReadVersion (), canonicalData.Version with
//        | generatorVersion, canonicalDataVersion when generatorVersion.Equals canonicalDataVersion -> UpToDate generator.Name
//        | generatorVersion, canonicalDataVersion -> Outdated (generator.Name, generatorVersion, canonicalDataVersion)

let printExercise indentAfter exercise =
    match exercise with
    | SummaryTypes.Outdated (name, oldVer, newVer) -> Log.Information(" {name}{indent}({oldVer} -> {newVer})", name, indentAfter name, oldVer, newVer)
    | _ -> Log.Information(" {name}", nameFromSummaryType exercise)

let printExerciseGroup indentAfter (groupType:System.Type, group:SummaryTypes list)=
    let description =
        match group.Head with
        | SummaryTypes.Custom _ -> "have customized tests"
        | SummaryTypes.Unimplemented _ -> "are missing a test generator"
        | SummaryTypes.MissingData _ -> "are missing canonical data"
        | SummaryTypes.Deprecated _ -> "are deprecated"
        | SummaryTypes.UpToDate _ -> "are up to date"
        | SummaryTypes.Outdated _ -> "are outdated"

    Log.Information("{num} exercises {description}:", group.Length, description)

    group |> List.iter (printExercise indentAfter)

    printfn ""
