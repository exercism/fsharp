<#
.SYNOPSIS
    Update exercise tools.
.DESCRIPTION
    Update the exercise tools for each exercise.
.EXAMPLE
    PS C:\> bin/update-exercise-tools.ps1
#>

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

Get-ChildItem -Path exercises -Filter dotnet-tools.json -Force -Recurse | ForEach-Object {
    dotnet tool update fantomas --tool-manifest $_.FullName
}
