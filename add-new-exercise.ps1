param (
    [Parameter(Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = @(),
    [Parameter()][switch]$Core,
    [Parameter()][int]$Difficulty = 1,
    [Parameter()]$UnlockedBy
)

class Exercise {
    [guid]$uuid
    [string]$slug
    [string[]]$topics
    [bool]$core
    [int]$difficulty
    $unlocked_by

    Exercise ([string]$Slug, [string[]]$Topics, [bool]$Core, [int]$Difficulty, $UnlockedBy) {
        $this.uuid = [Guid]::NewGuid()
        $this.slug = $Slug
        $this.topics = $Topics
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
$configJson = Resolve-Path "config.json"

$config = Get-Content $configJson | ConvertFrom-JSON
$config.Exercises += [Exercise]::new($Exercise, $Topics, $Core.IsPresent, $Difficulty, $UnlockedBy)

$newContent = ConvertTo-Json -InputObject $config -Depth 10
$newContent = Restore-Indentation $newContent
Set-Content -Path $configJson -Value $newContent

$exercisesDir = Resolve-Path "exercises"
$exerciseDir = Join-Path $exercisesDir $Exercise
$fsProj = "$exerciseDir/$projectName.fsproj"

dotnet new xunit -lang "F#" -o $exerciseDir -n $projectName
dotnet sln "$exercisesDir/Exercises.sln" add $fsProj

Remove-Item -Path "$exerciseDir/Program.fs" 
Remove-Item -Path "$exerciseDir/Tests.fs"

New-Item -ItemType File -Path "$exerciseDir/$projectName.fs" -Value "module $projectName"
New-Item -ItemType File -Path "$exerciseDir/${projectName}Test.fs" -Value "open $projectName"
New-Item -ItemType File -Path "$exerciseDir/Example.fs" -Value "module $projectName"

[xml]$proj = Get-Content $fsProj
$proj.Project.ItemGroup[0].Compile[0].Include = "$projectName.fs"
$proj.Project.ItemGroup[0].Compile[1].Include = "${projectName}Test.fs"
$proj.Save($fsProj)

exit $LastExitCode