module SumOfMultiplesTest

open NUnit.Framework
open SumOfMultiples

[<Test>]
let ``Sum to 1`` () =
    Assert.That(sumOfMultiples [3; 5] 0, Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 3`` () =
    Assert.That(sumOfMultiples [3; 5] 3, Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 10`` () =
    Assert.That(sumOfMultiples [3; 5] 10, Is.EqualTo(23))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 20`` () =
    Assert.That(sumOfMultiples [7; 13; 17] 20, Is.EqualTo(51))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sum to 10000`` () =
    Assert.That(sumOfMultiples [43; 47] 10000, Is.EqualTo(2203160))