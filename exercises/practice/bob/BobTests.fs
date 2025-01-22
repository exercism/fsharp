source("./bob.R")
library(testthat)

test_that("Stating something", {
    expect_equal(response "Tom-ay-to, tom-aaaah-to.", "Whatever.")

test_that("Shouting", {
    expect_equal(response "WATCH OUT!", "Whoa, chill out!")

test_that("Shouting gibberish", {
    expect_equal(response "FCECDFCAAB", "Whoa, chill out!")

test_that("Asking a question", {
    expect_equal(response "Does this cryogenic chamber make me look fat?", "Sure.")

test_that("Asking a numeric question", {
    expect_equal(response "You are, what, like 15?", "Sure.")

test_that("Asking gibberish", {
    expect_equal(response "fffbbcbeab?", "Sure.")

test_that("Talking forcefully", {
    expect_equal(response "Hi there!", "Whatever.")

test_that("Using acronyms in regular speech", {
    expect_equal(response "It's OK if you don't want to go work for NASA.", "Whatever.")

test_that("Forceful question", {
    expect_equal(response "WHAT'S GOING ON?", "Calm down, I know what I'm doing!")

test_that("Shouting numbers", {
    expect_equal(response "1, 2, 3 GO!", "Whoa, chill out!")

test_that("No letters", {
    expect_equal(response "1, 2, 3", "Whatever.")

test_that("Question with no letters", {
    expect_equal(response "4?", "Sure.")

test_that("Shouting with special characters", {
    expect_equal(response "ZOMG THE %^*@#$(*^ ZOMBIES ARE COMING!!11!!1!", "Whoa, chill out!")

test_that("Shouting with no exclamation mark", {
    expect_equal(response "I HATE THE DENTIST", "Whoa, chill out!")

test_that("Statement containing question mark", {
    expect_equal(response "Ending with ? means a question.", "Whatever.")

test_that("Non-letters with question", {
    expect_equal(response ":) ?", "Sure.")

test_that("Prattling on", {
    expect_equal(response "Wait! Hang on. Are you going to be OK?", "Sure.")

test_that("Silence", {
    expect_equal(response "", "Fine. Be that way!")

test_that("Prolonged silence", {
    expect_equal(response "          ", "Fine. Be that way!")

test_that("Alternate silence", {
    expect_equal(response "\t\t\t\t\t\t\t\t\t\t", "Fine. Be that way!")

test_that("Multiple line question", {
    expect_equal(response "\nDoes this cryogenic chamber make me look fat?\nNo.", "Whatever.")

test_that("Starting with whitespace", {
    expect_equal(response "         hmmmmmmm...", "Whatever.")

test_that("Ending with whitespace", {
    expect_equal(response "Okay if like my  spacebar  quite a bit?   ", "Sure.")

test_that("Other whitespace", {
    expect_equal(response "\n\r \t", "Fine. Be that way!")

test_that("Non-question ending with whitespace", {
    expect_equal(response "This is a statement ending with whitespace      ", "Whatever.")

