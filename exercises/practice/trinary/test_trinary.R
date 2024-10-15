source("./trinary.R")
library(testthat)

test_that("Trinary_1_is_decimal_1", {
    toDecimal "1" |> should equal 1
})

test_that("Trinary_2_is_decimal_2", {
    toDecimal "2" |> should equal 2
})

test_that("Trinary_10_is_decimal_3", {
    toDecimal "10" |> should equal 3
})

test_that("Trinary_11_is_decimal_4", {
    toDecimal "11" |> should equal 4
})

test_that("Trinary_100_is_decimal_9", {
    toDecimal "100" |> should equal 9
})

test_that("Trinary_112_is_decimal_14", {
    toDecimal "112" |> should equal 14
})

test_that("Trinary_222_is_decimal_26", {
    toDecimal "222" |> should equal 26
})

test_that("Trinary_1122000120_is_decimal_32091", {
    toDecimal "1122000120" |> should equal 32091
})

test_that("Invalid_trinary_digits_returns_0", {
    toDecimal "1234" |> should equal 0
})

test_that("Invalid_word_as_input_returns_0", {
    toDecimal "carrot" |> should equal 0
})

test_that("Invalid_numbers_with_letters_as_input_returns_0", {
    toDecimal "0a1b2c" |> should equal 0

