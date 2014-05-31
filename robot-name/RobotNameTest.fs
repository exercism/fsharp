module RobotNameTest

open NUnit.Framework
open RobotName

[<TestFixture>]
type RobotNameTest() =
    let robot = RobotName()

    [<Test>]
    member tests.Robot_has_a_name() =
        StringAssert.IsMatch(@"\w{2}\d{3}", robot.Name)

    [<Test>]
    [<Ignore>]
    member tests.Name_is_the_same_each_time() =
        Assert.True(true)

    [<Test>]
    [<Ignore>]
    member this.Different_robots_have_different_names() =
        let robot2 = RobotName()

        Assert.That(robot.Name, Is.Not.EqualTo(robot2.Name))

    [<Test>]
    [<Ignore>]
    member this.Can_reset_the_name() =
        let originalName = robot.Name
        
        robot.Reset()

        Assert.That(originalName, Is.Not.EqualTo(robot.Name))