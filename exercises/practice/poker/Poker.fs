module Poker

open System.Text.RegularExpressions

type Color =
    | Hearts
    | Spades
    | Diamonds
    | Clubs

type Type =
    | As
    | King
    | Queen
    | Jack
    | Value of int

type Card = { Card: Type * Color }

type Hand = Card array

let makeCard(card: string) : Card =
    let m = Regex.Match(card, @"(?<type>\d{1,2}|J|Q|K|A)(?<color>\w)")
    let type' =
        match m.Groups["type"].Value with
        | "A" -> As
        | "K" -> King
        | "Q" -> Queen
        | "J" -> Jack
        | v -> Value(v |> string |> int)

    let color =
        match m.Groups["color"].Value with
        | "H" -> Hearts
        | "D" -> Diamonds
        | "S" -> Spades
        | "C" -> Clubs
        | _ -> failwith "Unknown color"

    { Card = type', color }

let makeHand(hand: string) : Hand =
    hand.Split(' ') |> Array.map makeCard

let bestHands(hands: string list) =
    let pokerHands = hands |> List.map makeHand
    hands[0]

let s2 = "4S 5S 7H 8D JC"

let m = Regex.Match("4S 5S 7H 8D JC", "(\d{1,2}|J|Q|K|A)(\w)")
let hands = ["4D 5S 6S 8D 3C"; "2S 4C 7S 9H 10H"; "3S 4S 5D 6H JH"]

hands |> List.map makeHand
let x = bestHands hands
