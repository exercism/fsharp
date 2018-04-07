module GoCounting

type Owner = None | Black | White
type Coord = int * int
type Board = Owner [,]

let charToOwner =
    function
    | 'B' -> Black
    | 'W' -> White
    | _   -> None

let cols (board: Board) = board.GetUpperBound 0 + 1
let rows (board: Board) = board.GetUpperBound 1 + 1

let color (board: Board) (col, row) = board.[col, row]

let isEmpty (board: Board) (col, row) = color board (col, row) = None

let isValidCoordinate (board: Board) (col, row) = 
    let (minCol, maxCol) = board.GetLowerBound 0, board.GetUpperBound 0
    let (minRow, maxRow) = board.GetLowerBound 1, board.GetUpperBound 1
    row >= minRow && row <= maxRow && col >= minCol && col <= maxCol
    
let emptyCoordinates (board: Board) = 
    [for col in 0..cols board - 1 do
     for row in 0..rows board - 1 do
        if isEmpty board (col, row) then
            yield (col, row)]

let neighborCoordinates board (col, row) = 
    [(col, row-1); (col-1, row); (col+1, row); (col, row+1)]
    |> List.filter (isValidCoordinate board)
    
let nonEmptyNeighborCoordinates board (col, row) = 
    neighborCoordinates board (col, row) 
    |> List.filter (isEmpty board >> not)

let emptyNeighborCoordinates board (col, row) = 
    neighborCoordinates board (col, row) 
    |> List.filter (isEmpty board)

let mkBoard (input: string list) = 
    let rows = input.Length
    let cols = input.[0].Length

    Array2D.init cols rows (fun col row -> charToOwner input.[row].[col])

let territoryOwner (board: Board) (coords: Set<Coord>) = 
    let uniqueNeighborColors = 
        coords 
        |> Seq.collect (nonEmptyNeighborCoordinates board) 
        |> Seq.map (color board)
        |> set

    if uniqueNeighborColors.Count = 1 then Seq.head uniqueNeighborColors
    else Owner.None
    
let rec territoryHelper board remainder acc = 
    match remainder with
    | [] -> acc
    | _  ->
    
    let emptyNeighbors = 
        remainder
        |> Seq.collect (emptyNeighborCoordinates board) 
        |> set

    let newEmptyNeighbors = Set.difference emptyNeighbors acc
    let newRemainder = Set.toList newEmptyNeighbors
    let newAcc = Set.union acc newEmptyNeighbors

    territoryHelper board newRemainder newAcc

let territoryCoordinates board coord =
    if isValidCoordinate board coord && isEmpty board coord then territoryHelper board [coord] (Set.singleton coord)
    else Set.empty

let territory input coordinate = 
    let board = mkBoard input
    
    if not (isValidCoordinate board coordinate) then
        Option.None
    else
        let coords = territoryCoordinates board coordinate
        let owner = territoryOwner board coords
        Some (owner, Set.toList coords)

let rec territoriesHelper board remainder acc =
    match remainder with
    | [] -> acc
    | coord :: _ ->
        let coords = territoryCoordinates board coord
        let owner = territoryOwner board coords
        let remainder = Set.difference (Set.ofList remainder) coords |> Set.toList   
        let updatedOwnedTerritories = Map.find owner acc @ Set.toList coords
        territoriesHelper board remainder (Map.add owner updatedOwnedTerritories acc)

let territories input = 
  let board = mkBoard input
  let emptyCoords = emptyCoordinates board
  let startMap = Map.ofList [(Owner.None, []); (Owner.Black, []); (Owner.White, [])]
  territoriesHelper board emptyCoords startMap