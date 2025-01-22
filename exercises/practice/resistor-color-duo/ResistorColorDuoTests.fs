source("./resistor-color-duo.R")
library(testthat)

test_that("Brown and black", {
    expect_equal(value ["brown"; "black"], 10)
})

test_that("Blue and grey", {
    expect_equal(value ["blue"; "grey"], 68)
})

test_that("Yellow and violet", {
    expect_equal(value ["yellow"; "violet"], 47)
})

test_that("White and red", {
    expect_equal(value ["white"; "red"], 92)
})

test_that("Orange and orange", {
    expect_equal(value ["orange"; "orange"], 33)
})

test_that("Ignore additional colors", {
    expect_equal(value ["green"; "brown"; "orange"], 51)
})

test_that("Black and brown, one-digit", {
    expect_equal(value ["black"; "brown"], 1)
})
