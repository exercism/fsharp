// This file was auto-generated based on version 1.2.0 of the canonical data.

module RomanNumeralsTest

open FsUnit.Xunit
open Xunit

open RomanNumerals

[<Fact>]
let ``1 is a single I`` () =
    roman 1 |> should equal "I"

[<Fact(Skip = "Remove to run test")>]
let ``2 is two I's`` () =
    roman 2 |> should equal "II"

[<Fact(Skip = "Remove to run test")>]
let ``3 is three I's`` () =
    roman 3 |> should equal "III"

[<Fact(Skip = "Remove to run test")>]
let ``4, being 5 - 1, is IV`` () =
    roman 4 |> should equal "IV"

[<Fact(Skip = "Remove to run test")>]
let ``5 is a single V`` () =
    roman 5 |> should equal "V"

[<Fact(Skip = "Remove to run test")>]
let ``6, being 5 + 1, is VI`` () =
    roman 6 |> should equal "VI"

[<Fact(Skip = "Remove to run test")>]
let ``9, being 10 - 1, is IX`` () =
    roman 9 |> should equal "IX"

[<Fact(Skip = "Remove to run test")>]
let ``20 is two X's`` () =
    roman 27 |> should equal "XXVII"

[<Fact(Skip = "Remove to run test")>]
let ``48 is not 50 - 2 but rather 40 + 8`` () =
    roman 48 |> should equal "XLVIII"

[<Fact(Skip = "Remove to run test")>]
let ``49 is not 40 + 5 + 4 but rather 50 - 10 + 10 - 1`` () =
    roman 49 |> should equal "XLIX"

[<Fact(Skip = "Remove to run test")>]
let ``50 is a single L`` () =
    roman 59 |> should equal "LIX"

[<Fact(Skip = "Remove to run test")>]
let ``90, being 100 - 10, is XC`` () =
    roman 93 |> should equal "XCIII"

[<Fact(Skip = "Remove to run test")>]
let ``100 is a single C`` () =
    roman 141 |> should equal "CXLI"

[<Fact(Skip = "Remove to run test")>]
let ``60, being 50 + 10, is LX`` () =
    roman 163 |> should equal "CLXIII"

[<Fact(Skip = "Remove to run test")>]
let ``400, being 500 - 100, is CD`` () =
    roman 402 |> should equal "CDII"

[<Fact(Skip = "Remove to run test")>]
let ``500 is a single D`` () =
    roman 575 |> should equal "DLXXV"

[<Fact(Skip = "Remove to run test")>]
let ``900, being 1000 - 100, is CM`` () =
    roman 911 |> should equal "CMXI"

[<Fact(Skip = "Remove to run test")>]
let ``1000 is a single M`` () =
    roman 1024 |> should equal "MXXIV"

[<Fact(Skip = "Remove to run test")>]
let ``3000 is three M's`` () =
    roman 3000 |> should equal "MMM"

