module NucleotideCount

let private validNucleotides = ['A'; 'T'; 'C'; 'G']

let private isValid nucleotide = List.contains nucleotide validNucleotides

let count (nucleotide:char) (strand:string) = 
    match isValid nucleotide with
    | true  -> Seq.fold (fun acc elem -> if elem = nucleotide then acc + 1 else acc) 0 strand
    | false -> failwith "Invalid nucleotide"

let nucleotideCounts strand = 
    if String.forall isValid strand then
        List.map (fun nucleotide -> (nucleotide, count nucleotide strand)) validNucleotides 
        |> Map.ofSeq
        |> Some
    else    
        None