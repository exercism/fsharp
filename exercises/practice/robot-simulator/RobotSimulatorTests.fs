source("./robot-simulator.R")
library(testthat)

let ``At origin facing north`` () =
    expected <- create Direction.North (0, 0)
    create Direction.North (0, 0) |> should equal expected

let ``At negative position facing south`` () =
    expected <- create Direction.South (-1, -1)
    create Direction.South (-1, -1) |> should equal expected

let ``Changes north to east`` () =
    robot <- create Direction.North (0, 0)
    expected <- create Direction.East (0, 0)
    move "R" robot |> should equal expected

let ``Changes east to south`` () =
    robot <- create Direction.East (0, 0)
    expected <- create Direction.South (0, 0)
    move "R" robot |> should equal expected

let ``Changes south to west`` () =
    robot <- create Direction.South (0, 0)
    expected <- create Direction.West (0, 0)
    move "R" robot |> should equal expected

let ``Changes west to north`` () =
    robot <- create Direction.West (0, 0)
    expected <- create Direction.North (0, 0)
    move "R" robot |> should equal expected

let ``Changes north to west`` () =
    robot <- create Direction.North (0, 0)
    expected <- create Direction.West (0, 0)
    move "L" robot |> should equal expected

let ``Changes west to south`` () =
    robot <- create Direction.West (0, 0)
    expected <- create Direction.South (0, 0)
    move "L" robot |> should equal expected

let ``Changes south to east`` () =
    robot <- create Direction.South (0, 0)
    expected <- create Direction.East (0, 0)
    move "L" robot |> should equal expected

let ``Changes east to north`` () =
    robot <- create Direction.East (0, 0)
    expected <- create Direction.North (0, 0)
    move "L" robot |> should equal expected

let ``Facing north increments Y`` () =
    robot <- create Direction.North (0, 0)
    expected <- create Direction.North (0, 1)
    move "A" robot |> should equal expected

let ``Facing south decrements Y`` () =
    robot <- create Direction.South (0, 0)
    expected <- create Direction.South (0, -1)
    move "A" robot |> should equal expected

let ``Facing east increments X`` () =
    robot <- create Direction.East (0, 0)
    expected <- create Direction.East (1, 0)
    move "A" robot |> should equal expected

let ``Facing west decrements X`` () =
    robot <- create Direction.West (0, 0)
    expected <- create Direction.West (-1, 0)
    move "A" robot |> should equal expected

let ``Moving east and north from README`` () =
    robot <- create Direction.North (7, 3)
    expected <- create Direction.West (9, 4)
    move "RAALAL" robot |> should equal expected

let ``Moving west and north`` () =
    robot <- create Direction.North (0, 0)
    expected <- create Direction.West (-4, 1)
    move "LAAARALA" robot |> should equal expected

let ``Moving west and south`` () =
    robot <- create Direction.East (2, -7)
    expected <- create Direction.South (-3, -8)
    move "RRAAAAALA" robot |> should equal expected

let ``Moving east and north`` () =
    robot <- create Direction.South (8, 4)
    expected <- create Direction.North (11, 5)
    move "LAAARRRALLLL" robot |> should equal expected

