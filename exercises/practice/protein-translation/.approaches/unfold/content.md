# Unfold

```fsharp
module ProteinTranslation

let proteins (rna: string): string list =
    let doProteins (rna: string): (string * string) option =
        match rna[0..2] with
        | "AUG" ->                         Some ("Methionine",    rna[3..])
        | "UUC" | "UUU" ->                 Some ("Phenylalanine", rna[3..])
        | "UUA" | "UUG" ->                 Some ("Leucine",       rna[3..])
        | "UCU" | "UCC" | "UCA" | "UCG" -> Some ("Serine",        rna[3..])
        | "UAU" | "UAC" ->                 Some ("Tyrosine",      rna[3..])
        | "UGU" | "UGC" ->                 Some ("Cysteine",      rna[3..])
        | "UGG" ->                         Some ("Tryptophan",    rna[3..])
        | "UAA" | "UAG" | "UGA" | "" ->    None
        | _ -> failwith "Unknown coding"

    rna
    |> Seq.unfold doProteins
    |> Seq.toList
```

The protein translation algorithm is basically a while loop that accumulates values and terminates when the "STOP" protein is reached or when there are no more codons left to translate.
This is a common enough pattern, that F# has a built-in function for this use case: [`Seq.unfold`][seq.unfold], which we'll use in this approach.

## `Seq.unfold`

The `Seq.unfold` function takes two arguments:

1. A function that takes a value and returns a value pair wrapped in an [`Option<T>`][options]
2. The initial value

The function can return either:

1. `Some (returnValue, newValue)`: continue executing, whilst adding the first value (`returnValue`) to the list of values to return, and use `newValue` as the value for the next call to the lambda
2. `None`: stop execution

Once the function returns `None`, the accumulated return values are returned.

## Unfolding the proteins

Now that we know how `Seq.unfold` works, let's use it to translate our codons.

Let's define a `doProteins` function that takes a `string` parameter representing the codons left to translate, and returns a `(string * string) option`.
The string pair consists of the translated protein and the remaining, unprocessed RNA:

```fsharp
let doProteins (rna: string): (string * string) option
```

We'll define this function inside the `proteins` function (also known as a _nested_ function), but it could just as well have been defined outside the `proteins` function.
That said, its implementation _is_ tied to the `Seq.unfold` call, so have it be close to that often makes sense (it signals to the reader that the function should only be used _within_ its parent function).

### Translating

As each codon is three letters long, the `doProteins` function looks at the first three letters of its `codons` parameter.
For each translateable codon, we return a pair of strings, the first being its protein translation and the second being the remainder of the codons (skipping the first three letters).
We'll wrap the pair in `Some` to signal `Seq.unfold` to continue processing:

```fsharp
match rna[0..2] with
| "AUG" -> Some ("Methionine", rna[3..])
| "UUC" -> Some ("Phenylalanine", rna[3..])
| "UUU" -> Some ("Phenylalanine", rna[3..])
| "UUA" -> Some ("Leucine", rna[3..])
| "UUG" -> Some ("Leucine", rna[3..])
| "UCU" -> Some ("Serine", rna[3..])
| "UCC" -> Some ("Serine", rna[3..])
| "UCA" -> Some ("Serine", rna[3..])
| "UCG" -> Some ("Serine", rna[3..])
| "UAU" -> Some ("Tyrosine", rna[3..])
| "UAC" -> Some ("Tyrosine", rna[3..])
| "UGU" -> Some ("Cysteine", rna[3..])
| "UGC" -> Some ("Cysteine", rna[3..])
| "UGG" -> Some ("Tryptophan", rna[3..])
```

### Stopping

Next up is to handle the "STOP" proteins.
We'll add branches for each of the three "STOP" proteins, which stop execution by returning `None`:

```fsharp
| "UAA" -> None
| "UAG" -> None
| "UGA" -> None
```

There is one additional case we need to process, and that is when there are no codons left to process:

```fsharp
| "" -> None
```

### Unknown input

At this point, the F# compiler lets us know that we haven't handled all possible cases, which is true.
The easiest thing to do is to throw an error if none of the previous branches matched:

```fsharp
| _ -> failwith "Unknown coding"
```

### Combining patterns

You might have noticed that many of the branches end up doing the exact same thing.
F# allows one to "chain" multiple patterns to reduce the duplication:

```fsharp
match rna[0..2] with
| "AUG" -> Some ("Methionine", rna[3..])
| "UUC" | "UUU" -> Some ("Phenylalanine", rna[3..])
| "UUA" | "UUG" -> Some ("Leucine", rna[3..])
| "UCU" | "UCC" | "UCA" | "UCG" -> Some ("Serine", rna[3..])
| "UAU" | "UAC" -> Some ("Tyrosine", rna[3..])
| "UGU" | "UGC" -> Some ("Cysteine", rna[3..])
| "UGG" -> Some ("Tryptophan", rna[3..])
| "UAA" | "UAG" | "UGA" | "" -> None
| _ -> failwith "Unknown coding"
```

### Alignment

While definitely not needed, aligning the code vertically makes it more clear that the codon patterns all end up doing basically the same thing, but with a different protein:

```fsharp
match rna[0..2] with
| "AUG" ->                         Some ("Methionine"   , rna[3..])
| "UUC" | "UUU" ->                 Some ("Phenylalanine", rna[3..])
| "UUA" | "UUG" ->                 Some ("Leucine"      , rna[3..])
| "UCU" | "UCC" | "UCA" | "UCG" -> Some ("Serine"       , rna[3..])
| "UAU" | "UAC" ->                 Some ("Tyrosine"     , rna[3..])
| "UGU" | "UGC" ->                 Some ("Cysteine"     , rna[3..])
| "UGG" ->                         Some ("Tryptophan"   , rna[3..])
| "UAA" | "UAG" | "UGA" | "" ->    None
| _ -> failwith "Unknown coding"
```

```exercism/note
A downside of vertical alignment is that changes to the code require more work, as you'll need to ensure everything is still aligned.
For this particular case, it isn't really an issue, as the codons are fixed and the code is thus unlikely to change.
```

### Step-by-step execution

Let's run through the `Seq.unfold` calls to get a better feel for it working as intended:

| Remaining RNA | Lambda return                   | Return values                                   |
| ------------- | ------------------------------- | ----------------------------------------------- |
| `"AUGUUUUGG"` | `Some ("Methionine", "UUUUGG")` | `["Methionine"]`                                |
| `"UUUUGG"`    | `Some ("Phenylalanine", "UGG")` | `["Methionine"; "Phenylalanine"]`               |
| `"UGG"`       | `Some ("Tryptophan", "")`       | `["Methionine"; "Phenylalanine"; "Tryptophan"]` |
| `""`          | `None`                          | `["Methionine"; "Phenylalanine"; "Tryptophan"]` |

You can see that we process the codons step by step, slowly building up the return values and returning them once we've processed them all.

## Putting it all together

Finally, we can put it all to together by piping the RNA into `Seq.unfold` with our `doProteins` function as its first argument, and then converting the sequence to a list via [Seq.toList][seq.tolist]:

```fsharp
rna
|> Seq.unfold doProteins
|> Seq.toList
```

We now have a working implementation that translates the RNA to proteins.

[seq.unfold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#unfold
[seq.length]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#length
[seq.tolist]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#toList
[options]: https://learn.microsoft.com/en-us/dotnet/fsharp/language-reference/options
