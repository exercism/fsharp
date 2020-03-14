<#
.SYNOPSIS
    Add a new exercise.
.DESCRIPTION
    Add the files need to add a new exercise.
.PARAMETER Exercise
    The slug of the exercise to add.
.PARAMETER Topics
    The topics of the exercise (optional).
.PARAMETER Core
    Indicates if the exercise is a core exercise (optional).
.PARAMETER Difficulty
    The difficulty of the exercise on a scale from 1 to 10 (optional).
.PARAMETER UnlockedBy
    The slug of the exercise that unlocks exercise (optional).
.EXAMPLE
    The example below will add the "acronym" exercise
    PS C:\> ./add-new-exercise.ps1 acronym
.EXAMPLE
    The example below will add the "acronym" exercise as a core exercise
    PS C:\> ./add-new-exercise.ps1 acronym -Core
.EXAMPLE
    The example below will add the "acronym" exercise as a core exercise, with
    two topics, a specified difficulty and being unlocked by "two-fer"
    PS C:\> ./add-new-exercise.ps1 acronym -Core -Topics strings,optional -Difficulty 3 -UnlockedBy two-fer
#>

param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = @(),
    [Parameter()][switch]$Core,
    [Parameter()][int]$Difficulty = 1,
    [Parameter()]$UnlockedBy
)

# Import shared functionality
. ./shared.ps1

$exerciseName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$exercisesDir = Resolve-Path "exercises"
$exerciseDir = Join-Path $exercisesDir $Exercise

function Add-Project {
    Write-Output "Adding project"

    $fsProj = "$exerciseDir/$exerciseName.fsproj"

    Run-Command "dotnet new xunit -lang ""F#"" -o $exerciseDir -n $exerciseName"
    Run-Command "dotnet new tool-manifest -o $exerciseDir"
    Run-Command "dotnet tool install --tool-manifest $exerciseDir/.config/dotnet-tools.json fantomas-tool"
    Run-Command "dotnet sln ""$exercisesDir/Exercises.sln"" add $fsProj"
    
    Remove-Item -Path "$exerciseDir/Program.fs" 
    Remove-Item -Path "$exerciseDir/Tests.fs"

    New-Item -ItemType File -Path "$exerciseDir/$exerciseName.fs" -Value "module $exerciseName"
    New-Item -ItemType File -Path "$exerciseDir/Example.fs" -Value "module $exerciseName"

    [xml]$proj = Get-Content $fsProj
    $proj.Project.ItemGroup[0].Compile[0].Include = "$exerciseName.fs"
    $proj.Project.ItemGroup[0].Compile[1].Include = "${exerciseName}Tests.fs"
    $proj.Save($fsProj)
}

function Add-Generator {
    Write-Output "Adding generator"

    $generatorsDir = Resolve-Path "generators"
    $generator = "type $exerciseName() =`n    inherit GeneratorExercise()`n"
    Add-Content -Path "$generatorsDir/Generators.fs" -Value $generator
}

function Update-Readme {
    Write-Output "Updating README"
    ./update-docs.ps1 $Exercise
}

function Update-Tests { 
    Write-Output "Updating test suite"
    ./generate-tests.ps1 $Exercise
}

function Update-Config-Json {
    Write-Output "Updating config.json"

    $configJson = Resolve-Path "config.json"

    $config = Get-Content $configJson | ConvertFrom-JSON
    $config.exercises += [pscustomobject]@{
        slug        = $Exercise;
        uuid        = [Guid]::NewGuid();
        core        = $Core.IsPresent;
        unlocked_by = $UnlockedBy;
        difficulty  = $Difficulty;
        topics      = $Topics;
    }
    
    ConvertTo-Json -InputObject $config -Depth 10 | Set-Content -Path $configJson

    Run-Command "./bin/fetch-configlet"
    Run-Command "./bin/configlet fmt ."
}

Add-Project
Add-Generator
Update-Readme
Update-Tests
Update-Config-Json

exit $LastExitCode