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

</Project>"""

let upperCaseFirst (str: string) =
    Char.ToUpper(str.[0]).ToString() + str.[1..]

let pascalCase (str: string) =
    str.Split('-')
    |> Array.map upperCaseFirst
    |> String.concat ""

let convertExercise exerciseDirectory =
    let slug = Path.GetFileName(exerciseDirectory)
    let exerciseName = slug |> pascalCase
    let projectFileContents = projectTemplate.Replace("{Exercise}", exerciseName)
    let projectFileName = sprintf "%s.fsproj" exerciseName
    let projectFilePath = Path.Combine(exerciseDirectory, projectFileName)
    File.WriteAllText(projectFilePath, projectFileContents)

Directory.EnumerateDirectories("./exercises")
|> Seq.iter convertExercise