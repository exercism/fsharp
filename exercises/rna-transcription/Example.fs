module RNATranscription

let dnaToRna = 
    function
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _   -> invalidOp "Invalid nucleotide"

let toRna = String.map dnaToRna