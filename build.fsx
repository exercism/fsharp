#r "nuget: Bullseye"
#r "nuget: Humanizer.Core"
#r "nuget: SimpleExec"

open System
open System.IO
open Humanizer

open type Bullseye.Targets
open type SimpleExec.Command

type Exercise =
    | ConceptExercise of Slug: string * Name: string * Dir: string
    | PracticeExercise of Slug: string * Name: string * Dir: string

let (/) left right = Path.Combine(left, right)

let buildDir = "build"

let exitWithErrorMessage (message: string) =
    Console.ForegroundColor <- ConsoleColor.DarkRed
    Console.Error.WriteLine(message)
    exit 1

let implementationFile exercise =
    match exercise with
    | ConceptExercise _ -> $".meta/Exemplar.fs"
    | PracticeExercise _ -> $".meta/Example.fs"

let solutionFile exercise =
    match exercise with
    | ConceptExercise (Name = name)
    | PracticeExercise (Name = name) -> $"{name}.fs"

let testsFile exercise =
    match exercise with
    | ConceptExercise (Name = name)
    | PracticeExercise (Name = name) -> $"{name}Tests.fs"

let projectFile exercise =
    match exercise with
    | ConceptExercise (Name = name)
    | PracticeExercise (Name = name) -> $"{name}.fsproj"

let copyExercise exercise =
    match exercise with
    | ConceptExercise (Dir = dir)
    | PracticeExercise (Dir = dir) ->
        Directory.CreateDirectory(buildDir / dir)
        |> ignore

        File.Copy(dir / implementationFile exercise, buildDir / dir / solutionFile exercise)
        File.Copy(dir / testsFile exercise, buildDir / dir / testsFile exercise)
        File.Copy(dir / projectFile exercise, buildDir / dir / projectFile exercise)

let unskipTests exercise =
    match exercise with
    | ConceptExercise (Dir = dir)
    | PracticeExercise (Dir = dir) ->
        let testsFile = buildDir / dir / testsFile exercise
        let tests = File.ReadAllText(testsFile)

        let unskippedTests =
            tests.Replace("(Skip = \"Remove this Skip property to run this test\")", "")

        File.WriteAllText(testsFile, unskippedTests)

let testExercise exercise =
    unskipTests exercise

    match exercise with
    | ConceptExercise (Dir = dir)
    | PracticeExercise (Dir = dir) -> Run("dotnet", "test", buildDir / dir)

let findExercise exercise =
    let conceptExerciseDir = "exercises" / "concept" / exercise
    let practiceExerciseDir = "exercises" / "practice" / exercise
    let name = exercise.Dehumanize().Pascalize()

    if Directory.Exists(conceptExerciseDir) then
        ConceptExercise(exercise, name, conceptExerciseDir)
    elif Directory.Exists(practiceExerciseDir) then
        PracticeExercise(exercise, name, practiceExerciseDir)
    else
        exitWithErrorMessage $"Could not find directory for exercise with slug '{exercise}'"

Target("clean", (fun () -> Run("rm", "-r ./build")))
Target("build", (fun () -> Run("dotnet", "build")))

Target(
    "default",
    DependsOn("clean"),
    (fun () ->
        let exercise = findExercise "word-count"
        copyExercise exercise
        testExercise exercise
        printfn "%A" exercise)
)

RunTargetsAndExit(Array.tail fsi.CommandLineArgs)
