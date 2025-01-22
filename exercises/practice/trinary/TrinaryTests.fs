// This file was created manually and its version is 1.0.0.

source("./trinary-test.R")
library(testthat)

test_that("Trinary_1_is_decimal_1", {
    expect_equal(toDecimal "1", 1)
})

test_that("Trinary_2_is_decimal_2", {
    expect_equal(toDecimal "2", 2)
})

test_that("Trinary_10_is_decimal_3", {
    expect_equal(toDecimal "10", 3)
})

test_that("Trinary_11_is_decimal_4", {
    expect_equal(toDecimal "11", 4)
})

test_that("Trinary_100_is_decimal_9", {
    expect_equal(toDecimal "100", 9)
})

test_that("Trinary_112_is_decimal_14", {
    expect_equal(toDecimal "112", 14)
})

test_that("Trinary_222_is_decimal_26", {
    expect_equal(toDecimal "222", 26)
})

test_that("Trinary_1122000120_is_decimal_32091", {
    expect_equal(toDecimal "1122000120", 32091)
})

test_that("Invalid_trinary_digits_returns_0", {
    expect_equal(toDecimal "1234", 0)
})

test_that("Invalid_word_as_input_returns_0", {
    expect_equal(toDecimal "carrot", 0)
})

test_that("Invalid_numbers_with_letters_as_input_returns_0", {
    expect_equal(toDecimal "0a1b2c", 0)
})
