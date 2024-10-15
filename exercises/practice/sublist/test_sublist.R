source("./sublist.R")
library(testthat)

test_that("Empty lists", {
    let listOne = c()
    let listTwo = c()
  expect_equal(sublist listOne listTwo, SublistType.Equal)
})

test_that("Empty list within non empty list", {
    let listOne = c()
    let listTwo = c(1, 2, 3)
  expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Non empty list contains empty list", {
    let listOne = c(1, 2, 3)
    let listTwo = c()
  expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("List equals itself", {
    let listOne = c(1, 2, 3)
    let listTwo = c(1, 2, 3)
  expect_equal(sublist listOne listTwo, SublistType.Equal)
})

test_that("Different lists", {
    let listOne = c(1, 2, 3)
    let listTwo = c(2, 3, 4)
  expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("False start", {
    let listOne = c(1, 2, 5)
    let listTwo = c(0, 1, 2, 3, 1, 2, 5, 6)
  expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Consecutive", {
    let listOne = c(1, 1, 2)
    let listTwo = c(0, 1, 1, 1, 2, 1, 2)
  expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist at start", {
    let listOne = c(0, 1, 2)
    let listTwo = c(0, 1, 2, 3, 4, 5)
  expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist in middle", {
    let listOne = c(2, 3, 4)
    let listTwo = c(0, 1, 2, 3, 4, 5)
  expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist at end", {
    let listOne = c(3, 4, 5)
    let listTwo = c(0, 1, 2, 3, 4, 5)
  expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("At start of superlist", {
    let listOne = c(0, 1, 2, 3, 4, 5)
    let listTwo = c(0, 1, 2)
  expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("In middle of superlist", {
    let listOne = c(0, 1, 2, 3, 4, 5)
    let listTwo = c(2, 3)
  expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("At end of superlist", {
    let listOne = c(0, 1, 2, 3, 4, 5)
    let listTwo = c(3, 4, 5)
  expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("First list missing element from second list", {
    let listOne = c(1, 3)
    let listTwo = c(1, 2, 3)
  expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Second list missing element from first list", {
    let listOne = c(1, 2, 3)
    let listTwo = c(1, 3)
  expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("First list missing additional digits from second list", {
    let listOne = c(1, 2)
    let listTwo = c(1, 22)
  expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Order matters to a list", {
    let listOne = c(1, 2, 3)
    let listTwo = c(3, 2, 1)
  expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Same digits but different numbers", {
    let listOne = c(1, 0, 1)
    let listTwo = c(10, 1)
  expect_equal(sublist listOne listTwo, SublistType.Unequal)

