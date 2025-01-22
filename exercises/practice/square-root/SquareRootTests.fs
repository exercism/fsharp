source("./square-root.R")
library(testthat)

test_that("Root of 1", {
    expect_equal(squareRoot 1, 1)

test_that("Root of 4", {
    expect_equal(squareRoot 4, 2)

test_that("Root of 25", {
    expect_equal(squareRoot 25, 5)

test_that("Root of 81", {
    expect_equal(squareRoot 81, 9)

test_that("Root of 196", {
    expect_equal(squareRoot 196, 14)

test_that("Root of 65025", {
    expect_equal(squareRoot 65025, 255)

