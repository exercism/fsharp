module Minesweeper

type Type =
    | Empty
    | Mine

type Position = int * int

let parseChar =
    function
    | ' ' -> Empty
    | '*' -> Mine
    | _ -> failwith "Unexpected char"

let calculateMineCount minePositions element =
    let (x, y), type' = element

    match type' with
    | Mine -> "*"
    | Empty ->
        let neighbours =
            [ x - 1, y - 1
              x, y - 1
              x + 1, y - 1
              x - 1, y
              x + 1, y
              x - 1, y + 1
              x, y + 1
              x + 1, y + 1 ]
            |> Set.ofList

        let count = Set.intersect neighbours (minePositions |> Set.ofList) |> Set.count
        if count = 0 then " " else (count |> string)

let transform minePositions element =
    element |> List.map (calculateMineCount minePositions) |> String.concat ""

let annotate(input: string list) =
    let field =
        [ for row, line in (input |> List.indexed) do
              [ for col, char in (line |> Seq.indexed) -> (row, col), parseChar char ] ]

    let minePositions =
        field
        |> List.collect (fun element ->
            element
            |> List.choose (fun (pos, type') ->
                match type' with
                | Empty -> None
                | Mine -> Some pos))

    field |> List.map (transform minePositions)
