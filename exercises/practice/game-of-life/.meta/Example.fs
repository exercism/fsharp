module GameOfLife

let tick (input: int list list) =
    input
    |> List.mapi (fun row cells ->
        cells
        |> List.mapi (fun col cell ->
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
                    && x < List.length input
                    && y >= 0
                    && y < List.length cells
                    && input.[x].[y] = 1)
                |> List.length
            with
            | 2 when cell = 1 -> 1
            | 3 -> 1
            | _ -> 0))
