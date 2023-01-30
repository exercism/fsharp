# Pattern matching

```fsharp
module TwoFer

let twoFer nameOpt =
    let name =
        match nameOpt with
        | Some name -> name
        | None -> "you"

    $"One for {name}, one for me."
```

We use [pattern matching][pattern-match-identifier-pattern] to get the name we need to use in our greeting:

1. `Some name` matches when a name was specified. In this case, we'll just return that name
2. `None` matching when no name was specified. We'll return `"you"` in this case

We then use [string interpolation][string-interpolation] to build the return string where `{name}` is replaced with the name we just found.

## String formatting

The [string formatting article][article-string-formatting] discusses alternative ways to format the returned string.

[article-string-formatting]: https://exercism.org/tracks/fsharp/exercises/two-fer/articles/string-formatting
[pattern-match-identifier-pattern]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/pattern-matching#identifier-patterns
[string-interpolation]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/interpolated-strings
