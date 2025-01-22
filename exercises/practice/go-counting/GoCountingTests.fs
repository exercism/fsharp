source("./go-counting.R")
library(testthat)

test_that("Black corner territory on 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (0, 1)
    expected <- Option.Some (Owner.Black, c((0, 0), (0, 1), (1, 0)))
    expect_equal(territory(board, position), expected)
})

test_that("White center territory on 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (2, 3)
    expected <- Option.Some (Owner.White, c((2, 3)))
    expect_equal(territory(board, position), expected)
})

test_that("Open corner territory on 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, 4)
    expected <- Option.Some (Owner.None, c((0, 3), (0, 4), (1, 4)))
    expect_equal(territory(board, position), expected)
})

test_that("A stone and not a territory on 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, 1)
    let expected: (Owner * (int * int) list) option = Option.Some (Owner.None, [])
    expect_equal(territory(board, position), expected)
})

test_that("Invalid because X is too low for 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (-1, 1)
    expected <- Option.None
    expect_equal(territory(board, position), expected)
})

test_that("Invalid because X is too high for 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (5, 1)
    expected <- Option.None
    expect_equal(territory(board, position), expected)
})

test_that("Invalid because Y is too low for 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, -1)
    expected <- Option.None
    expect_equal(territory(board, position), expected)
})

test_that("Invalid because Y is too high for 5x5 board", {
    board <- 
        [ "  B  ";
          " B B ";
          "B W B";
          " W W ";
          "  W  " ]
    position <- (1, 5)
    expected <- Option.None
    expect_equal(territory(board, position), expected)
})

test_that("One territory is the whole board", {
    board <- c(" ")
    expected <- 
        c( (Owner.Black, [));
          (Owner.White, []);
          (Owner.None, c((0, 0))) ]
        |> Map.ofList
    expect_equal(territories(board), expected)
})

test_that("Two territory rectangular board", {
    board <- 
        [ " BW ";
          " BW " ]
    expected <- 
        c( (Owner.Black, [(0, 0), (0, 1)));
          (Owner.White, c((3, 0), (3, 1)));
          (Owner.None, c(]) )
        |> Map.ofList
    expect_equal(territories(board), expected)
})

test_that("Two region rectangular board", {
    board <- c(" B ")
    expected <- 
        c( (Owner.Black, [(0, 0), (2, 0)));
          (Owner.White, []);
          (Owner.None, c(]) )
        |> Map.ofList
    expect_equal(territories(board), expected)
})
