source("./high-scores.R")
library(testthat)

test_that("List of scores", {
    expect_equal(scores c(30, 50, 20, 70), c(30, 50, 20, 70))
})

test_that("Latest score", {
    expect_equal(latest c(100, 0, 90, 30), 30)
})

test_that("Personal best", {
    expect_equal(personalBest c(40, 100, 70), 100)
})

test_that("Personal top three from a list of scores", {
    expect_equal(personalTopThree c(10, 30, 90, 30, 100, 20, 10, 0, 30, 40, 40, 70, 70), c(100, 90, 70))
})

test_that("Personal top highest to lowest", {
    expect_equal(personalTopThree c(20, 10, 30), c(30, 20, 10))
})

test_that("Personal top when there is a tie", {
    expect_equal(personalTopThree c(40, 20, 40, 30), c(40, 40, 30))
})

test_that("Personal top when there are less than 3", {
    expect_equal(personalTopThree c(30, 70), c(70, 30))
})

test_that("Personal top when there is only one", {
    expect_equal(personalTopThree c(40), c(40))
})
