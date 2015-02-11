module RomanNumeralTests

open NUnit.Framework
open RomanNumeral

[<TestFixture>]
type RomanNumeralTests() =
    
    [<TestCase(0, Result = "")>]
    [<TestCase(1, Result = "I", Ignore = true)>]
    [<TestCase(2, Result = "II", Ignore = true)>]
    [<TestCase(3, Result = "III", Ignore = true)>]
    [<TestCase(4, Result = "IV", Ignore = true)>]
    [<TestCase(5, Result = "V", Ignore = true)>]
    [<TestCase(6, Result = "VI", Ignore = true)>]
    [<TestCase(9, Result = "IX", Ignore = true)>]
    [<TestCase(27, Result = "XXVII", Ignore = true)>]
    [<TestCase(48, Result = "XLVIII", Ignore = true)>]
    [<TestCase(59, Result = "LIX", Ignore = true)>]
    [<TestCase(93, Result = "XCIII", Ignore = true)>]
    [<TestCase(141, Result = "CXLI", Ignore = true)>]
    [<TestCase(163, Result = "CLXIII", Ignore = true)>]
    [<TestCase(402, Result = "CDII", Ignore = true)>]
    [<TestCase(575, Result = "DLXXV", Ignore = true)>]
    [<TestCase(911, Result = "CMXI", Ignore = true)>]
    [<TestCase(1024, Result = "MXXIV", Ignore = true)>]
    [<TestCase(3000, Result = "MMM", Ignore = true)>]
    member tests.Convert_roman_to_arabic_numerals(arabicNumeral) =
        RomanNumeral().toRoman(arabicNumeral)