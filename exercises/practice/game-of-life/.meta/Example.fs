module GameOfLife

let tick (input: int[,]) =
    input
    |> Array2D.mapi (fun row col cell ->
        match
            [ (row - 1, col - 1)
              (row - 1, col)
              (row - 1, col + 1)
              (row, col - 1)
              (row, col + 1)
              (row + 1, col - 1)
              (row + 1, col)
              (row + 1, col + 1) ]
            |> List.filter (fun (x, y) ->
                x >= 0
                && x < Array2D.length1 input
                && y >= 0
                && y < Array2D.length2 input
                && input[x, y] = 1)
            |> List.length
        with
        | 2 when cell = 1 -> 1
        | 3 -> 1
        | _ -> 0)
