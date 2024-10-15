source("./minesweeper.R")
library(testthat)

test_that("No rows", {
  minefield <- c()
  expected <- c()
  expect_equal(annotate minefield, expected)
})

test_that("No columns", {
  minefield <- c("")
  expected <- c("")
  expect_equal(annotate minefield, expected)
})

test_that("No mines", {
  minefield <- 
        c( "   ",
          "   ",
          "   " )
  expected <- 
        c( "   ",
          "   ",
          "   " )
  expect_equal(annotate minefield, expected)
})

test_that("Minefield with only mines", {
  minefield <- 
        c( "***",
          "***",
          "***" )
  expected <- 
        c( "***",
          "***",
          "***" )
  expect_equal(annotate minefield, expected)
})

test_that("Mine surrounded by spaces", {
  minefield <- 
        c( "   ",
          " * ",
          "   " )
  expected <- 
        c( "111",
          "1*1",
          "111" )
  expect_equal(annotate minefield, expected)
})

test_that("Space surrounded by mines", {
  minefield <- 
        c( "***",
          "* *",
          "***" )
  expected <- 
        c( "***",
          "*8*",
          "***" )
  expect_equal(annotate minefield, expected)
})

test_that("Horizontal line", {
  minefield <- c(" * * ")
  expected <- c("1*2*1")
  expect_equal(annotate minefield, expected)
})

test_that("Horizontal line, mines at edges", {
  minefield <- c("*   *")
  expected <- c("*1 1*")
  expect_equal(annotate minefield, expected)
})

test_that("Vertical line", {
  minefield <- 
        c( " ",
          "*",
          " ",
          "*",
          " " )
  expected <- 
        c( "1",
          "*",
          "2",
          "*",
          "1" )
  expect_equal(annotate minefield, expected)
})

test_that("Vertical line, mines at edges", {
  minefield <- 
        c( "*",
          " ",
          " ",
          " ",
          "*" )
  expected <- 
        c( "*",
          "1",
          " ",
          "1",
          "*" )
  expect_equal(annotate minefield, expected)
})

test_that("Cross", {
  minefield <- 
        c( "  *  ",
          "  *  ",
          "*****",
          "  *  ",
          "  *  " )
  expected <- 
        c( " 2*2 ",
          "25*52",
          "*****",
          "25*52",
          " 2*2 " )
  expect_equal(annotate minefield, expected)
})

test_that("Large minefield", {
  minefield <- 
        c( " *  * ",
          "  *   ",
          "    * ",
          "   * *",
          " *  * ",
          "      " )
  expected <- 
        c( "1*22*1",
          "12*322",
          " 123*2",
          "112*4*",
          "1*22*2",
          "111111" )
  expect_equal(annotate minefield, expected)
})