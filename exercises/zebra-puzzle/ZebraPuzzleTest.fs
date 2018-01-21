// This file was created manually and its version is 1.0.0.

module ZebraPuzzleTest

open Xunit
open FsUnit.Xunit

open ZebraPuzzle

[<Fact>]
let ``Who drinks water?`` () =
    let solution = solve()
    whoDrinksWater solution |> should equal Norwegian

[<Fact(Skip = "Remove to run test")>]
let ``Who owns the zebra?`` () =
    let solution = solve()
    whoOwnsZebra solution |> should equal Japanese