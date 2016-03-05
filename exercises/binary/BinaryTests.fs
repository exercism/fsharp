module BinaryTests

open NUnit.Framework
open Binary

type BinaryTests() =
    
    [<TestCase("1", ExpectedResult = 1)>]
    [<TestCase("10", ExpectedResult = 2, Ignore = "Remove to run test case")>]
    [<TestCase("11", ExpectedResult = 3, Ignore = "Remove to run test case")>]
    [<TestCase("100", ExpectedResult = 4, Ignore = "Remove to run test case")>]
    [<TestCase("1001", ExpectedResult = 9, Ignore = "Remove to run test case")>]
    [<TestCase("11010", ExpectedResult = 26, Ignore = "Remove to run test case")>]
    [<TestCase("10001101000", ExpectedResult = 1128, Ignore = "Remove to run test case")>]
    member tests.Binary_converts_to_decimal(input) =
        Binary(input).toDecimal()

    [<TestCase("carrot", Ignore = "Remove to run test case")>]
    [<TestCase("2", Ignore = "Remove to run test case")>]
    [<TestCase("5", Ignore = "Remove to run test case")>]
    [<TestCase("9", Ignore = "Remove to run test case")>]
    [<TestCase("134678", Ignore = "Remove to run test case")>]
    [<TestCase("abc10z", Ignore = "Remove to run test case")>]
    member tests.Invalid_binary_is_decimal_0(input) =
        Assert.That(Binary(input).toDecimal(), Is.EqualTo(0))