#r "nuget: Bullseye"
#r "nuget: Humanizer.Core"
#r "nuget: SimpleExec"

open System
open System.IO
open Humanizer

open type Bullseye.Targets
open type SimpleExec.Command

let (/) left right = Path.Combine(left, right)

let buildDir = "build"

let exitWithErrorMessage (message: string) =
    Console.ForegroundColor <- ConsoleColor.DarkRed
    Console.Error.WriteLine(message)
    exit 1

let copyExercise exerciseDir =
    Directory.CreateDirectory(buildDir / exerciseDir / ".meta")
    |> ignore

    Directory.EnumerateFiles(exerciseDir, "*.fs")
    |> Seq.append (Directory.EnumerateFiles(exerciseDir / ".meta", "*.fs"))
    |> Seq.append (Directory.EnumerateFiles(exerciseDir, "*.fsproj"))
    |> Seq.iter (fun exerciseFile -> File.Copy(exerciseFile, buildDir / exerciseFile, overwrite = true))

let unskipTests exerciseDir =
    // let tests =
    //     File.ReadAllText(exercise.BuildPaths.TestsFile)

    // let unskippedTests =
    //     tests.Replace("(Skip = \"Remove this Skip property to run this test\")", "")

    // File.WriteAllText(exercise.BuildPaths.TestsFile, unskippedTests)
    ()

let testExercise exerciseDir =
    // unskipTests exerciseDir

    // Run("dotnet", "test", buildDir / exerciseDir)
    ()

let findExerciseDir exercise =
    let conceptExerciseDir = "exercises" / "concept" / exercise
    let practiceExerciseDir = "exercises" / "practice" / exercise

    if Directory.Exists(conceptExerciseDir) then
        conceptExerciseDir
    elif Directory.Exists(practiceExerciseDir) then
        practiceExerciseDir
    else
        exitWithErrorMessage $"Could not find directory for exercise with slug '{exercise}'"

Target("build-generators", (fun () -> Run("dotnet", "build", "generators")))

Target(
    "build-refactoring-exercises",
    ForEach("tree-building", "ledger", "markdown"),
    new Action<string>(
        (fun slug ->
            // let exercise = findExercise slug
            // copyExercise exercise
            // testExercise exercise
            ())
    )
)

Target(
    "default",
    new Action(fun () ->
        let exercise = "word-count"
        let exerciseDir = findExerciseDir exercise
        copyExercise exerciseDir
        testExercise exerciseDir)
)

RunTargetsAndExit(Array.tail fsi.CommandLineArgs)
