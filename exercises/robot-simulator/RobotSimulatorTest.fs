// This file was auto-generated based on version 3.1.0 of the canonical data.

module RobotSimulatorTest

open FsUnit.Xunit
open Xunit

open RobotSimulator

[<Fact>]
let ``Robots are created with a position and direction`` () =
    let expected = create Direction.North (0, 0)
    create Direction.North (0, 0) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Negative positions are allowed`` () =
    let expected = create Direction.South (-1, -1)
    create Direction.South (-1, -1) |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from north to east`` () =
    let robot = create Direction.North (0, 0)
    let expected = create Direction.East (0, 0)
    move "R" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from east to south`` () =
    let robot = create Direction.East (0, 0)
    let expected = create Direction.South (0, 0)
    move "R" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from south to west`` () =
    let robot = create Direction.South (0, 0)
    let expected = create Direction.West (0, 0)
    move "R" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from west to north`` () =
    let robot = create Direction.West (0, 0)
    let expected = create Direction.North (0, 0)
    move "R" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from north to west`` () =
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (0, 0)
    move "L" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from west to south`` () =
    let robot = create Direction.West (0, 0)
    let expected = create Direction.South (0, 0)
    move "L" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from south to east`` () =
    let robot = create Direction.South (0, 0)
    let expected = create Direction.East (0, 0)
    move "L" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Changes the direction from east to north`` () =
    let robot = create Direction.East (0, 0)
    let expected = create Direction.North (0, 0)
    move "L" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Increases the y coordinate one when facing north`` () =
    let robot = create Direction.North (0, 0)
    let expected = create Direction.North (0, 1)
    move "A" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decreases the y coordinate by one when facing south`` () =
    let robot = create Direction.South (0, 0)
    let expected = create Direction.South (0, -1)
    move "A" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Increases the x coordinate by one when facing east`` () =
    let robot = create Direction.East (0, 0)
    let expected = create Direction.East (1, 0)
    move "A" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Decreases the x coordinate by one when facing west`` () =
    let robot = create Direction.West (0, 0)
    let expected = create Direction.West (-1, 0)
    move "A" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move east and north from README`` () =
    let robot = create Direction.North (7, 3)
    let expected = create Direction.West (9, 4)
    move "RAALAL" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move west and north`` () =
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (-4, 1)
    move "LAAARALA" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move west and south`` () =
    let robot = create Direction.East (2, -7)
    let expected = create Direction.South (-3, -8)
    move "RRAAAAALA" robot |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Instructions to move east and north`` () =
    let robot = create Direction.South (8, 4)
    let expected = create Direction.North (11, 5)
    move "LAAARRRALLLL" robot |> should equal expected

