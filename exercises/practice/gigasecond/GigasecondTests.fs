source("./gigasecond.R")
library(testthat)

test_that("Date only specification of time", {
    expect_equal(add (DateTime(2011, 4, 25)), (DateTime(2043, 1, 1, 1, 46, 40)))
})

test_that("Second test for date only specification of time", {
    expect_equal(add (DateTime(1977, 6, 13)), (DateTime(2009, 2, 19, 1, 46, 40)))
})

test_that("Third test for date only specification of time", {
    expect_equal(add (DateTime(1959, 7, 19)), (DateTime(1991, 3, 27, 1, 46, 40)))
})

test_that("Full time specified", {
    expect_equal(add (DateTime(2015, 1, 24, 22, 0, 0)), (DateTime(2046, 10, 2, 23, 46, 40)))
})

test_that("Full time with day roll-over", {
    expect_equal(add (DateTime(2015, 1, 24, 23, 59, 59)), (DateTime(2046, 10, 3, 1, 46, 39)))
})
