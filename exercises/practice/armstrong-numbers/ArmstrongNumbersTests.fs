source("./armstrong-numbers.R")
library(testthat)

test_that("Zero is an Armstrong number", {
    expect_equal(isArmstrongNumber 0, true)
})

test_that("Single-digit numbers are Armstrong numbers", {
    expect_equal(isArmstrongNumber 5, true)
})

test_that("There are no two-digit Armstrong numbers", {
    expect_equal(isArmstrongNumber 10, false)
})

test_that("Three-digit number that is an Armstrong number", {
    expect_equal(isArmstrongNumber 153, true)
})

test_that("Three-digit number that is not an Armstrong number", {
    expect_equal(isArmstrongNumber 100, false)
})

test_that("Four-digit number that is an Armstrong number", {
    expect_equal(isArmstrongNumber 9474, true)
})

test_that("Four-digit number that is not an Armstrong number", {
    expect_equal(isArmstrongNumber 9475, false)
})

test_that("Seven-digit number that is an Armstrong number", {
    expect_equal(isArmstrongNumber 9926315, true)
})

test_that("Seven-digit number that is not an Armstrong number", {
    expect_equal(isArmstrongNumber 9926314, false)
})
