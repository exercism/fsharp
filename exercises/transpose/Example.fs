module Transpose

let transpose (input: string) = 
    let rows = input.Split '\n'

    let transposedCoordinates =
        rows
        |> Array.mapi (fun row str -> str |> Seq.mapi (fun col char -> (col, (row, char))) |> Seq.toArray)
        |> Array.concat

    let groupedByTransposedColumns =
        transposedCoordinates
        |> Array.groupBy fst
        |> Array.map (fun (row, chars) -> (row, chars |> Array.map snd))

    let transposedColToRow (input: (int * char)[]) =
        let maxCol = input |> Array.map fst |> Array.max
        let findCharacter col = 
            match Array.tryFind (fun (c, _) -> c = col) input with
            | Some y -> snd y
            | None -> ' '
                
        [| 0..maxCol |] 
        |> Array.map findCharacter
        |> System.String

    groupedByTransposedColumns
    |> Seq.map (snd >> transposedColToRow)
    |> String.concat "\n"