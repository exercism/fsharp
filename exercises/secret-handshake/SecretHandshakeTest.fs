// This file was auto-generated based on version 1.2.0 of the canonical data.

module SecretHandshakeTest

open FsUnit.Xunit
open Xunit

open SecretHandshake

[<Fact>]
let ``Wink for 1`` () =
    commands 1 |> should equal ["wink"]

[<Fact(Skip = "Remove to run test")>]
let ``Double blink for 10`` () =
    commands 2 |> should equal ["double blink"]

[<Fact(Skip = "Remove to run test")>]
let ``Close your eyes for 100`` () =
    commands 4 |> should equal ["close your eyes"]

[<Fact(Skip = "Remove to run test")>]
let ``Jump for 1000`` () =
    commands 8 |> should equal ["jump"]

[<Fact(Skip = "Remove to run test")>]
let ``Combine two actions`` () =
    commands 3 |> should equal ["wink"; "double blink"]

[<Fact(Skip = "Remove to run test")>]
let ``Reverse two actions`` () =
    commands 19 |> should equal ["double blink"; "wink"]

[<Fact(Skip = "Remove to run test")>]
let ``Reversing one action gives the same action`` () =
    commands 24 |> should equal ["jump"]

[<Fact(Skip = "Remove to run test")>]
let ``Reversing no actions still gives no actions`` () =
    commands 16 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``All possible actions`` () =
    commands 15 |> should equal ["wink"; "double blink"; "close your eyes"; "jump"]

[<Fact(Skip = "Remove to run test")>]
let ``Reverse all possible actions`` () =
    commands 31 |> should equal ["jump"; "close your eyes"; "double blink"; "wink"]

[<Fact(Skip = "Remove to run test")>]
let ``Do nothing for zero`` () =
    commands 0 |> should be Empty

