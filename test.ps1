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
    PS C:\> ./test.ps1
.EXAMPLE
    The example below will verify the "acronym" exercise
    PS C:\> ./test.ps1 acronym
#>

[CmdletBinding(SupportsShouldProcess)]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$Exercise
)

# Import shared functionality
. ./shared.ps1

function Invoke-Build-Generators {
    Write-Output "Building generators"
    Run-Command "dotnet build ./generators"
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

function Test-Refactoring-Projects($PracticeExercisesDir) {
    Write-Output "Testing refactoring projects"
    @("tree-building", "ledger", "markdown") | ForEach-Object {
        Run-Command "dotnet test $practiceExercisesDir/$_"
    }
}

function Set-ExerciseImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ExercisesDir, $ReplaceFileName)

    if ($PSCmdlet.ShouldProcess("Exercise $ReplaceFileName", "replace solution with example")) {
        Get-ChildItem -Path $ExercisesDir -Include "*.fsproj" -Recurse | ForEach-Object {
            $stub = Join-Path -Path $_.Directory ($_.BaseName + ".fs")
            $example = Join-Path -Path $_.Directory ".meta" $ReplaceFileName

            Move-Item -Path $example -Destination $stub -Force
        }
    }
}

function Use-ExerciseImplementation {
    [CmdletBinding(SupportsShouldProcess)]
    param($ConceptExercisesDir, $PracticeExercisesDir)

    if ($PSCmdlet.ShouldProcess("Exercises directory", "replace all solutions with corresponding examples")) {
        Write-Output "Replacing concept exercise stubs with exemplar"
        Set-ExerciseImplementation $ConceptExercisesDir "Exemplar.fs"

        Write-Output "Replacing practice exercise stubs with example"
        Set-ExerciseImplementation $PracticeExercisesDir "Example.fs"
    }
}

function Add-Packages-ExerciseImplementation($PracticeExercisesDir) {
    Run-Command "dotnet add $PracticeExercisesDir/sgf-parsing package FParsec"
}

function Test-ExerciseImplementation($Exercise, $BuildDir, $ConceptExercisesDir, $PracticeExercisesDir) {
    Write-Output "Running tests"

    if (-Not $Exercise) {
        Run-Command "dotnet test $buildDir/Exercises.sln"
    }
    elseif (Test-Path "$ConceptExercisesDir/$Exercise") {
        Run-Command "dotnet test $conceptExercisesDir/$exercise"
    }
    elseif (Test-Path "$PracticeExercisesDir/$Exercise") {
        Run-Command "dotnet test $practiceExercisesDir/$exercise"
    }
    else {
        throw "Could not find exercise '$Exercise'"
    }
}


$buildDir = Join-Path $PSScriptRoot "build"
$conceptExercisesDir = Join-Path $buildDir "concept"
$practiceExercisesDir = Join-Path $buildDir "practice"
$sourceDir = Resolve-Path "exercises"

Clean $buildDir
Copy-Exercise $sourceDir $buildDir
Enable-All-UnitTests $buildDir

if (!$Exercise) {
    Invoke-Build-Generators
    Test-Refactoring-Projects -PracticeExercisesDir $practiceExercisesDir
}

Use-ExerciseImplementation -ConceptExercisesDir $conceptExercisesDir -PracticeExercisesDir $practiceExercisesDir
Add-Packages-ExerciseImplementation -PracticeExercisesDir $practiceExercisesDir
Test-ExerciseImplementation -Exercise $Exercise -BuildDir $buildDir -ConceptExercisesDir $conceptExercisesDir -PracticeExercisesDir $practiceExercisesDir

exit $LastExitCode
