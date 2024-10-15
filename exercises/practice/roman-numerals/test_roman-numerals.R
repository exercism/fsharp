source("./roman-numerals.R")
library(testthat)

test_that("1 is I", {
    roman 1 |> should equal "I"
})

test_that("2 is II", {
    roman 2 |> should equal "II"
})

test_that("3 is III", {
    roman 3 |> should equal "III"
})

test_that("4 is IV", {
    roman 4 |> should equal "IV"
})

test_that("5 is V", {
    roman 5 |> should equal "V"
})

test_that("6 is VI", {
    roman 6 |> should equal "VI"
})

test_that("9 is IX", {
    roman 9 |> should equal "IX"
})

test_that("16 is XVI", {
    roman 16 |> should equal "XVI"
})

test_that("27 is XXVII", {
    roman 27 |> should equal "XXVII"
})

test_that("48 is XLVIII", {
    roman 48 |> should equal "XLVIII"
})

test_that("49 is XLIX", {
    roman 49 |> should equal "XLIX"
})

test_that("59 is LIX", {
    roman 59 |> should equal "LIX"
})

test_that("66 is LXVI", {
    roman 66 |> should equal "LXVI"
})

test_that("93 is XCIII", {
    roman 93 |> should equal "XCIII"
})

test_that("141 is CXLI", {
    roman 141 |> should equal "CXLI"
})

test_that("163 is CLXIII", {
    roman 163 |> should equal "CLXIII"
})

test_that("166 is CLXVI", {
    roman 166 |> should equal "CLXVI"
})

test_that("402 is CDII", {
    roman 402 |> should equal "CDII"
})

test_that("575 is DLXXV", {
    roman 575 |> should equal "DLXXV"
})

test_that("666 is DCLXVI", {
    roman 666 |> should equal "DCLXVI"
})

test_that("911 is CMXI", {
    roman 911 |> should equal "CMXI"
})

test_that("1024 is MXXIV", {
    roman 1024 |> should equal "MXXIV"
})

test_that("1666 is MDCLXVI", {
    roman 1666 |> should equal "MDCLXVI"
})

test_that("3000 is MMM", {
    roman 3000 |> should equal "MMM"
})

test_that("3001 is MMMI", {
    roman 3001 |> should equal "MMMI"
})

test_that("3999 is MMMCMXCIX", {
    roman 3999 |> should equal "MMMCMXCIX"

