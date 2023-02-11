# Recursion

```fsharp
module ProteinTranslation

let proteins (rna: string): string list =
    let rec doProteins (rna: string) (proteins: string list): string list =
        match rna[0..2] with
        | "AUG" ->                         doProteins rna[3..] ("Methionine"    :: proteins)
        | "UUC" | "UUU" ->                 doProteins rna[3..] ("Phenylalanine" :: proteins)
        | "UUA" | "UUG" ->                 doProteins rna[3..] ("Leucine"       :: proteins)
        | "UCU" | "UCC" | "UCA" | "UCG" -> doProteins rna[3..] ("Serine"        :: proteins)
        | "UAU" | "UAC" ->                 doProteins rna[3..] ("Tyrosine"      :: proteins)
        | "UGU" | "UGC" ->                 doProteins rna[3..] ("Cysteine"      :: proteins)
        | "UGG" ->                         doProteins rna[3..] ("Tryptophan"    :: proteins)
        | "UAA" | "UAG" | "UGA" | "" ->    List.rev proteins
        | _ -> failwith "Unknown coding"

    doProteins rna []
```

In this approach, we'll define a recursive function that will recursively process the RNA sequence and keep track of the translated proteins.

## Recursive translation

To use (tail call) recursion to translate the RNA to proteins, we'll introduce a helper function: `doProteins`.
This function takes the remaining, unprocessed RNA and a list of translated proteins (the _accumulator_ value):

```fsharp
let rec doProteins (rna: string) (proteins: string list): string list
```

We'll define this function inside the `proteins` function (also known as a _nested_ function), but it could just as well have been defined outside the `proteins` function.
That said, its implementation _is_ merely a helper to the `proteins` function and is thus tied to that function, so to have it be close to where it is called often makes sense (it signals to the reader that the function should only be used _within_ its parent function).

```exercism/note
To allow a function to recursively call itself, the `rec` modified must be added.
In other words: by default, functions cannot call themselves.
```

### Translating

As each codon is three letters long, the `doProteins` function looks at the first three letters of its `codons` parameter.
For each translateable codon, we recursively call the `doProteins` function, with the remainder of the codons (skipping the first three letters) and the codon's protein added to the proteins accumulator value as arguments.

```fsharp
match rna[0..2] with
| "AUG" -> doProteins rna[3..] ("Methionine" :: proteins)
| "UUC" -> doProteins rna[3..] ("Phenylalanine" :: proteins)
| "UUU" -> doProteins rna[3..] ("Phenylalanine" :: proteins)
| "UUA" -> doProteins rna[3..] ("Leucine" :: proteins)
| "UUG" -> doProteins rna[3..] ("Leucine" :: proteins)
| "UCU" -> doProteins rna[3..] ("Serine" :: proteins)
| "UCC" -> doProteins rna[3..] ("Serine" :: proteins)
| "UCA" -> doProteins rna[3..] ("Serine" :: proteins)
| "UCG" -> doProteins rna[3..] ("Serine" :: proteins)
| "UAU" -> doProteins rna[3..] ("Tyrosine" :: proteins)
| "UAC" -> doProteins rna[3..] ("Tyrosine" :: proteins)
| "UGU" -> doProteins rna[3..] ("Cysteine" :: proteins)
| "UGC" -> doProteins rna[3..] ("Cysteine" :: proteins)
| "UGG" -> doProteins rna[3..] ("Tryptophan" :: proteins)
```

### Stopping

Next up is to handle the "STOP" proteins.
We'll add branches for each of the three "STOP" proteins, which stop the recursion and instead return the (reversed) accumulator value:

```fsharp
| "UAA" -> List.rev proteins
| "UAG" -> List.rev proteins
| "UGA" -> List.rev proteins
```

There is one additional case we need to process, and that is when there are no codons left to process:

```fsharp
| "" -> List.rev proteins
```

```exercism/note
We need to use [`List.rev`](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#rev) to reverse the proteins, as translated proteins are added at the head of the list (in the front).
Prepending an element to a list is _much_ faster than appending an element.
In fact, it is so much faster that the penalty of having to reverse the list ends up being well worth it.
```

### Unknown input

At this point, the F# compiler lets us know that we haven't handled all possible cases, which is true.
The easiest thing to do is to throw an error if none of the previous branches matched:

```fsharp
| _ -> failwith "Unknown coding"
```

## Combining patterns

You might have noticed that many of the branches end up doing the exact same thing.
F# allows one to "chain" multiple patterns to reduce the duplication:

```fsharp
match rna[0..2] with
| "AUG" -> doProteins rna[3..] ("Methionine" :: proteins)
| "UUC" | "UUU" -> doProteins rna[3..] ("Phenylalanine" :: proteins)
| "UUA" | "UUG" -> doProteins rna[3..] ("Leucine" :: proteins)
| "UCU" | "UCC" | "UCA" | "UCG" -> doProteins rna[3..] ("Serine" :: proteins)
| "UAU" | "UAC" -> doProteins rna[3..] ("Tyrosine" :: proteins)
| "UGU" | "UGC" -> doProteins rna[3..] ("Cysteine" :: proteins)
| "UGG" -> doProteins rna[3..] ("Tryptophan" :: proteins)
| "UAA" | "UAG" | "UGA" | "" -> List.rev proteins
| _ -> failwith "Unknown coding"
```

### Alignment

While definitely not needed, aligning the code vertically makes it more clear that the codon patterns all end up doing basically the same thing, but with a different protein:

```fsharp
match rna[0..2] with
| "AUG" ->                         doProteins rna[3..] ("Methionine"    :: proteins)
| "UUC" | "UUU" ->                 doProteins rna[3..] ("Phenylalanine" :: proteins)
| "UUA" | "UUG" ->                 doProteins rna[3..] ("Leucine"       :: proteins)
| "UCU" | "UCC" | "UCA" | "UCG" -> doProteins rna[3..] ("Serine"        :: proteins)
| "UAU" | "UAC" ->                 doProteins rna[3..] ("Tyrosine"      :: proteins)
| "UGU" | "UGC" ->                 doProteins rna[3..] ("Cysteine"      :: proteins)
| "UGG" ->                         doProteins rna[3..] ("Tryptophan"    :: proteins)
| "UAA" | "UAG" | "UGA" | "" ->    List.rev proteins
| _ -> failwith "Unknown coding"
```

```exercism/note
A downside of vertical alignment is that changes to the code require more work, as you'll need to ensure everything is still aligned.
For this particular case, it isn't really an issue, as the codons are fixed and the code is thus unlikely to change.
```

## Putting it all together

The final step is to call our recursive helper function:

```fsharp
doProteins rna []
```

And with that, we have a working, tail recursive implementation that translates the RNA to proteins.

```exercism/note
Tail recursion prevents stack overflows when a recursive function is called many times.
While the exercise does not have large test cases that would cause a stack overflow, it is good practice to always use using tail recursion when implementing a recursive functions.
If you'd like to read more about tail recursion, [this MSDN article](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/) goes into more detail.
Another good resource on tail recursion is [this blog post](http://blog.ploeh.dk/2015/12/22/tail-recurse/).
```
