source("./state-of-tic-tac-toe.R")
library(testthat)

test_that("Finished game where X won via left column victory", {
    board <- 
        array2D c( ['X', 'O', 'O');
                  c('X', ' ', ' ');
                  c('X', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via middle column victory", {
    board <- 
        array2D c( ['O', 'X', 'O');
                  c(' ', 'X', ' ');
                  c(' ', 'X', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via right column victory", {
    board <- 
        array2D c( ['O', 'O', 'X');
                  c(' ', ' ', 'X');
                  c(' ', ' ', 'X') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via left column victory", {
    board <- 
        array2D c( ['O', 'X', 'X');
                  c('O', 'X', ' ');
                  c('O', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via middle column victory", {
    board <- 
        array2D c( ['X', 'O', 'X');
                  c(' ', 'O', 'X');
                  c(' ', 'O', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via right column victory", {
    board <- 
        array2D c( ['X', 'X', 'O');
                  c(' ', 'X', 'O');
                  c(' ', ' ', 'O') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via top row victory", {
    board <- 
        array2D c( ['X', 'X', 'X');
                  c('X', 'O', 'O');
                  c('O', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via middle row victory", {
    board <- 
        array2D c( ['O', ' ', ' ');
                  c('X', 'X', 'X');
                  c(' ', 'O', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via bottom row victory", {
    board <- 
        array2D c( [' ', 'O', 'O');
                  c('O', ' ', 'X');
                  c('X', 'X', 'X') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via top row victory", {
    board <- 
        array2D c( ['O', 'O', 'O');
                  c('X', 'X', 'O');
                  c('X', 'X', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via middle row victory", {
    board <- 
        array2D c( ['X', 'X', ' ');
                  c('O', 'O', 'O');
                  c('X', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via bottom row victory", {
    board <- 
        array2D c( ['X', 'O', 'X');
                  c(' ', 'X', 'X');
                  c('O', 'O', 'O') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via falling diagonal victory", {
    board <- 
        array2D c( ['X', 'O', 'O');
                  c(' ', 'X', ' ');
                  c(' ', ' ', 'X') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via rising diagonal victory", {
    board <- 
        array2D c( ['O', ' ', 'X');
                  c('O', 'X', ' ');
                  c('X', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via falling diagonal victory", {
    board <- 
        array2D c( ['O', 'X', 'X');
                  c('O', 'O', 'X');
                  c('X', ' ', 'O') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where O won via rising diagonal victory", {
    board <- 
        array2D c( [' ', ' ', 'O');
                  c(' ', 'O', 'X');
                  c('O', 'X', 'X') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via a row and a column victory", {
    board <- 
        array2D c( ['X', 'X', 'X');
                  c('X', 'O', 'O');
                  c('X', 'O', 'O') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Finished game where X won via two diagonal victories", {
    board <- 
        array2D c( ['X', 'O', 'X');
                  c('O', 'X', 'O');
                  c('X', 'O', 'X') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Win
    expect_equal(gamestate board, expected)
})

test_that("Draw", {
    board <- 
        array2D c( ['X', 'O', 'X');
                  c('X', 'X', 'O');
                  c('O', 'X', 'O') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Draw
    expect_equal(gamestate board, expected)
})

test_that("Another draw", {
    board <- 
        array2D c( ['X', 'X', 'O');
                  c('O', 'X', 'X');
                  c('X', 'O', 'O') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Draw
    expect_equal(gamestate board, expected)
})

test_that("Ongoing game: one move in", {
    board <- 
        array2D c( [' ', ' ', ' ');
                  c('X', ' ', ' ');
                  c(' ', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Ongoing
    expect_equal(gamestate board, expected)
})

test_that("Ongoing game: two moves in", {
    board <- 
        array2D c( ['O', ' ', ' ');
                  c(' ', 'X', ' ');
                  c(' ', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Ongoing
    expect_equal(gamestate board, expected)
})

test_that("Ongoing game: five moves in", {
    board <- 
        array2D c( ['X', ' ', ' ');
                  c(' ', 'X', 'O');
                  c('O', 'X', ' ') ]
    let expected: Result<EndGameState, GameError> = Ok EndGameState.Ongoing
    expect_equal(gamestate board, expected)
})

test_that("Invalid board: X went twice", {
    board <- 
        array2D c( ['X', 'X', ' ');
                  c(' ', ' ', ' ');
                  c(' ', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Error ConsecutiveMovesBySamePlayer
    expect_equal(gamestate board, expected)
})

test_that("Invalid board: O started", {
    board <- 
        array2D c( ['O', 'O', 'X');
                  c(' ', ' ', ' ');
                  c(' ', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Error WrongPlayerStarted
    expect_equal(gamestate board, expected)
})

test_that("Invalid board: X won and O kept playing", {
    board <- 
        array2D c( ['X', 'X', 'X');
                  c('O', 'O', 'O');
                  c(' ', ' ', ' ') ]
    let expected: Result<EndGameState, GameError> = Error MoveMadeAfterGameWasDone
    expect_equal(gamestate board, expected)
})

test_that("Invalid board: players kept playing after a win", {
    board <- 
        array2D c( ['X', 'X', 'X');
                  c('O', 'O', 'O');
                  c('X', 'O', 'X') ]
    let expected: Result<EndGameState, GameError> = Error MoveMadeAfterGameWasDone
    expect_equal(gamestate board, expected)
})
