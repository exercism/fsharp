# `Seq` module

```fsharp
module ProteinTranslation

let private codonToProtein (codon: string): string =
    match codon with
    | "AUG"                         -> "Methionine"
    | "UUC" | "UUU"                 -> "Phenylalanine"
    | "UUA" | "UUG"                 -> "Leucine"
    | "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
    | "UAU" | "UAC"                 -> "Tyrosine"
    | "UGU" | "UGC"                 -> "Cysteine"
    | "UGG"                         -> "Tryptophan"
    | "UAA" | "UAG" | "UGA"         -> "STOP"
    | _ -> failwith "Invalid codon"

let proteins (rna: string): string list =
    rna
    |> Seq.chunkBySize 3
    |> Seq.map System.String
    |> Seq.map codonToProtein
    |> Seq.takeWhile (fun protein -> protein <> "STOP")
    |> Seq.toList
```

This approach combines a number of functions from the [`Seq` module][seq-module] to build up a pipeline to translate the RNA to proteins.

## Translating

Let's define a `codonToProtein` function that takes a `string` parameter representing the codon and returns the translated protein, also as a string:

```fsharp
let private codonToProtein (codon: string): string
```

~~~~exercism/note
We could have defined this function as a nested function within the `proteins` function, but as it could reasonably be used _outside_ the `proteins` function, we chose not to.
~~~~

Within the function, we simply pattern match on the codon to translate it to its corresponding protein:

```fsharp
match codon with
| "AUG" -> "Methionine"
| "UUC" -> "Phenylalanine"
| "UUU" -> "Phenylalanine"
| "UUA" -> "Leucine"
| "UUG" -> "Leucine"
| "UCU" -> "Serine"
| "UCC" -> "Serine"
| "UCA" -> "Serine"
| "UCG" -> "Serine"
| "UAU" -> "Tyrosine"
| "UAC" -> "Tyrosine"
| "UGU" -> "Cysteine"
| "UGC" -> "Cysteine"
| "UGG" -> "Tryptophan"
| "UAA" -> "STOP"
| "UAG" -> "STOP"
| "UGA" -> "STOP"
| _ -> failwith "Invalid codon"
```

## Combining patterns

You might have noticed that many of the branches end up doing the exact same thing.
F# allows one to "chain" multiple patterns to reduce the duplication:

```fsharp
match codon with
| "AUG" -> "Methionine"
| "UUC" | "UUU" -> "Phenylalanine"
| "UUA" | "UUG" -> "Leucine"
| "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
| "UAU" | "UAC" -> "Tyrosine"
| "UGU" | "UGC" -> "Cysteine"
| "UGG" -> "Tryptophan"
| "UAA" | "UAG" | "UGA" -> "STOP"
| _ -> failwith "Unknown coding"
```

### Alignment

While definitely not needed, aligning the code vertically makes it more clear that the codon patterns all end up doing basically the same thing, but with a different protein:

```fsharp
match codon with
| "AUG"                         -> "Methionine"
| "UUC" | "UUU"                 -> "Phenylalanine"
| "UUA" | "UUG"                 -> "Leucine"
| "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
| "UAU" | "UAC"                 -> "Tyrosine"
| "UGU" | "UGC"                 -> "Cysteine"
| "UGG"                         -> "Tryptophan"
| "UAA" | "UAG" | "UGA"         -> "STOP"
| _ -> failwith "Unknown coding"
```

### Using `function` instead of `match`

As the `codonToProtein` function has one argument on which the function then immediately starts pattern matching, one could rewrite it using the [`function` keyword][function-keyword]:

```fsharp
let private codonToProtein =
    function
    | "AUG"                         -> "Methionine"
    | "UUC" | "UUU"                 -> "Phenylalanine"
    | "UUA" | "UUG"                 -> "Leucine"
    | "UCU" | "UCC" | "UCA" | "UCG" -> "Serine"
    | "UAU" | "UAC"                 -> "Tyrosine"
    | "UGU" | "UGC"                 -> "Cysteine"
    | "UGG"                         -> "Tryptophan"
    | "UAA" | "UAG" | "UGA"         -> "STOP"
    | _ -> failwith "Invalid codon"
```

What function does is to return a one-parameter function that pattern matches on that parameter.
The following definitions are thus functional equivalent:

```fsharp
let private codonToProtein codon =
    match codon with
    | "AUG" -> "Methionine"

let private codonToProtein =
    function
    | "AUG" -> "Methionine"

let private codonToProtein =
    fun codon ->
        match codon with
        | "AUG" -> "Methionine"
```

Whilst they are all valid, the first option (function with parameter and explicit `match`) is preferred for readability.

## Putting it all together

Now that we can translated RNA to proteins, let's build up a working solution.

### Split RNA sequence into codons

First, let's split our `rna` parameter into chunks of three letters:

```fsharp
rna
|> Seq.chunkBySize 3
|> Seq.map System.String
```

The [`Seq.chunkBySize`][seq.chunk-by-size] function will split the `string` into a sequence of three letters.
We then use [`Seq.map`][seq.map] to convert those three letter sequences into strings (basically: concatenating the letters), which represent the codons.

### Converting to proteins

Next up is converting the codons to proteins, once again using `Seq.map`:

```fsharp
|> Seq.map codonToProtein
```

### Stopping

Then we'll need to stop processing when we encounter a "STOP" protein.
For that we can use [`Seq.takeWhile`][seq.take-while], where we pass in a lambda function that checks if the protein is not the "STOP" protein.
It is isn't the element is preserved, and the next element is checked, until either there are no elements or a "STOP" protein is found (this protein is _not_ included in the results).

```fsharp
|> Seq.takeWhile (fun protein -> protein <> "STOP")
```

~~~~exercism/note
One could also write the above as:

```fsharp
|> Seq.takeWhile ((<>) "STOP")
```

However, this is arguably less readable.
~~~~

### Converting to a list

Finally, we convert the sequence to a list via [Seq.toList][seq.tolist]:

```fsharp
|> Seq.toList
```

### Combining it all

This gives us the following pipeline:

```fsharp
let proteins (rna: string): string list =
    rna
    |> Seq.chunkBySize 3
    |> Seq.map System.String
    |> Seq.map codonToProtein
    |> Seq.takeWhile (fun protein -> protein <> "STOP")
    |> Seq.toList
```

We now have a working implementation that translates the RNA to proteins.

[function-keyword]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/match-expressions#remarks
[seq.chunk-by-size]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#chunkBySize
[seq.map]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#map
[seq.take-while]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#takeWhile
[seq-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html
[seq.tolist]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#toList
