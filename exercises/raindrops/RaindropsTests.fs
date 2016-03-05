module RaindropsTests
    
open NUnit.Framework
open Raindrops

type RaindropsTests() =
    [<TestCase(1, ExpectedResult = "1")>]
    [<TestCase(52, ExpectedResult = "52", Ignore = "Remove to run test case")>]
    [<TestCase(12121, ExpectedResult = "12121", Ignore = "Remove to run test case")>]
    member tests.Non_primes_pass_through(number) =
        Raindrops().convert(number)

    [<TestCase(3, Ignore = "Remove to run test case")>]
    [<TestCase(6, Ignore = "Remove to run test case")>]
    [<TestCase(9, Ignore = "Remove to run test case")>]
    member tests.Numbers_containing_3_as_a_prime_factor_give_pling(number) =
        Assert.That(Raindrops().convert(number), Is.EqualTo("Pling"))

    [<TestCase(5, Ignore = "Remove to run test case")>]
    [<TestCase(10, Ignore = "Remove to run test case")>]
    [<TestCase(25, Ignore = "Remove to run test case")>]
    member tests.Numbers_containing_5_as_a_prime_factor_give_plang(number) =
        Assert.That(Raindrops().convert(number), Is.EqualTo("Plang"))

    [<TestCase(7, Ignore = "Remove to run test case")>]
    [<TestCase(14, Ignore = "Remove to run test case")>]
    [<TestCase(49, Ignore = "Remove to run test case")>]
    member tests.Numbers_containing_7_as_a_prime_factor_give_plong(number) =
        Assert.That(Raindrops().convert(number), Is.EqualTo("Plong"))

    [<TestCase(15, ExpectedResult = "PlingPlang", Ignore = "Remove to run test case")>]
    [<TestCase(21, ExpectedResult = "PlingPlong", Ignore = "Remove to run test case")>]
    [<TestCase(35, ExpectedResult = "PlangPlong", Ignore = "Remove to run test case")>]
    [<TestCase(105, ExpectedResult = "PlingPlangPlong", Ignore = "Remove to run test case")>]
    [<Ignore("Remove to run test")>]
    member tests.Numbers_containing_multiple_prime_factors_give_all_results_concatenated(number) =
        Raindrops().convert(number)