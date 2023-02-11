# Introduction

The key to this exercise is to repeatedly apply a transformation until certain stop condition is reached.

## General guidance

- Consider using pattern matching to elegantly and concisely match different codons to their proteins.

## Approach: unfold

```fsharp
let proteins (codons: string): string list =
    let doProteins (codons: string): (string * string) option =
        match codons[0..2] with
        | "AUG" ->                         Some ("Methionine",    codons[3..])
        | "UUC" | "UUU" ->                 Some ("Phenylalanine", codons[3..])
        | "UUA" | "UUG" ->                 Some ("Leucine",       codons[3..])
        | "UCU" | "UCC" | "UCA" | "UCG" -> Some ("Serine",        codons[3..])
        | "UAU" | "UAC" ->                 Some ("Tyrosine",      codons[3..])
        | "UGU" | "UGC" ->                 Some ("Cysteine",      codons[3..])
        | "UGG" ->                         Some ("Tryptophan",    codons[3..])
        | "UAA" | "UAG" | "UGA" | "" ->    None
        | _ -> failwith "Unknown coding"

    codons
    |> Seq.unfold doProteins
    |> Seq.toList
```

This approach uses [`Seq.unfold`][seq.unfold] to handle the codon translation.
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

let proteins (codons: string): string list =
    codons
    |> Seq.chunkBySize 3
    |> Seq.map System.String
    |> Seq.map codonToProtein
    |> Seq.takeWhile (fun protein -> protein <> "STOP")
    |> Seq.toList
```

This approach combines a number of functions from the [`Seq` module][seq-module] with pattern matching to handle the codon translation.
For more information, check the [`Seq` module approach][approach-seq-module].

## Approach: recursion

```fsharp
let proteins (codons: string): string list =
    let rec doProteins (codons: string) (proteins: string list): string list =
        match codons[0..2] with
        | "AUG" ->                         doProteins codons[3..] ("Methionine"    :: proteins)
        | "UUC" | "UUU" ->                 doProteins codons[3..] ("Phenylalanine" :: proteins)
        | "UUA" | "UUG" ->                 doProteins codons[3..] ("Leucine"       :: proteins)
        | "UCU" | "UCC" | "UCA" | "UCG" -> doProteins codons[3..] ("Serine"        :: proteins)
        | "UAU" | "UAC" ->                 doProteins codons[3..] ("Tyrosine"      :: proteins)
        | "UGU" | "UGC" ->                 doProteins codons[3..] ("Cysteine"      :: proteins)
        | "UGG" ->                         doProteins codons[3..] ("Tryptophan"    :: proteins)
        | "UAA" | "UAG" | "UGA" | "" ->    List.rev proteins
        | _ -> failwith "Unknown coding"

    doProteins codons []
```

This approach uses recursion to translate the codons.
For more information, check the [recursion approach][approach-recursion].

## Other approaches

Besides the aforementioned, idiomatic approaches, you could also approach the exercise as follows:

### Other approach: `Span<T>`

```fsharp
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

This approaches uses the [`Span<T>` type][span] to minimize string allocations.
For more information, check the [`Span<T>` approach][approach-span].

## Which approach to use?

All three approaches are equally valid; it thus comes down to personal preference.

[approach-recursion]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/recursion
[approach-unfold]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/unfold
[approach-seq-module]: https://exercism.org/tracks/fsharp/exercises/protein-translation/approaches/seq-module
[seq.unfold]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#unfold
[seq.map]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#map
[seq-module]: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html
[span]: https://learn.microsoft.com/en-us/dotnet/api/system.span-1
