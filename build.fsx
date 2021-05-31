#r "nuget: Bullseye"
#r "nuget: Humanizer.Core"
#r "nuget: SimpleExec"

open System
open System.IO
open Humanizer

open type Bullseye.Targets
open type SimpleExec.Command

type ExerciseType = ConceptExercise | PracticeExercise

type ExercisePaths =
    { Dir: string
      ImplementationFile: string
      SolutionFile: string
      TestsFile: string
      ProjectFile: string }

type Exercise =
    { Slug: string
      Name: string
      SourcePaths: ExercisePaths
      BuildPaths: ExercisePaths }

let (/) left right = Path.Combine(left, right)

let buildDir = "build"

let exitWithErrorMessage (message: string) =
    Console.ForegroundColor <- ConsoleColor.DarkRed
    Console.Error.WriteLine(message)
    exit 1

let copyExercise exercise =
    Directory.CreateDirectory(exercise.BuildPaths.Dir) |> ignore

    File.Copy(exercise.SourcePaths.ImplementationFile, exercise.BuildPaths.SolutionFile, overwrite = true)
    File.Copy(exercise.SourcePaths.TestsFile, exercise.BuildPaths.TestsFile, overwrite = true)
    File.Copy(exercise.SourcePaths.ProjectFile, exercise.BuildPaths.ProjectFile, overwrite = true)

let unskipTests exercise =
    let tests = File.ReadAllText(exercise.BuildPaths.TestsFile)

    let unskippedTests =
        tests.Replace("(Skip = \"Remove this Skip property to run this test\")", "")

    File.WriteAllText(exercise.BuildPaths.TestsFile, unskippedTests)

let testExercise exercise =
    unskipTests exercise

    Run("dotnet", "test", exercise.BuildPaths.Dir)

let toExerciseFiles exerciseType dir name =
    { Dir = dir
      SolutionFile = dir / $"{name}.fs"
      TestsFile = dir / $"{name}Tests.fs"
      ProjectFile = dir / $"{name}.fsproj"
      ImplementationFile =
          match exerciseType with
          | ConceptExercise -> dir / ".meta/Exemplar.fs"
          | PracticeExercise -> dir / ".meta/Example.fs" }

let toExercise exerciseType (exercise: string) dir =
    let name = exercise.Dehumanize().Pascalize()

    { Slug = exercise
      Name = name
      SourcePaths = toExerciseFiles exerciseType dir name
      BuildPaths = toExerciseFiles exerciseType (buildDir / dir) name }          

let findExercise exercise =
    let conceptExerciseDir = "exercises" / "concept" / exercise
    let practiceExerciseDir = "exercises" / "practice" / exercise

    if Directory.Exists(conceptExerciseDir) then
        toExercise ConceptExercise exercise conceptExerciseDir
    elif Directory.Exists(practiceExerciseDir) then
        toExercise PracticeExercise exercise practiceExerciseDir
    else
        exitWithErrorMessage $"Could not find directory for exercise with slug '{exercise}'"

Target(
    "default",
    (fun () ->
        let exercise = findExercise "word-count"
        copyExercise exercise
        testExercise exercise)
)

RunTargetsAndExit(Array.tail fsi.CommandLineArgs)
