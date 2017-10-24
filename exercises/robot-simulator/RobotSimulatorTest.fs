// This file was auto-generated based on version 2.0.0 of the canonical data.

module RobotSimulatorTest

open FsUnit.Xunit
open Xunit

open RobotSimulator

[<Fact>]
let ``create - Robots are created with a position and direction`` () =
    let robot = createRobot North (0, 0)
    let expected = createRobot North (0, 0)
    robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``create - Negative positions are allowed`` () =
    let robot = createRobot South (-1, -1)
    let expected = createRobot South (-1, -1)
    robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight - Does not change the position`` () =
    let robot = createRobot North (0, 0)
    let actual = turnRight robot
    let expected = (0, 0)
    actual.coordinate |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight - Changes the direction from north to east`` () =
    let robot = createRobot North (0, 0)
    let actual = turnRight robot
    let expected = East
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight - Changes the direction from east to south`` () =
    let robot = createRobot East (0, 0)
    let actual = turnRight robot
    let expected = South
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight - Changes the direction from south to west`` () =
    let robot = createRobot South (0, 0)
    let actual = turnRight robot
    let expected = West
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight - Changes the direction from west to north`` () =
    let robot = createRobot West (0, 0)
    let actual = turnRight robot
    let expected = North
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft - Does not change the position`` () =
    let robot = createRobot North (0, 0)
    let actual = turnLeft robot
    let expected = (0, 0)
    actual.coordinate |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft - Changes the direction from north to west`` () =
    let robot = createRobot North (0, 0)
    let actual = turnLeft robot
    let expected = West
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft - Changes the direction from west to south`` () =
    let robot = createRobot West (0, 0)
    let actual = turnLeft robot
    let expected = South
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft - Changes the direction from south to east`` () =
    let robot = createRobot South (0, 0)
    let actual = turnLeft robot
    let expected = East
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft - Changes the direction from east to north`` () =
    let robot = createRobot East (0, 0)
    let actual = turnLeft robot
    let expected = North
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``advance - Does not change the direction`` () =
    let robot = createRobot North (0, 0)
    let actual = advance robot
    let expected = North
    actual.bearing |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``advance - Increases the y coordinate one when facing north`` () =
    let robot = createRobot North (0, 0)
    let actual = advance robot
    let expected = (0, 1)
    actual.coordinate |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``advance - Decreases the y coordinate by one when facing south`` () =
    let robot = createRobot South (0, 0)
    let actual = advance robot
    let expected = (0, -1)
    actual.coordinate |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``advance - Increases the x coordinate by one when facing east`` () =
    let robot = createRobot East (0, 0)
    let actual = advance robot
    let expected = (1, 0)
    actual.coordinate |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``advance - Decreases the x coordinate by one when facing west`` () =
    let robot = createRobot West (0, 0)
    let actual = advance robot
    let expected = (-1, 0)
    actual.coordinate |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``instructions - Instructions to move west and north`` () =
    let robot = createRobot North (0, 0)
    let actual = simulate robot "LAAARALA"
    let expected = createRobot West (-4, 1)
    actual |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``instructions - Instructions to move west and south`` () =
    let robot = createRobot East (2, -7)
    let actual = simulate robot "RRAAAAALA"
    let expected = createRobot South (-3, -8)
    actual |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``instructions - Instructions to move east and north`` () =
    let robot = createRobot South (8, 4)
    let actual = simulate robot "LAAARRRALLLL"
    let expected = createRobot North (11, 5)
    actual |> should equal expected

