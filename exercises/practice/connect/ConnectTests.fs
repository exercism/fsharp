source("./connect.R")
library(testthat)

test_that("An empty board has no winner", {
    board <- 
        [ ". . . . .    ";
          " . . . . .   ";
          "  . . . . .  ";
          "   . . . . . ";
          "    . . . . ." ]
    expect_equal(winner board, None)
})

test_that("X can win on a 1x1 board", {
    board <- c("X")
    expect_equal(winner board, (Some Black))
})

test_that("O can win on a 1x1 board", {
    board <- c("O")
    expect_equal(winner board, (Some White))
})

test_that("Only edges does not make a winner", {
    board <- 
        [ "O O O X   ";
          " X . . X  ";
          "  X . . X ";
          "   X O O O" ]
    expect_equal(winner board, None)
})

test_that("Illegal diagonal does not make a winner", {
    board <- 
        [ "X O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   . O X . ";
          "    X X O O" ]
    expect_equal(winner board, None)
})

test_that("Nobody wins crossing adjacent angles", {
    board <- 
        [ "X . . .    ";
          " . X O .   ";
          "  O . X O  ";
          "   . O . X ";
          "    . . O ." ]
    expect_equal(winner board, None)
})

test_that("X wins crossing from left to right", {
    board <- 
        [ ". O . .    ";
          " O X X X   ";
          "  O X O .  ";
          "   X X O X ";
          "    . O X ." ]
    expect_equal(winner board, (Some Black))
})

test_that("O wins crossing from top to bottom", {
    board <- 
        [ ". O . .    ";
          " O X X X   ";
          "  O O O .  ";
          "   X X O X ";
          "    . O X ." ]
    expect_equal(winner board, (Some White))
})

test_that("X wins using a convoluted path", {
    board <- 
        [ ". X X . .    ";
          " X . X . X   ";
          "  . X . X .  ";
          "   . X X . . ";
          "    O O O O O" ]
    expect_equal(winner board, (Some Black))
})

test_that("X wins using a spiral path", {
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
})
