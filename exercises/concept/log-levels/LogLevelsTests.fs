source("./log-levels.R")
library(testthat)

    expect_equal(test_that("Error message", {

    expect_equal(test_that("Warning message", {

    expect_equal(test_that("Info message", {

test_that("Message with leading and trailing white space", {
    message "c(WARNING):   \tTimezone not set  \r\n"
    expect_equal( , "Timezone not set")

    expect_equal(test_that("Error log level", {

    expect_equal(test_that("Warning log level", {

    expect_equal(test_that("Info log level", {

    expect_equal(test_that("Error reformat", {

test_that("Warning reformat", {
    expect_equal(reformat "c(WARNING): Decreased performance", "Decreased performance (warning)")

    expect_equal(test_that("Info reformat", {

test_that("Reformat with leading and trailing white space", {
    reformat "c(ERROR): \t Corrupt disk\t \t \r\n"
    expect_equal( , "Corrupt disk (error)")
