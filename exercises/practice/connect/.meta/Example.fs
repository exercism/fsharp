module Connect

type Color = Black | White
type Coordinate = int * int

type Board = Color option [,]

let cols (board:Board) = board.GetLength(0)
let rows (board:Board) = board.GetLength(1)  

let isValidCoordinate board (col, row) = row >= 0 && row < rows board && col >= 0 && col < cols board

let hasColor color (board:Board) (col, row) = Array2D.get board col row = Some color

let adjacent color board (col, row) = 
    let valid coord = isValidCoordinate board coord && hasColor color board coord
    let coords = [(col + 1, row - 1);
                  (col,     row - 1); 
                  (col - 1, row); 
                  (col + 1, row); 
                  (col - 1, row + 1);
                  (col,     row + 1)]
    List.filter valid coords

let rec validPath color stop board processed coord =
    if stop board coord then true
    else
        let next = adjacent color board coord
        let notVisited = Set.difference (next |> Set.ofList) processed

        if Set.isEmpty notVisited then false
        else Set.exists (fun nextCoord -> validPath color stop board (Set.add coord processed) nextCoord) notVisited

let isWhiteStop board (_, row) = row = rows board - 1
let isBlackStop board (col, _) = col = cols board - 1

let whiteStart board = [for col in 0..cols board - 1 do if hasColor White board (col, 0) then yield (col, 0)] |> Set.ofList
let blackStart board = [for row in 0..rows board - 1 do if hasColor Black board (0, row) then yield (0, row)] |> Set.ofList

let colorWins color stop start board = Set.exists (validPath color stop board Set.empty) (start board)

let whiteWins = colorWins White isWhiteStop whiteStart
let blackWins = colorWins Black isBlackStop blackStart

let charToColor c = 
    match c with
    | 'O' -> Some White
    | 'X' -> Some Black
    | _   -> None

let normalizeRow (row: string) = row.Replace(" ", "")

let mkBoard (input: string list) =
    let normalizedRows = List.map normalizeRow input

    let rows' = List.length normalizedRows
    let cols' = Seq.length (List.head normalizedRows)
    let cellColor col row = normalizedRows |> List.item row |> Seq.item col |> charToColor
    
    Array2D.init cols' rows' cellColor

let winner input =
    let board = mkBoard input
    if whiteWins board then Some White
    elif blackWins board then Some Black
    else None