source("./connect.R")
library(testthat)

let ``An empty board has no winner`` () =
    board <- 
        [ ". . . . .    ";
          " . . . . .   ";
          "  . . . . .  ";
          "   . . . . . ";
          "    . . . . ." ]
    expect_equal(winner board, None)

let ``X can win on a 1x1 board`` () =
    board <- ["X"]
    expect_equal(winner board, (Some Black))

let ``O can win on a 1x1 board`` () =
    board <- ["O"]
    expect_equal(winner board, (Some White))

let ``Only edges does not make a winner`` () =
    board <- 
        [ "O O O X   ";
          " X . . X  ";
          "  X . . X ";
          "   X O O O" ]
    expect_equal(winner board, None)

let ``Illegal diagonal does not make a winner`` () =
    board <- 
        [ "X O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   . O X . ";
          "    X X O O" ]
    expect_equal(winner board, None)

let ``Nobody wins crossing adjacent angles`` () =
    board <- 
        [ "X . . .    ";
          " . X O .   ";
          "  O . X O  ";
          "   . O . X ";
          "    . . O ." ]
    expect_equal(winner board, None)

let ``X wins crossing from left to right`` () =
    board <- 
        [ ". O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   X X O X ";
          "    . O X ." ]
    expect_equal(winner board, (Some Black))

let ``O wins crossing from top to bottom`` () =
    board <- 
        [ ". O . .    ";
          " O X X X   ";
          "  O O O .  ";
          "   X X O X ";
          "    . O X ." ]
    expect_equal(winner board, (Some White))

let ``X wins using a convoluted path`` () =
    board <- 
        [ ". X X . .    ";
          " X . X . X   ";
          "  . X . X .  ";
          "   . X X . . ";
          "    O O O O O" ]
    expect_equal(winner board, (Some Black))

let ``X wins using a spiral path`` () =
    board <- 
        [ "O X X X X X X X X        ";
          " O X O O O O O O O       ";
          "  O X O X X X X X O      ";
          "   O X O X O O O X O     ";
          "    O X O X X X O X O    ";
          "     O X O O O X O X O   ";
          "      O X X X X X O X O  ";
          "       O O O O O O O X O ";
          "        X X X X X X X X O" ]
    expect_equal(winner board, (Some Black))

