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
    | h :: t when Char.IsDigit h ->
        let count = h |> string |> int
        let char = t |> Seq.head
        new string(char, count) + (rled t[1..])
        // let count = input |> Seq.takeWhile Char.IsDigit 
        // let number = String.Join("", count) |> int
        // let char = t |> Seq.skip (count |> Seq.length) |> Seq.head
        // new string(char, number) + (rled t[1..])
    | h :: t ->
        (h |> string) + (rled t)
        
let decode (input:string) =
    input.ToCharArray() |> Array.toList |> rled
    
decode "12WB12W3B24WB" 