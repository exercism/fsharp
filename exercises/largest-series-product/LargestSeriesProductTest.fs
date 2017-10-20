// This file was auto-generated based on version 1.0.0 of the canonical data.

module LargestSeriesProductTest

open FsUnit.Xunit
open Xunit

open LargestSeriesProduct

[<Fact>]
let ``Finds the largest product if span equals length`` () =
    let digits = "29"
    largestProduct digits 2 |> should equal 18

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 2 with numbers in order`` () =
    let digits = "0123456789"
    largestProduct digits 2 |> should equal 72

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 2`` () =
    let digits = "576802143"
    largestProduct digits 2 |> should equal 48

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 3 with numbers in order`` () =
    let digits = "0123456789"
    largestProduct digits 3 |> should equal 504

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 3`` () =
    let digits = "1027839564"
    largestProduct digits 3 |> should equal 270

[<Fact(Skip = "Remove to run test")>]
let ``Can find the largest product of 5 with numbers in order`` () =
    let digits = "0123456789"
    largestProduct digits 5 |> should equal 15120

[<Fact(Skip = "Remove to run test")>]
let ``Can get the largest product of a big number`` () =
    let digits = "73167176531330624919225119674426574742355349194934"
    largestProduct digits 6 |> should equal 23520

[<Fact(Skip = "Remove to run test")>]
let ``Reports zero if the only digits are zero`` () =
    let digits = "0000"
    largestProduct digits 2 |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Reports zero if all spans include zero`` () =
    let digits = "99099"
    largestProduct digits 3 |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Rejects span longer than string length`` () =
    let digits = "123"
    largestProduct digits 4 |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Reports 1 for empty string and empty product (0 span)`` () =
    let digits = ""
    largestProduct digits 0 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Reports 1 for nonempty string and empty product (0 span)`` () =
    let digits = "123"
    largestProduct digits 0 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Rejects empty string and nonzero span`` () =
    let digits = ""
    largestProduct digits 1 |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Rejects invalid character in digits`` () =
    let digits = "1234a5"
    largestProduct digits 2 |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Rejects negative span`` () =
    let digits = "12345"
    largestProduct digits -1 |> should equal -1

