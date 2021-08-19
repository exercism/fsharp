<#
.SYNOPSIS
    Add dotnet tools to exercises.
.DESCRIPTION
    For each exercise, create a tool manifest and add fantomas.
.EXAMPLE
    PS C:\> ./update-exercise-tools.ps1
#>

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
	
        If ($isProjectDir) {
            Write-Output "Writing tool manifest to $Path/.config"
            Run-Command "dotnet new tool-manifest -o $Path --force"
            Run-Command "dotnet tool install --tool-manifest $Path/.config/dotnet-tools.json fantomas-tool"
        }
    } Else {
        $dir | ForEach-Object {Add-Tools $_.FullName}
    }
}

Write-Output "Adding dotnet tools"
Add-Tools

exit $LastExitCode