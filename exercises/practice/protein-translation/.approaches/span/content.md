# `Span<T>`

```fsharp
module ProteinTranslation

open System

let rec private doProteins (codons: ReadOnlySpan<char>) (proteins: string list): string list =
    if   codons.StartsWith("AUG") then doProteins (codons.Slice(3)) ("Methionine"    :: proteins)
    elif codons.StartsWith("UUC") then doProteins (codons.Slice(3)) ("Phenylalanine" :: proteins)
    elif codons.StartsWith("UUU") then doProteins (codons.Slice(3)) ("Phenylalanine" :: proteins)
    elif codons.StartsWith("UUA") then doProteins (codons.Slice(3)) ("Leucine"       :: proteins)
    elif codons.StartsWith("UUG") then doProteins (codons.Slice(3)) ("Leucine"       :: proteins)
    elif codons.StartsWith("UCU") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
    elif codons.StartsWith("UCC") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
    elif codons.StartsWith("UCA") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
    elif codons.StartsWith("UCG") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
    elif codons.StartsWith("UAU") then doProteins (codons.Slice(3)) ("Tyrosine"      :: proteins)
    elif codons.StartsWith("UAC") then doProteins (codons.Slice(3)) ("Tyrosine"      :: proteins)
    elif codons.StartsWith("UGU") then doProteins (codons.Slice(3)) ("Cysteine"      :: proteins)
    elif codons.StartsWith("UGC") then doProteins (codons.Slice(3)) ("Cysteine"      :: proteins)
    elif codons.StartsWith("UGG") then doProteins (codons.Slice(3)) ("Tryptophan"    :: proteins)
    elif codons.StartsWith("UAA") then List.rev proteins
    elif codons.StartsWith("UAG") then List.rev proteins
    elif codons.StartsWith("UGA") then List.rev proteins
    elif codons.IsEmpty           then List.rev proteins
    else failwith "Unknown coding"

let proteins (codons: string): string list =
    doProteins (codons.AsSpan()) []
```

In this approach, we'll define a recursive function that will recursively process the codons and keep track of the translated proteins.
The codons will be passed as [`ReadOnlySpan<char>`][span] instances instead of `string` instances, to prevent re-allocating a new string for each recursive call.

## Recursive translation

To use (tail call) recursion to translate the codons to proteins, we'll introduce a helper function: `doProteins`.
This function takes the remaining, unprocessed codons as a `ReadOnlySpan<char>` and a list of translated proteins strings (the _accumulator_ value):

```fsharp
let rec doProteins (codons: ReadOnlySpan<char>) (proteins: string list): string list
```

We'll define this function inside the `proteins` function (also known as a _nested_ function), but it could just as well have been defined outside the `proteins` function.
That said, its implementation _is_ merely a helper to the `proteins` function and is thus tied to that function, so to have it be close to where it is called often makes sense (it signals to the reader that the function should only be used _within_ its parent function).

```exercism/note
To allow a function to recursively call itself, the `rec` modified must be added.
In other words: by default, functions cannot call themselves.
```

### Translating

As each codon is three letters long, the `doProteins` function looks at the first three letters of its `codons` parameter via its [`StartsWith()`][span.startswith] method.
For each translateable codon, we recursively call the `doProteins` function, with the remainder of the codons (skipping the first three letters) and the codon's protein added to the proteins accumulator value as arguments.

```exercism/note
We skip over the first three letters via the [`Slice()` method](https://learn.microsoft.com/en-us/dotnet/api/system.span-1.slice#system-span-1-slice(system-int32)), which does _not_ allocate a new `string` but only a new `ReadOnlySpan`.
The underlying `string` remains the same, but the _view_ of that string is offset by 3.
```

```fsharp
if   codons.StartsWith("AUG") then doProteins (codons.Slice(3)) ("Methionine"    :: proteins)
elif codons.StartsWith("UUC") then doProteins (codons.Slice(3)) ("Phenylalanine" :: proteins)
elif codons.StartsWith("UUU") then doProteins (codons.Slice(3)) ("Phenylalanine" :: proteins)
elif codons.StartsWith("UUA") then doProteins (codons.Slice(3)) ("Leucine"       :: proteins)
elif codons.StartsWith("UUG") then doProteins (codons.Slice(3)) ("Leucine"       :: proteins)
elif codons.StartsWith("UCU") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UCC") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UCA") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UCG") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UAU") then doProteins (codons.Slice(3)) ("Tyrosine"      :: proteins)
elif codons.StartsWith("UAC") then doProteins (codons.Slice(3)) ("Tyrosine"      :: proteins)
elif codons.StartsWith("UGU") then doProteins (codons.Slice(3)) ("Cysteine"      :: proteins)
elif codons.StartsWith("UGC") then doProteins (codons.Slice(3)) ("Cysteine"      :: proteins)
elif codons.StartsWith("UGG") then doProteins (codons.Slice(3)) ("Tryptophan"    :: proteins)
```

### Stopping

Next up is to handle the "STOP" proteins.
We'll add conditions for each of the three "STOP" proteins, which stop the recursion and instead return the (reversed) accumulator value:

```fsharp
elif codons.StartsWith("UAA") then List.rev proteins
elif codons.StartsWith("UAG") then List.rev proteins
elif codons.StartsWith("UGA") then List.rev proteins
```

There is one additional case we need to process, and that is when there are no codons left to process (for which we use its [`IsEmpty` property][span.isempty]):

```fsharp
elif codons.IsEmpty then List.rev protein
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
else failwith "Unknown coding"
```

### Alignment

While definitely not needed, aligning the code vertically makes it more clear that the codon patterns all end up doing basically the same thing, but with a different protein:

```fsharp
if   codons.StartsWith("AUG") then doProteins (codons.Slice(3)) ("Methionine"    :: proteins)
elif codons.StartsWith("UUC") then doProteins (codons.Slice(3)) ("Phenylalanine" :: proteins)
elif codons.StartsWith("UUU") then doProteins (codons.Slice(3)) ("Phenylalanine" :: proteins)
elif codons.StartsWith("UUA") then doProteins (codons.Slice(3)) ("Leucine"       :: proteins)
elif codons.StartsWith("UUG") then doProteins (codons.Slice(3)) ("Leucine"       :: proteins)
elif codons.StartsWith("UCU") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UCC") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UCA") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UCG") then doProteins (codons.Slice(3)) ("Serine"        :: proteins)
elif codons.StartsWith("UAU") then doProteins (codons.Slice(3)) ("Tyrosine"      :: proteins)
elif codons.StartsWith("UAC") then doProteins (codons.Slice(3)) ("Tyrosine"      :: proteins)
elif codons.StartsWith("UGU") then doProteins (codons.Slice(3)) ("Cysteine"      :: proteins)
elif codons.StartsWith("UGC") then doProteins (codons.Slice(3)) ("Cysteine"      :: proteins)
elif codons.StartsWith("UGG") then doProteins (codons.Slice(3)) ("Tryptophan"    :: proteins)
elif codons.StartsWith("UAA") then List.rev proteins
elif codons.StartsWith("UAG") then List.rev proteins
elif codons.StartsWith("UGA") then List.rev proteins
elif codons.IsEmpty           then List.rev proteins
else failwith "Unknown coding"
```

```exercism/note
A downside of vertical alignment is that changes to the code require more work, as you'll need to ensure everything is still aligned.
For this particular case, it isn't really an issue, as the codons are fixed and the code is thus unlikely to change.
```

## Putting it all together

The final step is to call our recursive helper function, converting our input `string` to a `ReadOnlySpan<char>` using its [`AsSpan()` method][string.asspan]:

```fsharp
doProteins (codons.AsSpan()) []
```

And with that, we have a working, tail recursive implementation that translates the codons to proteins whilst minimizing string allocations.

```exercism/note
Tail recursion prevents stack overflows when a recursive function is called many times.
While the exercise does not have large test cases that would cause a stack overflow, it is good practice to always use using tail recursion when implementing a recursive functions.
If you'd like to read more about tail recursion, [this MSDN article](https://blogs.msdn.microsoft.com/fsharpteam/2011/07/08/tail-calls-in-f/) goes into more detail.
Another good resource on tail recursion is [this blog post](http://blog.ploeh.dk/2015/12/22/tail-recurse/).
```

[span]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1
[span.startswith]: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.startswith#system-memoryextensions-startswith-1(system-span((-0))-system-readonlyspan((-0)))
[span.slice]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1.slice#system-span-1-slice(system-int32)
[span.isempty]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1.isempty
[string.asspan]: https://learn.microsoft.com/en-us/dotnet/api/system.memoryextensions.asspan#system-memoryextensions-asspan(system-string)
