module Hangman

open System

type Progress =
    | Win
    | Lose
    | Busy of int

type State = { progress: Progress; maskedWord: string; guesses: Set<char> }

let createGame word = failwith "You need to implement this function."
let startGame game = failwith "You need to implement this function."
let makeGuess guess game = failwith "You need to implement this function."
let statesObservable game = failwith "You need to implement this function."