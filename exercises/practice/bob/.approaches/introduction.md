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

TODO

For more information, check the [`if` expressions approach][approach-if].

## Which approach to use?

TODO

[trim]: https://learn.microsoft.com/en-us/dotnet/api/system.string.trim
[endswith]: https://learn.microsoft.com/en-us/dotnet/api/system.string.endswith
[dry]: https://en.wikipedia.org/wiki/Don%27t_repeat_yourself
[approach-if]: https://exercism.org/tracks/fsharp/exercises/bob/approaches/if
