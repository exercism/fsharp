source("./collatz-conjecture.R")
library(testthat)

test_that("Zero steps for one", {
    expect_equal(steps(1), (Some 0))
})

test_that("Divide if even", {
    expect_equal(steps(16), (Some 4))
})

test_that("Even and odd steps", {
    expect_equal(steps(12), (Some 9))
})

test_that("Large number of even and odd steps", {
    expect_equal(steps(1000000), (Some 152))
})

test_that("Zero is an error", {
    expect_equal(steps(0), None)
})

test_that("Negative value is an error", {
    expect_equal(steps -15, None)
})
