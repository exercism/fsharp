module Hangman

open System

let allowedFailures = 9

type Progress =
    | Win
    | Lose
    | Busy of int

type State = { progress: Progress; maskedWord: string; guesses: Set<char> }

let updateProgress word guess (state: State) =
    match state.progress with
    | Win  -> { state with progress = Win }
    | Lose -> { state with progress = Lose }
    | Busy x -> 
        if state.maskedWord = word then
            { state with progress = Win }
        elif x <= 0 then
            { state with progress = Lose }
        elif not <| word.Contains(string guess) || Set.contains guess state.guesses then
            { state with progress = Busy (x - 1) }        
        else
            state            

let updateMaskedWord word guess (state: State) = 
    let updatedGuesses = Set.add guess state.guesses
    let updatedMaskedWord = 
        word 
        |> Seq.map (fun x -> if Set.contains x updatedGuesses then x else '_') 
        |> Seq.toArray 
        |> System.String 

    { state with maskedWord = updatedMaskedWord }    

let updateGuesses guess (state: State) = { state with guesses = Set.add guess state.guesses }

let updateState word guess (state: State) =
    state
    |> updateMaskedWord word guess
    |> updateProgress word guess
    |> updateGuesses guess

let mkStartState (word: string) = { progress = Busy allowedFailures; maskedWord = String('_', word.Length); guesses = Set.empty }

type Game(word) = 
    let initialState = new Event<State>()
    let guesses = new Event<char>()
    let startState = mkStartState word
    
    member this.States = Observable.merge initialState.Publish (Observable.scan (fun state guess -> updateState word guess state) startState guesses.Publish)    
    member this.Start() = initialState.Trigger(startState)
    member this.MakeGuess(guess) = guesses.Trigger(guess)

let createGame word = new Game(word)
let startGame (game: Game) = game.Start()
let makeGuess guess (game: Game) = game.MakeGuess(guess)
let statesObservable (game: Game) = game.States