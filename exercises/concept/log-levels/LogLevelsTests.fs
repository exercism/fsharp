source("./log-levels.R")
library(testthat)

[<Task(1)>]
    expect_equal(test_that("Error message", {

[<Task(1)>]
    expect_equal(test_that("Warning message", {

[<Task(1)>]
    expect_equal(test_that("Info message", {

[<Task(1)>]
test_that("Message with leading and trailing white space", {
    message "[WARNING]:   \tTimezone not set  \r\n"
    expect_equal( , "Timezone not set")

[<Task(2)>]
    expect_equal(test_that("Error log level", {

[<Task(2)>]
    expect_equal(test_that("Warning log level", {

[<Task(2)>]
    expect_equal(test_that("Info log level", {

[<Task(3)>]
    expect_equal(test_that("Error reformat", {

[<Task(3)>]
test_that("Warning reformat", {
    expect_equal(reformat "[WARNING]: Decreased performance", "Decreased performance (warning)")

[<Task(3)>]
    expect_equal(test_that("Info reformat", {

[<Task(3)>]
test_that("Reformat with leading and trailing white space", {
    reformat "[ERROR]: \t Corrupt disk\t \t \r\n"
    expect_equal( , "Corrupt disk (error)")
