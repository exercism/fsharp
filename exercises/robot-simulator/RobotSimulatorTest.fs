// This file was auto-generated based on version 2.2.0 of the canonical data.

module RobotSimulatorTest

open FsUnit.Xunit
open Xunit

open RobotSimulator

[<Fact>]
let ``Robots are created with a position and direction`` () =
    let robot = create Direction.North (0, 0)
    let expected = create Direction.North (0, 0)
    robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Negative positions are allowed`` () =
    let robot = create Direction.South (-1, -1)
    let expected = create Direction.South (-1, -1)
    robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight does not change the position`` () =
    let robot = create Direction.North (0, 0)
    let sut = turnRight robot
    sut.position |> should equal (0, 0)

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from north to east`` () =
    let robot = create Direction.North (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal Direction.East

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from east to south`` () =
    let robot = create Direction.East (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal Direction.South

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from south to west`` () =
    let robot = create Direction.South (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal Direction.West

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from west to north`` () =
    let robot = create Direction.West (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal Direction.North

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft does not change the position`` () =
    let robot = create Direction.North (0, 0)
    let sut = turnLeft robot
    sut.position |> should equal (0, 0)

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from north to west`` () =
    let robot = create Direction.North (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal Direction.West

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from west to south`` () =
    let robot = create Direction.West (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal Direction.South

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from south to east`` () =
    let robot = create Direction.South (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal Direction.East

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from east to north`` () =
    let robot = create Direction.East (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal Direction.North

[<Fact(Skip = "Remove to run test")>]
let ``advance does not change the direction`` () =
    let robot = create Direction.North (0, 0)
    let sut = advance robot
    sut.direction |> should equal Direction.North

[<Fact(Skip = "Remove to run test")>]
let ``advance increases the y coordinate one when facing north`` () =
    let robot = create Direction.North (0, 0)
    let sut = advance robot
    sut.position |> should equal (0, 1)

[<Fact(Skip = "Remove to run test")>]
let ``advance decreases the y coordinate by one when facing south`` () =
    let robot = create Direction.South (0, 0)
    let sut = advance robot
    sut.position |> should equal (0, -1)

[<Fact(Skip = "Remove to run test")>]
let ``advance increases the x coordinate by one when facing east`` () =
    let robot = create Direction.East (0, 0)
    let sut = advance robot
    sut.position |> should equal (1, 0)

[<Fact(Skip = "Remove to run test")>]
let ``advance decreases the x coordinate by one when facing west`` () =
    let robot = create Direction.West (0, 0)
    let sut = advance robot
    sut.position |> should equal (-1, 0)

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move west and north`` () =
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (-4, 1)
    instructions "LAAARALA" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move west and south`` () =
    let robot = create Direction.East (2, -7)
    let expected = create Direction.South (-3, -8)
    instructions "RRAAAAALA" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move east and north`` () =
    let robot = create Direction.South (8, 4)
    let expected = create Direction.North (11, 5)
    instructions "LAAARRRALLLL" robot |> should equal expected

