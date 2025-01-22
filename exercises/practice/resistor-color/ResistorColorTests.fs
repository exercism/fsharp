source("./resistor-color.R")
library(testthat)

test_that("Black", {
    expect_equal(colorCode "black", 0)
})

test_that("White", {
    expect_equal(colorCode "white", 9)
})

test_that("Orange", {
    expect_equal(colorCode "orange", 3)
})

test_that("Colors", {
    expect_equal(colors, c("black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"))
})
