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
    PS C:\> ./add-new-exercise.ps1 acronym -Core -Topics strings -Difficulty 3 -UnlockedBy two-fer
#>

param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = @(),
    [Parameter()][switch]$Core,
    [Parameter()][int]$Difficulty = 1,
    [Parameter()]$UnlockedBy
)

class Exercise {
    [string]$slug
    [guid]$uuid
    [bool]$core
    $unlocked_by
    [int]$difficulty
    [string[]]$topics

    Exercise ([string]$Exercise, [string[]]$Topics, [bool]$Core, [int]$Difficulty, $UnlockedBy) {
        $this.uuid = [Guid]::NewGuid()
        $this.slug = $Exercise
        $this.topics = $Topics
        $this.core = $Core
        $this.difficulty = $Difficulty
        $this.unlocked_by = $UnlockedBy
    }
}

$projectName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$configJson = Resolve-Path "config.json"

$config = Get-Content $configJson | ConvertFrom-JSON
$config.Exercises += [Exercise]::new($Exercise, $Topics, $Core.IsPresent, $Difficulty, $UnlockedBy)

ConvertTo-Json -InputObject $config -Depth 10 | Set-Content -Path $configJson

$exercisesDir = Resolve-Path "exercises"
$exerciseDir = Join-Path $exercisesDir $Exercise
$fsProj = "$exerciseDir/$projectName.fsproj"

dotnet new xunit -lang "F#" -o $exerciseDir -n $projectName
dotnet sln "$exercisesDir/Exercises.sln" add $fsProj

Remove-Item -Path "$exerciseDir/Program.fs" 
Remove-Item -Path "$exerciseDir/Tests.fs"

New-Item -ItemType File -Path "$exerciseDir/$projectName.fs" -Value "module $projectName"
New-Item -ItemType File -Path "$exerciseDir/Example.fs" -Value "module $projectName"

[xml]$proj = Get-Content $fsProj
$proj.Project.ItemGroup[0].Compile[0].Include = "$projectName.fs"
$proj.Project.ItemGroup[0].Compile[1].Include = "${projectName}Test.fs"
$proj.Save($fsProj)

./update-docs.ps1 $Exercise

$generatorsDir = Resolve-Path "generators"
$generator = "type $projectName() =`n    inherit GeneratorExercise()`n"
Add-Content -Path "$generatorsDir/Generators.fs" -Value $generator

./generate-tests.ps1 $Exercise

exit $LastExitCode