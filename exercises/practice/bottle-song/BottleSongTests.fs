source("./bottle-song.R")
library(testthat)

test_that("First generic verse", {
    expected <- 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall." ]
  expect_equal(recite(10, 1), expected)
})

test_that("Last generic verse", {
    expected <- 
        [ "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall." ]
  expect_equal(recite(3, 1), expected)
})

test_that("Verse with 2 bottles", {
    expected <- 
        [ "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall." ]
  expect_equal(recite(2, 1), expected)
})

test_that("Verse with 1 bottle", {
    expected <- 
        [ "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
  expect_equal(recite(1, 1), expected)
})

test_that("First two verses", {
    expected <- 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall.";
          "";
          "Nine green bottles hanging on the wall,";
          "Nine green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be eight green bottles hanging on the wall." ]
  expect_equal(recite(10, 2), expected)
})

test_that("Last three verses", {
    expected <- 
        [ "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall.";
          "";
          "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall.";
          "";
          "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
  expect_equal(recite(3, 3), expected)
})

test_that("All verses", {
    expected <- 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall.";
          "";
          "Nine green bottles hanging on the wall,";
          "Nine green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be eight green bottles hanging on the wall.";
          "";
          "Eight green bottles hanging on the wall,";
          "Eight green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be seven green bottles hanging on the wall.";
          "";
          "Seven green bottles hanging on the wall,";
          "Seven green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be six green bottles hanging on the wall.";
          "";
          "Six green bottles hanging on the wall,";
          "Six green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be five green bottles hanging on the wall.";
          "";
          "Five green bottles hanging on the wall,";
          "Five green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be four green bottles hanging on the wall.";
          "";
          "Four green bottles hanging on the wall,";
          "Four green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be three green bottles hanging on the wall.";
          "";
          "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall.";
          "";
          "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall.";
          "";
          "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
  expect_equal(recite(10, 10), expected)
})
