module NucleotideCount

let nucleotides = [ 'A'; 'C'; 'G'; 'T' ]

let isValid c = nucleotides |> List.contains c

let folder map (c: char) =
    if (c |> isValid) then
        map
        |> Map.change c (function
            | Some v -> Some(v + 1)
            | None -> Some 1)
    else
        map


let nucleotideCounts(strand: string) : Option<Map<char, int>> =
    if strand |> Seq.exists (isValid >> not) then
        None
    else
        let map = nucleotides |> List.map (fun c -> (c, 0)) |> Map.ofList
        strand |> Seq.fold folder map |> Some
