module HexadecimalTests

open NUnit.Framework
open Hexadecimal

[<TestCase("1", ExpectedResult = 1)>]
[<TestCase("c", ExpectedResult = 12, Ignore = "Remove to run test case")>]
[<TestCase("10", ExpectedResult = 16, Ignore = "Remove to run test case")>]
[<TestCase("af", ExpectedResult = 175, Ignore = "Remove to run test case")>]
[<TestCase("100", ExpectedResult = 256, Ignore = "Remove to run test case")>]
[<TestCase("19ace", ExpectedResult = 105166, Ignore = "Remove to run test case")>]
[<TestCase("19ace", ExpectedResult = 105166, Ignore = "Remove to run test case")>]
[<TestCase("000000", ExpectedResult = 0, Ignore = "Remove to run test case")>]
[<TestCase("ffffff", ExpectedResult = 16777215, Ignore = "Remove to run test case")>]
[<TestCase("ffff00", ExpectedResult = 16776960, Ignore = "Remove to run test case")>]
let ``Hexadecimal_converts_to_decimal`` hexadecimal =
    toDecimal hexadecimal
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Invalid_hexadecimal_is_decimal_0`` () =
    Assert.That(toDecimal "carrot", Is.EqualTo(0))