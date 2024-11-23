~ "state-of-tic-tac-toe.ua" ~ StateOfTicTacToe

# Finished game where X won via left column victory
board ←
array2D [
  [’X’ ’O’ ’O’]
  [’X’ ’ ’ ’ ’]
  [’X’ ’ ’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via middle column victory
board ←
array2D [
  [’O’ ’X’ ’O’]
  [’ ’ ’X’ ’ ’]
  [’ ’ ’X’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via right column victory
board ←
array2D [
  [’O’ ’O’ ’X’]
  [’ ’ ’ ’ ’X’]
  [’ ’ ’ ’ ’X’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via left column victory
board ←
array2D [
  [’O’ ’X’ ’X’]
  [’O’ ’X’ ’ ’]
  [’O’ ’ ’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via middle column victory
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’ ’ ’O’ ’X’]
  [’ ’ ’O’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via right column victory
board ←
array2D [
  [’X’ ’X’ ’O’]
  [’ ’ ’X’ ’O’]
  [’ ’ ’ ’ ’O’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via top row victory
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’X’ ’O’ ’O’]
  [’O’ ’ ’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via middle row victory
board ←
array2D [
  [’O’ ’ ’ ’ ’]
  [’X’ ’X’ ’X’]
  [’ ’ ’O’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via bottom row victory
board ←
array2D [
  [’ ’ ’O’ ’O’]
  [’O’ ’ ’ ’X’]
  [’X’ ’X’ ’X’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via top row victory
board ←
array2D [
  [’O’ ’O’ ’O’]
  [’X’ ’X’ ’O’]
  [’X’ ’X’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via middle row victory
board ←
array2D [
  [’X’ ’X’ ’ ’]
  [’O’ ’O’ ’O’]
  [’X’ ’ ’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via bottom row victory
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’ ’ ’X’ ’X’]
  [’O’ ’O’ ’O’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via falling diagonal victory
board ←
array2D [
  [’X’ ’O’ ’O’]
  [’ ’ ’X’ ’ ’]
  [’ ’ ’ ’ ’X’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via rising diagonal victory
board ←
array2D [
  [’O’ ’ ’ ’X’]
  [’O’ ’X’ ’ ’]
  [’X’ ’ ’ ’ ’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via falling diagonal victory
board ←
array2D [
  [’O’ ’X’ ’X’]
  [’O’ ’O’ ’X’]
  [’X’ ’ ’ ’O’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where O won via rising diagonal victory
board ←
array2D [
  [’ ’ ’ ’ ’O’]
  [’ ’ ’O’ ’X’]
  [’O’ ’X’ ’X’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via a row and a column victory
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’X’ ’O’ ’O’]
  [’X’ ’O’ ’O’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Finished game where X won via two diagonal victories
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’O’ ’X’ ’O’]
  [’X’ ’O’ ’X’]]
expected ← EndGameState.Win
⍤⤙≍ expected gamestate board

# Draw
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’X’ ’X’ ’O’]
  [’O’ ’X’ ’O’]]
expected ← EndGameState.Draw
⍤⤙≍ expected gamestate board

# Another draw
board ←
array2D [
  [’X’ ’X’ ’O’]
  [’O’ ’X’ ’X’]
  [’X’ ’O’ ’O’]]
expected ← EndGameState.Draw
⍤⤙≍ expected gamestate board

# Ongoing game: one move in
board ←
array2D [
  [’ ’ ’ ’ ’ ’]
  [’X’ ’ ’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
expected ← EndGameState.Ongoing
⍤⤙≍ expected gamestate board

# Ongoing game: two moves in
board ←
array2D [
  [’O’ ’ ’ ’ ’]
  [’ ’ ’X’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
expected ← EndGameState.Ongoing
⍤⤙≍ expected gamestate board

# Ongoing game: five moves in
board ←
array2D [
  [’X’ ’ ’ ’ ’]
  [’ ’ ’X’ ’O’]
  [’O’ ’X’ ’ ’]]
expected ← EndGameState.Ongoing
⍤⤙≍ expected gamestate board

# Invalid board: X went twice
board ←
array2D [
  [’X’ ’X’ ’ ’]
  [’ ’ ’ ’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
expected ← Error ConsecutiveMovesBySamePlayer
⍤⤙≍ expected gamestate board

# Invalid board: O started
board ←
array2D [
  [’O’ ’O’ ’X’]
  [’ ’ ’ ’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
expected ← Error WrongPlayerStarted
⍤⤙≍ expected gamestate board

# Invalid board: X won and O kept playing
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’O’ ’O’ ’O’]
  [’ ’ ’ ’ ’ ’]]
expected ← Error MoveMadeAfterGameWasDone
⍤⤙≍ expected gamestate board

# Invalid board: players kept playing after a win
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’O’ ’O’ ’O’]
  [’X’ ’O’ ’X’]]
expected ← Error MoveMadeAfterGameWasDone
⍤⤙≍ expected gamestate board
