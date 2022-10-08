module RomanNumeralsTests

open FsUnit.Xunit
open Xunit

open RomanNumerals

[<Fact>]
let ``1 is I`` () =
    roman 1 |> should equal "I"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``2 is II`` () =
    roman 2 |> should equal "II"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``3 is III`` () =
    roman 3 |> should equal "III"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``4 is IV`` () =
    roman 4 |> should equal "IV"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``5 is V`` () =
    roman 5 |> should equal "V"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``6 is VI`` () =
    roman 6 |> should equal "VI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``9 is IX`` () =
    roman 9 |> should equal "IX"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``27 is XXVII`` () =
    roman 27 |> should equal "XXVII"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``48 is XLVIII`` () =
    roman 48 |> should equal "XLVIII"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``49 is XLIX`` () =
    roman 49 |> should equal "XLIX"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``59 is LIX`` () =
    roman 59 |> should equal "LIX"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``93 is XCIII`` () =
    roman 93 |> should equal "XCIII"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``141 is CXLI`` () =
    roman 141 |> should equal "CXLI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``163 is CLXIII`` () =
    roman 163 |> should equal "CLXIII"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``402 is CDII`` () =
    roman 402 |> should equal "CDII"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``575 is DLXXV`` () =
    roman 575 |> should equal "DLXXV"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``911 is CMXI`` () =
    roman 911 |> should equal "CMXI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``1024 is MXXIV`` () =
    roman 1024 |> should equal "MXXIV"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``3000 is MMM`` () =
    roman 3000 |> should equal "MMM"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``16 is XVI`` () =
    roman 16 |> should equal "XVI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``66 is LXVI`` () =
    roman 66 |> should equal "LXVI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``166 is CLXVI`` () =
    roman 166 |> should equal "CLXVI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``666 is DCLXVI`` () =
    roman 666 |> should equal "DCLXVI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``1666 is MDCLXVI`` () =
    roman 1666 |> should equal "MDCLXVI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``3001 is MMMI`` () =
    roman 3001 |> should equal "MMMI"

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``3999 is MMMCMXCIX`` () =
    roman 3999 |> should equal "MMMCMXCIX"

