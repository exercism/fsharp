source("./acronym.R")
library(testthat)

test_that("Basic", {
    expect_equal(abbreviate "Portable Network Graphics", "PNG")

test_that("Lowercase words", {
    expect_equal(abbreviate "Ruby on Rails", "ROR")

test_that("Punctuation", {
    expect_equal(abbreviate "First In, First Out", "FIFO")

test_that("All caps word", {
    expect_equal(abbreviate "GNU Image Manipulation Program", "GIMP")

test_that("Punctuation without whitespace", {
    expect_equal(abbreviate "Complementary metal-oxide semiconductor", "CMOS")

test_that("Very long abbreviation", {
    expect_equal(abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me", "ROTFLSHTMDCOALM")

test_that("Consecutive delimiters", {
    expect_equal(abbreviate "Something - I made up from thin air", "SIMUFTA")

test_that("Apostrophes", {
    expect_equal(abbreviate "Halley's Comet", "HC")

test_that("Underscore emphasis", {
    expect_equal(abbreviate "The Road _Not_ Taken", "TRNT")

