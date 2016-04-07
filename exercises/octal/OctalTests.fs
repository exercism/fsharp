module OctalTests

open NUnit.Framework
open Octal
    
[<TestCase("1", ExpectedResult = 1)>]
[<TestCase("10", ExpectedResult = 8, Ignore = "Remove to run test case")>]
[<TestCase("17", ExpectedResult = 15, Ignore = "Remove to run test case")>]
[<TestCase("11", ExpectedResult = 9, Ignore = "Remove to run test case")>]
[<TestCase("130", ExpectedResult = 88, Ignore = "Remove to run test case")>]
[<TestCase("2047", ExpectedResult = 1063, Ignore = "Remove to run test case")>]
[<TestCase("7777", ExpectedResult = 4095, Ignore = "Remove to run test case")>]
[<TestCase("1234567", ExpectedResult = 342391, Ignore = "Remove to run test case")>]
let ``Octal converts to decimal`` (input) =
    toDecimal input

[<TestCase("carrot", Ignore = "Remove to run test case")>]
[<TestCase("8", Ignore = "Remove to run test case")>]
[<TestCase("9", Ignore = "Remove to run test case")>]
[<TestCase("6789", Ignore = "Remove to run test case")>]
[<TestCase("abc1z", Ignore = "Remove to run test case")>]
let ``Invalid octal is decimal 0`` (input) =
    Assert.That(toDecimal input, Is.EqualTo(0))