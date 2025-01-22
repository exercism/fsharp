source("./rotational-cipher.R")
library(testthat)

test_that("Rotate a by 0, same output as input", {
    expect_equal(rotate 0 "a", "a")

test_that("Rotate a by 1", {
    expect_equal(rotate 1 "a", "b")

test_that("Rotate a by 26, same output as input", {
    expect_equal(rotate 26 "a", "a")

test_that("Rotate m by 13", {
    expect_equal(rotate 13 "m", "z")

test_that("Rotate n by 13 with wrap around alphabet", {
    expect_equal(rotate 13 "n", "a")

test_that("Rotate capital letters", {
    expect_equal(rotate 5 "OMG", "TRL")

test_that("Rotate spaces", {
    expect_equal(rotate 5 "O M G", "T R L")

test_that("Rotate numbers", {
    expect_equal(rotate 4 "Testing 1 2 3 testing", "Xiwxmrk 1 2 3 xiwxmrk")

test_that("Rotate punctuation", {
    expect_equal(rotate 21 "Let's eat, Grandma!", "Gzo'n zvo, Bmviyhv!")

test_that("Rotate all letters", {
    expect_equal(rotate 13 "The quick brown fox jumps over the lazy dog.", "Gur dhvpx oebja sbk whzcf bire gur ynml qbt.")

