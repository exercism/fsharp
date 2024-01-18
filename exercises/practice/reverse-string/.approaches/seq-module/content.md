# `Seq` module

```fsharp
module ReverseString

let reverse input =
    input
    |> Seq.rev
    |> Seq.toArray
    |> System.String
```

The `string` class implements the `seq` interface (which is an abbreviation of the CLI `IEnumerable` interface), which means we can use functions from the [`Seq` module][seq-module] on it.

First, we pipe the input `string` into [`Seq.reverse`][seq.rev], which returns an enumerable with the input in reverse order.

To convert the `seq<char>` returned by `Seq.reverse` back to a `string`, we first use [`Seq.toArray`][seq.toArray] to convert it to a `char[]`.

Finally, we convert the `char` array back to a `string` by piping it into the `System.String` constructor.

[seq-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html
[seq.rev]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#rev
[seq.toArray]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#toArray
