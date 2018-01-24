// This file was auto-generated based on version 1.3.0 of the canonical data.

module LeapTest

open FsUnit.Xunit
open Xunit

open Leap

[<Fact>]
let ``Year not divisible by 4: common year`` () =
    leapYear 2015 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 4, not divisible by 100: leap year`` () =
    leapYear 1996 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 100, not divisible by 400: common year`` () =
    leapYear 2100 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 400: leap year`` () =
    leapYear 2000 |> should equal true

