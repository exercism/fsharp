source("./dominoes.R")
library(testthat)

test_that("Empty input = empty output", {
    dominoes <- []
  expect_true(canChain dominoes)
})

test_that("Singleton input = singleton output", {
    dominoes <- c((1, 1))
  expect_true(canChain dominoes)
})

test_that("Singleton that can't be chained", {
    dominoes <- c((1, 2))
  expect_false(canChain dominoes)
})

test_that("Three elements", {
    dominoes <- c((1, 2), (3, 1), (2, 3))
  expect_true(canChain dominoes)
})

test_that("Can reverse dominoes", {
    dominoes <- c((1, 2), (1, 3), (2, 3))
  expect_true(canChain dominoes)
})

test_that("Can't be chained", {
    dominoes <- c((1, 2), (4, 1), (2, 3))
  expect_false(canChain dominoes)
})

test_that("Disconnected - simple", {
    dominoes <- c((1, 1), (2, 2))
  expect_false(canChain dominoes)
})

test_that("Disconnected - double loop", {
    dominoes <- c((1, 2), (2, 1), (3, 4), (4, 3))
  expect_false(canChain dominoes)
})

test_that("Disconnected - single isolated", {
    dominoes <- c((1, 2), (2, 3), (3, 1), (4, 4))
  expect_false(canChain dominoes)
})

test_that("Need backtrack", {
    dominoes <- c((1, 2), (2, 3), (3, 1), (2, 4), (2, 4))
  expect_true(canChain dominoes)
})

test_that("Separate loops", {
    dominoes <- c((1, 2), (2, 3), (3, 1), (1, 1), (2, 2), (3, 3))
  expect_true(canChain dominoes)
})

test_that("Nine elements", {
    dominoes <- c((1, 2), (5, 3), (3, 1), (1, 2), (2, 4), (1, 6), (2, 3), (3, 4), (5, 6))
  expect_true(canChain dominoes)
})

test_that("Separate three-domino loops", {
    dominoes <- c((1, 2), (2, 3), (3, 1), (4, 5), (5, 6), (6, 4))
  expect_false(canChain dominoes)
})
