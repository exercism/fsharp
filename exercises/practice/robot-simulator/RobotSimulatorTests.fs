source("./robot-simulator.R")
library(testthat)

test_that("At origin facing north", {
    expected <- create Direction.North (0, 0)
    expect_equal(create Direction.North (0, 0), expected)

test_that("At negative position facing south", {
    expected <- create Direction.South (-1, -1)
    expect_equal(create Direction.South (-1, -1), expected)

test_that("Changes north to east", {
    robot <- create Direction.North (0, 0)
    expected <- create Direction.East (0, 0)
    expect_equal(move "R" robot, expected)

test_that("Changes east to south", {
    robot <- create Direction.East (0, 0)
    expected <- create Direction.South (0, 0)
    expect_equal(move "R" robot, expected)

test_that("Changes south to west", {
    robot <- create Direction.South (0, 0)
    expected <- create Direction.West (0, 0)
    expect_equal(move "R" robot, expected)

test_that("Changes west to north", {
    robot <- create Direction.West (0, 0)
    expected <- create Direction.North (0, 0)
    expect_equal(move "R" robot, expected)

test_that("Changes north to west", {
    robot <- create Direction.North (0, 0)
    expected <- create Direction.West (0, 0)
    expect_equal(move "L" robot, expected)

test_that("Changes west to south", {
    robot <- create Direction.West (0, 0)
    expected <- create Direction.South (0, 0)
    expect_equal(move "L" robot, expected)

test_that("Changes south to east", {
    robot <- create Direction.South (0, 0)
    expected <- create Direction.East (0, 0)
    expect_equal(move "L" robot, expected)

test_that("Changes east to north", {
    robot <- create Direction.East (0, 0)
    expected <- create Direction.North (0, 0)
    expect_equal(move "L" robot, expected)

test_that("Facing north increments Y", {
    robot <- create Direction.North (0, 0)
    expected <- create Direction.North (0, 1)
    expect_equal(move "A" robot, expected)

test_that("Facing south decrements Y", {
    robot <- create Direction.South (0, 0)
    expected <- create Direction.South (0, -1)
    expect_equal(move "A" robot, expected)

test_that("Facing east increments X", {
    robot <- create Direction.East (0, 0)
    expected <- create Direction.East (1, 0)
    expect_equal(move "A" robot, expected)

test_that("Facing west decrements X", {
    robot <- create Direction.West (0, 0)
    expected <- create Direction.West (-1, 0)
    expect_equal(move "A" robot, expected)

test_that("Moving east and north from README", {
    robot <- create Direction.North (7, 3)
    expected <- create Direction.West (9, 4)
    expect_equal(move "RAALAL" robot, expected)

test_that("Moving west and north", {
    robot <- create Direction.North (0, 0)
    expected <- create Direction.West (-4, 1)
    expect_equal(move "LAAARALA" robot, expected)

test_that("Moving west and south", {
    robot <- create Direction.East (2, -7)
    expected <- create Direction.South (-3, -8)
    expect_equal(move "RRAAAAALA" robot, expected)

test_that("Moving east and north", {
    robot <- create Direction.South (8, 4)
    expected <- create Direction.North (11, 5)
    expect_equal(move "LAAARRRALLLL" robot, expected)

