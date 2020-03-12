// This file was created manually and its version is 1.0.0.

module RobotNameTest

open Xunit
open FsUnit.Xunit
open System.Text.RegularExpressions
open RobotName

[<Fact>]
let ``Robot has a name`` () =     
    let robot = mkRobot()
    Regex.IsMatch(name robot, @"^[A-Z]{2}\d{3}$") |> should equal true
    
[<Fact(Skip = "Remove to run test")>]
let ``Name is the same each time`` () =     
    let robot = mkRobot()
    name robot |> should equal (name robot)
    
[<Fact(Skip = "Remove to run test")>]
let ``Different robots have different names`` () = 
    let robot = mkRobot()
    let robot2 = mkRobot()
    name robot |> should not' (equal (name robot2))
    
[<Fact(Skip = "Remove to run test")>]
let ``Can reset the name`` () =  
    let robot = mkRobot()
    let originalName = name robot
    let resetRobot = reset robot
    originalName |> should not' (equal (name resetRobot))
