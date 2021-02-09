module AtbashCipher

open System

let rec mapMaybe f list = 
    match list with
    | [] -> []
    | x::xs -> 
        match f x with
        | Some(a) -> a :: mapMaybe f xs
        | None -> mapMaybe f xs

let stringFromChars (chars:char seq) = String(Array.ofSeq chars)
let chunksOfSize n xs = 
    xs 
    |> Seq.mapi(fun i x -> i / n, x)
    |> Seq.groupBy fst
    |> Seq.map (fun (_, g) -> Seq.map snd g)

let mapLetter letter = if Char.IsDigit letter then (letter, letter) else (letter, (char)((int)'z' - (int)letter + (int)'a'))
let lettersMap = ['a' .. 'z'] @ ['0'..'9'] |> List.map mapLetter |> Map.ofList

let encodeLetter letter = Map.tryFind (Char.ToLower letter) lettersMap
let encodeInChunks = String.concat " " << Seq.map stringFromChars << chunksOfSize 5
let encodeStr = encodeInChunks << mapMaybe encodeLetter
    
let encode (str:string) = str |> List.ofSeq |> encodeStr

let decode (str:string) = (encode str).Replace(" ", "")