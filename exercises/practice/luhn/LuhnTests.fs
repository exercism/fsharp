source("./luhn.R")
library(testthat)

test_that("Single digit strings can not be valid", {
    expect_false(valid "1")
})

test_that("A single zero is invalid", {
    expect_false(valid "0")
})

test_that("A simple valid SIN that remains valid if reversed", {
    expect_true(valid "059")
})

test_that("A simple valid SIN that becomes invalid if reversed", {
    expect_true(valid "59")
})

test_that("A valid Canadian SIN", {
    expect_true(valid "055 444 285")
})

test_that("Invalid Canadian SIN", {
    expect_false(valid "055 444 286")
})

test_that("Invalid credit card", {
    expect_false(valid "8273 1232 7352 0569")
})

test_that("Invalid long number with an even remainder", {
    expect_false(valid "1 2345 6789 1234 5678 9012")
})

test_that("Invalid long number with a remainder divisible by 5", {
    expect_false(valid "1 2345 6789 1234 5678 9013")
})

test_that("Valid number with an even number of digits", {
    expect_true(valid "095 245 88")
})

test_that("Valid number with an odd number of spaces", {
    expect_true(valid "234 567 891 234")
})

test_that("Valid strings with a non-digit added at the end become invalid", {
    expect_false(valid "059a")
})

test_that("Valid strings with punctuation included become invalid", {
    expect_false(valid "055-444-285")
})

test_that("Valid strings with symbols included become invalid", {
    expect_false(valid "055# 444$ 285")
})

test_that("Single zero with space is invalid", {
    expect_false(valid " 0")
})

test_that("More than a single zero is valid", {
    expect_true(valid "0000 0")
})

test_that("Input digit 9 is correctly converted to output digit 9", {
    expect_true(valid "091")
})

test_that("Very long input is valid", {
    expect_true(valid "9999999999 9999999999 9999999999 9999999999")
})

test_that("Valid luhn with an odd number of digits and non zero first digit", {
    expect_true(valid "109")
})

test_that("Using ascii value for non-doubled non-digit isn't allowed", {
    expect_false(valid "055b 444 285")
})

test_that("Using ascii value for doubled non-digit isn't allowed", {
    expect_false(valid ":9")
})

test_that("Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed", {
    expect_false(valid "59%59")
})
