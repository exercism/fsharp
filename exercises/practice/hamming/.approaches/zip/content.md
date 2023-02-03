# Zip

```fsharp
module Hamming

let distance (strand1: string) (strand2: string): Option<int> =
    if strand1.Length <> strand2.Length then
        None
    else
        Seq.zip strand1 strand2
        |> Seq.filter (fun (letter1, letter2) -> letter1 <> letter2)
        |> Seq.length
        |> Some
```

## Error path

We start by checking if the strings have unequal lengths, and return `None` if so:

```fsharp
if strand1.Length <> strand2.Length then
    None
```

```exercism/note
Note that we're using `string` class' `Length` property, not a function like `Seq.length`.
Even though F# is a functional-first language, you'll use types (like the `string` class) defined in the .NET framework, which is an object-oriented framework.
Inevitably, you'll thus use objects that have methods and properties defined on them.
Don't worry about using methods and objects though, F# is a multi-paradigm language and embraces the interaction with object-oriented code (like the `string` class).
```

## Happy path

In the happy path, we know that the strings have the same length.
We're using this in our call to [`Seq.zip`][seq.zip]:

```fsharp
Seq.zip strand1 strand2
```

What `Seq.zip` does is it takes two sequences and returns a sequence of (tuple) pairs, with the first pair containing the first element of the first sequence _and_ the first element of the second sequence, and so on.
We can use this to create letter pairs, as a `string` can be treated like a `char` sequence:

```fsharp
Seq.zip "GAG" "CAT"
```

is equivalent to:

```fsharp
seq { ('G', 'C'); ('A', 'A'); ('G', 'T') }
```

The next step is to select only those pairs where the letters are different, we se do by piping the zipped sequence to [`Seq.filter`][seq.filter]:

```fsharp
|> Seq.filter (fun (letter1, letter2) -> letter1 <> letter2)
```

With that, we now have a sequence of pairs with different letters.
As the hamming distance _is_ the number of different letter pairs, we can calculate the distance by counting the letter pairs using [`Seq.length`][seq.length] and wrapping the count in a `Some` value:

```fsharp
|> Seq.length
|> Some
```

[seq.length]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#length
[seq.filter]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#filter
[seq.zip]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#zip
