module FlowerField

open System
    
type Cell = Flower | Empty
type Board = { cells: Cell [,]; rows: int; cols: int }

let parseCell = 
    function
    | '*' -> Flower
    | _   -> Empty

let parseCells (input: string list) =
    input
    |> Seq.map (Seq.map parseCell)
    |> array2D

let mkBoard (input: string list) =
    let cells = parseCells input
    { cells = cells; rows = cells.GetLength 0; cols = cells.GetLength 1 }

let neighborPositions (row, col) = 
    [(row - 1, col - 1); (row - 1, col); (row - 1, col + 1);
     (row,     col - 1);                 (row,     col + 1);
     (row + 1, col - 1); (row + 1, col); (row + 1, col + 1)]

let isValidPosition (board: Board) (row, col) = row >= 0 && row < board.rows && col >= 0 && col < board.cols

let isFlower (board: Board) (row, col) = isValidPosition board (row, col) && board.cells.[row, col] = Flower

let neighborFlowers (board: Board) (row, col) =
    neighborPositions (row, col)
    |> List.filter (isFlower board)
    |> List.length

let cellOutput (board: Board) (row, col) =   
    match board.cells.[row, col] with
    | Flower -> 
        '*'
    | Empty -> 
        match neighborFlowers board (row, col) with
        | 0 -> ' '
        | x -> char x + '0'

let rowOutput (board: Board) row = 
    Array.init board.cols (fun col -> cellOutput board (row, col)) 
    |> (fun chars -> new String(chars))
    
let annotate (input: string list) = 
    let board = mkBoard input    
    List.init board.rows (rowOutput board)