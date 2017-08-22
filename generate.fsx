open System
open System.IO

let projectTemplate = 
    """
<Project Sdk="Microsoft.NET.Sdk">

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

</Project>
"""

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

let convertToFsUnit exercise =
    ()

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
    let objDirectory = Path.Combine(exercisesDirectory, "obj")

    match Directory.Exists(objDirectory) with
    | true  -> Directory.Delete(objDirectory, true)
    | false -> ()

    Directory.EnumerateDirectories("./exercises")

exerciseDirectories
|> Seq.map toExercise
|> Seq.iter convertExercise