module Poker

type Suit = 
    | Hearts 
    | Diamonds 
    | Clubs 
    | Spades

type Rank =
    | Two
    | Three
    | Four
    | Five
    | Six
    | Seven
    | Eight
    | Nine
    | Ten
    | Jack 
    | Queen
    | King
    | Ace 

type Card = Rank * Suit
type Hand = Card * Card * Card * Card * Card 

type PokerHand = 
    | HighCard of Rank * Rank * Rank * Rank * Rank
    | OnePair of Rank * Rank * Rank * Rank 
    | TwoPair of Rank * Rank * Rank
    | ThreeOfAKind of Rank * Rank * Rank
    | Straight of Rank
    | Flush of Rank * Rank * Rank * Rank * Rank
    | FullHouse of Rank * Rank
    | FourOfAKind of Rank * Rank
    | StraightFlush of Rank
    
let tuple5ToList = function (one, two, three, four, five) -> [one; two; three; four; five]
    
let listToTuple5 =
    function
    | [c1; c2; c3; c4; c5] -> c1, c2, c3, c4, c5
    | _ -> failwith "Invalid number of cards"

let ranks hand = tuple5ToList hand |> List.map fst
let ranksWithCount hand = ranks hand |> List.countBy id |> List.sortByDescending snd

let suits hand = tuple5ToList hand |> List.map snd
let suitsWithCount hand = suits hand |> List.countBy id |> List.sortByDescending snd
    
let nextRank =
    function
    | Two   -> Three
    | Three -> Four
    | Four  -> Five
    | Five  -> Six
    | Six   -> Seven
    | Seven -> Eight
    | Eight -> Nine
    | Nine  -> Ten
    | Ten   -> Jack
    | Jack  -> Queen
    | Queen -> King
    | King  -> Ace
    | Ace   -> Two

let parseSuit =
    function
    | 'H' -> Hearts
    | 'D' -> Diamonds
    | 'C' -> Clubs
    | 'S' -> Spades
    | _   -> failwith "Invalid suit"
        
let parseRank =
    function
    | "2" -> Two
    | "3" -> Three
    | "4" -> Four
    | "5" -> Five
    | "6" -> Six
    | "7" -> Seven
    | "8" -> Eight
    | "9" -> Nine
    | "10" -> Ten
    | "J" -> Jack 
    | "Q" -> Queen
    | "K" -> King
    | "A" -> Ace 
    | _   -> failwith "Invalid rank"
        
let parseCard (input: string) = 
    if input.Length = 2 then
        parseRank input.[0..0], parseSuit input.[1]
    else
        parseRank input.[0..1], parseSuit input.[2]

let parseHand (input: string) =
    input.Split(' ') 
    |> List.ofArray 
    |> List.map parseCard
    |> List.sortByDescending fst
    |> listToTuple5

let areSequentialCards (rank1, rank2) = rank1 = nextRank rank2
let ranksAreSequential = List.pairwise >> List.forall areSequentialCards

let (|Flush|_|) hand =
    match suitsWithCount hand with
    | (_, 5)::[] -> ranks hand |> listToTuple5 |> PokerHand.Flush |> Some 
    | _ -> None
    
let (|Straight|_|) hand =
    match ranks hand with
    | [Ace; r2; r3; r4; Two] -> 
        match ranksAreSequential [r2; r3; r4; Two] with
        | true  -> PokerHand.Straight r2 |> Some
        | false -> None
    | [r1; r2; r3; r4; r5] -> 
        match ranksAreSequential [r1; r2; r3; r4; r5] with
        | true  -> PokerHand.Straight r1 |> Some
        | false -> None
    | _ -> None

let (|StraightFlush|_|) hand =
    match hand with
    | Flush _ & Straight _ -> ranks hand |> List.head |> PokerHand.StraightFlush |> Some
    | _ -> None
    
let (|FourOfAKind|_|) hand =
    match ranksWithCount hand with
    | (rank1, 4)::(rank2, 1)::[] -> PokerHand.FourOfAKind (rank1, rank2) |> Some 
    | _ -> None
    
let (|ThreeOfAKind|_|) hand =
    match ranksWithCount hand with
    | (rank1, 3)::(rank2, 1)::(rank3, 1)::[] -> PokerHand.ThreeOfAKind (rank1, rank2, rank3) |> Some 
    | _ -> None

let (|TwoPair|_|) hand =
    match ranksWithCount hand with
    | (rank1, 2)::(rank2, 2)::(rank3, 1)::[] -> PokerHand.TwoPair (rank1, rank2, rank3) |> Some 
    | _ -> None

let (|OnePair|_|) hand =
    match ranksWithCount hand with
    | (rank1, 2)::(rank2, 1)::(rank3, 1)::(rank4, 1)::[] -> PokerHand.OnePair (rank1, rank2, rank3, rank4) |> Some 
    | _ -> None

let (|FullHouse|_|) hand =
    match ranksWithCount hand with
    | (rank1, 3)::(rank2, 2)::[] -> PokerHand.FullHouse (rank1, rank2) |> Some 
    | _ -> None

let (|HighCard|_|) hand = ranks hand |> listToTuple5 |> PokerHand.HighCard |> Some

let parsePokerHand (input: string) =
    match parseHand input with
    | StraightFlush hand -> hand
    | FourOfAKind hand -> hand
    | FullHouse hand -> hand
    | Flush hand -> hand
    | Straight hand -> hand
    | ThreeOfAKind hand -> hand
    | TwoPair hand -> hand
    | OnePair hand -> hand
    | HighCard hand -> hand
    | _ -> failwith "Invalid hand"

let bestHands hands =
    let pokerHands = List.map (fun hand -> hand, parsePokerHand hand) hands
    let bestHand = pokerHands |> List.map snd |> List.max 
    pokerHands
    |> List.filter (snd >> (=) bestHand)
    |> List.map fst