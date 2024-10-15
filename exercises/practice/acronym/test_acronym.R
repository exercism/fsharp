source("./acronym.R")
library(testthat)

test_that("Basic", {
    abbreviate "Portable Network Graphics" |> should equal "PNG"
})

test_that("Lowercase words", {
    abbreviate "Ruby on Rails" |> should equal "ROR"
})

test_that("Punctuation", {
    abbreviate "First In, First Out" |> should equal "FIFO"
})

test_that("All caps word", {
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"
})

test_that("Punctuation without whitespace", {
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"
})

test_that("Very long abbreviation", {
    abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" |> should equal "ROTFLSHTMDCOALM"
})

test_that("Consecutive delimiters", {
    abbreviate "Something - I made up from thin air" |> should equal "SIMUFTA"
})

test_that("Apostrophes", {
    abbreviate "Halley's Comet" |> should equal "HC"
})

test_that("Underscore emphasis", {
    abbreviate "The Road _Not_ Taken" |> should equal "TRNT"

