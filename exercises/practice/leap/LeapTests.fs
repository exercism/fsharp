source("./leap.R")
library(testthat)

test_that("Year not divisible by 4 in common year", {
  expect_false(leapYear 2015)
})

test_that("Year divisible by 2, not divisible by 4 in common year", {
  expect_false(leapYear 1970)
})

test_that("Year divisible by 4, not divisible by 100 in leap year", {
  expect_true(leapYear 1996)
})

test_that("Year divisible by 4 and 5 is still a leap year", {
  expect_true(leapYear 1960)
})

test_that("Year divisible by 100, not divisible by 400 in common year", {
  expect_false(leapYear 2100)
})

test_that("Year divisible by 100 but not by 3 is still not a leap year", {
  expect_false(leapYear 1900)
})

test_that("Year divisible by 400 is leap year", {
  expect_true(leapYear 2000)
})

test_that("Year divisible by 400 but not by 125 is still a leap year", {
  expect_true(leapYear 2400)
})

test_that("Year divisible by 200, not divisible by 400 in common year", {
  expect_false(leapYear 1800)
})
