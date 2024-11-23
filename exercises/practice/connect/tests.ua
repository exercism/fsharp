~ "connect.ua" ~ Connect

# An empty board has no winner
    let board = 
        [ ". . . . .    ";
          " . . . . .   ";
          "  . . . . .  ";
          "   . . . . . ";
          "    . . . . ." ]
⍤⤙≍ None winner board

# X can win on a 1x1 board
    let board = ["X"]
⍤⤙≍ (Some Black) winner board

# O can win on a 1x1 board
    let board = ["O"]
⍤⤙≍ (Some White) winner board

# Only edges does not make a winner
    let board = 
        [ "O O O X   ";
          " X . . X  ";
          "  X . . X ";
          "   X O O O" ]
⍤⤙≍ None winner board

# Illegal diagonal does not make a winner
    let board = 
        [ "X O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   . O X . ";
          "    X X O O" ]
⍤⤙≍ None winner board

# Nobody wins crossing adjacent angles
    let board = 
        [ "X . . .    ";
          " . X O .   ";
          "  O . X O  ";
          "   . O . X ";
          "    . . O ." ]
⍤⤙≍ None winner board

# X wins crossing from left to right
    let board = 
        [ ". O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   X X O X ";
          "    . O X ." ]
⍤⤙≍ (Some Black) winner board

# O wins crossing from top to bottom
    let board = 
        [ ". O . .    ";
          " O X X X   ";
          "  O O O .  ";
          "   X X O X ";
          "    . O X ." ]
⍤⤙≍ (Some White) winner board

# X wins using a convoluted path
    let board = 
        [ ". X X . .    ";
          " X . X . X   ";
          "  . X . X .  ";
          "   . X X . . ";
          "    O O O O O" ]
⍤⤙≍ (Some Black) winner board

# X wins using a spiral path
    let board = 
        [ "O X X X X X X X X        ";
          " O X O O O O O O O       ";
          "  O X O X X X X X O      ";
          "   O X O X O O O X O     ";
          "    O X O X X X O X O    ";
          "     O X O O O X O X O   ";
          "      O X X X X X O X O  ";
          "       O O O O O O O X O ";
          "        X X X X X X X X O" ]
⍤⤙≍ (Some Black) winner board

