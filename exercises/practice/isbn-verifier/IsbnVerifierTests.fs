source("./isbn-verifier.R")
library(testthat)

test_that("Valid isbn", {
    expect_true(isValid "3-598-21508-8")
})

test_that("Invalid isbn check digit", {
    expect_false(isValid "3-598-21508-9")
})

test_that("Valid isbn with a check digit of 10", {
    expect_true(isValid "3-598-21507-X")
})

test_that("Check digit is a character other than X", {
    expect_false(isValid "3-598-21507-A")
})

test_that("Invalid check digit in isbn is not treated as zero", {
    expect_false(isValid "4-598-21507-B")
})

test_that("Invalid character in isbn is not treated as zero", {
    expect_false(isValid "3-598-P1581-X")
})

test_that("X is only valid as a check digit", {
    expect_false(isValid "3-598-2X507-9")
})

test_that("Valid isbn without separating dashes", {
    expect_true(isValid "3598215088")
})

test_that("Isbn without separating dashes and X as check digit", {
    expect_true(isValid "359821507X")
})

test_that("Isbn without check digit and dashes", {
    expect_false(isValid "359821507")
})

test_that("Too long isbn and no dashes", {
    expect_false(isValid "3598215078X")
})

test_that("Too short isbn", {
    expect_false(isValid "00")
})

test_that("Isbn without check digit", {
    expect_false(isValid "3-598-21507")
})

test_that("Check digit of X should not be used for 0", {
    expect_false(isValid "3-598-21515-X")
})

test_that("Empty isbn", {
    expect_false(isValid "")
})

test_that("Input is 9 characters", {
    expect_false(isValid "134456729")
})

test_that("Invalid characters are not ignored after checking length", {
    expect_false(isValid "3132P34035")
})

test_that("Invalid characters are not ignored before checking length", {
    expect_false(isValid "3598P215088")
})

test_that("Input is too long but contains a valid isbn", {
    expect_false(isValid "98245726788")
})
