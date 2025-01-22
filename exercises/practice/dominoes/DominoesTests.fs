source("./dominoes.R")
library(testthat)

test_that("Empty input = empty output", {
    dominoes <- []
    expect_equal(canChain dominoes, true)
})

test_that("Singleton input = singleton output", {
    dominoes <- [(1, 1)]
    expect_equal(canChain dominoes, true)
})

test_that("Singleton that can't be chained", {
    dominoes <- [(1, 2)]
    expect_equal(canChain dominoes, false)
})

test_that("Three elements", {
    dominoes <- [(1, 2); (3, 1); (2, 3)]
    expect_equal(canChain dominoes, true)
})

test_that("Can reverse dominoes", {
    dominoes <- [(1, 2); (1, 3); (2, 3)]
    expect_equal(canChain dominoes, true)
})

test_that("Can't be chained", {
    dominoes <- [(1, 2); (4, 1); (2, 3)]
    expect_equal(canChain dominoes, false)
})

test_that("Disconnected - simple", {
    dominoes <- [(1, 1); (2, 2)]
    expect_equal(canChain dominoes, false)
})

test_that("Disconnected - double loop", {
    dominoes <- [(1, 2); (2, 1); (3, 4); (4, 3)]
    expect_equal(canChain dominoes, false)
})

test_that("Disconnected - single isolated", {
    dominoes <- [(1, 2); (2, 3); (3, 1); (4, 4)]
    expect_equal(canChain dominoes, false)
})

test_that("Need backtrack", {
    dominoes <- [(1, 2); (2, 3); (3, 1); (2, 4); (2, 4)]
    expect_equal(canChain dominoes, true)
})

test_that("Separate loops", {
    dominoes <- [(1, 2); (2, 3); (3, 1); (1, 1); (2, 2); (3, 3)]
    expect_equal(canChain dominoes, true)
})

test_that("Nine elements", {
    dominoes <- [(1, 2); (5, 3); (3, 1); (1, 2); (2, 4); (1, 6); (2, 3); (3, 4); (5, 6)]
    expect_equal(canChain dominoes, true)
})

test_that("Separate three-domino loops", {
    dominoes <- [(1, 2); (2, 3); (3, 1); (4, 5); (5, 6); (6, 4)]
    expect_equal(canChain dominoes, false)
})
