source("./sublist.R")
library(testthat)

test_that("Empty lists", {
    listOne <- []
    listTwo <- []
    expect_equal(sublist listOne listTwo, SublistType.Equal)
})

test_that("Empty list within non empty list", {
    listOne <- []
    listTwo <- [1; 2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Non empty list contains empty list", {
    listOne <- [1; 2; 3]
    listTwo <- []
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("List equals itself", {
    listOne <- [1; 2; 3]
    listTwo <- [1; 2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Equal)
})

test_that("Different lists", {
    listOne <- [1; 2; 3]
    listTwo <- [2; 3; 4]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("False start", {
    listOne <- [1; 2; 5]
    listTwo <- [0; 1; 2; 3; 1; 2; 5; 6]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Consecutive", {
    listOne <- [1; 1; 2]
    listTwo <- [0; 1; 1; 1; 2; 1; 2]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist at start", {
    listOne <- [0; 1; 2]
    listTwo <- [0; 1; 2; 3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist in middle", {
    listOne <- [2; 3; 4]
    listTwo <- [0; 1; 2; 3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("Sublist at end", {
    listOne <- [3; 4; 5]
    listTwo <- [0; 1; 2; 3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Sublist)
})

test_that("At start of superlist", {
    listOne <- [0; 1; 2; 3; 4; 5]
    listTwo <- [0; 1; 2]
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("In middle of superlist", {
    listOne <- [0; 1; 2; 3; 4; 5]
    listTwo <- [2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("At end of superlist", {
    listOne <- [0; 1; 2; 3; 4; 5]
    listTwo <- [3; 4; 5]
    expect_equal(sublist listOne listTwo, SublistType.Superlist)
})

test_that("First list missing element from second list", {
    listOne <- [1; 3]
    listTwo <- [1; 2; 3]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Second list missing element from first list", {
    listOne <- [1; 2; 3]
    listTwo <- [1; 3]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("First list missing additional digits from second list", {
    listOne <- [1; 2]
    listTwo <- [1; 22]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Order matters to a list", {
    listOne <- [1; 2; 3]
    listTwo <- [3; 2; 1]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})

test_that("Same digits but different numbers", {
    listOne <- [1; 0; 1]
    listTwo <- [10; 1]
    expect_equal(sublist listOne listTwo, SublistType.Unequal)
})
