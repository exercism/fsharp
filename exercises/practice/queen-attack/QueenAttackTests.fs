source("./queen-attack.R")
library(testthat)

test_that("Queen with a valid position", {
    expect_equal(create (2, 2), true)
})

test_that("Queen must have positive row", {
    expect_equal(create (-2, 2), false)
})

test_that("Queen must have row on board", {
    expect_equal(create (8, 4), false)
})

test_that("Queen must have positive column", {
    expect_equal(create (2, -2), false)
})

test_that("Queen must have column on board", {
    expect_equal(create (4, 8), false)
})

test_that("Cannot attack", {
    whiteQueen <- (2, 4)
    blackQueen <- (6, 6)
    expect_equal(canAttack blackQueen whiteQueen, false)
})

test_that("Can attack on same row", {
    whiteQueen <- (2, 4)
    blackQueen <- (2, 6)
    expect_equal(canAttack blackQueen whiteQueen, true)
})

test_that("Can attack on same column", {
    whiteQueen <- (4, 5)
    blackQueen <- (2, 5)
    expect_equal(canAttack blackQueen whiteQueen, true)
})

test_that("Can attack on first diagonal", {
    whiteQueen <- (2, 2)
    blackQueen <- (0, 4)
    expect_equal(canAttack blackQueen whiteQueen, true)
})

test_that("Can attack on second diagonal", {
    whiteQueen <- (2, 2)
    blackQueen <- (3, 1)
    expect_equal(canAttack blackQueen whiteQueen, true)
})

test_that("Can attack on third diagonal", {
    whiteQueen <- (2, 2)
    blackQueen <- (1, 1)
    expect_equal(canAttack blackQueen whiteQueen, true)
})

test_that("Can attack on fourth diagonal", {
    whiteQueen <- (1, 7)
    blackQueen <- (0, 6)
    expect_equal(canAttack blackQueen whiteQueen, true)
})

test_that("Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal", {
    whiteQueen <- (4, 1)
    blackQueen <- (2, 5)
    expect_equal(canAttack blackQueen whiteQueen, false)
})
