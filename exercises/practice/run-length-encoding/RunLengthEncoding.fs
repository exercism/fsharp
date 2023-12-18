module RunLengthEncoding

open System

let rec rle input =
    match input with
    | [] -> "" 
    | h :: _ ->
        let sequence = input |> Seq.takeWhile (fun c -> c = h)
        let length = sequence |> Seq.length
        let entry = if length = 1 then $"{h}" else $"{length}{h}"
        let rest = input |> List.skip length
        entry + (rle rest)

let encode (input:string) = 
    input.ToCharArray() |> Array.toList |> rle

let rec rled input =
    match input with
    | [] -> ""
    | h :: _ when Char.IsDigit h ->
        let ar = input |> Seq.takeWhile Char.IsDigit |> Seq.toArray
        let count = new string(ar) |> int
        let len = ar |> Array.length
        let char = input[len..len] |> List.head
        
        let rest = input |> List.skip (ar.Length + 1)

        new string(char, count) + (rled rest)
    | h :: t ->
        (h |> string) + (rled t)
        
let decode (input:string) =
    input.ToCharArray() |> Array.toList |> rled
