source("./robot-name.R")
library(testthat)
test_that("Robot has a name", {     
    let robot = mkRobot()
    Regex.IsMatch(name robot, @"^[A-Z]{2}\d{3}$") |> should equal true
    

test_that("Name is the same each time", {     
    let robot = mkRobot()
    name robot |> should equal (name robot)
    

test_that("2 Different robots have different names", { 
    let robot = mkRobot()
    let robot2 = mkRobot()
    name robot |> should not' (equal (name robot2))

 
test_that("2500 Different robots have different names``() =
    let robotCount = 2500
    seq { 1 .. robotCount }
    |> Seq.map (fun _ -> mkRobot())
    |> Seq.map (fun robot -> name robot)
    |> Set
    |> Set.count
    |> should equal robotCount
    

test_that("Can reset the name", {  
    let robot = mkRobot()
    let originalName = name robot
    let resetRobot = reset robot
    originalName |> should not' (equal (name resetRobot))
