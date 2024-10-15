source("./transpose.R")
library(testthat)

test_that("Empty string", {
  lines <- c()
  expected <- c()
  expect_equal(transpose lines, expected)
})

test_that("Two characters in a row", {
  lines <- c("A1")
  expected <- 
        c( "A",
          "1" )
  expect_equal(transpose lines, expected)
})

test_that("Two characters in a column", {
  lines <- 
        c( "A",
          "1" )
  expected <- c("A1")
  expect_equal(transpose lines, expected)
})

test_that("Simple", {
  lines <- 
        c( "ABC",
          "123" )
  expected <- 
        c( "A1",
          "B2",
          "C3" )
  expect_equal(transpose lines, expected)
})

test_that("Single line", {
  lines <- c("Single line.")
  expected <- 
        c( "S",
          "i",
          "n",
          "g",
          "l",
          "e",
          " ",
          "l",
          "i",
          "n",
          "e",
          "." )
  expect_equal(transpose lines, expected)
})

test_that("First line longer than second line", {
  lines <- 
        c( "The fourth line.",
          "The fifth line." )
  expected <- 
        c( "TT",
          "hh",
          "ee",
          "  ",
          "ff",
          "oi",
          "uf",
          "rt",
          "th",
          "h ",
          " l",
          "li",
          "in",
          "ne",
          "e.",
          "." )
  expect_equal(transpose lines, expected)
})

test_that("Second line longer than first line", {
  lines <- 
        c( "The first line.",
          "The second line." )
  expected <- 
        c( "TT",
          "hh",
          "ee",
          "  ",
          "fs",
          "ie",
          "rc",
          "so",
          "tn",
          " d",
          "l ",
          "il",
          "ni",
          "en",
          ".e",
          " ." )
  expect_equal(transpose lines, expected)
})

test_that("Mixed line length", {
  lines <- 
        c( "The longest line.",
          "A long line.",
          "A longer line.",
          "A line." )
  expected <- 
        c( "TAAA",
          "h   ",
          "elll",
          " ooi",
          "lnnn",
          "ogge",
          "n e.",
          "glr",
          "ei ",
          "snl",
          "tei",
          " .n",
          "l e",
          "i .",
          "n",
          "e",
          "." )
  expect_equal(transpose lines, expected)
})

test_that("Square", {
  lines <- 
        c( "HEART",
          "EMBER",
          "ABUSE",
          "RESIN",
          "TREND" )
  expected <- 
        c( "HEART",
          "EMBER",
          "ABUSE",
          "RESIN",
          "TREND" )
  expect_equal(transpose lines, expected)
})

test_that("Rectangle", {
  lines <- 
        c( "FRACTURE",
          "OUTLINED",
          "BLOOMING",
          "SEPTETTE" )
  expected <- 
        c( "FOBS",
          "RULE",
          "ATOP",
          "CLOT",
          "TIME",
          "UNIT",
          "RENT",
          "EDGE" )
  expect_equal(transpose lines, expected)
})

test_that("Triangle", {
  lines <- 
        c( "T",
          "EE",
          "AAA",
          "SSSS",
          "EEEEE",
          "RRRRRR" )
  expected <- 
        c( "TEASER",
          " EASER",
          "  ASER",
          "   SER",
          "    ER",
          "     R" )
  expect_equal(transpose lines, expected)
})

test_that("Jagged triangle", {
  lines <- 
        c( "11",
          "2",
          "3333",
          "444",
          "555555",
          "66666" )
  expected <- 
        c( "123456",
          "1 3456",
          "  3456",
          "  3 56",
          "    56",
          "    5" )
  expect_equal(transpose lines, expected)
})