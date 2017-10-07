module RnaTranscription

open System.Text.RegularExpressions

let dnaToRna = 
    function
    | 'G' -> Some 'C'
    | 'C' -> Some 'G'
    | 'T' -> Some 'A'
    | 'A' -> Some 'U'
    | _   -> None

let toRna dna = 
    let helper rna nucleotide = 
        match rna, dnaToRna nucleotide with
        | Some x, Some y -> Some (x + string y)
        | _ -> None

    Seq.fold helper (Some "") dna 