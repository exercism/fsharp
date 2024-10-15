source("./dominoes.R")
library(testthat)

test_that("Empty input = empty output", {
    let dominoes = []
  expect_equal(canChain dominoes, true)
})

test_that("Singleton input = singleton output", {
    let dominoes = [(1, 1)]
  expect_equal(canChain dominoes, true)
})

test_that("Singleton that can't be chained", {
    let dominoes = [(1, 2)]
  expect_equal(canChain dominoes, false)
})

test_that("Three elements", {
    let dominoes = [(1, 2); (3, 1); (2, 3)]
  expect_equal(canChain dominoes, true)
})

test_that("Can reverse dominoes", {
    let dominoes = [(1, 2); (1, 3); (2, 3)]
  expect_equal(canChain dominoes, true)
})

test_that("Can't be chained", {
    let dominoes = [(1, 2); (4, 1); (2, 3)]
  expect_equal(canChain dominoes, false)
})

test_that("Disconnected - simple", {
    let dominoes = [(1, 1); (2, 2)]
  expect_equal(canChain dominoes, false)
})

test_that("Disconnected - double loop", {
    let dominoes = [(1, 2); (2, 1); (3, 4); (4, 3)]
  expect_equal(canChain dominoes, false)
})

test_that("Disconnected - single isolated", {
    let dominoes = [(1, 2); (2, 3); (3, 1); (4, 4)]
  expect_equal(canChain dominoes, false)
})

test_that("Need backtrack", {
    let dominoes = [(1, 2); (2, 3); (3, 1); (2, 4); (2, 4)]
  expect_equal(canChain dominoes, true)
})

test_that("Separate loops", {
    let dominoes = [(1, 2); (2, 3); (3, 1); (1, 1); (2, 2); (3, 3)]
  expect_equal(canChain dominoes, true)
})

test_that("Nine elements", {
    let dominoes = [(1, 2); (5, 3); (3, 1); (1, 2); (2, 4); (1, 6); (2, 3); (3, 4); (5, 6)]
  expect_equal(canChain dominoes, true)
})

test_that("Separate three-domino loops", {
    let dominoes = [(1, 2); (2, 3); (3, 1); (4, 5); (5, 6); (6, 4)]
  expect_equal(canChain dominoes, false)

