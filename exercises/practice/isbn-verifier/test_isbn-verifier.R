source("./isbn-verifier.R")
library(testthat)

test_that("Valid isbn", {
  expect_equal(isValid "3-598-21508-8", TRUE)
})

test_that("Invalid isbn check digit", {
  expect_equal(isValid "3-598-21508-9", FALSE)
})

test_that("Valid isbn with a check digit of 10", {
  expect_equal(isValid "3-598-21507-X", TRUE)
})

test_that("Check digit is a character other than X", {
  expect_equal(isValid "3-598-21507-A", FALSE)
})

test_that("Invalid check digit in isbn is not treated as zero", {
  expect_equal(isValid "4-598-21507-B", FALSE)
})

test_that("Invalid character in isbn is not treated as zero", {
  expect_equal(isValid "3-598-P1581-X", FALSE)
})

test_that("X is only valid as a check digit", {
  expect_equal(isValid "3-598-2X507-9", FALSE)
})

test_that("Valid isbn without separating dashes", {
  expect_equal(isValid "3598215088", TRUE)
})

test_that("Isbn without separating dashes and X as check digit", {
  expect_equal(isValid "359821507X", TRUE)
})

test_that("Isbn without check digit and dashes", {
  expect_equal(isValid "359821507", FALSE)
})

test_that("Too long isbn and no dashes", {
  expect_equal(isValid "3598215078X", FALSE)
})

test_that("Too short isbn", {
  expect_equal(isValid "00", FALSE)
})

test_that("Isbn without check digit", {
  expect_equal(isValid "3-598-21507", FALSE)
})

test_that("Check digit of X should not be used for 0", {
  expect_equal(isValid "3-598-21515-X", FALSE)
})

test_that("Empty isbn", {
  expect_equal(isValid "", FALSE)
})

test_that("Input is 9 characters", {
  expect_equal(isValid "134456729", FALSE)
})

test_that("Invalid characters are not ignored after checking length", {
  expect_equal(isValid "3132P34035", FALSE)
})

test_that("Invalid characters are not ignored before checking length", {
  expect_equal(isValid "3598P215088", FALSE)
})

test_that("Input is too long but contains a valid isbn", {
  expect_equal(isValid "98245726788", FALSE)

