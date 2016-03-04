module HexadecimalTests

open NUnit.Framework
open Hexadecimal

type HexadecimalTests() =

    [<TestCase("1", ExpectedResult = 1)>]
    [<TestCase("c", ExpectedResult = 12, Ignore = true)>]
    [<TestCase("10", ExpectedResult = 16, Ignore = true)>]
    [<TestCase("af", ExpectedResult = 175, Ignore = true)>]
    [<TestCase("100", ExpectedResult = 256, Ignore = true)>]
    [<TestCase("19ace", ExpectedResult = 105166, Ignore = true)>]
    [<TestCase("19ace", ExpectedResult = 105166, Ignore = true)>]
    [<TestCase("000000", ExpectedResult = 0, Ignore = true)>]
    [<TestCase("ffffff", ExpectedResult = 16777215, Ignore = true)>]
    [<TestCase("ffff00", ExpectedResult = 16776960, Ignore = true)>]
    member test.Hexadecimal_converts_to_decimal(hexadecimal) =
        toDecimal(hexadecimal)
    
    [<Test>]
    [<Ignore>]
    member test.Invalid_hexadecimal_is_decimal_0() =
        Assert.That(toDecimal("carrot"), Is.EqualTo(0))