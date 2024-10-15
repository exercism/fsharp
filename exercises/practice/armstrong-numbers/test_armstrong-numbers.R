source("./armstrong-numbers.R")
library(testthat)

test_that("Zero is an Armstrong number", {
  expect_equal(isArmstrongNumber(0), TRUE)
})

test_that("Single-digit numbers are Armstrong numbers", {
  expect_equal(isArmstrongNumber(5), TRUE)
})

test_that("There are no two-digit Armstrong numbers", {
  expect_equal(isArmstrongNumber(10), FALSE)
})

test_that("Three-digit number that is an Armstrong number", {
  expect_equal(isArmstrongNumber(153), TRUE)
})

test_that("Three-digit number that is not an Armstrong number", {
  expect_equal(isArmstrongNumber(100), FALSE)
})

test_that("Four-digit number that is an Armstrong number", {
  expect_equal(isArmstrongNumber(9474), TRUE)
})

test_that("Four-digit number that is not an Armstrong number", {
  expect_equal(isArmstrongNumber(9475), FALSE)
})

test_that("Seven-digit number that is an Armstrong number", {
  expect_equal(isArmstrongNumber(9926315), TRUE)
})

test_that("Seven-digit number that is not an Armstrong number", {
  expect_equal(isArmstrongNumber(9926314), FALSE)

