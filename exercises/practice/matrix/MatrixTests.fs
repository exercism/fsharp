source("./matrix.R")
library(testthat)

test_that("Extract row from one number matrix", {
    expect_equal(row 1 "1", [1])

test_that("Can extract row", {
    expect_equal(row 2 "1 2\n3 4", [3; 4])

test_that("Extract row where numbers have different widths", {
    expect_equal(row 2 "1 2\n10 20", [10; 20])

test_that("Can extract row from non-square matrix with no corresponding column", {
    expect_equal(row 4 "1 2 3\n4 5 6\n7 8 9\n8 7 6", [8; 7; 6])

test_that("Extract column from one number matrix", {
    expect_equal(column 1 "1", [1])

test_that("Can extract column", {
    expect_equal(column 3 "1 2 3\n4 5 6\n7 8 9", [3; 6; 9])

test_that("Can extract column from non-square matrix with no corresponding row", {
    expect_equal(column 4 "1 2 3 4\n5 6 7 8\n9 8 7 6", [4; 8; 6])

test_that("Extract column where numbers have different widths", {
    expect_equal(column 2 "89 1903 3\n18 3 1\n9 4 800", [1903; 3; 4])

