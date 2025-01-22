source("./perfect-numbers.R")
library(testthat)

test_that("Smallest perfect number is classified correctly", {
    expect_equal(classify 6, (Some Classification.Perfect))

test_that("Medium perfect number is classified correctly", {
    expect_equal(classify 28, (Some Classification.Perfect))

test_that("Large perfect number is classified correctly", {
    expect_equal(classify 33550336, (Some Classification.Perfect))

test_that("Smallest abundant number is classified correctly", {
    expect_equal(classify 12, (Some Classification.Abundant))

test_that("Medium abundant number is classified correctly", {
    expect_equal(classify 30, (Some Classification.Abundant))

test_that("Large abundant number is classified correctly", {
    expect_equal(classify 33550335, (Some Classification.Abundant))

test_that("Smallest prime deficient number is classified correctly", {
    expect_equal(classify 2, (Some Classification.Deficient))

test_that("Smallest non-prime deficient number is classified correctly", {
    expect_equal(classify 4, (Some Classification.Deficient))

test_that("Medium deficient number is classified correctly", {
    expect_equal(classify 32, (Some Classification.Deficient))

test_that("Large deficient number is classified correctly", {
    expect_equal(classify 33550337, (Some Classification.Deficient))

test_that("Edge case (no factors other than itself) is classified correctly", {
    expect_equal(classify 1, (Some Classification.Deficient))

test_that("Zero is rejected (as it is not a positive integer)", {
    expect_equal(classify 0, None)

test_that("Negative integer is rejected (as it is not a positive integer)", {
    expect_equal(classify -1, None)

