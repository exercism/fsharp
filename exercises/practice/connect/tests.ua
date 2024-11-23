~ "connect.ua" ~ Connect

# An empty board has no winner
board ←
[". . . . .    "" . . . . .   ""  . . . . .  ""   . . . . . ""    . . . . ."]
⍤⤙≍ "TODO: insert error message" ⍣(winner board)

# X can win on a 1x1 board
board ← ["X"]
⍤⤙≍ Black winner board

# O can win on a 1x1 board
board ← ["O"]
⍤⤙≍ White winner board

# Only edges does not make a winner
board ←
["O O O X   "" X . . X  ""  X . . X ""   X O O O"]
⍤⤙≍ "TODO: insert error message" ⍣(winner board)

# Illegal diagonal does not make a winner
board ←
["X O . .    "" O X X X   ""  O X O .  ""   . O X . ""    X X O O"]
⍤⤙≍ "TODO: insert error message" ⍣(winner board)

# Nobody wins crossing adjacent angles
board ←
["X . . .    "" . X O .   ""  O . X O  ""   . O . X ""    . . O ."]
⍤⤙≍ "TODO: insert error message" ⍣(winner board)

# X wins crossing from left to right
board ←
[". O . .    "" O X X X   ""  O X O .  ""   X X O X ""    . O X ."]
⍤⤙≍ Black winner board

# O wins crossing from top to bottom
board ←
[". O . .    "" O X X X   ""  O O O .  ""   X X O X ""    . O X ."]
⍤⤙≍ White winner board

# X wins using a convoluted path
board ←
[". X X . .    "" X . X . X   ""  . X . X .  ""   . X X . . ""    O O O O O"]
⍤⤙≍ Black winner board

# X wins using a spiral path
board ←
["O X X X X X X X X        "" O X O O O O O O O       ""  O X O X X X X X O      ""   O X O X O O O X O     ""    O X O X X X O X O    ""     O X O O O X O X O   ""      O X X X X X O X O  ""       O O O O O O O X O ""        X X X X X X X X O"]
⍤⤙≍ Black winner board
