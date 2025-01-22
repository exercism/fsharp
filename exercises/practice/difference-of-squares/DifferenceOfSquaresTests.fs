source("./difference-of-squares.R")
library(testthat)

test_that("Square of sum 1", {
    expect_equal(squareOfSum(1), 1)
})

test_that("Square of sum 5", {
    expect_equal(squareOfSum(5), 225)
})

test_that("Square of sum 100", {
    expect_equal(squareOfSum(100), 25502500)
})

test_that("Sum of squares 1", {
    expect_equal(sumOfSquares(1), 1)
})

test_that("Sum of squares 5", {
    expect_equal(sumOfSquares(5), 55)
})

test_that("Sum of squares 100", {
    expect_equal(sumOfSquares(100), 338350)
})

test_that("Difference of squares 1", {
    expect_equal(differenceOfSquares(1), 0)
})

test_that("Difference of squares 5", {
    expect_equal(differenceOfSquares(5), 170)
})

test_that("Difference of squares 100", {
    expect_equal(differenceOfSquares(100), 25164150)
})
