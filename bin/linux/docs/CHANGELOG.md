# Journal of changes

These are notes on changes made while developing tooling for `fsharp` track of Exercism and Linux platform.

## Nov 17, 2026

Started with porting Powershell scripts to their equivalents for Linux (bash scripts)

The very first lines in each Powershell script define how to parse command line arguments, like so:

```powershell
param (
    [Parameter(Position = 0, Mandatory = $true)][string]$Exercise,
    [Parameter(Position = 1, Mandatory = $true)][string]$Author,
    [Parameter(Position = 2)][int]$Difficulty = 1
)
```

We need and alternative in bash. So here is version 0.1.0:

- Added `command-line-parser` folder.
- Added `argument.sh` and `no-argument.sh` scripts.
- Prepared folders for documentation and tests and wrote a few files to those folders.

In short, version 0.1.0 forms a skeleton of future project and adds a simple command line parser implementation, but does not contain any actual work on translating the Powershell scripts yet.

## Nov 18, 2026

Version 0.1.1

- Added implementation of code snippet checker.
- Added implementation of exercise tools updater.

Translation of other Powershell scripts is more complex. Their translations are just stubbed for now. They will be translated one at time.
