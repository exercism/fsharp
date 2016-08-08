module Transpose

let maxLength (input: string[]) = 
    input
    |> Array.map (fun x -> x.Length) 
    |> Array.max

let padRows rows =
    rows
    |> Array.mapi (fun i row -> if i < Array.length rows - 1 then rows |> maxLength |> row.PadRight else row)

let transpose (input: string) = 
    input.Split '\n'
    |> padRows
    |> Seq.collect (fun s -> s |> Seq.mapi (fun i e -> (i, e)))
    |> Seq.groupBy fst
    |> Seq.map (fun (_, s) -> s |> Seq.map snd |> Seq.toArray |> System.String)
    |> String.concat "\n"