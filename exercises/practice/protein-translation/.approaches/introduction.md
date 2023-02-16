# Introduction

The key to this exercise is to repeatedly apply a transformation until a stop condition is reached.

## General guidance

- Consider using pattern matching to elegantly and concisely match rna to their proteins.

## Approach: unfold

```fsharp
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

    List.unfold doProteins rna
```

This approach uses [`List.unfold`][list.unfold] to handle the RNA translation.
For more information, check the [unfold approach][approach-unfold].

## Approach: `Seq` module

```fsharp
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

This approach combines a number of functions from the [`Seq` module][seq-module] with pattern matching to handle the RNA translation.
For more information, check the [`Seq` module approach][approach-seq-module].

## Approach: recursion

```fsharp
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

This approach uses recursion to translate the RNA.
For more information, check the [recursion approach][approach-recursion].

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

### Other approach: `Span<T>`

```fsharp
let rec private doProteins (rna: ReadOnlySpan<char>) (proteins: string list): string list =
    if   rna.StartsWith("AUG") then doProteins (rna.Slice(3)) ("Methionine"    :: proteins)
    elif rna.StartsWith("UUC") then doProteins (rna.Slice(3)) ("Phenylalanine" :: proteins)
    elif rna.StartsWith("UUU") then doProteins (rna.Slice(3)) ("Phenylalanine" :: proteins)
    elif rna.StartsWith("UUA") then doProteins (rna.Slice(3)) ("Leucine"       :: proteins)
    elif rna.StartsWith("UUG") then doProteins (rna.Slice(3)) ("Leucine"       :: proteins)
    elif rna.StartsWith("UCU") then doProteins (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UCC") then doProteins (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UCA") then doProteins (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UCG") then doProteins (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UAU") then doProteins (rna.Slice(3)) ("Tyrosine"      :: proteins)
    elif rna.StartsWith("UAC") then doProteins (rna.Slice(3)) ("Tyrosine"      :: proteins)
    elif rna.StartsWith("UGU") then doProteins (rna.Slice(3)) ("Cysteine"      :: proteins)
    elif rna.StartsWith("UGC") then doProteins (rna.Slice(3)) ("Cysteine"      :: proteins)
    elif rna.StartsWith("UGG") then doProteins (rna.Slice(3)) ("Tryptophan"    :: proteins)
    elif rna.StartsWith("UAA") then List.rev proteins
    elif rna.StartsWith("UAG") then List.rev proteins
    elif rna.StartsWith("UGA") then List.rev proteins
    elif rna.IsEmpty           then List.rev proteins
    else failwith "Unknown coding"

let proteins (rna: string): string list =
    doProteins (rna.AsSpan()) []
```

This approaches uses the [`Span<T>` type][span] to minimize string allocations.
For more information, check the [`Span<T>` approach][approach-span].

## Which approach to use?

All three approaches are equally valid; it thus comes down to personal preference.

If you care about performance, the fourth, `Span<T>`-based approach is best.
You can read more about performance in the [performance article][article-performance].

[approach-recursion]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/recursion
[approach-unfold]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/unfold
[approach-seq-module]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/seq-module
[approach-span]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/span
[article-performance]: https://exercism.org/tracks/fsharp/exercises/protein-translation/articles/performance
[list.unfold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#unfold
[seq.map]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#map
[seq-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html
[span]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1
