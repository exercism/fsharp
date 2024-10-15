source("./leap.R")
library(testthat)

test_that("Year not divisible by 4 in common year", {
  expect_equal(leapYear(2015), FALSE)
})

test_that("Year divisible by 2, not divisible by 4 in common year", {
  expect_equal(leapYear(1970), FALSE)
})

test_that("Year divisible by 4, not divisible by 100 in leap year", {
  expect_equal(leapYear(1996), TRUE)
})

test_that("Year divisible by 4 and 5 is still a leap year", {
  expect_equal(leapYear(1960), TRUE)
})

test_that("Year divisible by 100, not divisible by 400 in common year", {
  expect_equal(leapYear(2100), FALSE)
})

test_that("Year divisible by 100 but not by 3 is still not a leap year", {
  expect_equal(leapYear(1900), FALSE)
})

test_that("Year divisible by 400 is leap year", {
  expect_equal(leapYear(2000), TRUE)
})

test_that("Year divisible by 400 but not by 125 is still a leap year", {
  expect_equal(leapYear(2400), TRUE)
})

test_that("Year divisible by 200, not divisible by 400 in common year", {
  expect_equal(leapYear(1800), FALSE)

