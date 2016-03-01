module RomanNumeralTests

open NUnit.Framework
open RomanNumeral

[<TestFixture>]
type RomanNumeralTests() =
    
    [<TestCase(0, ExpectedResult = "")>]
    [<TestCase(1, ExpectedResult = "I", Ignore = true)>]
    [<TestCase(2, ExpectedResult = "II", Ignore = true)>]
    [<TestCase(3, ExpectedResult = "III", Ignore = true)>]
    [<TestCase(4, ExpectedResult = "IV", Ignore = true)>]
    [<TestCase(5, ExpectedResult = "V", Ignore = true)>]
    [<TestCase(6, ExpectedResult = "VI", Ignore = true)>]
    [<TestCase(9, ExpectedResult = "IX", Ignore = true)>]
    [<TestCase(27, ExpectedResult = "XXVII", Ignore = true)>]
    [<TestCase(48, ExpectedResult = "XLVIII", Ignore = true)>]
    [<TestCase(59, ExpectedResult = "LIX", Ignore = true)>]
    [<TestCase(93, ExpectedResult = "XCIII", Ignore = true)>]
    [<TestCase(141, ExpectedResult = "CXLI", Ignore = true)>]
    [<TestCase(163, ExpectedResult = "CLXIII", Ignore = true)>]
    [<TestCase(402, ExpectedResult = "CDII", Ignore = true)>]
    [<TestCase(575, ExpectedResult = "DLXXV", Ignore = true)>]
    [<TestCase(911, ExpectedResult = "CMXI", Ignore = true)>]
    [<TestCase(1024, ExpectedResult = "MXXIV", Ignore = true)>]
    [<TestCase(3000, ExpectedResult = "MMM", Ignore = true)>]
    member tests.Convert_roman_to_arabic_numerals(arabicNumeral) =
        RomanNumeral().toRoman(arabicNumeral)