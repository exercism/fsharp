# StringBuilder

```fsharp
module ReverseString

open System.Text

let reverse (input: string) =
    let chars = StringBuilder()
    for char in Seq.rev input do
        chars.Append(char) |> ignore
    chars.ToString()
```

Strings can also be created using the [`StringBuilder`][string-builder] class.
The purpose of this class is to efficiently and incrementally build a `string`.

```exercism/note
A `StringBuilder` is often overkill when used to create short strings, but can be very useful to create larger strings.
```

The first step is to create a `StringBuilder`.
We then use a `for`-loop to walk through the string's characters in reverse order via the [`Seq.rev` function][seq.rev], appending them to the `StringBuilder` via its [`Append()`][string-builder-append] method.

Finally, we return the reversed `string` by calling the `ToString()` method on the `StringBuilder` instance.

[string-builder]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder
[string-builder-append]: https://learn.microsoft.com/en-us/dotnet/api/system.text.stringbuilder.append
[seq.rev]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#rev
