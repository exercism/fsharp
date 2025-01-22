source("./killer-sudoku-helper.R")
library(testthat)

test_that("1", {
    expect_equal(combinations [] 1 1, [[1]])

test_that("2", {
    expect_equal(combinations [] 1 2, [[2]])

test_that("3", {
    expect_equal(combinations [] 1 3, [[3]])

test_that("4", {
    expect_equal(combinations [] 1 4, [[4]])

test_that("5", {
    expect_equal(combinations [] 1 5, [[5]])

test_that("6", {
    expect_equal(combinations [] 1 6, [[6]])

test_that("7", {
    expect_equal(combinations [] 1 7, [[7]])

test_that("8", {
    expect_equal(combinations [] 1 8, [[8]])

test_that("9", {
    expect_equal(combinations [] 1 9, [[9]])

test_that("Cage with sum 45 contains all digits 1:9", {
    expect_equal(combinations [] 9 45, [[1; 2; 3; 4; 5; 6; 7; 8; 9]])

test_that("Cage with only 1 possible combination", {
    expect_equal(combinations [] 3 7, [[1; 2; 4]])

test_that("Cage with several combinations", {
    expect_equal(combinations [] 2 10, [[1; 9]; [2; 8]; [3; 7]; [4; 6]])

test_that("Cage with several combinations that is restricted", {
    expect_equal(combinations [1; 4] 2 10, [[2; 8]; [3; 7]])

