module Minesweeper

let t (c:char) =
    match c with
    | '*' -> '*'
    | _ -> ' '
    
let transform (input:string list) =
    let c = input |> List.collect (fun c -> c.ToCharArray()|>Array.toList)
    // printfn "%A" c
    c
    |> List.ta (printf "%c")
    |> List.map t
    |> List.chunkBySize (input |> List.length)
    |> List.map(fun c -> new string (c |> List.toArray))
    
let annotate input =  transform input