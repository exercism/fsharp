source("./secret-handshake.R")
library(testthat)

test_that("Wink for 1", {
    commands 1 |> should equal ["wink"]
})

test_that("Double blink for 10", {
    commands 2 |> should equal ["double blink"]
})

test_that("Close your eyes for 100", {
    commands 4 |> should equal ["close your eyes"]
})

test_that("Jump for 1000", {
    commands 8 |> should equal ["jump"]
})

test_that("Combine two actions", {
    commands 3 |> should equal ["wink"; "double blink"]
})

test_that("Reverse two actions", {
    commands 19 |> should equal ["double blink"; "wink"]
})

test_that("Reversing one action gives the same action", {
    commands 24 |> should equal ["jump"]
})

test_that("Reversing no actions still gives no actions", {
    commands 16 |> should be Empty
})

test_that("All possible actions", {
    commands 15 |> should equal ["wink"; "double blink"; "close your eyes"; "jump"]
})

test_that("Reverse all possible actions", {
    commands 31 |> should equal ["jump"; "close your eyes"; "double blink"; "wink"]
})

test_that("Do nothing for zero", {
    commands 0 |> should be Empty

