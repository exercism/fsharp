source("./connect.R")
library(testthat)

test_that("An empty board has no winner", {
    let board = 
        c( ". . . . .    ",
          " . . . . .   ",
          "  . . . . .  ",
          "   . . . . . ",
          "    . . . . ." )
  expect_equal(winner board, None)
})

test_that("X can win on a 1x1 board", {
    let board = c("X")
  expect_equal(winner board, (Some Black))
})

test_that("O can win on a 1x1 board", {
    let board = c("O")
  expect_equal(winner board, (Some White))
})

test_that("Only edges does not make a winner", {
    let board = 
        c( "O O O X   ",
          " X . . X  ",
          "  X . . X ",
          "   X O O O" )
  expect_equal(winner board, None)
})

test_that("Illegal diagonal does not make a winner", {
    let board = 
        c( "X O . .    ",
          " O X X X   ",
          "  O X O .  ",
          "   . O X . ",
          "    X X O O" )
  expect_equal(winner board, None)
})

test_that("Nobody wins crossing adjacent angles", {
    let board = 
        c( "X . . .    ",
          " . X O .   ",
          "  O . X O  ",
          "   . O . X ",
          "    . . O ." )
  expect_equal(winner board, None)
})

test_that("X wins crossing from left to right", {
    let board = 
        c( ". O . .    ",
          " O X X X   ",
          "  O X O .  ",
          "   X X O X ",
          "    . O X ." )
  expect_equal(winner board, (Some Black))
})

test_that("O wins crossing from top to bottom", {
    let board = 
        c( ". O . .    ",
          " O X X X   ",
          "  O O O .  ",
          "   X X O X ",
          "    . O X ." )
  expect_equal(winner board, (Some White))
})

test_that("X wins using a convoluted path", {
    let board = 
        c( ". X X . .    ",
          " X . X . X   ",
          "  . X . X .  ",
          "   . X X . . ",
          "    O O O O O" )
  expect_equal(winner board, (Some Black))
})

test_that("X wins using a spiral path", {
    let board = 
        c( "O X X X X X X X X        ",
          " O X O O O O O O O       ",
          "  O X O X X X X X O      ",
          "   O X O X O O O X O     ",
          "    O X O X X X O X O    ",
          "     O X O O O X O X O   ",
          "      O X X X X X O X O  ",
          "       O O O O O O O X O ",
          "        X X X X X X X X O" )
  expect_equal(winner board, (Some Black))

