source("./pangram.R")
library(testthat)

test_that("Empty sentence", {
  expect_false(isPangram "")
})

test_that("Perfect lower case", {
  expect_true(isPangram "abcdefghijklmnopqrstuvwxyz")
})

test_that("Only lower case", {
  expect_true(isPangram "the quick brown fox jumps over the lazy dog")
})

test_that("Missing the letter 'x'", {
  expect_false(isPangram "a quick movement of the enemy will jeopardize five gunboats")
})

test_that("Missing the letter 'h'", {
  expect_false(isPangram "five boxing wizards jump quickly at it")
})

test_that("With underscores", {
  expect_true(isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog")
})

test_that("With numbers", {
  expect_true(isPangram "the 1 quick brown fox jumps over the 2 lazy dogs")
})

test_that("Missing letters replaced by numbers", {
  expect_false(isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog")
})

test_that("Mixed case and punctuation", {
  expect_true(isPangram "\"Five quacking Zephyrs jolt my wax bed.\"")
})

test_that("A-m and A-M are 26 different characters but not a pangram", {
  expect_false(isPangram "abcdefghijklm ABCDEFGHIJKLM")
})
