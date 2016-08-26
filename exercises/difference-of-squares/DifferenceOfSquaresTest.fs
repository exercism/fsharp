module DifferenceOfSquaresTest

open NUnit.Framework
open DifferenceOfSquares
    
[<Test>]
let ``Square of sums to 5`` () =
    Assert.That(squareOfSums 5, Is.EqualTo(225))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum of squares to 5`` () =
    Assert.That(sumOfSquares 5, Is.EqualTo(55))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of sums to 5`` () =
    Assert.That(difference 5, Is.EqualTo(170))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Square of sums to 10`` () =
    Assert.That(squareOfSums 10, Is.EqualTo(3025))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum of squares to 10`` () =
    Assert.That(sumOfSquares 10, Is.EqualTo(385))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of sums to 10`` () =
    Assert.That(difference 10, Is.EqualTo(2640))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Square of sums to 100`` () =
    Assert.That(squareOfSums 100, Is.EqualTo(25502500))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum of squares to 100`` () =
    Assert.That(sumOfSquares 100, Is.EqualTo(338350))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Difference of sums to 100`` () =
    Assert.That(difference 100, Is.EqualTo(25164150))