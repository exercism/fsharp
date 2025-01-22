source("./saddle-points.R")
library(testthat)

test_that("Can identify single saddle point", {
    matrix <- 
        [ [9; 8; 7];
          [5; 3; 2];
          [6; 6; 7] ]
    expect_equal(saddlePoints matrix, [(2, 1)])
})

test_that("Can identify that empty matrix has no saddle points", {
    matrix <- [[]]
    saddlePoints matrix |> should be Empty

test_that("Can identify lack of saddle points when there are none", {
    matrix <- 
        [ [1; 2; 3];
          [3; 1; 2];
          [2; 3; 1] ]
    saddlePoints matrix |> should be Empty

test_that("Can identify multiple saddle points in a column", {
    matrix <- 
        [ [4; 5; 4];
          [3; 5; 5];
          [1; 5; 4] ]
    expect_equal(saddlePoints matrix, [(1, 2); (2, 2); (3, 2)])
})

test_that("Can identify multiple saddle points in a row", {
    matrix <- 
        [ [6; 7; 8];
          [5; 5; 5];
          [7; 5; 6] ]
    expect_equal(saddlePoints matrix, [(2, 1); (2, 2); (2, 3)])
})

test_that("Can identify saddle point in bottom right corner", {
    matrix <- 
        [ [8; 7; 9];
          [6; 7; 6];
          [3; 2; 5] ]
    expect_equal(saddlePoints matrix, [(3, 3)])
})

test_that("Can identify saddle points in a non square matrix", {
    matrix <- 
        [ [3; 1; 3];
          [3; 2; 4] ]
    expect_equal(saddlePoints matrix, [(1, 1); (1, 3)])
})

test_that("Can identify that saddle points in a single column matrix are those with the minimum value", {
    matrix <- 
        [ [2];
          [1];
          [4];
          [1] ]
    expect_equal(saddlePoints matrix, [(2, 1); (4, 1)])
})

test_that("Can identify that saddle points in a single row matrix are those with the maximum value", {
    matrix <- [[2; 5; 3; 5]]
    expect_equal(saddlePoints matrix, [(1, 2); (1, 4)])
})
