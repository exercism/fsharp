module HangmanTest

open NUnit.Framework

open Hangman

[<Test>]
let ``Initially 9 failures are allowed`` () =
    let game = createGame "foo"
    let states = statesObservable game

    let mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    Assert.That(lastProgress, Is.EqualTo(Busy 9))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Initially no letters are guessed`` () =
    let game = createGame "foo"
    let states = statesObservable game

    let mutable lastMaskedWord = ""
    states.Add(fun state -> lastMaskedWord <- state.maskedWord) |> ignore

    startGame game |> ignore

    Assert.That(lastMaskedWord, Is.EqualTo("___"))

[<Test>]
[<Ignore("Remove to run test")>]
let ``After 10 failures the game is over`` () =
    let game = createGame "foo"
    let states = statesObservable game

    let mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    [for x in 1..10 do makeGuess 'x' game] |> ignore

    Assert.That(lastProgress, Is.EqualTo(Lose))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Feeding a correct letter removes underscores`` () =
    let game = createGame "foobar"
    let states = statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 9))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("___b__"))

    makeGuess 'o' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 9))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("_oob__"))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Feeding a correct letter twice counts as a failure`` () =
    let game = createGame "foobar"
    let states = statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 9))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("___b__"))

    makeGuess 'b' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 8))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("___b__"))
     
[<Test>]
[<Ignore("Remove to run test")>]
let ``Getting all the letters right makes for a win`` () =
    let game = createGame "hello"
    let states = statesObservable game

    let mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 8))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("_____"))

    makeGuess 'e' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 8))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("_e___"))

    makeGuess 'l' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 8))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("_ell_"))

    makeGuess 'o' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Busy 8))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("_ello"))

    makeGuess 'h' game |> ignore

    Assert.That(lastState.Value.progress, Is.EqualTo(Win))
    Assert.That(lastState.Value.maskedWord, Is.EqualTo("hello"))