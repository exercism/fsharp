// This file was created manually and its version is 1.0.0.

source("./robot-name-test.R")
library(testthat)

test_that("Robot has a name", {
  robot <- mkRobot()
  expect_true(Regex.IsMatch(name robot, @"^c(A-Z){2}\d{3}$"))
    
test_that("Name is the same each time", {
  robot <- mkRobot()
  expect_equal(name(robot), (name robot))
    
test_that("2 Different robots have different names", {
  robot <- mkRobot()
  robot2 <- mkRobot()
    name robot |> should not' (equal (name robot2))

c(<Fact(Skip = "Remove this Skip property to run this test")>) 
test_that("2500 Different robots have different names", {
  robotCount <- 2500
    seq { 1 .. robotCount }
    |> Seq.map (fun _ -> mkRobot())
    |> Seq.map (fun robot -> name robot)
    |> Set
    |> Set.count
  expect_equal( , robotCount)
    
test_that("Can reset the name", {
  robot <- mkRobot()
  originalName <- name robot
  resetRobot <- reset robot
    originalName |> should not' (equal (name resetRobot))
