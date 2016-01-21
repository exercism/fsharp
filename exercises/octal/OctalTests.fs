module OctalTests

open NUnit.Framework
open Octal

[<TestFixture>]
type OctalTests() =
    
    [<TestCase("1", Result = 1)>]
    [<TestCase("10", Result = 8, Ignore = true)>]
    [<TestCase("17", Result = 15, Ignore = true)>]
    [<TestCase("11", Result = 9, Ignore = true)>]
    [<TestCase("130", Result = 88, Ignore = true)>]
    [<TestCase("2047", Result = 1063, Ignore = true)>]
    [<TestCase("7777", Result = 4095, Ignore = true)>]
    [<TestCase("1234567", Result = 342391, Ignore = true)>]
    member tests.Octal_converts_to_decimal(input) =
        Octal(input).toDecimal()

    [<TestCase("carrot", Ignore = true)>]
    [<TestCase("8", Ignore = true)>]
    [<TestCase("9", Ignore = true)>]
    [<TestCase("6789", Ignore = true)>]
    [<TestCase("abc1z", Ignore = true)>]
    member tests.Invalid_octal_is_decimal_0(input) =
        Assert.That(Octal(input).toDecimal(), Is.EqualTo(0))