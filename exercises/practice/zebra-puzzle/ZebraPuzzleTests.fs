source("./zebra-puzzle.R")
library(testthat)

test_that("Resident who drinks water", {
    expect_equal(drinksWater, Norwegian)
})

test_that("Resident who owns zebra", {
    expect_equal(ownsZebra, Japanese)
})
