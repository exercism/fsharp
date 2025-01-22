source("./secret-handshake.R")
library(testthat)

test_that("Wink for 1", {
    expect_equal(commands 1, c("wink"))
})

test_that("Double blink for 10", {
    expect_equal(commands 2, c("double blink"))
})

test_that("Close your eyes for 100", {
    expect_equal(commands 4, c("close your eyes"))
})

test_that("Jump for 1000", {
    expect_equal(commands 8, c("jump"))
})

test_that("Combine two actions", {
    expect_equal(commands 3, c("wink", "double blink"))
})

test_that("Reverse two actions", {
    expect_equal(commands 19, c("double blink", "wink"))
})

test_that("Reversing one action gives the same action", {
    expect_equal(commands 24, c("jump"))
})

test_that("Reversing no actions still gives no actions", {
    commands 16 |> should be Empty

test_that("All possible actions", {
    expect_equal(commands 15, c("wink", "double blink", "close your eyes", "jump"))
})

test_that("Reverse all possible actions", {
    expect_equal(commands 31, c("jump", "close your eyes", "double blink", "wink"))
})

test_that("Do nothing for zero", {
    commands 0 |> should be Empty

