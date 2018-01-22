// This file was auto-generated based on version 1.1.0 of the canonical data.

module LargestSeriesProductTest

open FsUnit.Xunit
open Xunit

open LargestSeriesProduct

[<Fact>]
let ``Finds the largest product if span equals length`` () =
    let digits = "29"
    let span = 2
    largestProduct digits span |> should equal (Some 18)

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 2 with numbers in order`` () =
    let digits = "0123456789"
    let span = 2
    largestProduct digits span |> should equal (Some 72)

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 2`` () =
    let digits = "576802143"
    let span = 2
    largestProduct digits span |> should equal (Some 48)

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 3 with numbers in order`` () =
    let digits = "0123456789"
    let span = 3
    largestProduct digits span |> should equal (Some 504)

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 3`` () =
    let digits = "1027839564"
    let span = 3
    largestProduct digits span |> should equal (Some 270)

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 5 with numbers in order`` () =
    let digits = "0123456789"
    let span = 5
    largestProduct digits span |> should equal (Some 15120)

[<Fact(Skip = "Remove to run test")>]
let ``Can get the largest product of a big number`` () =
    let digits = "73167176531330624919225119674426574742355349194934"
    let span = 6
    largestProduct digits span |> should equal (Some 23520)

[<Fact(Skip = "Remove to run test")>]
let ``Reports zero if the only digits are zero`` () =
    let digits = "0000"
    let span = 2
    largestProduct digits span |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Reports zero if all spans include zero`` () =
    let digits = "99099"
    let span = 3
    largestProduct digits span |> should equal (Some 0)

[<Fact(Skip = "Remove to run test")>]
let ``Rejects span longer than string length`` () =
    let digits = "123"
    let span = 4
    largestProduct digits span |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Reports 1 for empty string and empty product (0 span)`` () =
    let digits = ""
    let span = 0
    largestProduct digits span |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Reports 1 for nonempty string and empty product (0 span)`` () =
    let digits = "123"
    let span = 0
    largestProduct digits span |> should equal (Some 1)

[<Fact(Skip = "Remove to run test")>]
let ``Rejects empty string and nonzero span`` () =
    let digits = ""
    let span = 1
    largestProduct digits span |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Rejects invalid character in digits`` () =
    let digits = "1234a5"
    let span = 2
    largestProduct digits span |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Rejects negative span`` () =
    let digits = "12345"
    let span = -1
    largestProduct digits span |> should equal None

