<#
.SYNOPSIS
    Validate F# code snippets in concept exercise documentation.
.DESCRIPTION
    Run a CLI utility that will:
    - recursively search a list of directories for Markdown documentation
    - extract any F# code snippets
    - evaluate them to verify correct syntax (no type checking is performed)
.PARAMETER SourceDirectories
    A list of directories containing Markdown documentation (defaults to ["concepts","exercises"]).
.PARAMETER Exclude
    A list of directories to ignore (optional).
.EXAMPLE
    PS C:\> ./check-code-snippets.ps1
    Verifies all *.md files under the `concepts` and `exercises` directories
.EXAMPLE
    PS C:\> ./check-code-snippets.ps1 -Dirs "concepts/recursion exercises/concept/pizza-pricing"
    Verifies the *.md files under `concepts/recursion` and `exercises/concept/pizza-pricing`
.EXAMPLE
    PS C:\> ./check-code-snippets.ps1 -Exclude "concepts/arrays exercises/concept/bird-watcher"
    Ignores the *.md files in `concepts/arrays` and `exercises/concept/bird-watcher` while verifying all the others
.EXAMPLE
    PS C:\> ./check-code-snippets.ps1 exercises -Not "exercises/practice/acronym"
    Verifies the *.md files under the `exercises` directory, except those in `exercises/practice/acronym`
#>

[CmdletBinding()]
param (
    [Parameter(Position = 0, Mandatory = $false)]
    [alias("Dirs")]
    [string[]]$SourceDirectories=@("concepts", "exercises"),

    [Parameter(Position = 1, Mandatory = $false)]
    [alias("Not")]
    [string[]]$Exclude=@()
)

$toolDir = Resolve-Path "tools/CodeFenceChecker"

# Import shared functionality
. ./shared.ps1

function Check-DocumentationCodeExamples {
    $searchDirs = [string]::Join(' ', $SourceDirectories)
    $ignored = [string]::Join(' ', $Exclude)
    Write-Output "Searching documentation for code snippets"
    Run-Command "dotnet run -c Release --project $toolDir -- $searchDirs -Not $ignored"
}

Check-DocumentationCodeExamples -SourceDirectories $SourceDirectories

exit $LastExitCode
