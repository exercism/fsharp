// This file was created manually and its version is 1.0.0.

source("./robot-name-test.R")
library(testthat)

let ``Robot has a name`` () =     
    robot <- mkRobot()
    Regex.IsMatch(name robot, @"^[A-Z]{2}\d{3}$") |> should equal true
    
let ``Name is the same each time`` () =     
    robot <- mkRobot()
    name robot |> should equal (name robot)
    
let ``2 Different robots have different names`` () = 
    robot <- mkRobot()
    robot2 <- mkRobot()
    name robot |> should not' (equal (name robot2))

[<Fact(Skip = "Remove this Skip property to run this test")>] 
let ``2500 Different robots have different names``() =
    robotCount <- 2500
    seq { 1 .. robotCount }
    |> Seq.map (fun _ -> mkRobot())
    |> Seq.map (fun robot -> name robot)
    |> Set
    |> Set.count
    |> should equal robotCount
    
let ``Can reset the name`` () =  
    robot <- mkRobot()
    originalName <- name robot
    resetRobot <- reset robot
    originalName |> should not' (equal (name resetRobot))
