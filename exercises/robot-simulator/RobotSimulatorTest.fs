module RobotSimulatorTest

open NUnit.Framework
open FsUnit

open RobotSimulator

[<Test>]
let ``Turn right edge case`` () =
    let robot = createRobot Bearing.West (0, 0)
    let movedRobot = turnRight robot
    movedRobot |> should equal createRobot Bearing.North (0, 0)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Turn left edge case`` () =
    let robot = createRobot Bearing.North (0, 0)
    let movedRobot = turnLeft robot
    movedRobot |> should equal createRobot Bearing.West (0, 0)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Robbie`` () =
    let robbie = createRobot Bearing.East (-2, 1)
    robbie |> should equal createRobot Bearing.East (-2, 1)

    let movedRobbie = simulate robbie "RLAALAL"
    movedRobbie |> should equal createRobot Bearing.West (0, 2)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Clutz`` () =
    let clutz = createRobot Bearing.North (0, 0)
    let movedClutz = simulate clutz "LAAARALA"
    movedClutz |> should equal createRobot Bearing.West (-4, 1)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sphero`` () =
    let sphero = createRobot Bearing.East (2, -7)
    let movedSphero = simulate sphero "RRAAAAALA"
    movedSphero |> should equal createRobot Bearing.South (-3, -8)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Roomba`` () =
    let roomba = createRobot Bearing.South (8, 4)
    let movedRoomba = simulate roomba "LAAARRRALLLL"
    movedRoomba |> should equal createRobot Bearing.North (11, 5)