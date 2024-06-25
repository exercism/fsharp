module RnaTranscription

open System

let transform = function
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> failwith "Invalid DNA"

let toRna dna =
    dna |> Seq.map transform |> String.Concat
