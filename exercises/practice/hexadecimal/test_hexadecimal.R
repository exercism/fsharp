source("./hexadecimal.R")
library(testthat)

test_that("Hexadecimal 1 is decimal 1", {
    toDecimal "1" |> should equal 1
})

test_that("Hexadecimal c is decimal 12", {
    toDecimal "c" |> should equal 12
})

test_that("Hexadecimal 10 is decimal 16", {
    toDecimal "10" |> should equal 16
})

test_that("Hexadecimal af is decimal 175", {
    toDecimal "af" |> should equal 175
})

test_that("Hexadecimal 100 is decimal 256", {
    toDecimal "100" |> should equal 256
})

test_that("Hexadecimal 19ace is decimal 105166", {
    toDecimal "19ace" |> should equal 105166
})

test_that("Hexadecimal 000000 is decimal 0", {
    toDecimal "000000" |> should equal 0
})

test_that("Hexadecimal ffffff is decimal 16777215", {
    toDecimal "ffffff" |> should equal 16777215
})

test_that("Hexadecimal ffff00 is decimal 16776960", {
    toDecimal "ffff00" |> should equal 16776960
})

test_that("Hexadecimal carrot is decimal 0", {
    toDecimal "carrot" |> should equal 0

