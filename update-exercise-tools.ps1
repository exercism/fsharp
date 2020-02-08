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
    Write-Output "Adding dotnet tools"
    Get-ChildItem -Directory "exercises" | ForEach-Object {
        Run-Command "dotnet new tool-manifest -o $_"
        Run-Command "dotnet tool install --tool-manifest $_/.config/dotnet-tools.json fantomas-tool"
    }
}

Add-Tools

exit $LastExitCode