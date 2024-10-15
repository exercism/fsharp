source("./all-your-base.R")
library(testthat)

test_that("Single bit one to decimal", {
    let digits = c(1)
    let inputBase = 2
    let outputBase = 10
    expected <-Some c(1)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Binary to single decimal", {
    let digits = c(1, 0, 1)
    let inputBase = 2
    let outputBase = 10
    expected <-Some c(5)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Single decimal to binary", {
    let digits = c(5)
    let inputBase = 10
    let outputBase = 2
    expected <-Some c(1, 0, 1)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Binary to multiple decimal", {
    let digits = c(1, 0, 1, 0, 1, 0)
    let inputBase = 2
    let outputBase = 10
    expected <-Some c(4, 2)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Decimal to binary", {
    let digits = c(4, 2)
    let inputBase = 10
    let outputBase = 2
    expected <-Some c(1, 0, 1, 0, 1, 0)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Trinary to hexadecimal", {
    let digits = c(1, 1, 2, 0)
    let inputBase = 3
    let outputBase = 16
    expected <-Some c(2, 10)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Hexadecimal to trinary", {
    let digits = c(2, 10)
    let inputBase = 16
    let outputBase = 3
    expected <-Some c(1, 1, 2, 0)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("15-bit integer", {
    let digits = c(3, 46, 60)
    let inputBase = 97
    let outputBase = 73
    expected <-Some c(6, 10, 45)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Empty list", {
    let digits = c()
    let inputBase = 2
    let outputBase = 10
    expected <-Some c(0)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Single zero", {
    let digits = c(0)
    let inputBase = 10
    let outputBase = 2
    expected <-Some c(0)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Multiple zeros", {
    let digits = c(0, 0, 0)
    let inputBase = 10
    let outputBase = 2
    expected <-Some c(0)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Leading zeros", {
    let digits = c(0, 6, 0)
    let inputBase = 7
    let outputBase = 10
    expected <-Some c(4, 2)
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Input base is one", {
    let digits = c(0)
    let inputBase = 1
    let outputBase = 10
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Input base is zero", {
    let digits = c()
    let inputBase = 0
    let outputBase = 10
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Input base is negative", {
    let digits = c(1)
    let inputBase = -2
    let outputBase = 10
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Negative digit", {
    let digits = c(1, -1, 1, 0, 1, 0)
    let inputBase = 2
    let outputBase = 10
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Invalid positive digit", {
    let digits = c(1, 2, 1, 0, 1, 0)
    let inputBase = 2
    let outputBase = 10
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Output base is one", {
    let digits = c(1, 0, 1, 0, 1, 0)
    let inputBase = 2
    let outputBase = 1
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Output base is zero", {
    let digits = c(7)
    let inputBase = 10
    let outputBase = 0
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Output base is negative", {
    let digits = c(1)
    let inputBase = 2
    let outputBase = -7
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)
})

test_that("Both bases are negative", {
    let digits = c(1)
    let inputBase = -2
    let outputBase = -7
    expected <-None
  expect_equal(rebase digits inputBase outputBase, expected)

