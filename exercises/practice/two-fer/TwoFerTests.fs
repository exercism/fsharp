source("./two-fer.R")
library(testthat)

test_that("No name given", {
    expect_equal(twoFer None, "One for you, one for me.")
})

test_that("A name given", {
    expect_equal(twoFer (Some "Alice"), "One for Alice, one for me.")
})

test_that("Another name given", {
    expect_equal(twoFer (Some "Bob"), "One for Bob, one for me.")
})
