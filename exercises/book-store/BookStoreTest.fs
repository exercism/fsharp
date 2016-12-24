module BookStoreTest

open System
open NUnit.Framework
open BookStore

[<Test>]
let ``Basket with single book`` () =
    Assert.That(calculateTotalCost [1], Is.EqualTo(8))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with two of same book`` () =
    Assert.That(calculateTotalCost [2; 2], Is.EqualTo(16))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Empty basket`` () =
    Assert.That(calculateTotalCost [], Is.EqualTo(0))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with two different books`` () =
    Assert.That(calculateTotalCost [1; 2], Is.EqualTo(15.2))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with three different books`` () =
    Assert.That(calculateTotalCost [1; 2; 3], Is.EqualTo(21.6))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with four different books`` () =
    Assert.That(calculateTotalCost [1; 2; 3; 4], Is.EqualTo(25.6))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with five different books`` () =
    Assert.That(calculateTotalCost [1; 2; 3; 4; 5], Is.EqualTo(30))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with eight books`` () =
    Assert.That(calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 5], Is.EqualTo(51.20))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with nine books`` () =
    Assert.That(calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5], Is.EqualTo(55.60))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with ten books`` () =
    Assert.That(calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5; 5], Is.EqualTo(60))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with eleven books`` () =
    Assert.That(calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1], Is.EqualTo(68))

[<Ignore("Remove to run test")>]
[<Test>]
let ``Basket with twelve books`` () =
    Assert.That(calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1; 2], Is.EqualTo(75.20))