module Matrix

let private parseRow (row: string) =
    row.Split(' ')
    |> Seq.map int
    |> List.ofSeq

let private parseRows (matrix: string) =
    matrix.Split('\n') 
    |> Seq.map parseRow
    |> List.ofSeq

let row index matrix = 
    matrix
    |> parseRows
    |> List.item (index - 1)

let column index matrix =
    matrix
    |> parseRows
    |> List.map (List.item (index - 1))