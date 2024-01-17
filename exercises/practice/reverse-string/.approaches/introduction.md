# Introduction

The key to this exercise is to reverse a string's characters whilst F# strings being immutable.

## General guidance

- A `string`'s value cannot be changed (it is _immutable_). Therefore, to reverse a string you'll need to create a _new_ `string`.

- The most common way to create a new `string` (apart from hardcoding a string literal) is to call the [constructor that takes an array of characters][constructor-array-chars] (`char []`).

```exercism/note
F# strings represent text as a sequence of UTF-16 code units.
This means that you don't have to worry about multi-byte Unicode characters, as those are treated as one character.
```

## Approach: `Seq` module

```fsharp
let reverse input =
    input
    |> Seq.rev
    |> Seq.toArray
    |> System.String

```

This approach uses two functions from the [`Seq` module][seq-module] to first reverse the `string` and then convert the reversed characters back to a `string`.
For more information, check the [`Seq` module approach][approach-seq-module].

## Approach: `StringBuilder`

```fsharp
let reverse (input: string) =
    let chars = StringBuilder()
    for char in Seq.rev input do
        chars.Append(char) |> ignore
    chars.ToString()
```

This approach iterates over the string's characters backwards, building up the reverse string using a `StringBuilder`.
For more information, check the [`StringBuilder` approach][approach-string-builder].

## Which approach to use?

If readability is your primary concern (and it usually should be), the `Seq` module approach is hard to beat.

The `Array.Reverse()` approach is the best performing apporach.
For a more detailed breakdown, check the [performance article][article-performance].

The `StringBuilder` approach has the worst performance of the listed approach, and is more error-prone to write as it has to deal with lower and upper bounds checking.

[constructor-array-chars]: https://learn.microsoft.com/en-us/dotnet/api/system.string.-ctor
[article-performance]: https://exercism.org/tracks/fsharp/exercises/reverse-string/articles/performance
[approach-seq-module]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/seq-module
[approach-array-reverse]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/array-reverse
[approach-span]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/span
[approach-string-builder]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/string-builder
[seq-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html
