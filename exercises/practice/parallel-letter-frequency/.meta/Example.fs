module ParallelLetterFrequency

open System

let merge x y = 
    let folder acc key value =
        match Map.tryFind key acc with
        | Some z -> Map.add key (z + value) acc
        | None -> Map.add key value acc
    Map.fold folder x y

let calculateFrequency text = 
    text
    |> Seq.filter (Char.IsLetter)
    |> Seq.countBy (fun c -> Char.ToLower c)
    |> Map.ofSeq

let asyncCalculateFrequency text = async { return calculateFrequency(text) }

let frequency texts = 
    texts
    |> Seq.map asyncCalculateFrequency   
    |> Async.Parallel
    |> Async.RunSynchronously 
    |> Seq.fold merge Map.empty