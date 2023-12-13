# List comprehension

```fsharp
module Hamming

let distance (strand1: string) (strand2: string) : int option =

    if strand1.Length <> strand2.Length
    then None
    else
        [ for idx in 0 .. strand1.Length - 1 do
            if strand1[idx] <> strand2[idx] then yield 1 else yield 0 ]
        |> List.sum
        |> Some
```

## Error path

We start by checking if the strings have unequal lengths, and return `None` if so:

```fsharp
if strand1.Length <> strand2.Length
then None
```

~~~~exercism/note
Note that we're using `string` class' `Length` property, not a function like `Seq.length`.
Even though F# is a functional-first language, you'll use types (like the `string` class) defined in the .NET framework, which is an object-oriented framework.
Inevitably, you'll thus use objects that have methods and properties defined on them.
Don't worry about using methods and objects though, F# is a multi-paradigm language and embraces the interaction with object-oriented code (like the `string` class).
~~~~

## Happy path

In the happy path, we know that the strings have the same length so we can use the length (minus one) of the first string as the max of a range of _indices_ to use to access each `char` of both `string`s and compare them:

```fsharp
for idx in 0 .. strand1.Length - 1 do
```

The entire `for` expression is surrounded by square brackets (`[]`) indicating that this is a [List comprehension][list-comprehension].
This gives you the power of returning intermediate results based on comparing each pair of `char`s (returning a `1` when they differ or a `0` if they don't) and then continuing the next pair until you reach the end:

```fsharp
if strand1[idx] <> strand2[idx] then yield 1 else yield 0
```

The `yield` keyword indicates that this concerns an intermediate result, this can also be used in [C#][yield-return].

The resulting list of `1`'s and `0`'s is then _piped_ into a [List.sum][list.sum] to get the hamming distance and finally the result is wrapped in a `Some`.

```fsharp
|> List.sum
|> Some
```

[list-comprehension]: https://en.wikibooks.org/wiki/F_Sharp_Programming/Lists#Using_List_Comprehensions
[list.sum]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/lists#arithmetic-operations-on-lists
[yield-return]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield