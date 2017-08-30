open System
open System.IO
open System.Text.RegularExpressions

let regexReplace pattern (replacement: string) (str: string) = Regex.Replace(str, pattern, replacement)

let upperCaseFirst (str: string) =
    Char.ToUpper(str.[0]).ToString() + str.[1..]

let pascalCase (str: string) =
    str.Split('-')
    |> Array.map upperCaseFirst
    |> String.concat ""

type Exercise = 
    { Directory: string
      Name: string
      Slug: string }
    
    member this.TestFilePath = Path.Combine(this.Directory, sprintf "%sTest.fs" this.Name)
    member this.StubFilePath = Path.Combine(this.Directory, sprintf "%s.fs" this.Name)
    member this.ExampleFilePath = Path.Combine(this.Directory, "Example.fs")
    member this.ProgramFilePath = Path.Combine(this.Directory, "Program.fs")
    member this.ProjectFilePath = Path.Combine(this.Directory, sprintf "%s.fsproj" this.Name)

let convertToXunit (exercise: Exercise) =
    let testFileContents = File.ReadAllText(exercise.TestFilePath)

    let updatedTestFileContents =
        testFileContents
        |> regexReplace @"\[<Test>\]\r?\n\[<Ignore\(""Remove to run test""\)>\]" @"[Fact(Skip = ""Remove to run test"")]"
        |> regexReplace @"\[<Test>\]" @"[Fact]"

    File.WriteAllText(exercise.TestFilePath, updatedTestFileContents)    

let convertExercise exercise =
    convertToXunit exercise

let toExercise exerciseDirectory = 
    let slug = Path.GetFileName(exerciseDirectory)
    let name = pascalCase slug

    { Directory = exerciseDirectory
      Name = name
      Slug = slug }

let exercisesDirectory = "./exercises"

let exerciseDirectories = 
    let isExerciseDirectory path = 
        Path.GetFileName(path) <> "obj" && 
        Path.GetFileName(path) <> "bin" &&
        not (Path.GetFileName(path).StartsWith("."))

    Directory.EnumerateDirectories("./exercises")
    |> Seq.filter isExerciseDirectory

exerciseDirectories
|> Seq.map toExercise
|> Seq.iter convertExercise