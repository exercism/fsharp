// This file was auto-generated based on version 1.5.1 of the canonical data.

module LeapTest

open FsUnit.Xunit
open Xunit

open Leap

[<Fact>]
let ``Year not divisible by 4 in common year`` () =
    leapYear 2015 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 2, not divisible by 4 in common year`` () =
    leapYear 1970 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 4, not divisible by 100 in leap year`` () =
    leapYear 1996 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 100, not divisible by 400 in common year`` () =
    leapYear 2100 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 400 in leap year`` () =
    leapYear 2000 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Year divisible by 200, not divisible by 400 in common year`` () =
    leapYear 1800 |> should equal false

