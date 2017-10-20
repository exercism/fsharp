module PascalsTriangle
open System    
let triangle rows = 
    match rows with 
    | r when r < 0 -> raise (ArgumentOutOfRangeException())
    | _ ->
        let row i = 
            [1 .. i - 1] 
            |> List.scan (fun acc j -> acc * (i - j) / j) 1 

        [1..rows] 
        |> List.map row 