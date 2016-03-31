module RobotNameTest

open NUnit.Framework
open RobotName

[<Test>]
let ``Robot has a name`` () =     
    let robot = new Robot()
    StringAssert.IsMatch(@"\w{2}\d{3}", robot.Name)
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Name is the same each time`` () =     
    let robot = new Robot()
    Assert.That(robot.Name, Is.EqualTo(robot.Name))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Different robots have different names`` () = 
    let robot = new Robot()
    let robot2 = new Robot()
    Assert.That(robot.Name, Is.Not.EqualTo(robot2.Name))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can reset the name`` () =  
    let robot = new Robot()
    let originalName = robot.Name
    robot.Reset()
    Assert.That(originalName, Is.Not.EqualTo(robot.Name))