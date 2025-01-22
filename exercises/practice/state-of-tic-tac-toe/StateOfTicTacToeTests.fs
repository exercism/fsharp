source("./state-of-tic-tac-toe.R")
library(testthat)

let ``Finished game where X won via left column victory`` () =
    board <- 
        array2D [ ['X'; 'O'; 'O'];
                  ['X'; ' '; ' '];
                  ['X'; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via middle column victory`` () =
    board <- 
        array2D [ ['O'; 'X'; 'O'];
                  [' '; 'X'; ' '];
                  [' '; 'X'; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via right column victory`` () =
    board <- 
        array2D [ ['O'; 'O'; 'X'];
                  [' '; ' '; 'X'];
                  [' '; ' '; 'X'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via left column victory`` () =
    board <- 
        array2D [ ['O'; 'X'; 'X'];
                  ['O'; 'X'; ' '];
                  ['O'; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via middle column victory`` () =
    board <- 
        array2D [ ['X'; 'O'; 'X'];
                  [' '; 'O'; 'X'];
                  [' '; 'O'; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via right column victory`` () =
    board <- 
        array2D [ ['X'; 'X'; 'O'];
                  [' '; 'X'; 'O'];
                  [' '; ' '; 'O'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via top row victory`` () =
    board <- 
        array2D [ ['X'; 'X'; 'X'];
                  ['X'; 'O'; 'O'];
                  ['O'; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via middle row victory`` () =
    board <- 
        array2D [ ['O'; ' '; ' '];
                  ['X'; 'X'; 'X'];
                  [' '; 'O'; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via bottom row victory`` () =
    board <- 
        array2D [ [' '; 'O'; 'O'];
                  ['O'; ' '; 'X'];
                  ['X'; 'X'; 'X'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via top row victory`` () =
    board <- 
        array2D [ ['O'; 'O'; 'O'];
                  ['X'; 'X'; 'O'];
                  ['X'; 'X'; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via middle row victory`` () =
    board <- 
        array2D [ ['X'; 'X'; ' '];
                  ['O'; 'O'; 'O'];
                  ['X'; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via bottom row victory`` () =
    board <- 
        array2D [ ['X'; 'O'; 'X'];
                  [' '; 'X'; 'X'];
                  ['O'; 'O'; 'O'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via falling diagonal victory`` () =
    board <- 
        array2D [ ['X'; 'O'; 'O'];
                  [' '; 'X'; ' '];
                  [' '; ' '; 'X'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via rising diagonal victory`` () =
    board <- 
        array2D [ ['O'; ' '; 'X'];
                  ['O'; 'X'; ' '];
                  ['X'; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via falling diagonal victory`` () =
    board <- 
        array2D [ ['O'; 'X'; 'X'];
                  ['O'; 'O'; 'X'];
                  ['X'; ' '; 'O'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where O won via rising diagonal victory`` () =
    board <- 
        array2D [ [' '; ' '; 'O'];
                  [' '; 'O'; 'X'];
                  ['O'; 'X'; 'X'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via a row and a column victory`` () =
    board <- 
        array2D [ ['X'; 'X'; 'X'];
                  ['X'; 'O'; 'O'];
                  ['X'; 'O'; 'O'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Finished game where X won via two diagonal victories`` () =
    board <- 
        array2D [ ['X'; 'O'; 'X'];
                  ['O'; 'X'; 'O'];
                  ['X'; 'O'; 'X'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    gamestate board |> should equal expected

let ``Draw`` () =
    board <- 
        array2D [ ['X'; 'O'; 'X'];
                  ['X'; 'X'; 'O'];
                  ['O'; 'X'; 'O'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Draw
    gamestate board |> should equal expected

let ``Another draw`` () =
    board <- 
        array2D [ ['X'; 'X'; 'O'];
                  ['O'; 'X'; 'X'];
                  ['X'; 'O'; 'O'] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Draw
    gamestate board |> should equal expected

let ``Ongoing game: one move in`` () =
    board <- 
        array2D [ [' '; ' '; ' '];
                  ['X'; ' '; ' '];
                  [' '; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Ongoing
    gamestate board |> should equal expected

let ``Ongoing game: two moves in`` () =
    board <- 
        array2D [ ['O'; ' '; ' '];
                  [' '; 'X'; ' '];
                  [' '; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Ongoing
    gamestate board |> should equal expected

let ``Ongoing game: five moves in`` () =
    board <- 
        array2D [ ['X'; ' '; ' '];
                  [' '; 'X'; 'O'];
                  ['O'; 'X'; ' '] ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Ongoing
    gamestate board |> should equal expected

let ``Invalid board: X went twice`` () =
    board <- 
        array2D [ ['X'; 'X'; ' '];
                  [' '; ' '; ' '];
                  [' '; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Error ConsecutiveMovesBySamePlayer
    gamestate board |> should equal expected

let ``Invalid board: O started`` () =
    board <- 
        array2D [ ['O'; 'O'; 'X'];
                  [' '; ' '; ' '];
                  [' '; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Error WrongPlayerStarted
    gamestate board |> should equal expected

let ``Invalid board: X won and O kept playing`` () =
    board <- 
        array2D [ ['X'; 'X'; 'X'];
                  ['O'; 'O'; 'O'];
                  [' '; ' '; ' '] ]
    let expected: Result<EndGameState, GameError> = Error MoveMadeAfterGameWasDone
    gamestate board |> should equal expected

let ``Invalid board: players kept playing after a win`` () =
    board <- 
        array2D [ ['X'; 'X'; 'X'];
                  ['O'; 'O'; 'O'];
                  ['X'; 'O'; 'X'] ]
    let expected: Result<EndGameState, GameError> = Error MoveMadeAfterGameWasDone
    gamestate board |> should equal expected

