~ "bowling.ua" ~ Bowling

rollMany rolls game = List.∧(fun game pins -> roll pins game) game rolls

# Should be able to score a game with all zeros
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 0 score game

# Should be able to score a game with no strikes or spares
rolls ← [3 6 3 6 3 6 3 6 3 6 3 6 3 6 3 6 3 6 3 6]
game  ← rollMany rolls (newGame())
⍤⤙≍ 90 score game

# A spare followed by zeros is worth ten points
rolls ← [6 4 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 10 score game

# Points scored in the roll after a spare are counted twice
rolls ← [6 4 3 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 16 score game

# Consecutive spares each get a one roll bonus
rolls ← [5 5 3 7 4 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 31 score game

# A spare in the last frame gets a one roll bonus that is counted once
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 7 3 7]
game  ← rollMany rolls (newGame())
⍤⤙≍ 17 score game

# A strike earns ten points in a frame with a single roll
rolls ← [10 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 10 score game

# Points scored in the two rolls after a strike are counted twice as a bonus
rolls ← [10 5 3 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 26 score game

# Consecutive strikes each get the two roll bonus
rolls ← [10 10 10 5 3 0 0 0 0 0 0 0 0 0 0 0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ 81 score game

# A strike in the last frame gets a two roll bonus that is counted once
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 7 1]
game  ← rollMany rolls (newGame())
⍤⤙≍ 18 score game

# Rolling a spare with the two roll bonus does not get a bonus roll
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 7 3]
game  ← rollMany rolls (newGame())
⍤⤙≍ 20 score game

# Strikes with the two roll bonus do not get bonus rolls
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 10 10]
game  ← rollMany rolls (newGame())
⍤⤙≍ 30 score game

# Last two strikes followed by only last bonus with non strike points
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 10 0 1]
game  ← rollMany rolls (newGame())
⍤⤙≍ 31 score game

# A strike with the one roll bonus after a spare in the last frame does not get a bonus
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 7 3 10]
game  ← rollMany rolls (newGame())
⍤⤙≍ 20 score game

# All strikes is a perfect game
rolls ← [10 10 10 10 10 10 10 10 10 10 10 10]
game  ← rollMany rolls (newGame())
⍤⤙≍ 300 score game

# Rolls cannot score negative points
rolls         ← []
startingRolls ← rollMany rolls (newGame())
game          ← roll -1 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# A roll cannot score more than 10 points
rolls         ← []
startingRolls ← rollMany rolls (newGame())
game          ← roll 11 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Two rolls in a frame cannot score more than 10 points
rolls         ← [5]
startingRolls ← rollMany rolls (newGame())
game          ← roll 6 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Bonus roll after a strike in the last frame cannot score more than 10 points
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10]
startingRolls ← rollMany rolls (newGame())
game          ← roll 11 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Two bonus rolls after a strike in the last frame cannot score more than 10 points
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 5]
startingRolls ← rollMany rolls (newGame())
game          ← roll 6 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Two bonus rolls after a strike in the last frame can score more than 10 points if one is a strike
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 10 6]
game  ← rollMany rolls (newGame())
⍤⤙≍ 26 score game

# The second bonus rolls after a strike in the last frame cannot be a strike if the first one is not a strike
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 6]
startingRolls ← rollMany rolls (newGame())
game          ← roll 10 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Second bonus roll after a strike in the last frame cannot score more than 10 points
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 10]
startingRolls ← rollMany rolls (newGame())
game          ← roll 11 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# An unstarted game cannot be scored
rolls ← []
game  ← rollMany rolls (newGame())
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# An incomplete game cannot be scored
rolls ← [0 0]
game  ← rollMany rolls (newGame())
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Cannot roll if game already has ten frames
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0]
startingRolls ← rollMany rolls (newGame())
game          ← roll 0 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Bonus rolls for a strike in the last frame must be rolled before score can be calculated
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10]
game  ← rollMany rolls (newGame())
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Both bonus rolls for a strike in the last frame must be rolled before score can be calculated
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 10]
game  ← rollMany rolls (newGame())
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Bonus roll for a spare in the last frame must be rolled before score can be calculated
rolls ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 7 3]
game  ← rollMany rolls (newGame())
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Cannot roll after bonus roll for spare
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 7 3 2]
startingRolls ← rollMany rolls (newGame())
game          ← roll 2 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)

# Cannot roll after bonus rolls for strike
rolls         ← [0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 10 3 2]
startingRolls ← rollMany rolls (newGame())
game          ← roll 2 startingRolls
⍤⤙≍ "TODO: insert error message" ⍣(score game)
