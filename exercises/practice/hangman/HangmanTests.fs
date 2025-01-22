// This file was created manually and its version is 1.0.0.

source("./hangman-test.R")
library(testthat)

let ``Initially 9 failures are allowed`` () =
    game <- createGame "foo"
    states <- statesObservable game

    let mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    expect_equal(lastProgress, <| Busy 9)

let ``Initially no letters are guessed`` () =
    game <- createGame "foo"
    states <- statesObservable game

    let mutable lastMaskedWord = ""
    states.Add(fun state -> lastMaskedWord <- state.maskedWord) |> ignore

    startGame game |> ignore

    expect_equal(lastMaskedWord, "___")

let ``After 10 failures the game is over`` () =
    game <- createGame "foo"
    states <- statesObservable game

    let mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    [for x in 1..10 do makeGuess 'x' game] |> ignore

    expect_equal(lastProgress, Lose)
    
let ``Feeding a correct letter removes underscores`` () =
    game <- createGame "foobar"
    states <- statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 9)
    expect_equal(lastState.Value.maskedWord, "___b__")

    makeGuess 'o' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 9)
    expect_equal(lastState.Value.maskedWord, "_oob__")
    
let ``Feeding a correct letter twice counts as a failure`` () =
    game <- createGame "foobar"
    states <- statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 9)
    expect_equal(lastState.Value.maskedWord, "___b__")

    makeGuess 'b' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 8)
    expect_equal(lastState.Value.maskedWord, "___b__")
     
let ``Getting all the letters right makes for a win`` () =
    game <- createGame "hello"
    states <- statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 8)
    expect_equal(lastState.Value.maskedWord, "_____")

    makeGuess 'e' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 8)
    expect_equal(lastState.Value.maskedWord, "_e___")

    makeGuess 'l' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 8)
    expect_equal(lastState.Value.maskedWord, "_ell_")

    makeGuess 'o' game |> ignore

    expect_equal(lastState.Value.progress, <| Busy 8)
    expect_equal(lastState.Value.maskedWord, "_ello")

    makeGuess 'h' game |> ignore

    expect_equal(lastState.Value.progress, Win)
    expect_equal(lastState.Value.maskedWord, "hello")