module ProteinTranslation

open System

let codonToProtein = 
    function
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

let proteins (rna: string) =
    rna 
    |> Seq.chunkBySize 3 
    |> Seq.map (String >> codonToProtein)
    |> Seq.takeWhile (fun str -> str <> "STOP")
    |> Seq.toList