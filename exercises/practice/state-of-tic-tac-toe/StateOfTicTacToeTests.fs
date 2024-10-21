module StateOfTicTacToeTests

open FsUnit.Xunit
open Xunit

open StateOfTicTacToe

[<Fact>]
let ``Finished game where X won via left column victory`` () =
    let board =
        array2D [ 
            [ 'X'; 'O'; 'O' ]
            [ 'X'; ' '; ' ' ]
            [ 'X'; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via middle column victory`` () =
    let board =
        array2D [
            [ 'O'; 'X'; 'O' ]
            [ ' '; 'X'; ' ' ]
            [ ' '; 'X'; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via right column victory`` () =
    let board =
        array2D [
            [ 'O'; 'O'; 'X' ]
            [ ' '; ' '; 'X' ]
            [ ' '; ' '; 'X' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via left column victory`` () =
    let board =
        array2D [
            [ 'O'; 'X'; 'X' ]
            [ 'O'; 'X'; ' ' ]
            [ 'O'; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via middle column victory`` () =
    let board =
        array2D [
            [ 'X'; 'O'; 'X' ]
            [ ' '; 'O'; 'X' ]
            [ ' '; 'O'; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via right column victory`` () =
    let board =
        array2D [
            [ 'X'; 'X'; 'O' ]
            [ ' '; 'X'; 'O' ]
            [ ' '; ' '; 'O' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via top row victory`` () =
    let board =
        array2D [
            [ 'X'; 'X'; 'X' ]
            [ 'X'; 'O'; 'O' ]
            [ 'O'; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via middle row victory`` () =
    let board =
        array2D [
            [ 'O'; ' '; ' ' ]
            [ 'X'; 'X'; 'X' ]
            [ ' '; 'O'; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via bottom row victory`` () =
    let board =
        array2D [
            [ ' '; 'O'; 'O' ]
            [ 'O'; ' '; 'X' ]
            [ 'X'; 'X'; 'X' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via top row victory`` () =
    let board =
        array2D [
            [ 'O'; 'O'; 'O' ]
            [ 'X'; 'X'; 'O' ]
            [ 'X'; 'X'; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via middle row victory`` () =
    let board =
        array2D [
            [ 'X'; 'X'; ' ' ]
            [ 'O'; 'O'; 'O' ]
            [ 'X'; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via bottom row victory`` () =
    let board =
        array2D [
            [ 'X'; 'O'; 'X' ]
            [ ' '; 'X'; 'X' ]
            [ 'O'; 'O'; 'O' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via falling diagonal victory`` () =
    let board =
        array2D [
            [ 'X'; 'O'; 'O' ]
            [ ' '; 'X'; ' ' ]
            [ ' '; ' '; 'X' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via rising diagonal victory`` () =
    let board =
        array2D [
            [ 'O'; ' '; 'X' ]
            [ 'O'; 'X'; ' ' ]
            [ 'X'; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via falling diagonal victory`` () =
    let board =
        array2D [
            [ 'O'; 'X'; 'X' ]
            [ 'O'; 'O'; 'X' ]
            [ 'X'; ' '; 'O' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where O won via rising diagonal victory`` () =
    let board =
        array2D [
            [ ' '; ' '; 'O' ]
            [ ' '; 'O'; 'X' ]
            [ 'O'; 'X'; 'X' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via a row and a column victory`` () =
    let board =
        array2D [
            [ 'X'; 'X'; 'X' ]
            [ 'X'; 'O'; 'O' ]
            [ 'X'; 'O'; 'O' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``Finished game where X won via two diagonal victories`` () =
    let board =
        array2D [
            [ 'X'; 'O'; 'X' ]
            [ 'O'; 'X'; 'O' ]
            [ 'X'; 'O'; 'X' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Win
    gameState board |> should equal expected

[<Fact>]
let ``A draw`` () =
    let board =
        array2D [
            [ 'X'; 'O'; 'X' ]
            [ 'X'; 'X'; 'O' ]
            [ 'O'; 'X'; 'O' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Draw
    gameState board |> should equal expected

[<Fact>]
let ``Another draw`` () =
    let board =
        array2D [
            [ 'X'; 'X'; 'O' ]
            [ 'O'; 'X'; 'X' ]
            [ 'X'; 'O'; 'O' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Draw
    gameState board |> should equal expected

[<Fact>]
let ``Ongoing game: one move in`` () =
    let board =
        array2D [
            [ ' '; ' '; ' ' ]
            [ 'X'; ' '; ' ' ]
            [ ' '; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Ongoing
    gameState board |> should equal expected

[<Fact>]
let ``Ongoing game: two moves in`` () =
    let board =
        array2D [
            [ 'O'; ' '; ' ' ]
            [ ' '; 'X'; ' ' ]
            [ ' '; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Ongoing
    gameState board |> should equal expected

[<Fact>]
let ``Ongoing game: five moves in`` () =
    let board =
        array2D [
            [ 'X'; ' '; ' ' ]
            [ ' '; 'X'; 'O' ]
            [ 'O'; 'X'; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Ok Ongoing
    gameState board |> should equal expected

[<Fact>]
let ``Invalid board: X went twice`` () =
    let board =
        array2D [
            [ 'X'; 'X'; ' ' ]
            [ ' '; ' '; ' ' ]
            [ ' '; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Error ConsecutiveMovesBySamePlayer
    gameState board
    |> should equal expected

[<Fact>]
let ``Invalid board: O started`` () =
    let board =
        array2D [
            [ 'O'; 'O'; 'X' ]
            [ ' '; ' '; ' ' ]
            [ ' '; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Error WrongPlayerStarted
    gameState board
    |> should equal expected

[<Fact>]
let ``Invalid board: X won and O kept playing`` () =
    let board =
        array2D [
            [ 'X'; 'X'; 'X' ]
            [ 'O'; 'O'; 'O' ]
            [ ' '; ' '; ' ' ]
        ]

    let expected: Result<EndGameState, GameError> = Error MoveMadeAfterGameWasDone
    gameState board
    |> should equal expected

[<Fact>]
let ``Invalid board: players kept playing after a win`` () =
    let board =
        array2D [
            [ 'X'; 'X'; 'X' ]
            [ 'O'; 'O'; 'O' ]
            [ 'X'; 'O'; 'X' ]
        ]

    let expected: Result<EndGameState, GameError> = Error MoveMadeAfterGameWasDone
    gameState board
    |> should equal expected
