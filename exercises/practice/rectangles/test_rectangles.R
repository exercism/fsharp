source("./rectangles.R")
library(testthat)

test_that("No rows", {
    let strings = []
  expect_equal(rectangles strings, 0)
})

test_that("No columns", {
    let strings = [""]
  expect_equal(rectangles strings, 0)
})

test_that("No rectangles", {
    let strings = [" "]
  expect_equal(rectangles strings, 0)
})

test_that("One rectangle", {
    let strings = 
        [ "+-+";
          "| |";
          "+-+" ]
  expect_equal(rectangles strings, 1)
})

test_that("Two rectangles without shared parts", {
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
  expect_equal(rectangles strings, 2)
})

test_that("Five rectangles with shared parts", {
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
  expect_equal(rectangles strings, 5)
})

test_that("Rectangle of height 1 is counted", {
    let strings = 
        [ "+--+";
          "+--+" ]
  expect_equal(rectangles strings, 1)
})

test_that("Rectangle of width 1 is counted", {
    let strings = 
        [ "++";
          "||";
          "++" ]
  expect_equal(rectangles strings, 1)
})

test_that("1x1 square is counted", {
    let strings = 
        [ "++";
          "++" ]
  expect_equal(rectangles strings, 1)
})

test_that("Only complete rectangles are counted", {
    let strings = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
  expect_equal(rectangles strings, 1)
})

test_that("Rectangles can be of different sizes", {
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
  expect_equal(rectangles strings, 3)
})

test_that("Corner is required for a rectangle to be complete", {
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
  expect_equal(rectangles strings, 2)
})

test_that("Large input with many rectangles", {
    let strings = 
        [ "+---+--+----+";
          "|   +--+----+";
          "+---+--+    |";
          "|   +--+----+";
          "+---+--+--+-+";
          "+---+--+--+-+";
          "+------+  | |";
          "          +-+" ]
  expect_equal(rectangles strings, 60)
})

test_that("Rectangles must have four sides", {
    let strings = 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
  expect_equal(rectangles strings, 5)

