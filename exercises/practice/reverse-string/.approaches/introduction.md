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

## Alternative approach: `Span<T>`

```fsharp
let reverse (input: string) =
    let memory = NativePtr.stackalloc<byte>(input.Length) |> NativePtr.toVoidPtr
    let span = Span<char>(memory, input.Length)

    for i in 0..input.Length - 1 do
        span[input.Length - 1 - i] <- input[i]

    span.ToString()
```

This approach uses the `Span<T>` type, which is a highly optimized type designed to have great performance.
For more information, check the [`Span<T>` approach][approach-span].

## Which approach to use?

If readability is your primary concern (and it usually should be), the `Seq` module approach is hard to beat.

[constructor-array-chars]: https://learn.microsoft.com/en-us/dotnet/api/system.string.-ctor
[approach-seq-module]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/seq-module
[approach-span]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/span
[approach-string-builder]: https://exercism.org/tracks/fsharp/exercises/reverse-string/approaches/string-builder
[seq-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html
