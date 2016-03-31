module PrimeFactorsTest

open NUnit.Framework

open PrimeFactors

[<Test>]
let ``Test 1`` () =
    Assert.That(primeFactorsFor 1L, Is.EqualTo([]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 2`` () =
    Assert.That(primeFactorsFor 2L, Is.EqualTo([2]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 3`` () =
    Assert.That(primeFactorsFor 3L, Is.EqualTo([3]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 4`` () =
    Assert.That(primeFactorsFor 4L, Is.EqualTo([2; 2]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 6`` () =
    Assert.That(primeFactorsFor 6L, Is.EqualTo([2; 3]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 8`` () =
    Assert.That(primeFactorsFor 8L, Is.EqualTo([2; 2; 2]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 9`` () =
    Assert.That(primeFactorsFor 9L, Is.EqualTo([3; 3]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 27`` () =
    Assert.That(primeFactorsFor 27L, Is.EqualTo([3; 3; 3]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 625`` () =
    Assert.That(primeFactorsFor 625L, Is.EqualTo([5; 5; 5; 5]))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test 901255`` () =
    Assert.That(primeFactorsFor 901255L, Is.EqualTo([5; 17; 23; 461]))