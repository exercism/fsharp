// This file was auto-generated based on version 1.0.0 of the canonical data.

module QueenAttackTest

open FsUnit.Xunit
open Xunit

open QueenAttack

[<Fact>]
let ``Queen with a valid position`` () =
    create (2, 2) |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have positive rank`` () =
    create (-2, 2) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have rank on board`` () =
    create (8, 4) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have positive file`` () =
    create (2, -2) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have file on board`` () =
    create (4, 8) |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Can not attack`` () =
    let whiteQueen = (2, 4)
    let blackQueen = (6, 6)
    canAttack blackQueen whiteQueen |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on same rank`` () =
    let whiteQueen = (2, 4)
    let blackQueen = (2, 6)
    canAttack blackQueen whiteQueen |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on same file`` () =
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

