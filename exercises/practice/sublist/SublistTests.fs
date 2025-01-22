source("./sublist.R")
library(testthat)

test_that("Empty lists", {
    listOne <- []
    listTwo <- []
    expect_equal(sublist listOne listTwo, SublistType.Equal)
})

test_that("Empty list within non empty list", {
    listOne <- []
    listTwo <- c(1, 2, 3)
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Non empty list contains empty list", {
    listOne <- c(1, 2, 3)
    listTwo <- []
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("List equals itself", {
    listOne <- c(1, 2, 3)
    listTwo <- c(1, 2, 3)
    expect_equal(sublist listOne listTwo, SublistType.Equal)
})

test_that("Different lists", {
    listOne <- c(1, 2, 3)
    listTwo <- c(2, 3, 4)
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("False start", {
    listOne <- c(1, 2, 5)
    listTwo <- c(0, 1, 2, 3, 1, 2, 5, 6)
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Consecutive", {
    listOne <- c(1, 1, 2)
    listTwo <- c(0, 1, 1, 1, 2, 1, 2)
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist at start", {
    listOne <- c(0, 1, 2)
    listTwo <- c(0, 1, 2, 3, 4, 5)
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist in middle", {
    listOne <- c(2, 3, 4)
    listTwo <- c(0, 1, 2, 3, 4, 5)
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist at end", {
    listOne <- c(3, 4, 5)
    listTwo <- c(0, 1, 2, 3, 4, 5)
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("At start of superlist", {
    listOne <- c(0, 1, 2, 3, 4, 5)
    listTwo <- c(0, 1, 2)
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("In middle of superlist", {
    listOne <- c(0, 1, 2, 3, 4, 5)
    listTwo <- c(2, 3)
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("At end of superlist", {
    listOne <- c(0, 1, 2, 3, 4, 5)
    listTwo <- c(3, 4, 5)
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("First list missing element from second list", {
    listOne <- c(1, 3)
    listTwo <- c(1, 2, 3)
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Second list missing element from first list", {
    listOne <- c(1, 2, 3)
    listTwo <- c(1, 3)
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("First list missing additional digits from second list", {
    listOne <- c(1, 2)
    listTwo <- c(1, 22)
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Order matters to a list", {
    listOne <- c(1, 2, 3)
    listTwo <- c(3, 2, 1)
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Same digits but different numbers", {
    listOne <- c(1, 0, 1)
    listTwo <- c(10, 1)
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})
