module BinaryTests

open NUnit.Framework
open Binary

type BinaryTests() =
    
    [<TestCase("1", ExpectedResult = 1)>]
    [<TestCase("10", ExpectedResult = 2, Ignore = true)>]
    [<TestCase("11", ExpectedResult = 3, Ignore = true)>]
    [<TestCase("100", ExpectedResult = 4, Ignore = true)>]
    [<TestCase("1001", ExpectedResult = 9, Ignore = true)>]
    [<TestCase("11010", ExpectedResult = 26, Ignore = true)>]
    [<TestCase("10001101000", ExpectedResult = 1128, Ignore = true)>]
    member tests.Binary_converts_to_decimal(input) =
        Binary(input).toDecimal()

    [<TestCase("carrot", Ignore = true)>]
    [<TestCase("2", Ignore = true)>]
    [<TestCase("5", Ignore = true)>]
    [<TestCase("9", Ignore = true)>]
    [<TestCase("134678", Ignore = true)>]
    [<TestCase("abc10z", Ignore = true)>]
    member tests.Invalid_binary_is_decimal_0(input) =
        Assert.That(Binary(input).toDecimal(), Is.EqualTo(0))