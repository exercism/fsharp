source("./robot-simulator.R")
library(testthat)

test_that("At origin facing north", {
    let expected = create Direction.North (0, 0)
  expect_equal(create Direction.North (0, 0), expected)
})

test_that("At negative position facing south", {
    let expected = create Direction.South (-1, -1)
  expect_equal(create Direction.South (-1, -1), expected)
})

test_that("Changes north to east", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.East (0, 0)
  expect_equal(move "R" robot, expected)
})

test_that("Changes east to south", {
    let robot = create Direction.East (0, 0)
    let expected = create Direction.South (0, 0)
  expect_equal(move "R" robot, expected)
})

test_that("Changes south to west", {
    let robot = create Direction.South (0, 0)
    let expected = create Direction.West (0, 0)
  expect_equal(move "R" robot, expected)
})

test_that("Changes west to north", {
    let robot = create Direction.West (0, 0)
    let expected = create Direction.North (0, 0)
  expect_equal(move "R" robot, expected)
})

test_that("Changes north to west", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (0, 0)
  expect_equal(move "L" robot, expected)
})

test_that("Changes west to south", {
    let robot = create Direction.West (0, 0)
    let expected = create Direction.South (0, 0)
  expect_equal(move "L" robot, expected)
})

test_that("Changes south to east", {
    let robot = create Direction.South (0, 0)
    let expected = create Direction.East (0, 0)
  expect_equal(move "L" robot, expected)
})

test_that("Changes east to north", {
    let robot = create Direction.East (0, 0)
    let expected = create Direction.North (0, 0)
  expect_equal(move "L" robot, expected)
})

test_that("Facing north increments Y", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.North (0, 1)
  expect_equal(move "A" robot, expected)
})

test_that("Facing south decrements Y", {
    let robot = create Direction.South (0, 0)
    let expected = create Direction.South (0, -1)
  expect_equal(move "A" robot, expected)
})

test_that("Facing east increments X", {
    let robot = create Direction.East (0, 0)
    let expected = create Direction.East (1, 0)
  expect_equal(move "A" robot, expected)
})

test_that("Facing west decrements X", {
    let robot = create Direction.West (0, 0)
    let expected = create Direction.West (-1, 0)
  expect_equal(move "A" robot, expected)
})

test_that("Moving east and north from README", {
    let robot = create Direction.North (7, 3)
    let expected = create Direction.West (9, 4)
  expect_equal(move "RAALAL" robot, expected)
})

test_that("Moving west and north", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (-4, 1)
  expect_equal(move "LAAARALA" robot, expected)
})

test_that("Moving west and south", {
    let robot = create Direction.East (2, -7)
    let expected = create Direction.South (-3, -8)
  expect_equal(move "RRAAAAALA" robot, expected)
})

test_that("Moving east and north", {
    let robot = create Direction.South (8, 4)
    let expected = create Direction.North (11, 5)
  expect_equal(move "LAAARRRALLLL" robot, expected)

