module RobotNameTest

open NUnit.Framework
open RobotName

[<Test>]
let ``Robot has a name`` () =     
    let robot = mkRobot()
    StringAssert.IsMatch(@"\w{2}\d{3}", name robot)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Name is the same each time`` () =     
    let robot = mkRobot()
    Assert.That(name robot, Is.EqualTo(name robot))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Different robots have different names`` () = 
    let robot = mkRobot()
    let robot2 = mkRobot()
    Assert.That(name robot, Is.Not.EqualTo(name robot2))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can reset the name`` () =  
    let robot = mkRobot()
    let originalName = name robot
    let resetRobot = reset robot
    Assert.That(originalName, Is.Not.EqualTo(name resetRobot))