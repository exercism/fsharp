source("./queen-attack.R")
library(testthat)

test_that("Queen with a valid position", {
  expect_true(create (2, 2))
})

test_that("Queen must have positive row", {
  expect_false(create (-2, 2))
})

test_that("Queen must have row on board", {
  expect_false(create (8, 4))
})

test_that("Queen must have positive column", {
  expect_false(create (2, -2))
})

test_that("Queen must have column on board", {
  expect_false(create (4, 8))
})

test_that("Cannot attack", {
    whiteQueen <- (2, 4)
    blackQueen <- (6, 6)
  expect_false(canAttack blackQueen whiteQueen)
})

test_that("Can attack on same row", {
    whiteQueen <- (2, 4)
    blackQueen <- (2, 6)
  expect_true(canAttack blackQueen whiteQueen)
})

test_that("Can attack on same column", {
    whiteQueen <- (4, 5)
    blackQueen <- (2, 5)
  expect_true(canAttack blackQueen whiteQueen)
})

test_that("Can attack on first diagonal", {
    whiteQueen <- (2, 2)
    blackQueen <- (0, 4)
  expect_true(canAttack blackQueen whiteQueen)
})

test_that("Can attack on second diagonal", {
    whiteQueen <- (2, 2)
    blackQueen <- (3, 1)
  expect_true(canAttack blackQueen whiteQueen)
})

test_that("Can attack on third diagonal", {
    whiteQueen <- (2, 2)
    blackQueen <- (1, 1)
  expect_true(canAttack blackQueen whiteQueen)
})

test_that("Can attack on fourth diagonal", {
    whiteQueen <- (1, 7)
    blackQueen <- (0, 6)
  expect_true(canAttack blackQueen whiteQueen)
})

test_that("Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal", {
    whiteQueen <- (4, 1)
    blackQueen <- (2, 5)
  expect_false(canAttack blackQueen whiteQueen)
})
