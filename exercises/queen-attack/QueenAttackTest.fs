// This file was auto-generated based on version 2.1.0 of the canonical data.

module QueenAttackTest

open FsUnit.Xunit
open Xunit

open QueenAttack

[<Fact>]
let ``Queen with a valid position`` () =
    create (2, 2) |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have positive row`` () =
    create (-2, 2) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have row on board`` () =
    create (8, 4) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have positive column`` () =
    create (2, -2) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have column on board`` () =
    create (4, 8) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Can not attack`` () =
    let whiteQueen = (2, 4)
    let blackQueen = (6, 6)
    canAttack blackQueen whiteQueen |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on same row`` () =
    let whiteQueen = (2, 4)
    let blackQueen = (2, 6)
    canAttack blackQueen whiteQueen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on same column`` () =
    let whiteQueen = (4, 5)
    let blackQueen = (2, 5)
    canAttack blackQueen whiteQueen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on first diagonal`` () =
    let whiteQueen = (2, 2)
    let blackQueen = (0, 4)
    canAttack blackQueen whiteQueen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on second diagonal`` () =
    let whiteQueen = (2, 2)
    let blackQueen = (3, 1)
    canAttack blackQueen whiteQueen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on third diagonal`` () =
    let whiteQueen = (2, 2)
    let blackQueen = (1, 1)
    canAttack blackQueen whiteQueen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on fourth diagonal`` () =
    let whiteQueen = (2, 2)
    let blackQueen = (5, 5)
    canAttack blackQueen whiteQueen |> should equal true

