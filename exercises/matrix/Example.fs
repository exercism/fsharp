module Matrix

type Matrix = { rows: int [][]; cols: int [][] }

let fromString (str: string) =     
    let parseRow (row: string) = 
        row.Split(' ') 
        |> Array.map (string >> int)
    
    let rows = str.Split('\n') |> Array.map parseRow
    let numberOfCols = Array.item 0 rows |> Array.length
    let cols = [| for col in 0..numberOfCols - 1 ->
                    [| for row in rows -> Array.item col row |] |]

    { rows = rows; cols = cols }

let rows matrix = matrix.rows
let cols matrix = matrix.cols