module PythagoreanTripletTest

open NUnit.Framework

open PythagoreanTriplet
    
[<TestCase(3, 4, 5, ExpectedResult = true)>]
[<TestCase(3, 5, 4, ExpectedResult = true, Ignore = "Remove to run test case")>]
[<TestCase(4, 3, 5, ExpectedResult = true, Ignore = "Remove to run test case")>]
[<TestCase(4, 5, 3, ExpectedResult = true, Ignore = "Remove to run test case")>]
[<TestCase(5, 3, 4, ExpectedResult = true, Ignore = "Remove to run test case")>]
[<TestCase(5, 4, 3, ExpectedResult = true, Ignore = "Remove to run test case")>]
[<TestCase(3, 3, 3, ExpectedResult = false, Ignore = "Remove to run test case")>]
[<TestCase(5, 6, 7, ExpectedResult = false, Ignore = "Remove to run test case")>]
let ``Can recognize a valid pythagorean`` (x: int) (y: int) (z: int) =
    let actual = triplet x y z
    isPythagorean actual
   
[<Test>]
[<Ignore("Remove to run test")>]
let ``Can create simple triplets`` () =
    let actual = pythagoreanTriplets 1 10
    Assert.That(actual, Is.EqualTo([triplet 3 4 5; triplet 6 8 10]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can create more triplets`` () =
    let actual = pythagoreanTriplets 11 20
    Assert.That(actual, Is.EqualTo([triplet 12 16 20]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can create complex triplets`` () =
    let actual = pythagoreanTriplets 56 95
    Assert.That(actual, Is.EqualTo([triplet 57 76 95; triplet 60 63 87]))