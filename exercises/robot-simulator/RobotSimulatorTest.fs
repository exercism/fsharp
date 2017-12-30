// This file was auto-generated based on version 2.0.0 of the canonical data.

module RobotSimulatorTest

open FsUnit.Xunit
open Xunit

open RobotSimulator

[<Fact>]
let ``Robots are created with a position and direction`` () =
    let robot = create North (0, 0)
    let expected = create North (0, 0)
    robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Negative positions are allowed`` () =
    let robot = create South (-1, -1)
    let expected = create South (-1, -1)
    robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``turnRight does not change the position`` () =
    let robot = create North (0, 0)
    let sut = turnRight robot
    sut.position |> should equal (0, 0)

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from north to east`` () =
    let robot = create North (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal East

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from east to south`` () =
    let robot = create East (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal South

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from south to west`` () =
    let robot = create South (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal West

[<Fact(Skip = "Remove to run test")>]
let ``turnRight changes the direction from west to north`` () =
    let robot = create West (0, 0)
    let sut = turnRight robot
    sut.direction |> should equal North

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft does not change the position`` () =
    let robot = create North (0, 0)
    let sut = turnLeft robot
    sut.position |> should equal (0, 0)

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from north to west`` () =
    let robot = create North (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal West

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from west to south`` () =
    let robot = create West (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal South

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from south to east`` () =
    let robot = create South (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal East

[<Fact(Skip = "Remove to run test")>]
let ``turnLeft changes the direction from east to north`` () =
    let robot = create East (0, 0)
    let sut = turnLeft robot
    sut.direction |> should equal North

[<Fact(Skip = "Remove to run test")>]
let ``advance does not change the direction`` () =
    let robot = create North (0, 0)
    let sut = advance robot
    sut.direction |> should equal North

[<Fact(Skip = "Remove to run test")>]
let ``advance increases the y coordinate one when facing north`` () =
    let robot = create North (0, 0)
    let sut = advance robot
    sut.position |> should equal (0, 1)

[<Fact(Skip = "Remove to run test")>]
let ``advance decreases the y coordinate by one when facing south`` () =
    let robot = create South (0, 0)
    let sut = advance robot
    sut.position |> should equal (0, -1)

[<Fact(Skip = "Remove to run test")>]
let ``advance increases the x coordinate by one when facing east`` () =
    let robot = create East (0, 0)
    let sut = advance robot
    sut.position |> should equal (1, 0)

[<Fact(Skip = "Remove to run test")>]
let ``advance decreases the x coordinate by one when facing west`` () =
    let robot = create West (0, 0)
    let sut = advance robot
    sut.position |> should equal (-1, 0)

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move west and north`` () =
    let robot = create North (0, 0)
    let expected = create West (-4, 1)
    instructions "LAAARALA" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move west and south`` () =
    let robot = create East (2, -7)
    let expected = create South (-3, -8)
    instructions "RRAAAAALA" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move east and north`` () =
    let robot = create South (8, 4)
    let expected = create North (11, 5)
    instructions "LAAARRRALLLL" robot |> should equal expected

