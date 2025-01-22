source("./isogram.R")
library(testthat)

test_that("Empty string", {
    expect_equal(isIsogram "", true)
})

test_that("Isogram with only lower case characters", {
    expect_equal(isIsogram "isogram", true)
})

test_that("Word with one duplicated character", {
    expect_equal(isIsogram "eleven", false)
})

test_that("Word with one duplicated character from the end of the alphabet", {
    expect_equal(isIsogram "zzyzx", false)
})

test_that("Longest reported english isogram", {
    expect_equal(isIsogram "subdermatoglyphic", true)
})

test_that("Word with duplicated character in mixed case", {
    expect_equal(isIsogram "Alphabet", false)
})

test_that("Word with duplicated character in mixed case, lowercase first", {
    expect_equal(isIsogram "alphAbet", false)
})

test_that("Hypothetical isogrammic word with hyphen", {
    expect_equal(isIsogram "thumbscrew-japingly", true)
})

test_that("Hypothetical word with duplicated character following hyphen", {
    expect_equal(isIsogram "thumbscrew-jappingly", false)
})

test_that("Isogram with duplicated hyphen", {
    expect_equal(isIsogram "six-year-old", true)
})

test_that("Made-up name that is an isogram", {
    expect_equal(isIsogram "Emily Jung Schwartzkopf", true)
})

test_that("Duplicated character in the middle", {
    expect_equal(isIsogram "accentor", false)
})

test_that("Same first and last characters", {
    expect_equal(isIsogram "angola", false)
})

test_that("Word with duplicated character and with two hyphens", {
    expect_equal(isIsogram "up-to-date", false)
})
