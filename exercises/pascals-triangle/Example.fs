module PascalsTriangle
    
let triangle rows : int list list option = 
    match rows with 
    | r when r < 0 -> None
    | _ ->
        let row i = 
            [1 .. i - 1] 
            |> List.scan (fun acc j -> acc * (i - j) / j) 1 

        [1..rows] 
        |> List.map row 
        |> Some