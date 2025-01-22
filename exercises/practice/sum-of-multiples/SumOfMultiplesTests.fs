source("./sum-of-multiples.R")
library(testthat)

test_that("No multiples within limit", {
    expect_equal(sum c(3, 5) 1, 0)
})

test_that("One factor has multiples within limit", {
    expect_equal(sum c(3, 5) 4, 3)
})

test_that("More than one multiple within limit", {
    expect_equal(sum c(3) 7, 9)
})

test_that("More than one factor with multiples within limit", {
    expect_equal(sum c(3, 5) 10, 23)
})

test_that("Each multiple is only counted once", {
    expect_equal(sum c(3, 5) 100, 2318)
})

test_that("A much larger limit", {
    expect_equal(sum c(3, 5) 1000, 233168)
})

test_that("Three factors", {
    expect_equal(sum c(7, 13, 17) 20, 51)
})

test_that("Factors not relatively prime", {
    expect_equal(sum c(4, 6) 15, 30)
})

test_that("Some pairs of factors relatively prime and some not", {
    expect_equal(sum c(5, 6, 8) 150, 4419)
})

test_that("One factor is a multiple of another", {
    expect_equal(sum c(5, 25) 51, 275)
})

test_that("Much larger factors", {
    expect_equal(sum c(43, 47) 10000, 2203160)
})

test_that("All numbers are multiples of 1", {
    expect_equal(sum c(1) 100, 4950)
})

test_that("No factors means an empty sum", {
    expect_equal(sum [] 10000, 0)
})

test_that("The only multiple of 0 is 0", {
    expect_equal(sum c(0) 1, 0)
})

test_that("The factor 0 does not affect the sum of multiples of other factors", {
    expect_equal(sum c(3, 0) 4, 3)
})

test_that("Solutions using include-exclude must extend to cardinality greater than 3", {
    expect_equal(sum c(2, 3, 5, 7, 11) 10000, 39614537)
})
