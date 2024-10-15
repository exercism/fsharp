source("./isogram.R")
library(testthat)

test_that("Empty string", {
  expect_equal(isIsogram "", TRUE)
})

test_that("Isogram with only lower case characters", {
  expect_equal(isIsogram "isogram", TRUE)
})

test_that("Word with one duplicated character", {
  expect_equal(isIsogram "eleven", FALSE)
})

test_that("Word with one duplicated character from the end of the alphabet", {
  expect_equal(isIsogram "zzyzx", FALSE)
})

test_that("Longest reported english isogram", {
  expect_equal(isIsogram "subdermatoglyphic", TRUE)
})

test_that("Word with duplicated character in mixed case", {
  expect_equal(isIsogram "Alphabet", FALSE)
})

test_that("Word with duplicated character in mixed case, lowercase first", {
  expect_equal(isIsogram "alphAbet", FALSE)
})

test_that("Hypothetical isogrammic word with hyphen", {
  expect_equal(isIsogram "thumbscrew-japingly", TRUE)
})

test_that("Hypothetical word with duplicated character following hyphen", {
  expect_equal(isIsogram "thumbscrew-jappingly", FALSE)
})

test_that("Isogram with duplicated hyphen", {
  expect_equal(isIsogram "six-year-old", TRUE)
})

test_that("Made-up name that is an isogram", {
  expect_equal(isIsogram "Emily Jung Schwartzkopf", TRUE)
})

test_that("Duplicated character in the middle", {
  expect_equal(isIsogram "accentor", FALSE)
})

test_that("Same first and last characters", {
  expect_equal(isIsogram "angola", FALSE)
})

test_that("Word with duplicated character and with two hyphens", {
  expect_equal(isIsogram "up-to-date", FALSE)

