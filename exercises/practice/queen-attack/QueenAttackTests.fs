source("./queen-attack.R")
library(testthat)

let ``Queen with a valid position`` () =
    expect_equal(create (2, 2), true)

let ``Queen must have positive row`` () =
    expect_equal(create (-2, 2), false)

let ``Queen must have row on board`` () =
    expect_equal(create (8, 4), false)

let ``Queen must have positive column`` () =
    expect_equal(create (2, -2), false)

let ``Queen must have column on board`` () =
    expect_equal(create (4, 8), false)

let ``Cannot attack`` () =
    whiteQueen <- (2, 4)
    blackQueen <- (6, 6)
    expect_equal(canAttack blackQueen whiteQueen, false)

let ``Can attack on same row`` () =
    whiteQueen <- (2, 4)
    blackQueen <- (2, 6)
    expect_equal(canAttack blackQueen whiteQueen, true)

let ``Can attack on same column`` () =
    whiteQueen <- (4, 5)
    blackQueen <- (2, 5)
    expect_equal(canAttack blackQueen whiteQueen, true)

let ``Can attack on first diagonal`` () =
    whiteQueen <- (2, 2)
    blackQueen <- (0, 4)
    expect_equal(canAttack blackQueen whiteQueen, true)

let ``Can attack on second diagonal`` () =
    whiteQueen <- (2, 2)
    blackQueen <- (3, 1)
    expect_equal(canAttack blackQueen whiteQueen, true)

let ``Can attack on third diagonal`` () =
    whiteQueen <- (2, 2)
    blackQueen <- (1, 1)
    expect_equal(canAttack blackQueen whiteQueen, true)

let ``Can attack on fourth diagonal`` () =
    whiteQueen <- (1, 7)
    blackQueen <- (0, 6)
    expect_equal(canAttack blackQueen whiteQueen, true)

let ``Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal`` () =
    whiteQueen <- (4, 1)
    blackQueen <- (2, 5)
    expect_equal(canAttack blackQueen whiteQueen, false)

