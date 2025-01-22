source("./wordy.R")
library(testthat)

test_that("Just a number", {
    expect_equal(answer "What is 5?", (Some 5))

test_that("Addition", {
    expect_equal(answer "What is 1 plus 1?", (Some 2))

test_that("More addition", {
    expect_equal(answer "What is 53 plus 2?", (Some 55))

test_that("Addition with negative numbers", {
    expect_equal(answer "What is -1 plus -10?", (Some -11))

test_that("Large addition", {
    expect_equal(answer "What is 123 plus 45678?", (Some 45801))

test_that("Subtraction", {
    expect_equal(answer "What is 4 minus -12?", (Some 16))

test_that("Multiplication", {
    expect_equal(answer "What is -3 multiplied by 25?", (Some -75))

test_that("Division", {
    expect_equal(answer "What is 33 divided by -3?", (Some -11))

test_that("Multiple additions", {
    expect_equal(answer "What is 1 plus 1 plus 1?", (Some 3))

test_that("Addition and subtraction", {
    expect_equal(answer "What is 1 plus 5 minus -2?", (Some 8))

test_that("Multiple subtraction", {
    expect_equal(answer "What is 20 minus 4 minus 13?", (Some 3))

test_that("Subtraction then addition", {
    expect_equal(answer "What is 17 minus 6 plus 3?", (Some 14))

test_that("Multiple multiplication", {
    expect_equal(answer "What is 2 multiplied by -2 multiplied by 3?", (Some -12))

test_that("Addition and multiplication", {
    expect_equal(answer "What is -3 plus 7 multiplied by -2?", (Some -8))

test_that("Multiple division", {
    expect_equal(answer "What is -12 divided by 2 divided by -3?", (Some 2))

test_that("Unknown operation", {
    expect_equal(answer "What is 52 cubed?", None)

test_that("Non math question", {
    expect_equal(answer "Who is the President of the United States?", None)

test_that("Reject problem missing an operand", {
    expect_equal(answer "What is 1 plus?", None)

test_that("Reject problem with no operands or operators", {
    expect_equal(answer "What is?", None)

test_that("Reject two operations in a row", {
    expect_equal(answer "What is 1 plus plus 2?", None)

test_that("Reject two numbers in a row", {
    expect_equal(answer "What is 1 plus 2 1?", None)

test_that("Reject postfix notation", {
    expect_equal(answer "What is 1 2 plus?", None)

test_that("Reject prefix notation", {
    expect_equal(answer "What is plus 1 2?", None)

