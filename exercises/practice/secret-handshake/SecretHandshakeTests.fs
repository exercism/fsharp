source("./secret-handshake.R")
library(testthat)

test_that("Wink for 1", {
    expect_equal(commands 1, ["wink"])
})

test_that("Double blink for 10", {
    expect_equal(commands 2, ["double blink"])
})

test_that("Close your eyes for 100", {
    expect_equal(commands 4, ["close your eyes"])
})

test_that("Jump for 1000", {
    expect_equal(commands 8, ["jump"])
})

test_that("Combine two actions", {
    expect_equal(commands 3, ["wink"; "double blink"])
})

test_that("Reverse two actions", {
    expect_equal(commands 19, ["double blink"; "wink"])
})

test_that("Reversing one action gives the same action", {
    expect_equal(commands 24, ["jump"])
})

test_that("Reversing no actions still gives no actions", {
    commands 16 |> should be Empty

test_that("All possible actions", {
    expect_equal(commands 15, ["wink"; "double blink"; "close your eyes"; "jump"])
})

test_that("Reverse all possible actions", {
    expect_equal(commands 31, ["jump"; "close your eyes"; "double blink"; "wink"])
})

test_that("Do nothing for zero", {
    commands 0 |> should be Empty

