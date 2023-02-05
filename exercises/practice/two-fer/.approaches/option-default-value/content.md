# `Option.defaultValue`

```fsharp
let twoFer (nameOpt: string option): string =
    let name = Option.defaultValue "you" nameOpt
    $"One for {name}, one for me."
```

We use the [`Option.defaultValue`][option.default-value] function which either returns the value within the `Option<T>` value passed to it, or else returns the default value we pass to it (`"you"`).

We then use [string interpolation][string-interpolation] to build the return string where `{name}` is replaced with the name we just found.

## String formatting

The [string formatting article][article-string-formatting] discusses alternative ways to format the returned string.

[article-string-formatting]: https://exercism.org/tracks/fsharp/exercises/two-fer/articles/string-formatting
[pattern-match-identifier-pattern]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#identifier-patterns
[string-interpolation]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/interpolated-strings
[option.default-value]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#defaultValue
