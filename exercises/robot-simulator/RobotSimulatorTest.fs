module RobotSimulatorTest

open NUnit.Framework

open RobotSimulator

[<Test>]
let ``Turn right edge case`` () =
    let robot = createRobot Bearing.West (0, 0)
    let movedRobot = turnRight robot
    Assert.That(movedRobot, Is.EqualTo(createRobot Bearing.North (0, 0)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Turn left edge case`` () =
    let robot = createRobot Bearing.North (0, 0)
    let movedRobot = turnLeft robot
    Assert.That(movedRobot, Is.EqualTo(createRobot Bearing.West (0, 0)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Robbie`` () =
    let robbie = createRobot Bearing.East (-2, 1)
    Assert.That(robbie, Is.EqualTo(createRobot Bearing.East (-2, 1)))

    let movedRobbie = simulate robbie "RLAALAL"
    Assert.That(movedRobbie, Is.EqualTo(createRobot Bearing.West (0, 2)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Clutz`` () =
    let clutz = createRobot Bearing.North (0, 0)
    let movedClutz = simulate clutz "LAAARALA"
    Assert.That(movedClutz, Is.EqualTo(createRobot Bearing.West (-4, 1)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sphero`` () =
    let sphero = createRobot Bearing.East (2, -7)
    let movedSphero = simulate sphero "RRAAAAALA"
    Assert.That(movedSphero, Is.EqualTo(createRobot Bearing.South (-3, -8)))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Roomba`` () =
    let roomba = createRobot Bearing.South (8, 4)
    let movedRoomba = simulate roomba "LAAARRRALLLL"
    Assert.That(movedRoomba, Is.EqualTo(createRobot Bearing.North (11, 5)))