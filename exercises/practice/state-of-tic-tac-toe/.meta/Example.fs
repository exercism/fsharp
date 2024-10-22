module StateOfTicTacToe

type EndGameState =
    | Win
    | Draw
    | Ongoing

type GameError =
    | ConsecutiveMovesBySamePlayer
    | WrongPlayerStarted
    | MoveMadeAfterGameWasDone

type Cell = char
type Board = Cell [,]

let won (player: Cell) (board: Board) =
    let winning = [| player; player; player |]

    Array.init 3 (fun i -> board[i, i]) = winning
    || Array.init 3 (fun i -> board[i, 2 - i]) = winning
    || Array.init 3 (fun i -> board[i, *])
       |> Array.contains winning
    || Array.init 3 (fun i -> board[*, i])
       |> Array.contains winning

let gamestate (board: Board) =
    let numCells cell =
        board
        |> Seq.cast
        |> Seq.filter ((=) cell)
        |> Seq.length

    let numNaughts = numCells 'O'
    let numCrosses = numCells 'X'

    if abs (numCrosses - numNaughts) > 1 then
        Error ConsecutiveMovesBySamePlayer
    elif numNaughts > numCrosses then
        Error WrongPlayerStarted
    elif won 'X' board && won 'O' board then
        Error MoveMadeAfterGameWasDone
    elif won 'X' board || won 'O' board then
        Ok Win
    elif numNaughts + numCrosses = 9 then
        Ok Draw
    else
        Ok Ongoing
