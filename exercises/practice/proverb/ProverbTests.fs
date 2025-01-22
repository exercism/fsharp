source("./proverb.R")
library(testthat)

test_that("Zero pieces", {
  strings = c()
  expected = c()
  expect_equal(recite(strings), expected)
})

test_that("One piece", {
  strings <- c("nail")
  expected <- c("And all for the want of a nail.")
  expect_equal(recite(strings), expected)
})

test_that("Two pieces", {
  strings <- c("nail", "shoe")
  expected <- 
        [ "For want of a nail the shoe was lost.";
          "And all for the want of a nail." ]
  expect_equal(recite(strings), expected)
})

test_that("Three pieces", {
  strings <- c("nail", "shoe", "horse")
  expected <- 
        [ "For want of a nail the shoe was lost.";
          "For want of a shoe the horse was lost.";
          "And all for the want of a nail." ]
  expect_equal(recite(strings), expected)
})

test_that("Full proverb", {
  strings <- c("nail", "shoe", "horse", "rider", "message", "battle", "kingdom")
  expected <- 
        [ "For want of a nail the shoe was lost.";
          "For want of a shoe the horse was lost.";
          "For want of a horse the rider was lost.";
          "For want of a rider the message was lost.";
          "For want of a message the battle was lost.";
          "For want of a battle the kingdom was lost.";
          "And all for the want of a nail." ]
  expect_equal(recite(strings), expected)
})

test_that("Four pieces modernized", {
  strings <- c("pin", "gun", "soldier", "battle")
  expected <- 
        [ "For want of a pin the gun was lost.";
          "For want of a gun the soldier was lost.";
          "For want of a soldier the battle was lost.";
          "And all for the want of a pin." ]
  expect_equal(recite(strings), expected)
})
