# Introduction

The key to this exercise is to look at pattern in a `string`.

## General guidance

Regardless of the approach used, here are some things to consider:

- If the input is trimmed, [Trim][trim] only once.

- Use the [EndsWith][endswith] `String` method instead of checking the last character by index for `?`.

- Don't copy/paste the logic for determining a shout and for determing a question into determing a shouted question.
  Combine the two determinations instead of copying them.
  Not duplicating the code will keep the code [DRY][dry].

- Perhaps consider making `IsQuestion` and `IsShout` values set once instead of functions that are possibly called twice.

## Approach: `if` expressions

```fsharp
let response (phrase: string): string =
    let isEmpty = System.String.IsNullOrWhiteSpace phrase
    let isYell = phrase <> phrase.ToLower() && phrase = phrase.ToUpper()
    let isQuestion = phrase.Trim().EndsWith "?"

    if isEmpty then
        "Fine. Be that way!"
    elif isYell && isQuestion then
        "Calm down, I know what I'm doing!"
    elif isYell then
        "Whoa, chill out!"
    elif isQuestion then
        "Sure."
    else
        "Whatever."
```

This approach uses `if/elif/else` expressions to conditionally handle the different types of response.
For more information, check the [`if` expressions approach][approach-if].

## Approach: Active Patterns

```fsharp
let (|Empty|_|) (phrase: string) =
    if System.String.IsNullOrWhiteSpace phrase then Some () else None

let (|Yell|_|) (phrase: string) =
    if phrase <> phrase.ToLower() && phrase = phrase.ToUpper() then Some () else None

let (|Question|_|) (phrase: string) =
    if phrase.Trim().EndsWith "?" then Some () else None

let response (phrase: string): string =
    match phrase with
    | Empty -> "Fine. Be that way!"
    | Yell & Question -> "Calm down, I know what I'm doing!"
    | Yell -> "Whoa, chill out!"
    | Question -> "Sure."
    | _ -> "Whatever."
```

This approach uses Active Patterns to handle the different types of responses.
For more information, check the [Active Patterns approach][approach-active-pattern].

## Which approach to use?

TODO

[trim]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trim
[endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith
[dry]: https://en.wikipedia.org/wiki/Don%27t_repeat_yourself
[approach-if]: https://exercism.org/tracks/fsharp/exercises/bob/approaches/if
