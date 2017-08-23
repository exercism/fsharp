module Bowling

let map2 f opt1 opt2 = 
    match opt1, opt2 with
    | Some x, Some y -> Some (f x y)
    | _ -> None

let numberOfFrames = 10
let maximumFrameScore = 10
let minimumFrameScore = 0

let newGame() = Some []

let validatePins pins = 
    if pins < minimumFrameScore || pins > maximumFrameScore then 
        None 
    else 
        Some pins

let isStrike pins = pins = maximumFrameScore
let isSpare pins1 pins2 = pins1 + pins2 = maximumFrameScore

let roll pins rolls = map2 (fun rolls pins -> rolls @ [pins]) rolls (validatePins pins)

let rec scoreRolls totalScore frame rolls = 
    let isLastFrame = frame = numberOfFrames
    let gameFinished = frame = numberOfFrames + 1

    let scoreStrike remainder = 
        match remainder with
        | x::y::zs when isLastFrame ->
            if x + y > 10 && x <> 10 then None
            else scoreRolls (totalScore + 10 + x + y) (frame + 1) zs
        | x::y::zs ->
            scoreRolls (totalScore + 10 + x + y) (frame + 1) (x::y::zs)
        | _ ->
            None

    let scoreSpare x y remainder = 
        match remainder with 
        | z::zs->
            scoreRolls (totalScore + x + y + z) (frame + 1) (if isLastFrame then zs else z::zs)
        | _ ->
            None
            
    let scoreNormal x y remainder =
        match validatePins (x + y) with
        | Some z -> scoreRolls (totalScore + z) (frame + 1) remainder
        | None -> None

    match rolls with
    | [] -> if gameFinished then Some totalScore else None
    | x::xs when isStrike x -> scoreStrike xs        
    | x::y::ys when isSpare x y -> scoreSpare x y ys        
    | x::y::zs -> scoreNormal x y zs       
    | _ -> None
    
let score = Option.bind (scoreRolls 0 1)