module Camicia

open System
open System.Collections.Generic

type GameStatus =
    | Finished
    | Loop

type GameResult = { Status: GameStatus; Tricks: int; Cards: int }

type Player =
    | A
    | B

let private cardValue =
    function
    | "J" -> 1
    | "Q" -> 2
    | "K" -> 3
    | "A" -> 4
    | _ ->   0

let private otherPlayer =
    function
    | A -> B
    | B -> A

let private handFor player handA handB =
    match player with
    | A -> handA
    | B -> handB

let private positionKey (handA: Queue<int>) (handB: Queue<int>) activePlayer =
    let handAKey = String.Join(",", handA)
    let handBKey = String.Join(",", handB)
    $"{handAKey}|{handBKey}|{activePlayer}"

let private hasBeenSeen handA handB activePlayer (seen: HashSet<string>) =
    positionKey handA handB activePlayer |> seen.Add |> not

let private finishedGame tricks cards pile =
    let extraTrick = if Seq.isEmpty pile then 0 else 1
    { Status = Finished; Tricks = tricks + extraTrick; Cards = cards }

let private loopedGame tricks cards = { Status = Loop; Tricks = tricks; Cards = cards }

let private awardPile pile (winner: Queue<int>) =
    for card in pile do
        winner.Enqueue card

    (pile: List<int>).Clear()

let simulateGame (playerA: string array) (playerB: string array) =
    let handA = Queue<int>(playerA |> Seq.map cardValue)
    let handB = Queue<int>(playerB |> Seq.map cardValue)
    let pile = List<int>()
    let seen = HashSet<string>()
    let mutable activePlayer = A
    let mutable tricks = 0
    let mutable cards = 0
    let mutable debt = 0

    let rec play () =
        if Seq.isEmpty pile && hasBeenSeen handA handB activePlayer seen then
            loopedGame tricks cards
        else
            let activeHand = handFor activePlayer handA handB
            let otherHand = handFor (otherPlayer activePlayer) handA handB

            if activeHand.Count = 0 then
                finishedGame tricks cards pile
            else
                let card = activeHand.Dequeue()
                pile.Add card
                cards <- cards + 1

                if card > 0 then
                    debt <- card
                    activePlayer <- otherPlayer activePlayer
                    play ()
                elif debt > 1 then
                    debt <- debt - 1
                    play ()
                elif debt = 1 then
                    awardPile pile otherHand
                    tricks <- tricks + 1
                    debt <- 0

                    if handA.Count = 0 || handB.Count = 0 then
                        finishedGame tricks cards pile
                    else
                        activePlayer <- otherPlayer activePlayer
                        play ()
                else
                    activePlayer <- otherPlayer activePlayer
                    play ()

    play ()
