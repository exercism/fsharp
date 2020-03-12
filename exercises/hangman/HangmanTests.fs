// This file was created manually and its version is 1.0.0.

module HangmanTest

open Xunit
open FsUnit.Xunit

open Hangman

[<Fact>]
let ``Initially 9 failures are allowed`` () =
    let game = createGame "foo"
    let states = statesObservable game

    let mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    lastProgress |> should equal <| Busy 9

[<Fact(Skip = "Remove to run test")>]
let ``Initially no letters are guessed`` () =
    let game = createGame "foo"
    let states = statesObservable game

    let mutable lastMaskedWord = ""
    states.Add(fun state -> lastMaskedWord <- state.maskedWord) |> ignore

    startGame game |> ignore

    lastMaskedWord |> should equal "___"

[<Fact(Skip = "Remove to run test")>]
let ``After 10 failures the game is over`` () =
    let game = createGame "foo"
    let states = statesObservable game

    let mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    [for x in 1..10 do makeGuess 'x' game] |> ignore

    lastProgress |> should equal Lose
    
[<Fact(Skip = "Remove to run test")>]
let ``Feeding a correct letter removes underscores`` () =
    let game = createGame "foobar"
    let states = statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    lastState.Value.progress |> should equal <| Busy 9
    lastState.Value.maskedWord |> should equal "___b__"

    makeGuess 'o' game |> ignore

    lastState.Value.progress |> should equal <| Busy 9
    lastState.Value.maskedWord |> should equal "_oob__"
    
[<Fact(Skip = "Remove to run test")>]
let ``Feeding a correct letter twice counts as a failure`` () =
    let game = createGame "foobar"
    let states = statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    lastState.Value.progress |> should equal <| Busy 9
    lastState.Value.maskedWord |> should equal "___b__"

    makeGuess 'b' game |> ignore

    lastState.Value.progress |> should equal <| Busy 8
    lastState.Value.maskedWord |> should equal "___b__"
     
[<Fact(Skip = "Remove to run test")>]
let ``Getting all the letters right makes for a win`` () =
    let game = createGame "hello"
    let states = statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    lastState.Value.progress |> should equal <| Busy 8
    lastState.Value.maskedWord |> should equal "_____"

    makeGuess 'e' game |> ignore

    lastState.Value.progress |> should equal <| Busy 8
    lastState.Value.maskedWord |> should equal "_e___"

    makeGuess 'l' game |> ignore

    lastState.Value.progress |> should equal <| Busy 8
    lastState.Value.maskedWord |> should equal "_ell_"

    makeGuess 'o' game |> ignore

    lastState.Value.progress |> should equal <| Busy 8
    lastState.Value.maskedWord |> should equal "_ello"

    makeGuess 'h' game |> ignore

    lastState.Value.progress |> should equal Win
    lastState.Value.maskedWord |> should equal "hello"