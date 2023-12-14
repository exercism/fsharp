module RunLengthEncoding

let rec rle input =
    match input with
    | [] -> []
    | h :: _ ->
        let sequence = input |> Seq.takeWhile (fun c -> c = h)
        let length = sequence |> Seq.length
        let entry = if length = 1 then $"{h}" else $"{length}{h}"
        let rest = input |> List.skip length
        entry :: (rle rest)

let encode(input: string) =
    input.ToCharArray() |> Array.toList |> rle |> String.concat ""

let decode input =
    failwith "You need to implement this function."

encode "AABBBCCCC"
encode "aabbbcccc"
