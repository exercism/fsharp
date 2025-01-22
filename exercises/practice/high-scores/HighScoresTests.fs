source("./high-scores.R")
library(testthat)

test_that("List of scores", {
    expect_equal(scores [30; 50; 20; 70], [30; 50; 20; 70])

test_that("Latest score", {
    expect_equal(latest [100; 0; 90; 30], 30)

test_that("Personal best", {
    expect_equal(personalBest [40; 100; 70], 100)

test_that("Personal top three from a list of scores", {
    expect_equal(personalTopThree [10; 30; 90; 30; 100; 20; 10; 0; 30; 40; 40; 70; 70], [100; 90; 70])

test_that("Personal top highest to lowest", {
    expect_equal(personalTopThree [20; 10; 30], [30; 20; 10])

test_that("Personal top when there is a tie", {
    expect_equal(personalTopThree [40; 20; 40; 30], [40; 40; 30])

test_that("Personal top when there are less than 3", {
    expect_equal(personalTopThree [30; 70], [70; 30])

test_that("Personal top when there is only one", {
    expect_equal(personalTopThree [40], [40])

