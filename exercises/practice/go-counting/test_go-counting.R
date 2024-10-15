source("./go-counting.R")
library(testthat)

test_that("Black corner territory on 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (0, 1)
    let expected = Option.Some (Owner.Black, [(0, 0); (0, 1); (1, 0)])
  expect_equal(territory board position, expected)
})

test_that("White center territory on 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (2, 3)
    let expected = Option.Some (Owner.White, [(2, 3)])
  expect_equal(territory board position, expected)
})

test_that("    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, 4)
    let expected = Option.Some (Owner.None, [(0, 3); (0, 4); (1, 4)])
  expect_equal(territory board position, expected)
})

test_that("A stone and not a territory on 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, 1)
    let expected: (Owner * (int * int) list) option = Option.Some (Owner.None, [])
  expect_equal(territory board position, expected)
})

test_that("Invalid because X is too low for 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (-1, 1)
    let expected = Option.None
  expect_equal(territory board position, expected)
})

test_that("Invalid because X is too high for 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (5, 1)
    let expected = Option.None
  expect_equal(territory board position, expected)
})

test_that("Invalid because Y is too low for 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, -1)
    let expected = Option.None
  expect_equal(territory board position, expected)
})

test_that("Invalid because Y is too high for 5x5 board", {
    let board = 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    let position = (1, 5)
    let expected = Option.None
  expect_equal(territory board position, expected)
})

test_that("One territory is the whole board", {
    let board = [" "]
    let expected = 
        [ (Owner.Black, []);
          (Owner.White, []);
          (Owner.None, [(0, 0)]) ]
        |> Map.ofList
  expect_equal(territories board, expected)
})

test_that("Two territory rectangular board", {
    let board = 
        [ " BW ";
          " BW " ]
    let expected = 
        [ (Owner.Black, [(0, 0); (0, 1)]);
          (Owner.White, [(3, 0); (3, 1)]);
          (Owner.None, []) ]
        |> Map.ofList
  expect_equal(territories board, expected)
})

test_that("Two region rectangular board", {
    let board = [" B "]
    let expected = 
        [ (Owner.Black, [(0, 0); (2, 0)]);
          (Owner.White, []);
          (Owner.None, []) ]
        |> Map.ofList
  expect_equal(territories board, expected)

