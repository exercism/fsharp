source("./resistor-color-trio.R")
library(testthat)

test_that("Orange and orange and black", {
    expect_equal(label c("orange", "orange", "black"), "33 ohms")
})

test_that("Blue and grey and brown", {
    expect_equal(label c("blue", "grey", "brown"), "680 ohms")
})

test_that("Red and black and red", {
    expect_equal(label c("red", "black", "red"), "2 kiloohms")
})

test_that("Green and brown and orange", {
    expect_equal(label c("green", "brown", "orange"), "51 kiloohms")
})

test_that("Yellow and violet and yellow", {
    expect_equal(label c("yellow", "violet", "yellow"), "470 kiloohms")
})

test_that("Blue and violet and blue", {
    expect_equal(label c("blue", "violet", "blue"), "67 megaohms")
})

test_that("Minimum possible value", {
    expect_equal(label c("black", "black", "black"), "0 ohms")
})

test_that("Maximum possible value", {
    expect_equal(label c("white", "white", "white"), "99 gigaohms")
})

test_that("First two colors make an invalid octal number", {
    expect_equal(label c("black", "grey", "black"), "8 ohms")
})

test_that("Ignore extra colors", {
    expect_equal(label c("blue", "green", "yellow", "orange"), "650 kiloohms")
})
