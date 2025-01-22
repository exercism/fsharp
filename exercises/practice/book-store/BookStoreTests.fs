source("./book-store.R")
library(testthat)

test_that("Only a single book", {
    expect_equal(total [1], 8.00m)
})

test_that("Two of the same book", {
    expect_equal(total [2; 2], 16.00m)
})

test_that("Empty basket", {
    expect_equal(total [], 0.00m)
})

test_that("Two different books", {
    expect_equal(total [1; 2], 15.20m)
})

test_that("Three different books", {
    expect_equal(total [1; 2; 3], 21.60m)
})

test_that("Four different books", {
    expect_equal(total [1; 2; 3; 4], 25.60m)
})

test_that("Five different books", {
    expect_equal(total [1; 2; 3; 4; 5], 30.00m)
})

test_that("Two groups of four is cheaper than group of five plus group of three", {
    expect_equal(total [1; 1; 2; 2; 3; 3; 4; 5], 51.20m)
})

test_that("Two groups of four is cheaper than groups of five and three", {
    expect_equal(total [1; 1; 2; 3; 4; 4; 5; 5], 51.20m)
})

test_that("Group of four plus group of two is cheaper than two groups of three", {
    expect_equal(total [1; 1; 2; 2; 3; 4], 40.80m)
})

test_that("Two each of first four books and one copy each of rest", {
    expect_equal(total [1; 1; 2; 2; 3; 3; 4; 4; 5], 55.60m)
})

test_that("Two copies of each book", {
    expect_equal(total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5], 60.00m)
})

test_that("Three copies of first book and two each of remaining", {
    expect_equal(total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1], 68.00m)
})

test_that("Three each of first two books and two each of remaining books", {
    expect_equal(total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1; 2], 75.20m)
})

test_that("Four groups of four are cheaper than two groups each of five and three", {
    expect_equal(total [1; 1; 2; 2; 3; 3; 4; 5; 1; 1; 2; 2; 3; 3; 4; 5], 102.40m)
})

test_that("Check that groups of four are created properly even when there are more groups of three than groups of five", {
    expect_equal(total [1; 1; 1; 1; 1; 1; 2; 2; 2; 2; 2; 2; 3; 3; 3; 3; 3; 3; 4; 4; 5; 5], 145.60m)
})

test_that("One group of one and four is cheaper than one group of two and three", {
    expect_equal(total [1; 1; 2; 3; 4], 33.60m)
})

test_that("One group of one and two plus three groups of four is cheaper than one group of each size", {
    expect_equal(total [1; 2; 2; 3; 3; 3; 4; 4; 4; 4; 5; 5; 5; 5; 5], 100.00m)
})
