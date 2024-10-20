<#
.SYNOPSIS
    Test the solution.
.DESCRIPTION
    Test the solution to verify correctness. This script verifies that:
    - The config.json file is correct
    - The generators project builds successfully
    - The example implementations pass the test suites
    - The refactoring projects stub files pass the test suites
.PARAMETER Exercise
    The slug of the exercise to verify (optional).
.EXAMPLE
    The example below will verify the full solution
    PS C:\> bin/test.ps1
.EXAMPLE
    The example below will verify the "acronym" exercise
    PS C:\> bin/test.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

function Invoke-Build-Generators {
    Write-Output "Building generators"
    & dotnet build ./generators 
}

function Clean($BuildDir) {
    Write-Output "Cleaning previous build"
    Remove-Item -Recurse -Force $BuildDir -ErrorAction Ignore
}

function Copy-Exercise($SourceDir, $BuildDir) {
    Write-Output "Copying exercises"
    Copy-Item $SourceDir -Destination $BuildDir -Recurse
}

function Enable-All-UnitTests($BuildDir) {
    Write-Output "Enabling all tests"
    Get-ChildItem -Path $BuildDir -Include "*Tests.fs" -Recurse | ForEach-Object {
        (Get-Content $_.FullName) -replace "Skip = ""Remove this Skip property to run this test""", "" | Set-Content $_.FullName
    }
}

function Add-Packages-ExerciseImplementation($PracticeExercisesDir) {
    & dotnet add "${PracticeExercisesDir}/sgf-parsing" package FParsec
}

function Test-Refactoring-Projects($PracticeExercisesDir) {
    Write-Output "Testing refactoring projects"
    @("tree-building", "ledger", "markdown") | ForEach-Object {
        dotnet test "${PracticeExercisesDir}/${_}"
    }
}

function Set-ExampleImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ExercisesDir, $ReplaceFileName)

    if ($PSCmdlet.ShouldProcess("Exercise ${ReplaceFileName}", "replace solution with example")) {
        Get-ChildItem -Path $ExercisesDir -Include "*.fsproj" -Recurse | ForEach-Object {
            $stub = Join-Path -Path $_.Directory ($_.BaseName + ".fs")
            $example = Join-Path -Path $_.Directory ".meta" $ReplaceFileName

            Move-Item -Path $example -Destination $stub -Force
        }
    }
}

function Use-ExampleImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ConceptExercisesDir, $PracticeExercisesDir)

    if ($PSCmdlet.ShouldProcess("Exercises directory", "replace all solutions with corresponding examples")) {
        Write-Output "Replacing concept exercise stubs with exemplar"
        Set-ExampleImplementation $ConceptExercisesDir "Exemplar.fs"

        Write-Output "Replacing practice exercise stubs with example"
        Set-ExampleImplementation $PracticeExercisesDir "Example.fs"
    }
}

function Test-ExerciseImplementation($Exercise, $BuildDir, $ConceptExercisesDir, $PracticeExercisesDir) {
    Write-Output "Running tests"

    if (-Not $Exercise) {
        dotnet test $BuildDir
    }
    elseif (Test-Path "${ConceptExercisesDir}/${Exercise}") {
        dotnet test "${ConceptExercisesDir}/${Exercise}"
    }
    elseif (Test-Path "${PracticeExercisesDir}/${Exercise}") {
        dotnet test "${PracticeExercisesDir}/${Exercise}"
    }
    else {
        throw "Could not find exercise '${Exercise}'"
    }
}

$buildDir = "${PSScriptRoot}/build"
$practiceExercisesDir = "${buildDir}/practice"
$conceptExercisesDir = "${buildDir}/concept"
$sourceDir = Resolve-Path "exercises"

Clean $buildDir
Copy-Exercise $sourceDir $buildDir
Enable-All-UnitTests $buildDir

if (!$Exercise) {
    Invoke-Build-Generators
    Test-Refactoring-Projects $practiceExercisesDir
}

Use-ExampleImplementation $conceptExercisesDir $practiceExercisesDir
Add-Packages-ExerciseImplementation -PracticeExercisesDir $practiceExercisesDir
Test-ExerciseImplementation -Exercise $Exercise -BuildDir $buildDir -ConceptExercisesDir $conceptExercisesDir -PracticeExercisesDir $practiceExercisesDir
