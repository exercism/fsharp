// This file was auto-generated based on version 2.1.0 of the canonical data.

module NthPrimeTest

open FsUnit.Xunit
open Xunit

open NthPrime

[<Fact>]
let ``First prime`` () =
    prime 1 |> should equal (Some 2)

[<Fact(Skip = "Remove to run test")>]
let ``Second prime`` () =
    prime 2 |> should equal (Some 3)

[<Fact(Skip = "Remove to run test")>]
let ``Sixth prime`` () =
    prime 6 |> should equal (Some 13)

[<Fact(Skip = "Remove to run test")>]
let ``Big prime`` () =
    prime 10001 |> should equal (Some 104743)

[<Fact(Skip = "Remove to run test")>]
let ``There is no zeroth prime`` () =
    prime 0 |> should equal None

