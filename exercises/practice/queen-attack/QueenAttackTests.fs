source("./queen-attack.R")
library(testthat)

let ``Queen with a valid position`` () =
    create (2, 2) |> should equal true

let ``Queen must have positive row`` () =
    create (-2, 2) |> should equal false

let ``Queen must have row on board`` () =
    create (8, 4) |> should equal false

let ``Queen must have positive column`` () =
    create (2, -2) |> should equal false

let ``Queen must have column on board`` () =
    create (4, 8) |> should equal false

let ``Cannot attack`` () =
    whiteQueen <- (2, 4)
    blackQueen <- (6, 6)
    canAttack blackQueen whiteQueen |> should equal false

let ``Can attack on same row`` () =
    whiteQueen <- (2, 4)
    blackQueen <- (2, 6)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on same column`` () =
    whiteQueen <- (4, 5)
    blackQueen <- (2, 5)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on first diagonal`` () =
    whiteQueen <- (2, 2)
    blackQueen <- (0, 4)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on second diagonal`` () =
    whiteQueen <- (2, 2)
    blackQueen <- (3, 1)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on third diagonal`` () =
    whiteQueen <- (2, 2)
    blackQueen <- (1, 1)
    canAttack blackQueen whiteQueen |> should equal true

let ``Can attack on fourth diagonal`` () =
    whiteQueen <- (1, 7)
    blackQueen <- (0, 6)
    canAttack blackQueen whiteQueen |> should equal true

let ``Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal`` () =
    whiteQueen <- (4, 1)
    blackQueen <- (2, 5)
    canAttack blackQueen whiteQueen |> should equal false

