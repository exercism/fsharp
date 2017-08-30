module RomanNumeralTest

open Xunit
open FsUnit
open RomanNumeral
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData(0, "")>]
[<InlineData(1, "I")>]
[<InlineData(2, "II")>]
[<InlineData(3, "III")>]
[<InlineData(4, "IV")>]
[<InlineData(5, "V")>]
[<InlineData(6, "VI")>]
[<InlineData(9, "IX")>]
[<InlineData(27, "XXVII")>]
[<InlineData(48, "XLVIII")>]
[<InlineData(59, "LIX")>]
[<InlineData(93, "XCIII")>]
[<InlineData(141, "CXLI")>]
[<InlineData(163, "CLXIII")>]
[<InlineData(402, "CDII")>]
[<InlineData(575, "DLXXV")>]
[<InlineData(911, "CMXI")>]
[<InlineData(1024, "MXXIV")>]
[<InlineData(3000, "MMM")>]
let ``Convert roman to arabic numerals`` arabicNumeral expected =
    toRoman arabicNumeral |> should equal expected