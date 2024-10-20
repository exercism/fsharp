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
    PS C:\> ./add-practice-exercise.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter(Mandatory = $true)][string]$Author,
    [Parameter()][int]$Difficulty = 1
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
& dotnet new xunit --force -lang "F#" --target-framework-override net8.0 -o $exerciseDir -n $ExerciseName
& dotnet sln exercises/Exercises.sln add $project

# Update project packages
& dotnet remove $project package coverlet.collector
& dotnet add $project package Exercism.Tests --version 0.1.0-beta1
& dotnet add $project package xunit.runner.visualstudio --version 2.4.3
& dotnet add $project package xunit --version 2.4.1
& dotnet add $project package Microsoft.NET.Test.Sdk --version 16.8.3

# Add tools
& dotnet new tool-manifest -o $exerciseDir
& dotnet tool install --tool-manifest "${exerciseDir}/.config/dotnet-tools.json" fantomas-tool

# Remove and update files
Remove-Item -Path "${exerciseDir}/Program.fs"
Remove-Item -Path "${exerciseDir}/Tests.fs"
Set-Content -Path "${exerciseDir}/${exerciseName}.fs" -Value "module ${exerciseName}"
Set-Content -Path "${exerciseDir}/.meta/Example.fs" -Value "module ${exerciseName}"

# Fix the includes
[xml]$proj = Get-Content $project
$proj.Project.ItemGroup[0].Compile[0].Include = "${exerciseName}.fs"
$proj.Project.ItemGroup[0].Compile[1].Include = "${exerciseName}Tests.fs"
$proj.Save($project)

# Add and run generator (this will update the tests file)
Add-Content -Path generators/Generators.fs -Value @"

type ${exerciseName}() =
    inherit ExerciseGenerator()
"@
& dotnet run --project generators --exercise $Exercise
