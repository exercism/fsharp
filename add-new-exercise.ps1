param (
    [Parameter(Mandatory = $true)][string]$Exercise,
    [Parameter()][string[]]$Topics = $null,
    [Parameter()][bool]$Core,
    [Parameter()][int32]$Difficulty = 1,
    [Parameter()][String]$UnlockedBy = $null
)

class Exercise {
    [String]$slug = ""
    [guid]$uuid = [Guid]::Empty
    [Boolean]$core = $false
    [string]$unlocked_by = $null
    [int32]$difficulty = 1
    [string[]]$topics = $null

    Exercise ([String]$Slug, [String[]]$Topics, [Boolean]$Core, [int32]$Difficulty, [String]$UnlockedBy) {
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
New-Item -Path "Exercises/$Exercise" -ItemType Directory
$config = ConvertFrom-JSON -InputObject ([IO.File]::ReadAllText("./config.json"))
$Exercises = $config.Exercises
$newExercise = New-Object -Typename Exercise -ArgumentList $Exercise, $Topics, $Core, $Difficulty, $UnlockedBy
$Exercises += $newExercise
$config.Exercises = $Exercises;
$newContent = ConvertTo-Json -InputObject $config -Depth 10
$newContent = Restore-Indentation $newContent
$newContent = $newContent -replace "\\u0027", "'"
$newContent = $newContent -replace 'unlocked_by": ""', 'unlocked_by": null'
[IO.File]::WriteAllText("./config.json", $newContent)

$fsProj = "Exercises/$Exercise/$projectName.fsproj"
dotnet new xunit -lang F# -o "Exercises/$Exercise" -n $projectName
dotnet sln "Exercises/Exercises.sln" add $fsProj
Remove-Item -Path "Exercises/$Exercise/Program.fs" 
Remove-Item -Path "Exercises/$Exercise/Tests.fs"

New-Item -Path "Exercises/$Exercise/$projectName.fs" -ItemType File
New-Item -Path ("Exercises/$Exercise/${projectName}Test.fs") -ItemType File
New-Item -Path "Exercises/$Exercise/Example.fs" -ItemType File
[xml]$proj = Get-Content $fsProj

$proj.Project.ItemGroup[0].Compile[0].Include = "$projectName.fs"
$proj.Project.ItemGroup[0].Compile[1].Include = "${projectName}Test.fs"
$proj.Save($fsProj)

exit $LastExitCode