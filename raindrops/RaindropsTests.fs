module RaindropsTests
    
open NUnit.Framework
open Raindrops

[<TestFixture>]
type RaindropsTests() =
    [<TestCase(1, Result = "1")>]
    [<TestCase(52, Result = "52", Ignore = true)>]
    [<TestCase(12121, Result = "12121", Ignore = true)>]
    member tests.Non_primes_pass_through(number) =
        Raindrops().convert(number)

    [<TestCase(3)>]
    [<TestCase(6)>]
    [<TestCase(9)>]
    [<Ignore>]
    member tests.Numbers_containing_3_as_a_prime_factor_give_pling(number) =
        Assert.That(Raindrops().convert(number), Is.EqualTo("Pling"))

    [<TestCase(5)>]
    [<TestCase(10)>]
    [<TestCase(25)>]
    [<Ignore>]
    member tests.Numbers_containing_5_as_a_prime_factor_give_plang(number) =
        Assert.That(Raindrops().convert(number), Is.EqualTo("Plang"))

    [<TestCase(7)>]
    [<TestCase(14)>]
    [<TestCase(49)>]
    [<Ignore>]
    member tests.Numbers_containing_7_as_a_prime_factor_give_plong(number) =
        Assert.That(Raindrops().convert(number), Is.EqualTo("Plong"))

    [<TestCase(15, Result = "PlingPlang")>]
    [<TestCase(21, Result = "PlingPlong")>]
    [<TestCase(35, Result = "PlangPlong")>]
    [<TestCase(105, Result = "PlingPlangPlong")>]
    [<Ignore>]
    member tests.Numbers_containing_multiple_prime_factors_give_all_results_concatenated(number) =
        Raindrops().convert(number)