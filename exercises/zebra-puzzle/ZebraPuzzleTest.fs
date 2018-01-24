// This file was auto-generated based on version 1.1.0 of the canonical data.

module ZebraPuzzleTest

open FsUnit.Xunit
open Xunit

open ZebraPuzzle

[<Fact>]
let ``Resident who drinks water`` () =
    drinksWater |> should equal Norwegian

[<Fact(Skip = "Remove to run test")>]
let ``Resident who owns zebra`` () =
    ownsZebra |> should equal Japanese

