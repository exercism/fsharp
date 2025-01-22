source("./darts.R")
library(testthat)

test_that("Missed target", {
  expect_equal(score -9.0 9.0, 0)
})

test_that("On the outer circle", {
  expect_equal(score 0.0 10.0, 1)
})

test_that("On the middle circle", {
  expect_equal(score -5.0 0.0, 5)
})

test_that("On the inner circle", {
  expect_equal(score 0.0 -1.0, 10)
})

test_that("Exactly on center", {
  expect_equal(score 0.0 0.0, 10)
})

test_that("Near the center", {
  expect_equal(score -0.1 -0.1, 10)
})

test_that("Just within the inner circle", {
  expect_equal(score 0.7 0.7, 10)
})

test_that("Just outside the inner circle", {
  expect_equal(score 0.8 -0.8, 5)
})

test_that("Just within the middle circle", {
  expect_equal(score -3.5 3.5, 5)
})

test_that("Just outside the middle circle", {
  expect_equal(score -3.6 -3.6, 1)
})

test_that("Just within the outer circle", {
  expect_equal(score -7.0 7.0, 1)
})

test_that("Just outside the outer circle", {
  expect_equal(score 7.1 -7.1, 0)
})

test_that("Asymmetric position between the inner and middle circles", {
  expect_equal(score 0.5 -4.0, 5)
})
