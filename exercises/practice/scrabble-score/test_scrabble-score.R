source("./scrabble-score.R")
library(testthat)

test_that("Lowercase letter", {
    score "a" |> should equal 1
})

test_that("Uppercase letter", {
    score "A" |> should equal 1
})

test_that("Valuable letter", {
    score "f" |> should equal 4
})

test_that("Short word", {
    score "at" |> should equal 2
})

test_that("Short, valuable word", {
    score "zoo" |> should equal 12
})

test_that("Medium word", {
    score "street" |> should equal 6
})

test_that("Medium, valuable word", {
    score "quirky" |> should equal 22
})

test_that("Long, mixed-case word", {
    score "OxyphenButazone" |> should equal 41
})

test_that("English-like word", {
    score "pinata" |> should equal 8
})

test_that("Empty input", {
    score "" |> should equal 0
})

test_that("Entire alphabet available", {
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87

