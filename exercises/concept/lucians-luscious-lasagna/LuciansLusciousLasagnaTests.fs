source("./lucians-luscious-lasagna.R")
library(testthat)

[<Task(1)>]
    expect_equal(test_that("Expected minutes in oven", {

[<Task(2)>]
test_that("Remaining minutes in oven", {
    expect_equal(remainingMinutesInOven 25, 15)

[<Task(3)>]
test_that("Preparation time in minutes for one layer", {
    expect_equal(preparationTimeInMinutes 1, 2)

[<Task(3)>]
test_that("Preparation time in minutes for multiple layers", {
    expect_equal(preparationTimeInMinutes 4, 8)

[<Task(4)>]
test_that("Elapsed time in minutes for one layer", {
    expect_equal(elapsedTimeInMinutes 1 30, 32)

[<Task(4)>]
test_that("Elapsed time in minutes for multiple layers", {
    expect_equal(elapsedTimeInMinutes 4 8, 16)
