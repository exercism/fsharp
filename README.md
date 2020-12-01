# Exercism F# Track

![Test](https://github.com/exercism/fsharp/workflows/Test/badge.svg)

Exercism exercises in F#

## Support and Discussion

We have a [gitter channel](https://gitter.im/exercism/xfsharp) where you can get support for any issues you might be facing (build setup, failing tests, etc.) or brainstorm with other people for the solution.


## Contributing Guide

Please see the [contributing guide](https://github.com/exercism/docs/tree/master/contributing-to-language-tracks)

## Local Tools

[PowerShell](https://github.com/PowerShell/PowerShell), [Fantomas](https://github.com/fsprojects/fantomas), and [FSharpLint](https://github.com/fsprojects/FSharpLint) are are available in this repo as [local tools](https://docs.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-0#local-tools). (This requires [.NET Core](https://dotnet.microsoft.com/download) >=3.0) Example usage:

```
> dotnet tool restore
Tool 'dotnet-fsharplint' (version '0.12.3') was restored. Available commands: dotnet-fsharplint
Tool 'fantomas-tool' (version '2.9.2') was restored. Available commands: fantomas
Tool 'powershell' (version '6.2.3') was restored. Available commands: pwsh

Restore was successful.

> dotnet fsharplint -sf generators/Track.fs
========== Linting generators/Track.fs ==========
========== Finished: 0 warnings ==========
========== Summary: 0 warnings ==========

> dotnet fantomas generators/Track.fs
generators/Track.fs has been written.

> dotnet pwsh ./test.ps1
Linting config.json
-> An implementation for 'bracket-push' was found, but config.json does not reference this exercise.
-> The implementation for 'bracket-push' is missing a README.
-> The implementation for 'bracket-push' is missing an example solution.
-> The implementation for 'bracket-push' is missing a test suite.
```

### F# icon
The F# Software Foundation logo for F# is an asset of the F# Software Foundation. We have adapted it with permission.
