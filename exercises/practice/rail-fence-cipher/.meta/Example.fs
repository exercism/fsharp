module RailFenceCipher

open System

let track rails index = 
    let size = rails * 2 - 2
    let correct i = i % size = 0

    if correct index then 0
    elif correct (index - rails + 1) then rails - 1
    else [1 .. (rails - 2)] |> List.find (fun i -> correct (index - i) || correct (index - size + i))

let encode rails message = 
    message
    |> Seq.mapi (fun i c -> track rails i, c)
    |> Seq.groupBy fst
    |> Seq.map (fun (_, sequence) -> sequence|> Seq.map snd |> Array.ofSeq |> String)
    |> Seq.reduce (fun x y -> x + y)

let decode rails (message: string) =    
    [0 .. message.Length - 1]
    |> Seq.groupBy (track rails) 
    |> Seq.collect snd
    |> Seq.zip message
    |> Seq.sortBy snd
    |> Seq.map (fst >> string)
    |> Seq.reduce (+)