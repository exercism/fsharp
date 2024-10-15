source("./armstrong-numbers.R")
library(testthat)

test_that("Zero is an Armstrong number", {
    isArmstrongNumber 0 |> should equal true
})

test_that("Single-digit numbers are Armstrong numbers", {
    isArmstrongNumber 5 |> should equal true
})

test_that("There are no two-digit Armstrong numbers", {
    isArmstrongNumber 10 |> should equal false
})

test_that("Three-digit number that is an Armstrong number", {
    isArmstrongNumber 153 |> should equal true
})

test_that("Three-digit number that is not an Armstrong number", {
    isArmstrongNumber 100 |> should equal false
})

test_that("Four-digit number that is an Armstrong number", {
    isArmstrongNumber 9474 |> should equal true
})

test_that("Four-digit number that is not an Armstrong number", {
    isArmstrongNumber 9475 |> should equal false
})

test_that("Seven-digit number that is an Armstrong number", {
    isArmstrongNumber 9926315 |> should equal true
})

test_that("Seven-digit number that is not an Armstrong number", {
    isArmstrongNumber 9926314 |> should equal false

