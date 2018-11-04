// This file was auto-generated based on version 1.0.0 of the canonical data.

module DartsTest

open FsUnit.Xunit
open Xunit

open Darts

[<Fact>]
let ``A dart lands outside the target`` () =
    score 15.3 13.2 |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``A dart lands just in the border of the target`` () =
    score 10.0 0.0 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``A dart lands in the middle circle`` () =
    score 3.0 3.7 |> should equal 5

[<Fact(Skip = "Remove to run test")>]
let ``A dart lands right in the border between outside and middle circles`` () =
    score 0.0 5.0 |> should equal 5

[<Fact(Skip = "Remove to run test")>]
let ``A dart lands in the inner circle`` () =
    score 0.0 0.0 |> should equal 10

