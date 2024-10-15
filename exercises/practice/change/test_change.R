source("./change.R")
library(testthat)

test_that("Change for 1 cent", {
    let coins = c(1, 5, 10, 25)
    let target = 1
    expected <-Some c(1)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Single coin change", {
    let coins = c(1, 5, 10, 25, 100)
    let target = 25
    expected <-Some c(25)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Multiple coin change", {
    let coins = c(1, 5, 10, 25, 100)
    let target = 15
    expected <-Some c(5, 10)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Change with Lilliputian Coins", {
    let coins = c(1, 4, 15, 20, 50)
    let target = 23
    expected <-Some c(4, 4, 15)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Change with Lower Elbonia Coins", {
    let coins = c(1, 5, 10, 21, 25)
    let target = 63
    expected <-Some c(21, 21, 21)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Large target values", {
    let coins = c(1, 2, 5, 10, 20, 50, 100)
    let target = 999
    expected <-Some c(2, 2, 5, 20, 20, 50, 100, 100, 100, 100, 100, 100, 100, 100, 100)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Possible change without unit coins available", {
    let coins = c(2, 5, 10, 20, 50)
    let target = 21
    expected <-Some c(2, 2, 2, 5, 10)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Another possible change without unit coins available", {
    let coins = c(4, 5)
    let target = 27
    expected <-Some c(4, 4, 4, 5, 5, 5)
  expect_equal(findFewestCoins coins target, expected)
})

test_that("No coins make 0 change", {
    let coins = c(1, 5, 10, 21, 25)
    let target = 0
    let expected: int list option = Some c()
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Error testing for change smaller than the smallest of coins", {
    let coins = c(5, 10)
    let target = 3
    expected <-None
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Error if no combination can add up to target", {
    let coins = c(5, 10)
    let target = 94
    expected <-None
  expect_equal(findFewestCoins coins target, expected)
})

test_that("Cannot find negative change values", {
    let coins = c(1, 2, 5)
    let target = -5
    expected <-None
  expect_equal(findFewestCoins coins target, expected)

