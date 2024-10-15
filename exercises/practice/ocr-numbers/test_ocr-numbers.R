source("./ocr-numbers.R")
library(testthat)

test_that("Recognizes 0", {
    let rows = 
        c( " _ ",
          "| |",
          "|_|",
          "   " )
  expect_equal(convert rows, (Some "0"))
})

test_that("Recognizes 1", {
    let rows = 
        c( "   ",
          "  |",
          "  |",
          "   " )
  expect_equal(convert rows, (Some "1"))
})

test_that("Unreadable but correctly sized inputs return ?", {
    let rows = 
        c( "   ",
          "  _",
          "  |",
          "   " )
  expect_equal(convert rows, (Some "?"))
})

test_that("Input with a number of lines that is not a multiple of four raises an error", {
    let rows = 
        c( " _ ",
          "| |",
          "   " )
  expect_equal(convert rows, None)
})

test_that("Input with a number of columns that is not a multiple of three raises an error", {
    let rows = 
        c( "    ",
          "   |",
          "   |",
          "    " )
  expect_equal(convert rows, None)
})

test_that("Recognizes 110101100", {
    let rows = 
        c( "       _     _        _  _ ",
          "  |  || |  || |  |  || || |",
          "  |  ||_|  ||_|  |  ||_||_|",
          "                           " )
  expect_equal(convert rows, (Some "110101100"))
})

test_that("Garbled numbers in a string are replaced with ?", {
    let rows = 
        c( "       _     _           _ ",
          "  |  || |  || |     || || |",
          "  |  | _|  ||_|  |  ||_||_|",
          "                           " )
  expect_equal(convert rows, (Some "11?10?1?0"))
})

test_that("Recognizes 2", {
    let rows = 
        c( " _ ",
          " _|",
          "|_ ",
          "   " )
  expect_equal(convert rows, (Some "2"))
})

test_that("Recognizes 3", {
    let rows = 
        c( " _ ",
          " _|",
          " _|",
          "   " )
  expect_equal(convert rows, (Some "3"))
})

test_that("Recognizes 4", {
    let rows = 
        c( "   ",
          "|_|",
          "  |",
          "   " )
  expect_equal(convert rows, (Some "4"))
})

test_that("Recognizes 5", {
    let rows = 
        c( " _ ",
          "|_ ",
          " _|",
          "   " )
  expect_equal(convert rows, (Some "5"))
})

test_that("Recognizes 6", {
    let rows = 
        c( " _ ",
          "|_ ",
          "|_|",
          "   " )
  expect_equal(convert rows, (Some "6"))
})

test_that("Recognizes 7", {
    let rows = 
        c( " _ ",
          "  |",
          "  |",
          "   " )
  expect_equal(convert rows, (Some "7"))
})

test_that("Recognizes 8", {
    let rows = 
        c( " _ ",
          "|_|",
          "|_|",
          "   " )
  expect_equal(convert rows, (Some "8"))
})

test_that("Recognizes 9", {
    let rows = 
        c( " _ ",
          "|_|",
          " _|",
          "   " )
  expect_equal(convert rows, (Some "9"))
})

test_that("Recognizes string of decimal numbers", {
    let rows = 
        c( "    _  _     _  _  _  _  _  _ ",
          "  | _| _||_||_ |_   ||_||_|| |",
          "  ||_  _|  | _||_|  ||_| _||_|",
          "                              " )
  expect_equal(convert rows, (Some "1234567890"))
})

test_that("Numbers separated by empty lines are recognized. Lines are joined by commas.", {
    let rows = 
        c( "    _  _ ",
          "  | _| _|",
          "  ||_  _|",
          "         ",
          "    _  _ ",
          "|_||_ |_ ",
          "  | _||_|",
          "         ",
          " _  _  _ ",
          "  ||_||_|",
          "  ||_| _|",
          "         " )
  expect_equal(convert rows, (Some "123,456,789"))

