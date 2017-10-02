// This file was auto-generated based on version 1.0.0 of the canonical data.

module QueenAttackTest

open FsUnit.Xunit
open Xunit

open QueenAttack

[<Fact>]
let ``Queen with a valid position`` () =
    create (2, 2) |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have positive rank`` () =
    create (-2, 2) |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have rank on board`` () =
    create (8, 4) |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have positive file`` () =
    create (2, -2) |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Queen must have file on board`` () =
    create (4, 8) |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Can not attack`` () =
    canAttack {
  "position": "(6,6)"
} {
  "position": "(2,4)"
} |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on same rank`` () =
    canAttack {
  "position": "(2,6)"
} {
  "position": "(2,4)"
} |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on same file`` () =
    canAttack {
  "position": "(2,5)"
} {
  "position": "(4,5)"
} |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on first diagonal`` () =
    canAttack {
  "position": "(0,4)"
} {
  "position": "(2,2)"
} |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on second diagonal`` () =
    canAttack {
  "position": "(3,1)"
} {
  "position": "(2,2)"
} |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on third diagonal`` () =
    canAttack {
  "position": "(1,1)"
} {
  "position": "(2,2)"
} |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Can attack on fourth diagonal`` () =
    canAttack {
  "position": "(5,5)"
} {
  "position": "(2,2)"
} |> should equal true

