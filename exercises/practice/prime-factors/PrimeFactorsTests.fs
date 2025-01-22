source("./prime-factors.R")
library(testthat)

test_that("No factors", {
    factors 1L |> should be Empty

test_that("Prime number", {
    expect_equal(factors 2L, [2])

test_that("Another prime number", {
    expect_equal(factors 3L, [3])

test_that("Square of a prime", {
    expect_equal(factors 9L, [3; 3])

test_that("Product of first prime", {
    expect_equal(factors 4L, [2; 2])

test_that("Cube of a prime", {
    expect_equal(factors 8L, [2; 2; 2])

test_that("Product of second prime", {
    expect_equal(factors 27L, [3; 3; 3])

test_that("Product of third prime", {
    expect_equal(factors 625L, [5; 5; 5; 5])

test_that("Product of first and second prime", {
    expect_equal(factors 6L, [2; 3])

test_that("Product of primes and non-primes", {
    expect_equal(factors 12L, [2; 2; 3])

test_that("Product of primes", {
    expect_equal(factors 901255L, [5; 17; 23; 461])

test_that("Factors include a large prime", {
    expect_equal(factors 93819012551L, [11; 9539; 894119])

