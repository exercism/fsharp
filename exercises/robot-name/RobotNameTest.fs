module RobotNameTest

open NUnit.Framework
open FsUnit
open System.Text.RegularExpressions
open RobotName

[<Test>]
let ``Robot has a name`` () =     
    let robot = mkRobot()
    Regex.IsMatch(name robot, @"\w{2}\d{3}") |> should be True
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Name is the same each time`` () =     
    let robot = mkRobot()
    name robot |> should equal name robot
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Different robots have different names`` () = 
    let robot = mkRobot()
    let robot2 = mkRobot()
    name robot |> should not' )equal name robot2)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can reset the name`` () =  
    let robot = mkRobot()
    let originalName = name robot
    let resetRobot = reset robot
    originalName |> should not' )equal name resetRobot)