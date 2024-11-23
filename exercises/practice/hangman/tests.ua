~ "hangman.ua" ~ Hangman

# Initially 9 failures are allowed
game   ← createGame "foo"
states ← statesObservable game

mutable ⊣Progress = Busy 9
states.Add(fun state -> ⊣Progress <- state.progress)
| > ignore

startGame game
| > ignore

⍤⤙≍ <
|Busy  9 ⊣Progress

# Initially no letters are guessed
game   ← createGame "foo"
states ← statesObservable game

mutable ⊣MaskedWord = ""
states.Add(fun state -> ⊣MaskedWord <- state.maskedWord)
| > ignore

startGame game
| > ignore

⍤⤙≍ "___" ⊣MaskedWord

# After 10 failures the game is over
game   ← createGame "foo"
states ← statesObservable game

mutable ⊣Progress = Busy 9
states.Add(fun state -> ⊣Progress <- state.progress)
| > ignore

startGame game
| > ignore

[⊃x in 1..10 ⍢makeGuess ’x’ game]
| > ignore

⍤⤙≍ Lose ⊣Progress

# Feeding a correct letter removes underscores
game   ← createGame "foobar"
states ← statesObservable game

mutable ⊣State = None
states.Add(fun state -> ⊣State <- state)
| > ignore

startGame game
| > ignore

makeGuess ’b’ game
| > ignore

⍤⤙≍ <
|Busy  9 ⊣State.Value.progress
⍤⤙≍ "___b__" ⊣State.Value.maskedWord

makeGuess ’o’ game
| > ignore

⍤⤙≍ <
|Busy  9 ⊣State.Value.progress
⍤⤙≍ "_oob__" ⊣State.Value.maskedWord

# Feeding a correct letter twice counts as a failure
game   ← createGame "foobar"
states ← statesObservable game

mutable ⊣State = None
states.Add(fun state -> ⊣State <- state)
| > ignore

startGame game
| > ignore

makeGuess ’b’ game
| > ignore

⍤⤙≍ <
|Busy  9 ⊣State.Value.progress
⍤⤙≍ "___b__" ⊣State.Value.maskedWord

makeGuess ’b’ game
| > ignore

⍤⤙≍ <
|Busy  8 ⊣State.Value.progress
⍤⤙≍ "___b__" ⊣State.Value.maskedWord

# Getting all the letters right makes for a win
game   ← createGame "hello"
states ← statesObservable game

mutable ⊣State = None
states.Add(fun state -> ⊣State <- state)
| > ignore

startGame game
| > ignore

makeGuess ’b’ game
| > ignore

⍤⤙≍ <
|Busy  8 ⊣State.Value.progress
⍤⤙≍ "_____" ⊣State.Value.maskedWord

makeGuess ’e’ game
| > ignore

⍤⤙≍ <
|Busy  8 ⊣State.Value.progress
⍤⤙≍ "_e___" ⊣State.Value.maskedWord

makeGuess ’l’ game
| > ignore

⍤⤙≍ <
|Busy  8 ⊣State.Value.progress
⍤⤙≍ "_ell_" ⊣State.Value.maskedWord

makeGuess ’o’ game
| > ignore

⍤⤙≍ <
|Busy  8 ⊣State.Value.progress
⍤⤙≍ "_ello" ⊣State.Value.maskedWord

makeGuess ’h’ game
| > ignore

⍤⤙≍ Win ⊣State.Value.progress
⍤⤙≍ "hello" ⊣State.Value.maskedWord
