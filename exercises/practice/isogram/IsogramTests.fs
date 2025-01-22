source("./isogram.R")
library(testthat)

test_that("Empty string", {
    expect_true(isIsogram "")
})

test_that("Isogram with only lower case characters", {
    expect_true(isIsogram "isogram")
})

test_that("Word with one duplicated character", {
    expect_false(isIsogram "eleven")
})

test_that("Word with one duplicated character from the end of the alphabet", {
    expect_false(isIsogram "zzyzx")
})

test_that("Longest reported english isogram", {
    expect_true(isIsogram "subdermatoglyphic")
})

test_that("Word with duplicated character in mixed case", {
    expect_false(isIsogram "Alphabet")
})

test_that("Word with duplicated character in mixed case, lowercase first", {
    expect_false(isIsogram "alphAbet")
})

test_that("Hypothetical isogrammic word with hyphen", {
    expect_true(isIsogram "thumbscrew-japingly")
})

test_that("Hypothetical word with duplicated character following hyphen", {
    expect_false(isIsogram "thumbscrew-jappingly")
})

test_that("Isogram with duplicated hyphen", {
    expect_true(isIsogram "six-year-old")
})

test_that("Made-up name that is an isogram", {
    expect_true(isIsogram "Emily Jung Schwartzkopf")
})

test_that("Duplicated character in the middle", {
    expect_false(isIsogram "accentor")
})

test_that("Same first and last characters", {
    expect_false(isIsogram "angola")
})

test_that("Word with duplicated character and with two hyphens", {
    expect_false(isIsogram "up-to-date")
})
