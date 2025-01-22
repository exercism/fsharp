source("./grains.R")
library(testthat)

test_that("Grains on square 1", {
    let expected: Result<uint64,string> = Ok 1UL
    expect_equal(square(1), expected)
})

test_that("Grains on square 2", {
    let expected: Result<uint64,string> = Ok 2UL
    expect_equal(square(2), expected)
})

test_that("Grains on square 3", {
    let expected: Result<uint64,string> = Ok 4UL
    expect_equal(square(3), expected)
})

test_that("Grains on square 4", {
    let expected: Result<uint64,string> = Ok 8UL
    expect_equal(square(4), expected)
})

test_that("Grains on square 16", {
    let expected: Result<uint64,string> = Ok 32768UL
    expect_equal(square(16), expected)
})

test_that("Grains on square 32", {
    let expected: Result<uint64,string> = Ok 2147483648UL
    expect_equal(square(32), expected)
})

test_that("Grains on square 64", {
    let expected: Result<uint64,string> = Ok 9223372036854775808UL
    expect_equal(square(64), expected)
})

test_that("Square 0 is invalid", {
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    expect_equal(square(0), expected)
})

test_that("Negative square is invalid", {
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    expect_equal(square -1, expected)
})

test_that("Square greater than 64 is invalid", {
    let expected: Result<uint64,string> = Error "square must be between 1 and 64"
    expect_equal(square(65), expected)
})

test_that("Returns the total number of grains on the board", {
    let expected: Result<uint64,string> = Ok 18446744073709551615UL
    expect_equal(total, expected)
})
