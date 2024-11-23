~ "SOLUTION" ~ Hangman

# Initially 9 failures are allowed
game = createGame "foo"
states = statesObservable game

mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

⍤⤙≍ <| Busy 9 lastProgress

# Initially no letters are guessed
game = createGame "foo"
states = statesObservable game

mutable lastMaskedWord = ""
    states.Add(fun state -> lastMaskedWord <- state.maskedWord) |> ignore

    startGame game |> ignore

⍤⤙≍ "___" lastMaskedWord

# After 10 failures the game is over
game = createGame "foo"
states = statesObservable game

mutable lastProgress = Busy 9
    states.Add(fun state -> lastProgress <- state.progress) |> ignore

    startGame game |> ignore

    [for x in 1..10 do makeGuess 'x' game] |> ignore

⍤⤙≍ Lose lastProgress
    
# Feeding a correct letter removes underscores
game = createGame "foobar"
states = statesObservable game

mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

⍤⤙≍ <| Busy 9 lastState.Value.progress
⍤⤙≍ "___b__" lastState.Value.maskedWord

    makeGuess 'o' game |> ignore

⍤⤙≍ <| Busy 9 lastState.Value.progress
⍤⤙≍ "_oob__" lastState.Value.maskedWord
    
# Feeding a correct letter twice counts as a failure
game = createGame "foobar"
states = statesObservable game

mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

⍤⤙≍ <| Busy 9 lastState.Value.progress
⍤⤙≍ "___b__" lastState.Value.maskedWord

    makeGuess 'b' game |> ignore

⍤⤙≍ <| Busy 8 lastState.Value.progress
⍤⤙≍ "___b__" lastState.Value.maskedWord
     
# Getting all the letters right makes for a win
game = createGame "hello"
states = statesObservable game

mutable lastState = None
    states.Add(fun state -> lastState <- Some state) |> ignore

    startGame game |> ignore

    makeGuess 'b' game |> ignore

⍤⤙≍ <| Busy 8 lastState.Value.progress
⍤⤙≍ "_____" lastState.Value.maskedWord

    makeGuess 'e' game |> ignore

⍤⤙≍ <| Busy 8 lastState.Value.progress
⍤⤙≍ "_e___" lastState.Value.maskedWord

    makeGuess 'l' game |> ignore

⍤⤙≍ <| Busy 8 lastState.Value.progress
⍤⤙≍ "_ell_" lastState.Value.maskedWord

    makeGuess 'o' game |> ignore

⍤⤙≍ <| Busy 8 lastState.Value.progress
⍤⤙≍ "_ello" lastState.Value.maskedWord

    makeGuess 'h' game |> ignore

⍤⤙≍ Win lastState.Value.progress
⍤⤙≍ "hello" lastState.Value.maskedWord