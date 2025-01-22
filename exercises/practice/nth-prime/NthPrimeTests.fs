source("./nth-prime.R")
library(testthat)

test_that("First prime", {
    expect_equal(prime(1), (Some 2))
})

test_that("Second prime", {
    expect_equal(prime(2), (Some 3))
})

test_that("Sixth prime", {
    expect_equal(prime(6), (Some 13))
})

test_that("Big prime", {
    expect_equal(prime(10001), (Some 104743))
})

test_that("There is no zeroth prime", {
    expect_equal(prime(0), None)
})
