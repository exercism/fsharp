module Transpose

let transpose (rows: string list): string list =
    let transposedCoordinates =
        rows
        |> List.mapi (fun row str -> str |> Seq.mapi (fun col char -> (col, (row, char))) |> List.ofSeq)
        |> List.concat

    let groupedByTransposedColumns =
        transposedCoordinates
        |> List.groupBy fst
        |> List.map (fun (row, chars) -> (row, chars |> List.map snd))

    let transposedColToRow (input: (int * char) list) =
        let maxCol = input |> List.map fst |> List.max
        let findCharacter col = 
            match List.tryFind (fun (c, _) -> c = col) input with
            | Some y -> snd y
            | None -> ' '

        [| 0..maxCol |] 
        |> Array.map findCharacter
        |> System.String

    groupedByTransposedColumns
    |> List.map (snd >> transposedColToRow)