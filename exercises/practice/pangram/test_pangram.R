source("./pangram.R")
library(testthat)

test_that("Empty sentence", {
  expect_equal(isPangram "", FALSE)
})

test_that("Perfect lower case", {
  expect_equal(isPangram "abcdefghijklmnopqrstuvwxyz", TRUE)
})

test_that("Only lower case", {
  expect_equal(isPangram "the quick brown fox jumps over the lazy dog", TRUE)
})

test_that("Missing the letter 'x'", {
  expect_equal(isPangram "a quick movement of the enemy will jeopardize five gunboats", FALSE)
})

test_that("Missing the letter 'h'", {
  expect_equal(isPangram "five boxing wizards jump quickly at it", FALSE)
})

test_that("With underscores", {
  expect_equal(isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog", TRUE)
})

test_that("With numbers", {
  expect_equal(isPangram "the 1 quick brown fox jumps over the 2 lazy dogs", TRUE)
})

test_that("Missing letters replaced by numbers", {
  expect_equal(isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog", FALSE)
})

test_that("Mixed case and punctuation", {
  expect_equal(isPangram "\"Five quacking Zephyrs jolt my wax bed.\"", TRUE)
})

test_that("A-m and A-M are 26 different characters but not a pangram", {
  expect_equal(isPangram "abcdefghijklm ABCDEFGHIJKLM", FALSE)

