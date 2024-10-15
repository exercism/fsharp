source("./binary-search.R")
library(testthat)

test_that("Finds a value in an array with one element", {
    let array = c(|6|)
    let value = 6
    expected <-Some 0
  expect_equal(find array value, expected)
})

test_that("Finds a value in the middle of an array", {
    let array = c(|1, 3, 4, 6, 8, 9, 11|)
    let value = 6
    expected <-Some 3
  expect_equal(find array value, expected)
})

test_that("Finds a value at the beginning of an array", {
    let array = c(|1, 3, 4, 6, 8, 9, 11|)
    let value = 1
    expected <-Some 0
  expect_equal(find array value, expected)
})

test_that("Finds a value at the end of an array", {
    let array = c(|1, 3, 4, 6, 8, 9, 11|)
    let value = 11
    expected <-Some 6
  expect_equal(find array value, expected)
})

test_that("Finds a value in an array of odd length", {
    let array = c(|1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634|)
    let value = 144
    expected <-Some 9
  expect_equal(find array value, expected)
})

test_that("Finds a value in an array of even length", {
    let array = c(|1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377|)
    let value = 21
    expected <-Some 5
  expect_equal(find array value, expected)
})

test_that("Identifies that a value is not included in the array", {
    let array = c(|1, 3, 4, 6, 8, 9, 11|)
    let value = 7
    expected <-None
  expect_equal(find array value, expected)
})

test_that("A value smaller than the array's smallest value is not found", {
    let array = c(|1, 3, 4, 6, 8, 9, 11|)
    let value = 0
    expected <-None
  expect_equal(find array value, expected)
})

test_that("A value larger than the array's largest value is not found", {
    let array = c(|1, 3, 4, 6, 8, 9, 11|)
    let value = 13
    expected <-None
  expect_equal(find array value, expected)
})

test_that("Nothing is found in an empty array", {
    let array = c(||)
    let value = 1
    expected <-None
  expect_equal(find array value, expected)
})

test_that("Nothing is found when the left and right bounds cross", {
    let array = c(|1, 2|)
    let value = 0
    expected <-None
  expect_equal(find array value, expected)

