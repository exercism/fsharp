source("./game-of-life.R")
library(testthat)

test_that("Empty matrix", {
    let matrix: int[,] = array2D []
    let expected: int[,] = array2D []
    expect_equal(tick matrix, expected)

test_that("Live cells with zero live neighbors die", {
    matrix <- 
        array2D [ [0; 0; 0];
                  [0; 1; 0];
                  [0; 0; 0] ]
    expected <- 
        array2D [ [0; 0; 0];
                  [0; 0; 0];
                  [0; 0; 0] ]
    expect_equal(tick matrix, expected)

test_that("Live cells with only one live neighbor die", {
    matrix <- 
        array2D [ [0; 0; 0];
                  [0; 1; 0];
                  [0; 1; 0] ]
    expected <- 
        array2D [ [0; 0; 0];
                  [0; 0; 0];
                  [0; 0; 0] ]
    expect_equal(tick matrix, expected)

test_that("Live cells with two live neighbors stay alive", {
    matrix <- 
        array2D [ [1; 0; 1];
                  [1; 0; 1];
                  [1; 0; 1] ]
    expected <- 
        array2D [ [0; 0; 0];
                  [1; 0; 1];
                  [0; 0; 0] ]
    expect_equal(tick matrix, expected)

test_that("Live cells with three live neighbors stay alive", {
    matrix <- 
        array2D [ [0; 1; 0];
                  [1; 0; 0];
                  [1; 1; 0] ]
    expected <- 
        array2D [ [0; 0; 0];
                  [1; 0; 0];
                  [1; 1; 0] ]
    expect_equal(tick matrix, expected)

test_that("Dead cells with three live neighbors become alive", {
    matrix <- 
        array2D [ [1; 1; 0];
                  [0; 0; 0];
                  [1; 0; 0] ]
    expected <- 
        array2D [ [0; 0; 0];
                  [1; 1; 0];
                  [0; 0; 0] ]
    expect_equal(tick matrix, expected)

test_that("Live cells with four or more neighbors die", {
    matrix <- 
        array2D [ [1; 1; 1];
                  [1; 1; 1];
                  [1; 1; 1] ]
    expected <- 
        array2D [ [1; 0; 1];
                  [0; 0; 0];
                  [1; 0; 1] ]
    expect_equal(tick matrix, expected)

test_that("Bigger matrix", {
    matrix <- 
        array2D [ [1; 1; 0; 1; 1; 0; 0; 0];
                  [1; 0; 1; 1; 0; 0; 0; 0];
                  [1; 1; 1; 0; 0; 1; 1; 1];
                  [0; 0; 0; 0; 0; 1; 1; 0];
                  [1; 0; 0; 0; 1; 1; 0; 0];
                  [1; 1; 0; 0; 0; 1; 1; 1];
                  [0; 0; 1; 0; 1; 0; 0; 1];
                  [1; 0; 0; 0; 0; 0; 1; 1] ]
    expected <- 
        array2D [ [1; 1; 0; 1; 1; 0; 0; 0];
                  [0; 0; 0; 0; 0; 1; 1; 0];
                  [1; 0; 1; 1; 1; 1; 0; 1];
                  [1; 0; 0; 0; 0; 0; 0; 1];
                  [1; 1; 0; 0; 1; 0; 0; 1];
                  [1; 1; 0; 1; 0; 0; 0; 1];
                  [1; 0; 0; 0; 0; 0; 0; 0];
                  [0; 0; 0; 0; 0; 0; 1; 1] ]
    expect_equal(tick matrix, expected)

