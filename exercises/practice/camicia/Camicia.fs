module Camicia

type GameStatus =
    | Finished
    | Loop

type GameResult = { Status: GameStatus; Tricks: int; Cards: int }

let simulateGame (playerA: string array) (playerB: string array) = failwith "You need to implement this function."
