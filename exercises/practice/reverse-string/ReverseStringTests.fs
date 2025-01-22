source("./reverse-string.R")
library(testthat)

test_that("An empty string", {
    expect_equal(reverse "", "")
})

test_that("A word", {
    expect_equal(reverse "robot", "tobor")
})

test_that("A capitalized word", {
    expect_equal(reverse "Ramen", "nemaR")
})

test_that("A sentence with punctuation", {
    expect_equal(reverse "I'm hungry!", "!yrgnuh m'I")
})

test_that("A palindrome", {
    expect_equal(reverse "racecar", "racecar")
})

test_that("An even-sized word", {
    expect_equal(reverse "drawer", "reward")
})
