module PascalsTriangle

let rows numberOfRows : int list list =
    match numberOfRows with 
    | r when r < 0 -> []
    | _ ->
        let row i = 
            [1 .. i - 1] 
            |> List.scan (fun acc j -> acc * (i - j) / j) 1 

        [1..numberOfRows] 
        |> List.map row
