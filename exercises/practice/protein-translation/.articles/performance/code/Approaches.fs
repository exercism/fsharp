module Approaches

open System

let recursionApproach (rna: string): string list =
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

let seqModuleApproach (rna: string): string list =
    let codonToProtein (codon: string): string =
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

    rna
    |> Seq.chunkBySize 3
    |> Seq.map System.String
    |> Seq.map codonToProtein
    |> Seq.takeWhile (fun protein -> protein <> "STOP")
    |> Seq.toList

let rec private doSpanApproach (rna: ReadOnlySpan<char>) (proteins: string list): string list =
    if   rna.StartsWith("AUG") then doSpanApproach (rna.Slice(3)) ("Methionine"    :: proteins)
    elif rna.StartsWith("UUC") then doSpanApproach (rna.Slice(3)) ("Phenylalanine" :: proteins)
    elif rna.StartsWith("UUU") then doSpanApproach (rna.Slice(3)) ("Phenylalanine" :: proteins)
    elif rna.StartsWith("UUA") then doSpanApproach (rna.Slice(3)) ("Leucine"       :: proteins)
    elif rna.StartsWith("UUG") then doSpanApproach (rna.Slice(3)) ("Leucine"       :: proteins)
    elif rna.StartsWith("UCU") then doSpanApproach (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UCC") then doSpanApproach (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UCA") then doSpanApproach (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UCG") then doSpanApproach (rna.Slice(3)) ("Serine"        :: proteins)
    elif rna.StartsWith("UAU") then doSpanApproach (rna.Slice(3)) ("Tyrosine"      :: proteins)
    elif rna.StartsWith("UAC") then doSpanApproach (rna.Slice(3)) ("Tyrosine"      :: proteins)
    elif rna.StartsWith("UGU") then doSpanApproach (rna.Slice(3)) ("Cysteine"      :: proteins)
    elif rna.StartsWith("UGC") then doSpanApproach (rna.Slice(3)) ("Cysteine"      :: proteins)
    elif rna.StartsWith("UGG") then doSpanApproach (rna.Slice(3)) ("Tryptophan"    :: proteins)
    elif rna.StartsWith("UAA") then List.rev proteins
    elif rna.StartsWith("UAG") then List.rev proteins
    elif rna.StartsWith("UGA") then List.rev proteins
    elif rna.IsEmpty           then List.rev proteins
    else failwith "Unknown coding"

let spanApproach (rna: string): string list =
    doSpanApproach (rna.AsSpan()) []

let unfoldApproach (rna: string): string list =
    let doUnfoldApproach (rna: string): (string * string) option =
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
    |> Seq.unfold doUnfoldApproach
    |> Seq.toList
