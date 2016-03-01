module OctalTests

open NUnit.Framework
open Octal

[<TestFixture>]
type OctalTests() =
    
    [<TestCase("1", ExpectedResult = 1)>]
    [<TestCase("10", ExpectedResult = 8, Ignore = true)>]
    [<TestCase("17", ExpectedResult = 15, Ignore = true)>]
    [<TestCase("11", ExpectedResult = 9, Ignore = true)>]
    [<TestCase("130", ExpectedResult = 88, Ignore = true)>]
    [<TestCase("2047", ExpectedResult = 1063, Ignore = true)>]
    [<TestCase("7777", ExpectedResult = 4095, Ignore = true)>]
    [<TestCase("1234567", ExpectedResult = 342391, Ignore = true)>]
    member tests.Octal_converts_to_decimal(input) =
        Octal(input).toDecimal()

    [<TestCase("carrot", Ignore = true)>]
    [<TestCase("8", Ignore = true)>]
    [<TestCase("9", Ignore = true)>]
    [<TestCase("6789", Ignore = true)>]
    [<TestCase("abc1z", Ignore = true)>]
    member tests.Invalid_octal_is_decimal_0(input) =
        Assert.That(Octal(input).toDecimal(), Is.EqualTo(0))