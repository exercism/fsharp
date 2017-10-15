module RunLengthEncoding

open System

let digitToInt c = int c - int '0'

let partitionConsecutive list =
    let folder item acc = 
        match acc with 
        | (x::xs)::ys when x = item -> (item::x::xs) :: ys
        | _  -> [item] :: acc

    List.foldBack folder list []

let encode (input: string) =
    let encodePartition (partition: char list) = 
        match partition with
        | [x]  -> string x
        | x::_ -> sprintf "%i%O" (List.length partition) x
        | _    -> failwith "Can't encode empty partition"

    input.ToCharArray()
    |> List.ofArray
    |> partitionConsecutive
    |> List.map encodePartition
    |> List.fold (+) ""

let decode (input: string) = 
    let folder ((decoded: string), (count: int option)) item =
        let updatedCount = Option.fold (fun acc x -> acc + x * 10) (digitToInt item) count |> Some
        let updateDecoded = Option.fold (fun acc x -> acc + String(item, x - 1)) (decoded + string item) count

        if Char.IsDigit item then (decoded, updatedCount) else (updateDecoded, None)

    input 
    |> Seq.fold folder ("", None)
    |> fst