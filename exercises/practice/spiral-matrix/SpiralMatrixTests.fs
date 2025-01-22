source("./spiral-matrix.R")
library(testthat)

test_that("Empty spiral", {
    spiralMatrix 0 |> should be Empty

test_that("Trivial spiral", {
    expect_equal(spiralMatrix 1, c([1)])
})

test_that("Spiral of size 2", {
    spiralMatrix 2 |> should equal 
        c( [1, 2);
          c(4, 3) ]

test_that("Spiral of size 3", {
    spiralMatrix 3 |> should equal 
        c( [1, 2, 3);
          c(8, 9, 4);
          c(7, 6, 5) ]

test_that("Spiral of size 4", {
    spiralMatrix 4 |> should equal 
        c( [1, 2, 3, 4);
          c(12, 13, 14, 5);
          c(11, 16, 15, 6);
          c(10, 9, 8, 7) ]

test_that("Spiral of size 5", {
    spiralMatrix 5 |> should equal 
        c( [1, 2, 3, 4, 5);
          c(16, 17, 18, 19, 6);
          c(15, 24, 25, 20, 7);
          c(14, 23, 22, 21, 8);
          c(13, 12, 11, 10, 9) ]

