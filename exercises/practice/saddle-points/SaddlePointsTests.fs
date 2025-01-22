source("./saddle-points.R")
library(testthat)

test_that("Can identify single saddle point", {
    matrix <- 
        c( [9, 8, 7);
          c(5, 3, 2);
          c(6, 6, 7) ]
    expect_equal(saddlePoints matrix, c((2, 1)))
})

test_that("Can identify that empty matrix has no saddle points", {
    matrix <- c([)]
    saddlePoints matrix |> should be Empty

test_that("Can identify lack of saddle points when there are none", {
    matrix <- 
        c( [1, 2, 3);
          c(3, 1, 2);
          c(2, 3, 1) ]
    saddlePoints matrix |> should be Empty

test_that("Can identify multiple saddle points in a column", {
    matrix <- 
        c( [4, 5, 4);
          c(3, 5, 5);
          c(1, 5, 4) ]
    expect_equal(saddlePoints matrix, c((1, 2), (2, 2), (3, 2)))
})

test_that("Can identify multiple saddle points in a row", {
    matrix <- 
        c( [6, 7, 8);
          c(5, 5, 5);
          c(7, 5, 6) ]
    expect_equal(saddlePoints matrix, c((2, 1), (2, 2), (2, 3)))
})

test_that("Can identify saddle point in bottom right corner", {
    matrix <- 
        c( [8, 7, 9);
          c(6, 7, 6);
          c(3, 2, 5) ]
    expect_equal(saddlePoints matrix, c((3, 3)))
})

test_that("Can identify saddle points in a non square matrix", {
    matrix <- 
        c( [3, 1, 3);
          c(3, 2, 4) ]
    expect_equal(saddlePoints matrix, c((1, 1), (1, 3)))
})

test_that("Can identify that saddle points in a single column matrix are those with the minimum value", {
    matrix <- 
        c( [2);
          c(1);
          c(4);
          c(1) ]
    expect_equal(saddlePoints matrix, c((2, 1), (4, 1)))
})

test_that("Can identify that saddle points in a single row matrix are those with the maximum value", {
    matrix <- c([2, 5, 3, 5)]
    expect_equal(saddlePoints matrix, c((1, 2), (1, 4)))
})
