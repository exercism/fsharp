source("./two-fer.R")
library(testthat)

test_that("No name given", {
    twoFer None |> should equal "One for you, one for me."
})

test_that("A name given", {
    twoFer (Some "Alice") |> should equal "One for Alice, one for me."
})

test_that("Another name given", {
    twoFer (Some "Bob") |> should equal "One for Bob, one for me."

