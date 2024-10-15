source("./reverse-string.R")
library(testthat)

test_that("An empty string", {
    reverse "" |> should equal ""
})

test_that("A word", {
    reverse "robot" |> should equal "tobor"
})

test_that("A capitalized word", {
    reverse "Ramen" |> should equal "nemaR"
})

test_that("A sentence with punctuation", {
    reverse "I'm hungry!" |> should equal "!yrgnuh m'I"
})

test_that("A palindrome", {
    reverse "racecar" |> should equal "racecar"
})

test_that("An even-sized word", {
    reverse "drawer" |> should equal "reward"

