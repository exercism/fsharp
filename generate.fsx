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
    <Compile Include="{Exercise}Tests.fs" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.3.0-preview-20170628-02" />
    <PackageReference Include="NUnit" Version="3.5.0" />
    <PackageReference Include="dotnet-test-nunit" Version="3.4.0-beta-3" />
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

let createExerciseProject exercise =  
    let projectFileContents = projectTemplate.Replace("{Exercise}", exercise.Name)
    let projectFileName = sprintf "%s.fsproj" exercise.Name
    let projectFilePath = Path.Combine(exercise.Directory, projectFileName)
    File.WriteAllText(projectFilePath, projectFileContents)

let createStubFile exercise = 
    let exampleFileName = "Example.fs"    
    let exampleFilePath = Path.Combine(exercise.Directory, exampleFileName)

    let stubFileName = sprintf "%s.fs" exercise.Name
    let stubFilePath = Path.Combine(exercise.Directory, stubFileName)

    match File.Exists(stubFilePath) with
    | true  -> ()
    | false -> File.Copy(exampleFilePath, stubFilePath, false)

let convertExercise exercise =
    createExerciseProject exercise
    createStubFile exercise

let toExercise exerciseDirectory = 
    let slug = Path.GetFileName(exerciseDirectory)

    { Directory = exerciseDirectory
      Name = pascalCase slug
      Slug = slug }

let exerciseDirectories = 
    Directory.EnumerateDirectories("./exercises")
    |> Seq.filter ((<>) "obj")

exerciseDirectories
|> Seq.map toExercise
|> Seq.iter convertExercise