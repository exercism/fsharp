open System
open System.IO
open System.Text.RegularExpressions

let projectTemplate = 
    """<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.0</TargetFramework>

    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <Compile Include="{Exercise}.fs" />
    <Compile Include="{Exercise}Test.fs" />
    <Compile Include="Program.fs" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.3.0" />
    <PackageReference Include="NUnit" Version="3.7.1" />
    <PackageReference Include="NUnit3TestAdapter" Version="3.8.0" />
    <PackageReference Include="FsUnit" Version="3.0.0" />
  </ItemGroup>

</Project>"""

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

let createExerciseProject exercise =  
    let projectFileContents = projectTemplate.Replace("{Exercise}", exercise.Name)
    File.WriteAllText(exercise.ProjectFilePath, projectFileContents)

let createStubFile (exercise: Exercise) = 
    match File.Exists(exercise.StubFilePath) with
    | true  -> ()
    | false -> File.Copy(exercise.ExampleFilePath, exercise.StubFilePath, false)

let normalizeTestFileName exercise = 
    let testsFileName = sprintf "%sTests.fs" exercise.Name
    let testsFilePath = Path.Combine(exercise.Directory, testsFileName)

    match File.Exists(testsFilePath) with
    | true  -> File.Move(testsFilePath, exercise.TestFilePath)
    | false -> ()

let createProgramFile (exercise: Exercise) = 
    File.WriteAllText(exercise.ProgramFilePath, "module Program = let [<EntryPoint>] main _ = 0")    

let convertToFsUnit (exercise: Exercise) =
    let testFileContents = File.ReadAllText(exercise.TestFilePath)

    let updatedTestFileContents =
        testFileContents
        |> if testFileContents.Contains("FsUnit") then id else regexReplace "open NUnit.Framework" "open NUnit.Framework\nopen FsUnit"
        |> regexReplace "Assert\.That\((.+), Is\.(EqualTo|EquivalentTo)\((.+)\)\)" "$1 |> should equal $3"
        |> regexReplace "Assert\.That\((.+), Is\.Not\.(EqualTo|EquivalentTo)\((.+)\)\)" "$1 |> should not' )equal $3)"
        |> regexReplace "Assert\.That\((.+) = (.+)\)" "$1 |> should equal $2"
        |> regexReplace "Assert\.That\((.+) <> (.+)\)" "$1 |> should not' (equal $2)"
        |> regexReplace "Assert\.That\((.+), Throws\.(.+)\)" "$1 |> should throw typeof<$2>"
        |> regexReplace "Assert\.That\((.+), Is.True\)" "$1 |> should equal true"
        |> regexReplace "Assert\.That\((.+), Is.False\)" "$1 |> should equal false"
        |> regexReplace "Assert\.True\((.+)\)" "$1 |> should equal true"
        |> regexReplace "Assert\.False\((.+)\)" "$1 |> should equal false"
        |> regexReplace "Assert\.That\((.+), Is.Empty\)" "$1 |> should be Empty"
        |> regexReplace "Assert\.That\((.+), Has\.Length\.EqualTo\((.+)\)\)" "$1 |> should haveLength $2"

    File.WriteAllText(exercise.TestFilePath, updatedTestFileContents)    

let convertExercise exercise =
    createExerciseProject exercise
    createStubFile exercise
    createProgramFile exercise
    normalizeTestFileName exercise
    convertToFsUnit exercise

let toExercise exerciseDirectory = 
    let slug = Path.GetFileName(exerciseDirectory)
    let name = pascalCase slug

    { Directory = exerciseDirectory
      Name = name
      Slug = slug }

let exercisesDirectory = "./exercises"

let exerciseDirectories = 
    let isExerciseDirectory path = 
        path <> "obj" && 
        path <> "bin" &&
        not (Path.GetFileName(path).StartsWith("."))

    Directory.EnumerateDirectories("./exercises")
    |> Seq.filter isExerciseDirectory

exerciseDirectories
|> Seq.map toExercise
|> Seq.iter convertExercise