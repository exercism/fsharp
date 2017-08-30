module LuhnTest

open Xunit
open FsUnit
open Luhn

[Fact]
let ``Single digit strings cannot be valid`` () =
    let input = "1"
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``A single zero is invalid`` () =
    let input = "0"
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Single zero with space is invalid`` () =
    let input = "0 "
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Lots of zeros are valid`` () =
    let input = "00000"
    let expected = true
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Nine doubled is nine`` () =
    let input = "091"
    let expected = true
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Simple valid number`` () =
    let input = " 5 9 "
    let expected = true
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Valid Canadian SIN`` () =
    let input = "046 454 286"
    let expected = true
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Another valid SIN`` () =
    let input = "055 444 285"
    let expected = true
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Invalid Canadian SIN`` () =
    let input = "046 454 287"
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Invalid credit card`` () =
    let input = "8273 1232 7352 0569"
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Strings that contain non-digits are not valid`` () =
    let input = "827a 1232 7352 0569"
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Punctuation is not allowed`` () =
    let input = "055-444-285"
    let expected = false
    let actual = valid input
    actual |> should equal expected

[Fact(Skip = "Remove to run test")]
let ``Symbols are not allowed`` () =
    let input = "055£ 444$ 285"
    let expected = false
    let actual = valid input
    actual |> should equal expected