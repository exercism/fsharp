# Introduction

The key to this exercise is to work with the optional values as represented by [`Option<T>` type][options].

## General guidance

- Try to not repeat any string building logic ([DRY][dry])
- [String interpolation][article-string-formatting] is a great way to build strings

## Approach: `Option.defaultValue`

```fsharp
let twoFer (nameOpt: string option): string =
    let name = Option.defaultValue "you" nameOpt
    $"One for {name}, one for me."
```

This approach uses the [`Option.defaultValue` function][option.default-value] to handle the optional name.
For more information, check the [`Option.defaultValue` approach][approach-option.default-value].

## Approach: pattern matching

```fsharp
let twoFer (nameOpt: string option): string =
    let name =
        match nameOpt with
        | Some name -> name
        | None -> "you"

    $"One for {name}, one for me."
```

This approach uses pattern matching to handle the optional name.
For more information, check the [pattern matching approach][approach-pattern-matching].

## Which approach to use?

Both approaches are equally valid, so which one to choose is basically up to personal preference.

[options]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options
[approach-option.default-value]: https://exercism.org/tracks/fsharp/exercises/two-fer/approaches/option-default-value
[approach-pattern-matching]: https://exercism.org/tracks/fsharp/exercises/two-fer/approaches/pattern-matching
[article-string-formatting]: https://exercism.org/tracks/fsharp/exercises/two-fer/articles/string-formatting
[dry]: https://en.wikipedia.org/wiki/Don%27t_repeat_yourself
[option.default-value]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-core-optionmodule.html#defaultValue
