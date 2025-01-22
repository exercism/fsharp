source("./luhn.R")
library(testthat)

test_that("Single digit strings can not be valid", {
    expect_equal(valid "1", false)
})

test_that("A single zero is invalid", {
    expect_equal(valid "0", false)
})

test_that("A simple valid SIN that remains valid if reversed", {
    expect_equal(valid "059", true)
})

test_that("A simple valid SIN that becomes invalid if reversed", {
    expect_equal(valid "59", true)
})

test_that("A valid Canadian SIN", {
    expect_equal(valid "055 444 285", true)
})

test_that("Invalid Canadian SIN", {
    expect_equal(valid "055 444 286", false)
})

test_that("Invalid credit card", {
    expect_equal(valid "8273 1232 7352 0569", false)
})

test_that("Invalid long number with an even remainder", {
    expect_equal(valid "1 2345 6789 1234 5678 9012", false)
})

test_that("Invalid long number with a remainder divisible by 5", {
    expect_equal(valid "1 2345 6789 1234 5678 9013", false)
})

test_that("Valid number with an even number of digits", {
    expect_equal(valid "095 245 88", true)
})

test_that("Valid number with an odd number of spaces", {
    expect_equal(valid "234 567 891 234", true)
})

test_that("Valid strings with a non-digit added at the end become invalid", {
    expect_equal(valid "059a", false)
})

test_that("Valid strings with punctuation included become invalid", {
    expect_equal(valid "055-444-285", false)
})

test_that("Valid strings with symbols included become invalid", {
    expect_equal(valid "055# 444$ 285", false)
})

test_that("Single zero with space is invalid", {
    expect_equal(valid " 0", false)
})

test_that("More than a single zero is valid", {
    expect_equal(valid "0000 0", true)
})

test_that("Input digit 9 is correctly converted to output digit 9", {
    expect_equal(valid "091", true)
})

test_that("Very long input is valid", {
    expect_equal(valid "9999999999 9999999999 9999999999 9999999999", true)
})

test_that("Valid luhn with an odd number of digits and non zero first digit", {
    expect_equal(valid "109", true)
})

test_that("Using ascii value for non-doubled non-digit isn't allowed", {
    expect_equal(valid "055b 444 285", false)
})

test_that("Using ascii value for doubled non-digit isn't allowed", {
    expect_equal(valid ":9", false)
})

test_that("Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed", {
    expect_equal(valid "59%59", false)
})
