<#
.SYNOPSIS
    Add a new exercise.
.DESCRIPTION
    Add the files need to add a new exercise.
.PARAMETER Exercise
    The slug of the exercise to add.
.PARAMETER Author
    The author of the exercise.
.PARAMETER Difficulty
    The difficulty of the exercise on a scale from 1 to 10 (optional, default: 1).
.EXAMPLE
    The example below will add the "acronym" exercise
    PS C:\> bin/add-practice-exercise.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter(Position = 1, Mandatory = $true)][string]$Author,
    [Parameter(Position = 2)][int]$Difficulty = 1
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

# Use configlet to create the exercise
& bin/fetch-configlet
& bin/configlet create --practice-exercise $Exercise --difficulty $Difficulty --author $Author

# Create project
$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$exerciseDir = "exercises/practice/${Exercise}"
$project = "${exerciseDir}/${ExerciseName}.fsproj"
& dotnet new xunit --force -lang "F#" --target-framework-override net9.0 -o $exerciseDir -n $ExerciseName
& dotnet sln exercises/Exercises.sln add $project

# Update project packages
& dotnet remove $project package coverlet.collector
& dotnet add $project package Exercism.Tests --version 0.1.0-beta1
& dotnet add $project package xunit.runner.visualstudio --version 2.4.3
& dotnet add $project package xunit --version 2.4.1
& dotnet add $project package Microsoft.NET.Test.Sdk --version 16.8.3
& dotnet add $project package FsUnit.xUnit --version 4.0.4

# Add tools
& dotnet new tool-manifest -o $exerciseDir
& dotnet tool install --tool-manifest "${exerciseDir}/.config/dotnet-tools.json" fantomas-tool

# Remove and update files
Remove-Item -Path "${exerciseDir}/Program.fs"
Remove-Item -Path "${exerciseDir}/Tests.fs"
Set-Content -Path "${exerciseDir}/${exerciseName}.fs" -Value "module ${exerciseName}"
Set-Content -Path "${exerciseDir}/.meta/Example.fs" -Value "module ${exerciseName}"

# Fix the project
[xml]$proj = Get-Content $project
$proj.Project.ItemGroup[0].Compile[0].Include = "${exerciseName}.fs"
$proj.Project.ItemGroup[0].Compile[1].Include = "${exerciseName}Tests.fs"
$proj.Project.PropertyGroup.RemoveChild($proj.Project.PropertyGroup.SelectSingleNode("//GenerateProgramFile"))
$proj.Save($project)

# Add and run generator (this will update the tests file)
$generator = "generators/Generators.fs"
Add-Content -Path $generator -Value @"

type ${exerciseName}() =
    inherit ExerciseGenerator()
"@
& dotnet run --project generators --exercise $Exercise

# Output the next steps
$files = Get-Content "${exerciseDir}/.meta/config.json" | ConvertFrom-Json | Select-Object -ExpandProperty files
Write-Output @"
The '${exerciseName}' exercise has been created in '${exerciseDir}'.
Your next steps are:
- Check the test suite in $($files.test | Join-String -Separator ",")
  - If the tests need changes, update the '${exerciseName}' class in the '${generator}' file
    and then run: 'dotnet run --project generators --exercise ${Exercise}'
- Any test cases you don't implement, mark them in '${exerciseDir}/.meta/tests.toml' with "include = false"
- Create the example solution in '$($files.example | Join-String -Separator "', '")'
- Verify the example solution passes the tests by running 'bin/verify-exercises ${Exercise}'
- Create the stub solution in '$($files.solution | Join-String -Separator "', '")'
- Update the 'difficulty' value for the exercise's entry in the 'config.json' file in the repo's root
- Validate CI using 'bin/configlet lint' and 'bin/configlet fmt'
"@
