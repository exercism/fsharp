module KillerSudokuHelper

module List =
    let rec combinations n l =
        match n, l with
        | 0, _ -> [ [] ]
        | _, [] -> []
        | k, (x :: xs) ->
            List.map ((@) [ x ]) (combinations (k - 1) xs)
            @ combinations k xs

let combinations exclude size sum =
    [ 1..9 ]
    |> List.except exclude
    |> List.combinations size
    |> List.filter (fun combination -> List.sum combination = sum)
