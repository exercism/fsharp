module Yacht

type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

let private diceWithCount dice = 
    dice
    |> List.countBy id
    |> List.sortByDescending snd

let private valueScore value dice =
    let count = 
        dice 
        |> List.filter ((=) value) 
        |> List.length 
    count * value

let private fullHouseScore dice =
    match diceWithCount dice with
    | [(_, 3); (_, 2)] -> List.sum dice
    | _ -> 0

let private fourOfAKindScore dice =
    match diceWithCount dice with
    | [(value, 4); _] -> value * 4
    | [(value, 5)]    -> value * 4
    | _ -> 0

let private littleStraightScore dice =
    if List.sort dice = [1; 2; 3; 4; 5] then 30 else 0

let private bigStraightScore dice =
    if List.sort dice = [2; 3; 4; 5; 6] then 30 else 0

let private choiceScore dice = 
    List.sum dice

let private yachtScore dice = 
    if dice |> List.distinct |> List.length = 1 then 50 else 0

let score category dice = 
    match category with
    | Ones           -> valueScore 1 dice
    | Twos           -> valueScore 2 dice
    | Threes         -> valueScore 3 dice
    | Fours          -> valueScore 4 dice
    | Fives          -> valueScore 5 dice
    | Sixes          -> valueScore 6 dice
    | FullHouse      -> fullHouseScore dice
    | FourOfAKind    -> fourOfAKindScore dice
    | LittleStraight -> littleStraightScore dice
    | BigStraight    -> bigStraightScore dice
    | Choice         -> choiceScore dice
    | Yacht          -> yachtScore dice