source("./isogram.R")
library(testthat)

test_that("Empty string", {
    isIsogram "" |> should equal true
})

test_that("Isogram with only lower case characters", {
    isIsogram "isogram" |> should equal true
})

test_that("Word with one duplicated character", {
    isIsogram "eleven" |> should equal false
})

test_that("Word with one duplicated character from the end of the alphabet", {
    isIsogram "zzyzx" |> should equal false
})

test_that("Longest reported english isogram", {
    isIsogram "subdermatoglyphic" |> should equal true
})

test_that("Word with duplicated character in mixed case", {
    isIsogram "Alphabet" |> should equal false
})

test_that("Word with duplicated character in mixed case, lowercase first", {
    isIsogram "alphAbet" |> should equal false
})

test_that("Hypothetical isogrammic word with hyphen", {
    isIsogram "thumbscrew-japingly" |> should equal true
})

test_that("Hypothetical word with duplicated character following hyphen", {
    isIsogram "thumbscrew-jappingly" |> should equal false
})

test_that("Isogram with duplicated hyphen", {
    isIsogram "six-year-old" |> should equal true
})

test_that("Made-up name that is an isogram", {
    isIsogram "Emily Jung Schwartzkopf" |> should equal true
})

test_that("Duplicated character in the middle", {
    isIsogram "accentor" |> should equal false
})

test_that("Same first and last characters", {
    isIsogram "angola" |> should equal false
})

test_that("Word with duplicated character and with two hyphens", {
    isIsogram "up-to-date" |> should equal false

