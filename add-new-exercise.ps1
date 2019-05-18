param (
    [Parameter(Mandatory=$true)][string]$exercise,
    [Parameter()][string[]]$topics,
    [Parameter()][bool]$core,
    [Parameter()][int32]$difficulty,
    [Parameter()][string]$unlocked_by
 )

class Exercise {
    [String]$slug = ""
    [guid]$uuid = [Guid]::Empty
    [Boolean]$core = $false
    [int32]$difficulty = 1
    [string[]]$topics
    [string]$unlocked_by = $null

    Exercise ([String]$slug, [String[]]$topics, [Boolean]$core,[int32]$difficulty,[string]$unlocked_by)
    {
        $this.slug = $slug
        $this.topics = $topics
        $this.uuid = [Guid]::NewGuid()
        $this.core = $core
        $this.difficulty = $difficulty
        $this.unlocked_by = $unlocked_by
    }
}
# create new folder and update config
$projectName = (Get-Culture).TextInfo.ToTitleCase($exercise).Replace("-", "")
New-Item -Path "exercises\$exercise" -ItemType Directory
$config =  ConvertFrom-JSON -InputObject ([IO.File]::ReadAllText("./config.json"))
$exercises = $config.exercises
$newExercise = New-Object -Typename Exercise -ArgumentList $exercise, $topics, $core, $difficulty, $unlocked_by
$exercises += $newExercise
$config.exercises = $exercises;
$newContent = ConvertTo-Json -InputObject $config
[IO.File]::WriteAllText("./config.json",$newContent)

$fsProj = "exercises/$exercise/$projectName.fsproj"
dotnet new classlib -lang F# -o "exercises/$exercise" -n $projectName
dotnet sln "exercises/Exercises.sln" add $fsProj
dotnet add "exercises/$exercise/$projectName.fsproj" package "Microsoft.NET.Test.Sdk"
dotnet add "exercises/$exercise/$projectName.fsproj" package "xunit"
dotnet add "exercises/$exercise/$projectName.fsproj" package "FsUnit.xUnit"
dotnet add "exercises/$exercise/$projectName.fsproj" package "xunit.runner.visualstudio"
New-Item -Path "exercises/$exercise/$projectName.fs" -ItemType File
New-Item -Path ("exercises/$exercise/$projectName" + "Test.fs") -ItemType File
New-Item -Path "exercises/$exercise/Example.fs" -ItemType File
[xml]$proj = Get-Content $fsProj

$proj.Project.ItemGroup[0].Compile.Include = "$projectName.fs"
$exFileTest = $proj.CreateElement("Compile")
$exFileTest.SetAttribute("Include","$projectName" + "Test.fs")
$proj.Project.ItemGroup[0].AppendChild($exFileTest)
$proj.Save($fsProj)