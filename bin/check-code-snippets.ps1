<#
.SYNOPSIS
    Validate F# code snippets in concept exercise documentation.
.DESCRIPTION
    Run a CLI utility that will:
    - recursively search a list of directories for Markdown documentation
    - extract any F# code snippets
    - evaluate them to verify correct syntax (no type checking is performed)
.EXAMPLE
    PS C:\> bin/check-code-snippets.ps1
    Verifies all *.md files under the `concepts` and `exercises` directories
#>

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

Write-Output "Searching documentation for code snippets"
& dotnet run -c Release --project tools/CodeFenceChecker
