module RaindropsTest
    
open NUnit.Framework
open Raindrops

[<TestCase(1, ExpectedResult = "1")>]
[<TestCase(52, ExpectedResult = "52", Ignore = "Remove to run test case")>]
[<TestCase(12121, ExpectedResult = "12121", Ignore = "Remove to run test case")>]
let ``Non primes pass through`` (number) =
    convert number

[<TestCase(3, Ignore = "Remove to run test case")>]
[<TestCase(6, Ignore = "Remove to run test case")>]
[<TestCase(9, Ignore = "Remove to run test case")>]
let ``Numbers containing 3 as a prime factor give pling`` (number) =
    Assert.That(convert number, Is.EqualTo("Pling"))

[<TestCase(5, Ignore = "Remove to run test case")>]
[<TestCase(10, Ignore = "Remove to run test case")>]
[<TestCase(25, Ignore = "Remove to run test case")>]
let ``Numbers containing 5 as a prime factor give plang`` (number) =
    Assert.That(convert number, Is.EqualTo("Plang"))

[<TestCase(7, Ignore = "Remove to run test case")>]
[<TestCase(14, Ignore = "Remove to run test case")>]
[<TestCase(49, Ignore = "Remove to run test case")>]
let ``Numbers containing 7 as a prime factor give plong`` (number) =
    Assert.That(convert number, Is.EqualTo("Plong"))

[<TestCase(15, ExpectedResult = "PlingPlang", Ignore = "Remove to run test case")>]
[<TestCase(21, ExpectedResult = "PlingPlong", Ignore = "Remove to run test case")>]
[<TestCase(35, ExpectedResult = "PlangPlong", Ignore = "Remove to run test case")>]
[<TestCase(105, ExpectedResult = "PlingPlangPlong", Ignore = "Remove to run test case")>]    
let ``Numbers containing multiple prime factors give all results concatenated`` (number) =
    convert number