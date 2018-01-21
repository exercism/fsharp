// This file was created manually and its version is 1.0.0.

module TrinaryTest

open NUnit.Framework
open Trinary
    
[<TestCase("1", ExpectedResult = 1)>]
[<TestCase("2", ExpectedResult = 2, Ignore = "Remove to run test case")>]
[<TestCase("10", ExpectedResult = 3, Ignore = "Remove to run test case")>]
[<TestCase("11", ExpectedResult = 4, Ignore = "Remove to run test case")>]
[<TestCase("100", ExpectedResult = 9, Ignore = "Remove to run test case")>]
[<TestCase("112", ExpectedResult = 14, Ignore = "Remove to run test case")>]
[<TestCase("222", ExpectedResult = 26, Ignore = "Remove to run test case")>]
[<TestCase("1122000120", ExpectedResult = 32091, Ignore = "Remove to run test case")>]
let ``Binary converts to decimal`` input =
    toDecimal input

[<TestCase("carrot", Ignore = "Remove to run test case")>]
[<TestCase("3", Ignore = "Remove to run test case")>]
[<TestCase("6", Ignore = "Remove to run test case")>]
[<TestCase("9", Ignore = "Remove to run test case")>]
[<TestCase("124578", Ignore = "Remove to run test case")>]
[<TestCase("abc1z", Ignore = "Remove to run test case")>]
let ``Invalid binary is decimal 0`` input =
    Assert.That(toDecimal input, Is.EqualTo(0))
