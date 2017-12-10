// This file was auto-generated based on version 1.0.0 of the canonical data.

module ArmstrongNumbersTest

open FsUnit.Xunit
open Xunit

open ArmstrongNumbers

[<Fact>]
let ``Single digit numbers are Armstrong numbers`` () =
    isArmstrongNumber 5 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``There are no 2 digit Armstrong numbers`` () =
    isArmstrongNumber 10 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Three digit number that is an Armstrong number`` () =
    isArmstrongNumber 153 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Three digit number that is not an Armstrong number`` () =
    isArmstrongNumber 100 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Four digit number that is an Armstrong number`` () =
    isArmstrongNumber 9474 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Four digit number that is not an Armstrong number`` () =
    isArmstrongNumber 9475 |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Seven digit number that is an Armstrong number`` () =
    isArmstrongNumber 9926315 |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Seven digit number that is not an Armstrong number`` () =
    isArmstrongNumber 9926314 |> should equal false

