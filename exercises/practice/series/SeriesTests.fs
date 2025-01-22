source("./series.R")
library(testthat)

test_that("Slices of one from one", {
    expect_equal(slices "1" 1, (Some ["1"]))

test_that("Slices of one from two", {
    expect_equal(slices "12" 1, (Some ["1"; "2"]))

test_that("Slices of two", {
    expect_equal(slices "35" 2, (Some ["35"]))

test_that("Slices of two overlap", {
    expect_equal(slices "9142" 2, (Some ["91"; "14"; "42"]))

test_that("Slices can include duplicates", {
    expect_equal(slices "777777" 3, (Some ["777"; "777"; "777"; "777"]))

test_that("Slices of a long series", {
    expect_equal(slices "918493904243" 5, (Some ["91849"; "18493"; "84939"; "49390"; "93904"; "39042"; "90424"; "04243"]))

test_that("Slice length is too large", {
    expect_equal(slices "12345" 6, None)

test_that("Slice length is way too large", {
    expect_equal(slices "12345" 42, None)

test_that("Slice length cannot be zero", {
    expect_equal(slices "12345" 0, None)

test_that("Slice length cannot be negative", {
    expect_equal(slices "123" -1, None)

test_that("Empty series is invalid", {
    expect_equal(slices "" 1, None)

