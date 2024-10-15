source("./robot-simulator.R")
library(testthat)




test_that("At origin facing north", {
    let expected = create Direction.North (0, 0)
    create Direction.North (0, 0) |> should equal expected


test_that("At negative position facing south", {
    let expected = create Direction.South (-1, -1)
    create Direction.South (-1, -1) |> should equal expected


test_that("Changes north to east", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.East (0, 0)
    move "R" robot |> should equal expected


test_that("Changes east to south", {
    let robot = create Direction.East (0, 0)
    let expected = create Direction.South (0, 0)
    move "R" robot |> should equal expected


test_that("Changes south to west", {
    let robot = create Direction.South (0, 0)
    let expected = create Direction.West (0, 0)
    move "R" robot |> should equal expected


test_that("Changes west to north", {
    let robot = create Direction.West (0, 0)
    let expected = create Direction.North (0, 0)
    move "R" robot |> should equal expected


test_that("Changes north to west", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (0, 0)
    move "L" robot |> should equal expected


test_that("Changes west to south", {
    let robot = create Direction.West (0, 0)
    let expected = create Direction.South (0, 0)
    move "L" robot |> should equal expected


test_that("Changes south to east", {
    let robot = create Direction.South (0, 0)
    let expected = create Direction.East (0, 0)
    move "L" robot |> should equal expected


test_that("Changes east to north", {
    let robot = create Direction.East (0, 0)
    let expected = create Direction.North (0, 0)
    move "L" robot |> should equal expected


test_that("Facing north increments Y", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.North (0, 1)
    move "A" robot |> should equal expected


test_that("Facing south decrements Y", {
    let robot = create Direction.South (0, 0)
    let expected = create Direction.South (0, -1)
    move "A" robot |> should equal expected


test_that("Facing east increments X", {
    let robot = create Direction.East (0, 0)
    let expected = create Direction.East (1, 0)
    move "A" robot |> should equal expected


test_that("Facing west decrements X", {
    let robot = create Direction.West (0, 0)
    let expected = create Direction.West (-1, 0)
    move "A" robot |> should equal expected


test_that("Moving east and north from README", {
    let robot = create Direction.North (7, 3)
    let expected = create Direction.West (9, 4)
    move "RAALAL" robot |> should equal expected


test_that("Moving west and north", {
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (-4, 1)
    move "LAAARALA" robot |> should equal expected


test_that("Moving west and south", {
    let robot = create Direction.East (2, -7)
    let expected = create Direction.South (-3, -8)
    move "RRAAAAALA" robot |> should equal expected


test_that("Moving east and north", {
    let robot = create Direction.South (8, 4)
    let expected = create Direction.North (11, 5)
    move "LAAARRRALLLL" robot |> should equal expected

