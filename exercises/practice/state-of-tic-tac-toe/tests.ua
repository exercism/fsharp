~ "state-of-tic-tac-toe.ua" ~ StateOfTicTacToe

# Finished game where X won via left column victory
board ←
array2D [
  [’X’ ’O’ ’O’]
  [’X’ ’ ’ ’ ’]
  [’X’ ’ ’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via middle column victory
board ←
array2D [
  [’O’ ’X’ ’O’]
  [’ ’ ’X’ ’ ’]
  [’ ’ ’X’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via right column victory
board ←
array2D [
  [’O’ ’O’ ’X’]
  [’ ’ ’ ’ ’X’]
  [’ ’ ’ ’ ’X’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via left column victory
board ←
array2D [
  [’O’ ’X’ ’X’]
  [’O’ ’X’ ’ ’]
  [’O’ ’ ’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via middle column victory
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’ ’ ’O’ ’X’]
  [’ ’ ’O’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via right column victory
board ←
array2D [
  [’X’ ’X’ ’O’]
  [’ ’ ’X’ ’O’]
  [’ ’ ’ ’ ’O’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via top row victory
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’X’ ’O’ ’O’]
  [’O’ ’ ’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via middle row victory
board ←
array2D [
  [’O’ ’ ’ ’ ’]
  [’X’ ’X’ ’X’]
  [’ ’ ’O’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via bottom row victory
board ←
array2D [
  [’ ’ ’O’ ’O’]
  [’O’ ’ ’ ’X’]
  [’X’ ’X’ ’X’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via top row victory
board ←
array2D [
  [’O’ ’O’ ’O’]
  [’X’ ’X’ ’O’]
  [’X’ ’X’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via middle row victory
board ←
array2D [
  [’X’ ’X’ ’ ’]
  [’O’ ’O’ ’O’]
  [’X’ ’ ’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via bottom row victory
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’ ’ ’X’ ’X’]
  [’O’ ’O’ ’O’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via falling diagonal victory
board ←
array2D [
  [’X’ ’O’ ’O’]
  [’ ’ ’X’ ’ ’]
  [’ ’ ’ ’ ’X’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via rising diagonal victory
board ←
array2D [
  [’O’ ’ ’ ’X’]
  [’O’ ’X’ ’ ’]
  [’X’ ’ ’ ’ ’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via falling diagonal victory
board ←
array2D [
  [’O’ ’X’ ’X’]
  [’O’ ’O’ ’X’]
  [’X’ ’ ’ ’O’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where O won via rising diagonal victory
board ←
array2D [
  [’ ’ ’ ’ ’O’]
  [’ ’ ’O’ ’X’]
  [’O’ ’X’ ’X’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via a row and a column victory
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’X’ ’O’ ’O’]
  [’X’ ’O’ ’O’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Finished game where X won via two diagonal victories
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’O’ ’X’ ’O’]
  [’X’ ’O’ ’X’]]
Expected ← EndGameState.Win
⍤⤙≍ Expected gamestate board

# Draw
board ←
array2D [
  [’X’ ’O’ ’X’]
  [’X’ ’X’ ’O’]
  [’O’ ’X’ ’O’]]
Expected ← EndGameState.Draw
⍤⤙≍ Expected gamestate board

# Another draw
board ←
array2D [
  [’X’ ’X’ ’O’]
  [’O’ ’X’ ’X’]
  [’X’ ’O’ ’O’]]
Expected ← EndGameState.Draw
⍤⤙≍ Expected gamestate board

# Ongoing game: one move in
board ←
array2D [
  [’ ’ ’ ’ ’ ’]
  [’X’ ’ ’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
Expected ← EndGameState.Ongoing
⍤⤙≍ Expected gamestate board

# Ongoing game: two moves in
board ←
array2D [
  [’O’ ’ ’ ’ ’]
  [’ ’ ’X’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
Expected ← EndGameState.Ongoing
⍤⤙≍ Expected gamestate board

# Ongoing game: five moves in
board ←
array2D [
  [’X’ ’ ’ ’ ’]
  [’ ’ ’X’ ’O’]
  [’O’ ’X’ ’ ’]]
Expected ← EndGameState.Ongoing
⍤⤙≍ Expected gamestate board

# Invalid board: X went twice
board ←
array2D [
  [’X’ ’X’ ’ ’]
  [’ ’ ’ ’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
Expected ← Error ConsecutiveMovesBySamePlayer
⍤⤙≍ Expected gamestate board

# Invalid board: O started
board ←
array2D [
  [’O’ ’O’ ’X’]
  [’ ’ ’ ’ ’ ’]
  [’ ’ ’ ’ ’ ’]]
Expected ← Error WrongPlayerStarted
⍤⤙≍ Expected gamestate board

# Invalid board: X won and O kept playing
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’O’ ’O’ ’O’]
  [’ ’ ’ ’ ’ ’]]
Expected ← Error MoveMadeAfterGameWasDone
⍤⤙≍ Expected gamestate board

# Invalid board: players kept playing after a win
board ←
array2D [
  [’X’ ’X’ ’X’]
  [’O’ ’O’ ’O’]
  [’X’ ’O’ ’X’]]
Expected ← Error MoveMadeAfterGameWasDone
⍤⤙≍ Expected gamestate board
