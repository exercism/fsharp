source("./killer-sudoku-helper.R")
library(testthat)

let ``1`` () =
    expect_equal(combinations [] 1 1, [[1]])

let ``2`` () =
    expect_equal(combinations [] 1 2, [[2]])

let ``3`` () =
    expect_equal(combinations [] 1 3, [[3]])

let ``4`` () =
    expect_equal(combinations [] 1 4, [[4]])

let ``5`` () =
    expect_equal(combinations [] 1 5, [[5]])

let ``6`` () =
    expect_equal(combinations [] 1 6, [[6]])

let ``7`` () =
    expect_equal(combinations [] 1 7, [[7]])

let ``8`` () =
    expect_equal(combinations [] 1 8, [[8]])

let ``9`` () =
    expect_equal(combinations [] 1 9, [[9]])

let ``Cage with sum 45 contains all digits 1:9`` () =
    expect_equal(combinations [] 9 45, [[1; 2; 3; 4; 5; 6; 7; 8; 9]])

let ``Cage with only 1 possible combination`` () =
    expect_equal(combinations [] 3 7, [[1; 2; 4]])

let ``Cage with several combinations`` () =
    expect_equal(combinations [] 2 10, [[1; 9]; [2; 8]; [3; 7]; [4; 6]])

let ``Cage with several combinations that is restricted`` () =
    expect_equal(combinations [1; 4] 2 10, [[2; 8]; [3; 7]])

