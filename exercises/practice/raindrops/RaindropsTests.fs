source("./raindrops.R")
library(testthat)

test_that("The sound for 1 is 1", {
    expect_equal(convert 1, "1")
})

test_that("The sound for 3 is Pling", {
    expect_equal(convert 3, "Pling")
})

test_that("The sound for 5 is Plang", {
    expect_equal(convert 5, "Plang")
})

test_that("The sound for 7 is Plong", {
    expect_equal(convert 7, "Plong")
})

test_that("The sound for 6 is Pling as it has a factor 3", {
    expect_equal(convert 6, "Pling")
})

test_that("2 to the power 3 does not make a raindrop sound as 3 is the exponent not the base", {
    expect_equal(convert 8, "8")
})

test_that("The sound for 9 is Pling as it has a factor 3", {
    expect_equal(convert 9, "Pling")
})

test_that("The sound for 10 is Plang as it has a factor 5", {
    expect_equal(convert 10, "Plang")
})

test_that("The sound for 14 is Plong as it has a factor of 7", {
    expect_equal(convert 14, "Plong")
})

test_that("The sound for 15 is PlingPlang as it has factors 3 and 5", {
    expect_equal(convert 15, "PlingPlang")
})

test_that("The sound for 21 is PlingPlong as it has factors 3 and 7", {
    expect_equal(convert 21, "PlingPlong")
})

test_that("The sound for 25 is Plang as it has a factor 5", {
    expect_equal(convert 25, "Plang")
})

test_that("The sound for 27 is Pling as it has a factor 3", {
    expect_equal(convert 27, "Pling")
})

test_that("The sound for 35 is PlangPlong as it has factors 5 and 7", {
    expect_equal(convert 35, "PlangPlong")
})

test_that("The sound for 49 is Plong as it has a factor 7", {
    expect_equal(convert 49, "Plong")
})

test_that("The sound for 52 is 52", {
    expect_equal(convert 52, "52")
})

test_that("The sound for 105 is PlingPlangPlong as it has factors 3, 5 and 7", {
    expect_equal(convert 105, "PlingPlangPlong")
})

test_that("The sound for 3125 is Plang as it has a factor 5", {
    expect_equal(convert 3125, "Plang")
})
