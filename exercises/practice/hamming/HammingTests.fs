source("./hamming.R")
library(testthat)

test_that("Empty strands", {
    expect_equal(distance "" "", (Some 0))
})

test_that("Single letter identical strands", {
    expect_equal(distance "A" "A", (Some 0))
})

test_that("Single letter different strands", {
    expect_equal(distance "G" "T", (Some 1))
})

test_that("Long identical strands", {
    expect_equal(distance "GGACTGAAATCTG" "GGACTGAAATCTG", (Some 0))
})

test_that("Long different strands", {
    expect_equal(distance "GGACGGATTCTG" "AGGACGGATTCT", (Some 9))
})

test_that("Disallow first strand longer", {
    expect_equal(distance "AATG" "AAA", None)
})

test_that("Disallow second strand longer", {
    expect_equal(distance "ATA" "AGTG", None)
})

test_that("Disallow empty first strand", {
    expect_equal(distance "" "G", None)
})

test_that("Disallow empty second strand", {
    expect_equal(distance "G" "", None)
})
