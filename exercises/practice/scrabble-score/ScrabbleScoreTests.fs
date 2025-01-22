source("./scrabble-score.R")
library(testthat)

test_that("Lowercase letter", {
    expect_equal(score "a", 1)

test_that("Uppercase letter", {
    expect_equal(score "A", 1)

test_that("Valuable letter", {
    expect_equal(score "f", 4)

test_that("Short word", {
    expect_equal(score "at", 2)

test_that("Short, valuable word", {
    expect_equal(score "zoo", 12)

test_that("Medium word", {
    expect_equal(score "street", 6)

test_that("Medium, valuable word", {
    expect_equal(score "quirky", 22)

test_that("Long, mixed-case word", {
    expect_equal(score "OxyphenButazone", 41)

test_that("English-like word", {
    expect_equal(score "pinata", 8)

test_that("Empty input", {
    expect_equal(score "", 0)

test_that("Entire alphabet available", {
    expect_equal(score "abcdefghijklmnopqrstuvwxyz", 87)

