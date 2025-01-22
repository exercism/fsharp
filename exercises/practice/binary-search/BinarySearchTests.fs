source("./binary-search.R")
library(testthat)

test_that("Finds a value in an array with one element", {
  array <- c(|6|)
  value <- 6
  expected <- 0
  expect_equal(find(array, value), expected)
})

test_that("Finds a value in the middle of an array", {
  array <- c(|1, 3, 4, 6, 8, 9, 11|)
  value <- 6
  expected <- 3
  expect_equal(find(array, value), expected)
})

test_that("Finds a value at the beginning of an array", {
  array <- c(|1, 3, 4, 6, 8, 9, 11|)
  value <- 1
  expected <- 0
  expect_equal(find(array, value), expected)
})

test_that("Finds a value at the end of an array", {
  array <- c(|1, 3, 4, 6, 8, 9, 11|)
  value <- 11
  expected <- 6
  expect_equal(find(array, value), expected)
})

test_that("Finds a value in an array of odd length", {
  array <- c(|1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 634|)
  value <- 144
  expected <- 9
  expect_equal(find(array, value), expected)
})

test_that("Finds a value in an array of even length", {
  array <- c(|1, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377|)
  value <- 21
  expected <- 5
  expect_equal(find(array, value), expected)
})

test_that("Identifies that a value is not included in the array", {
  array <- c(|1, 3, 4, 6, 8, 9, 11|)
  value <- 7
  expected <- None
  expect_equal(find(array, value), expected)
})

test_that("A value smaller than the array's smallest value is not found", {
  array <- c(|1, 3, 4, 6, 8, 9, 11|)
  value <- 0
  expected <- None
  expect_equal(find(array, value), expected)
})

test_that("A value larger than the array's largest value is not found", {
  array <- c(|1, 3, 4, 6, 8, 9, 11|)
  value <- 13
  expected <- None
  expect_equal(find(array, value), expected)
})

test_that("Nothing is found in an empty array", {
  array <- c(||)
  value <- 1
  expected <- None
  expect_equal(find(array, value), expected)
})

test_that("Nothing is found when the left and right bounds cross", {
  array <- c(|1, 2|)
  value <- 0
  expected <- None
  expect_equal(find(array, value), expected)
})
