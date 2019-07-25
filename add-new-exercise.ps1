param (
    [Parameter(Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = @(),
    [Parameter()][bool]$Core,
    [Parameter()][int32]$Difficulty = 1,
    [Parameter()][NullString]$UnlockedBy
)

class Exercise {
    [String]$slug = ""
    [guid]$uuid = [Guid]::Empty
    [Boolean]$core = $false
    [NullString]$unlocked_by
    [int32]$difficulty = 1
    [string[]]$topics = $null

    Exercise ([String]$Slug, [String[]]$Topics, [Boolean]$Core, [int32]$Difficulty, [NullString]$UnlockedBy) {
        $this.slug = $Slug
        $this.topics = $Topics
        $this.uuid = [Guid]::NewGuid()
        $this.core = $Core
        $this.difficulty = $Difficulty
        $this.unlocked_by = $UnlockedBy
    }
}

function Restore-Indentation {
    $newContent = $args[0]
    $newContent = $newContent -replace " {41}", "        "
    $newContent = $newContent -replace " {37}", "      "
    $newContent = $newContent -replace " {26}", "      "
    $newContent = $newContent -replace " {22}", "    "
    $newContent = $newContent -replace " {21}", "    "
    $newContent = $newContent -replace " {17}", "  "
    $newContent = $newContent -replace "(?<! |\n) {2}(?! )", " "
    $newContent
}

$projectName = (Get-Culture).TextInfo.ToTitleCase($Exercise).Replace("-", "")
$config = ConvertFrom-JSON -InputObject ([IO.File]::ReadAllText("./config.json"))
$Exercises = $config.Exercises
$newExercise = New-Object -Typename Exercise -ArgumentList $Exercise, $Topics, $Core, $Difficulty, $UnlockedBy
$Exercises += $newExercise
$config.Exercises = $Exercises;

$newContent = ConvertTo-Json -InputObject $config -Depth 10
$newContent = Restore-Indentation $newContent
[IO.File]::WriteAllText("./config.json", $newContent)

$exercisesDir = Resolve-Path "exercises"
$exerciseDir = Join-Path $exercisesDir $Exercise
$fsProj = "$exerciseDir/$projectName.fsproj"

dotnet new xunit -lang "F#" -o $exerciseDir -n $projectName
dotnet sln "$exercisesDir/Exercises.sln" add $fsProj

Remove-Item -Path "$exerciseDir/Program.fs" 
Remove-Item -Path "$exerciseDir/Tests.fs"

New-Item -ItemType File -Path "$exerciseDir/$projectName.fs"
New-Item -ItemType File -Path "$exerciseDir/${projectName}Test.fs"
New-Item -ItemType File -Path "$exerciseDir/Example.fs"

[xml]$proj = Get-Content $fsProj
$proj.Project.ItemGroup[0].Compile[0].Include = "$projectName.fs"
$proj.Project.ItemGroup[0].Compile[1].Include = "${projectName}Test.fs"
$proj.Save($fsProj)

exit $LastExitCode