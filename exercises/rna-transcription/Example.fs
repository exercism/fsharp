module RnaTranscription

let private dnaToRna = 
    function
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _   -> failwith "Unknown nucleotide"

let toRna dna = String.map dnaToRna dna