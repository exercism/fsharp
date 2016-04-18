module Bowling

let numberOfFrames = 10
let maximumFrameScore = 10

let roll pins game = game @ [pins]

let score game =    

    let roll index = List.item index game

    let isStrike frameIndex = roll frameIndex = maximumFrameScore
    let isSpare frameIndex = roll frameIndex + roll (frameIndex + 1) = maximumFrameScore

    let strikeBonus frameIndex = roll (frameIndex + 1) + roll (frameIndex + 2) 
    let spareBonus frameIndex = roll (frameIndex + 2) 

    let sumOfBallsInFrame frameIndex = roll frameIndex + roll (frameIndex + 1)
    
    let folder (score, frameIndex) frame = 
        if isStrike frameIndex then (score + 10 + strikeBonus frameIndex, frameIndex + 1)
        elif isSpare frameIndex then (score + 10 + spareBonus frameIndex, frameIndex + 2)
        else (score + sumOfBallsInFrame frameIndex, frameIndex + 2)

    [1..numberOfFrames]
    |> List.fold folder (0, 0)
    |> fst

let newGame = []