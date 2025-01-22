source("./eliuds-eggs.R")
library(testthat)

test_that("0 eggs", {
    expect_equal(eggCount 0, 0)
})

test_that("1 egg", {
    expect_equal(eggCount 16, 1)
})

test_that("4 eggs", {
    expect_equal(eggCount 89, 4)
})

test_that("13 eggs", {
    expect_equal(eggCount 2000000000, 13)
})
