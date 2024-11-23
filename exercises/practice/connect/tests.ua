~ "connect.ua" ~ Connect

# An empty board has no winner
    let board = 
        [ ". . . . .    ";
          " . . . . .   ";
          "  . . . . .  ";
          "   . . . . . ";
          "    . . . . ." ]
    winner board |> should equal None

# X can win on a 1x1 board
    let board = ["X"]
    winner board |> should equal (Some Black)

# O can win on a 1x1 board
    let board = ["O"]
    winner board |> should equal (Some White)

# Only edges does not make a winner
    let board = 
        [ "O O O X   ";
          " X . . X  ";
          "  X . . X ";
          "   X O O O" ]
    winner board |> should equal None

# Illegal diagonal does not make a winner
    let board = 
        [ "X O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   . O X . ";
          "    X X O O" ]
    winner board |> should equal None

# Nobody wins crossing adjacent angles
    let board = 
        [ "X . . .    ";
          " . X O .   ";
          "  O . X O  ";
          "   . O . X ";
          "    . . O ." ]
    winner board |> should equal None

# X wins crossing from left to right
    let board = 
        [ ". O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   X X O X ";
          "    . O X ." ]
    winner board |> should equal (Some Black)

# O wins crossing from top to bottom
    let board = 
        [ ". O . .    ";
          " O X X X   ";
          "  O O O .  ";
          "   X X O X ";
          "    . O X ." ]
    winner board |> should equal (Some White)

# X wins using a convoluted path
    let board = 
        [ ". X X . .    ";
          " X . X . X   ";
          "  . X . X .  ";
          "   . X X . . ";
          "    O O O O O" ]
    winner board |> should equal (Some Black)

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
    winner board |> should equal (Some Black)

