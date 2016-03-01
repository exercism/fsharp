module TrinaryTests

open NUnit.Framework
open Trinary

[<TestFixture>]
type TrinaryTests() =
    
    [<TestCase("1", ExpectedResult = 1)>]
    [<TestCase("2", ExpectedResult = 2, Ignore = true)>]
    [<TestCase("10", ExpectedResult = 3, Ignore = true)>]
    [<TestCase("11", ExpectedResult = 4, Ignore = true)>]
    [<TestCase("100", ExpectedResult = 9, Ignore = true)>]
    [<TestCase("112", ExpectedResult = 14, Ignore = true)>]
    [<TestCase("222", ExpectedResult = 26, Ignore = true)>]
    [<TestCase("1122000120", ExpectedResult = 32091, Ignore = true)>]
    member tests.Binary_converts_to_decimal(input) =
        Trinary(input).toDecimal()

    [<TestCase("carrot", Ignore = true)>]
    [<TestCase("3", Ignore = true)>]
    [<TestCase("6", Ignore = true)>]
    [<TestCase("9", Ignore = true)>]
    [<TestCase("124578", Ignore = true)>]
    [<TestCase("abc1z", Ignore = true)>]
    member tests.Invalid_binary_is_decimal_0(input) =
        Assert.That(Trinary(input).toDecimal(), Is.EqualTo(0))