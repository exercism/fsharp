source("./roman-numerals.R")
library(testthat)

test_that("1 is I", {
    expect_equal(roman 1, "I")

test_that("2 is II", {
    expect_equal(roman 2, "II")

test_that("3 is III", {
    expect_equal(roman 3, "III")

test_that("4 is IV", {
    expect_equal(roman 4, "IV")

test_that("5 is V", {
    expect_equal(roman 5, "V")

test_that("6 is VI", {
    expect_equal(roman 6, "VI")

test_that("9 is IX", {
    expect_equal(roman 9, "IX")

test_that("16 is XVI", {
    expect_equal(roman 16, "XVI")

test_that("27 is XXVII", {
    expect_equal(roman 27, "XXVII")

test_that("48 is XLVIII", {
    expect_equal(roman 48, "XLVIII")

test_that("49 is XLIX", {
    expect_equal(roman 49, "XLIX")

test_that("59 is LIX", {
    expect_equal(roman 59, "LIX")

test_that("66 is LXVI", {
    expect_equal(roman 66, "LXVI")

test_that("93 is XCIII", {
    expect_equal(roman 93, "XCIII")

test_that("141 is CXLI", {
    expect_equal(roman 141, "CXLI")

test_that("163 is CLXIII", {
    expect_equal(roman 163, "CLXIII")

test_that("166 is CLXVI", {
    expect_equal(roman 166, "CLXVI")

test_that("402 is CDII", {
    expect_equal(roman 402, "CDII")

test_that("575 is DLXXV", {
    expect_equal(roman 575, "DLXXV")

test_that("666 is DCLXVI", {
    expect_equal(roman 666, "DCLXVI")

test_that("911 is CMXI", {
    expect_equal(roman 911, "CMXI")

test_that("1024 is MXXIV", {
    expect_equal(roman 1024, "MXXIV")

test_that("1666 is MDCLXVI", {
    expect_equal(roman 1666, "MDCLXVI")

test_that("3000 is MMM", {
    expect_equal(roman 3000, "MMM")

test_that("3001 is MMMI", {
    expect_equal(roman 3001, "MMMI")

test_that("3999 is MMMCMXCIX", {
    expect_equal(roman 3999, "MMMCMXCIX")

