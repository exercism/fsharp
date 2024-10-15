source("./game-of-life.R")
library(testthat)

test_that("Empty matrix", {
    let matrix: intc(,) = array2D c()
    let expected: intc(,) = array2D c()
  expect_equal(tick matrix, expected)
})

test_that("Live cells with zero live neighbors die", {
    let matrix = 
        array2D c( c(0, 0, 0);
                  c(0, 1, 0);
                  c(0, 0, 0) )
    expected <-
        array2D c( c(0, 0, 0);
                  c(0, 0, 0);
                  c(0, 0, 0) )
  expect_equal(tick matrix, expected)
})

test_that("Live cells with only one live neighbor die", {
    let matrix = 
        array2D c( c(0, 0, 0);
                  c(0, 1, 0);
                  c(0, 1, 0) )
    expected <-
        array2D c( c(0, 0, 0);
                  c(0, 0, 0);
                  c(0, 0, 0) )
  expect_equal(tick matrix, expected)
})

test_that("Live cells with two live neighbors stay alive", {
    let matrix = 
        array2D c( c(1, 0, 1);
                  c(1, 0, 1);
                  c(1, 0, 1) )
    expected <-
        array2D c( c(0, 0, 0);
                  c(1, 0, 1);
                  c(0, 0, 0) )
  expect_equal(tick matrix, expected)
})

test_that("Live cells with three live neighbors stay alive", {
    let matrix = 
        array2D c( c(0, 1, 0);
                  c(1, 0, 0);
                  c(1, 1, 0) )
    expected <-
        array2D c( c(0, 0, 0);
                  c(1, 0, 0);
                  c(1, 1, 0) )
  expect_equal(tick matrix, expected)
})

test_that("Dead cells with three live neighbors become alive", {
    let matrix = 
        array2D c( c(1, 1, 0);
                  c(0, 0, 0);
                  c(1, 0, 0) )
    expected <-
        array2D c( c(0, 0, 0);
                  c(1, 1, 0);
                  c(0, 0, 0) )
  expect_equal(tick matrix, expected)
})

test_that("Live cells with four or more neighbors die", {
    let matrix = 
        array2D c( c(1, 1, 1);
                  c(1, 1, 1);
                  c(1, 1, 1) )
    expected <-
        array2D c( c(1, 0, 1);
                  c(0, 0, 0);
                  c(1, 0, 1) )
  expect_equal(tick matrix, expected)
})

test_that("Bigger matrix", {
    let matrix = 
        array2D c( c(1, 1, 0, 1, 1, 0, 0, 0);
                  c(1, 0, 1, 1, 0, 0, 0, 0);
                  c(1, 1, 1, 0, 0, 1, 1, 1);
                  c(0, 0, 0, 0, 0, 1, 1, 0);
                  c(1, 0, 0, 0, 1, 1, 0, 0);
                  c(1, 1, 0, 0, 0, 1, 1, 1);
                  c(0, 0, 1, 0, 1, 0, 0, 1);
                  c(1, 0, 0, 0, 0, 0, 1, 1) )
    expected <-
        array2D c( c(1, 1, 0, 1, 1, 0, 0, 0);
                  c(0, 0, 0, 0, 0, 1, 1, 0);
                  c(1, 0, 1, 1, 1, 1, 0, 1);
                  c(1, 0, 0, 0, 0, 0, 0, 1);
                  c(1, 1, 0, 0, 1, 0, 0, 1);
                  c(1, 1, 0, 1, 0, 0, 0, 1);
                  c(1, 0, 0, 0, 0, 0, 0, 0);
                  c(0, 0, 0, 0, 0, 0, 1, 1) )
  expect_equal(tick matrix, expected)

