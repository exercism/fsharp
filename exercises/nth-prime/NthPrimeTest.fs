module NthPrimeTest

open NUnit.Framework
open NthPrime

[<Test>]
let ``First prime`` () =
    Assert.That(nthPrime 1, Is.EqualTo(2))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Second prime`` () =
    Assert.That(nthPrime 2, Is.EqualTo(3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Third prime`` () =
    Assert.That(nthPrime 3, Is.EqualTo(5))

[<Test>]
[<Ignore("Remove to run test")>]
let ``4th prime`` () =
    Assert.That(nthPrime 4, Is.EqualTo(7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``5th prime`` () =
    Assert.That(nthPrime 5, Is.EqualTo(11))

[<Test>]
[<Ignore("Remove to run test")>]
let ``6th prime`` () =
    Assert.That(nthPrime 6, Is.EqualTo(13))

[<Test>]
[<Ignore("Remove to run test")>]
let ``7th prime`` () =
    Assert.That(nthPrime 7, Is.EqualTo(17))

[<Test>]
[<Ignore("Remove to run test")>]
let ``8th prime`` () =
    Assert.That(nthPrime 8, Is.EqualTo(19))

[<Test>]
[<Ignore("Remove to run test")>]
let ``1000th prime`` () =
    Assert.That(nthPrime 1000, Is.EqualTo(7919))

[<Test>]
[<Ignore("Remove to run test")>]
let ``10000th prime`` () =
    Assert.That(nthPrime 10000, Is.EqualTo(104729))

[<Test>]
[<Ignore("Remove to run test")>]
let ``10001th prime`` () =
    Assert.That(nthPrime 10001, Is.EqualTo(104743))