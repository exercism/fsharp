module BinaryTests

open NUnit.Framework
open Binary
    
[<TestCase("1", ExpectedResult = 1)>]
[<TestCase("10", ExpectedResult = 2, Ignore = "Remove to run test case")>]
[<TestCase("11", ExpectedResult = 3, Ignore = "Remove to run test case")>]
[<TestCase("100", ExpectedResult = 4, Ignore = "Remove to run test case")>]
[<TestCase("1001", ExpectedResult = 9, Ignore = "Remove to run test case")>]
[<TestCase("11010", ExpectedResult = 26, Ignore = "Remove to run test case")>]
[<TestCase("10001101000", ExpectedResult = 1128, Ignore = "Remove to run test case")>]
let ``Binary converts to decimal`` (input: string) =
    toDecimal input

[<TestCase("carrot", Ignore = "Remove to run test case")>]
[<TestCase("2", Ignore = "Remove to run test case")>]
[<TestCase("5", Ignore = "Remove to run test case")>]
[<TestCase("9", Ignore = "Remove to run test case")>]
[<TestCase("a10", Ignore = "Remove to run test case")>]
[<TestCase("100b", Ignore = "Remove to run test case")>]
[<TestCase("10c01", Ignore = "Remove to run test case")>]
[<TestCase("134678", Ignore = "Remove to run test case")>]
[<TestCase("abc10z", Ignore = "Remove to run test case")>]
let ``Invalid binary is decimal 0`` (input: string) =
    Assert.That(toDecimal input, Is.EqualTo(0))