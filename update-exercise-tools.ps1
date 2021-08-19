<#
.SYNOPSIS
    Add dotnet tools to exercises.
.DESCRIPTION
    For each exercise, create a tool manifest and add/upgrade fantomas.
.PARAMETER FantomasVersion
    Target version of the `fantomas-tool` NuGet package (defaults to current latest version).
.EXAMPLE
    PS C:\> ./update-exercise-tools.ps1
.EXAMPLE
    PS C:\> ./update-exercise-tools.ps1 4.4.0
#>

param (
    [Parameter(Position = 0, Mandatory = $false)]
    [string]$FantomasVersion="4.5.2"
)

# Import shared functionality
. ./shared.ps1

function Add-Tools {
    Param ($Path="exercises")

    # explicitly ignore dot directories as Windows will not treat them as hidden
    $dir=Get-ChildItem -Directory $Path -Exclude @(".*", "bin", "obj")

    # recur to bottom of directory tree
    If ($dir.Count -eq 0) {
        # make sure this directory contains a project
        $isProjectDir=(Test-Path "$Path/*.fsproj")
        $manifestPath="$Path/.config/dotnet-tools.json"

        # check for an existing tool manifest
        $hasManifest=(Test-Path $manifestPath)

        # validate version number
        $hasValidToolVersion=($FantomasVersion -match '^(\d+\.){2}\d+$')

        # assume tools are out of date
        $needsUpdate=$true
        $versionArg=$null

        If ($hasValidToolVersion -and $hasManifest) {
            $currentVersion=(
                Get-Content -Raw -Path $manifestPath | ConvertFrom-Json
            ).tools."fantomas-tool".version

            $needsUpdate=($currentVersion -ne $FantomasVersion)
        }

        If ($isProjectDir -and $needsUpdate) {
            If ($hasValidToolVersion) {
                $versionArg="--version $FantomasVersion"
            }
            Write-Output "Writing tool manifest to $Path/.config"
            Run-Command "dotnet new tool-manifest -o $Path --force"
            Run-Command "dotnet tool install --tool-manifest $manifestPath fantomas-tool $versionArg"
        }
    } Else {
        $dir | ForEach-Object {Add-Tools $_.FullName}
    }
}

Write-Output "Adding dotnet tools"
Add-Tools

exit $LastExitCode