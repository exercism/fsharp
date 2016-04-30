module SublistTest

open NUnit.Framework

open Sublist

[<Test>]
let ``Empty equals empty`` () =
    Assert.That(sublist [] [], Is.EqualTo(Equal))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Empty is a sublist of anything`` () =
    Assert.That(sublist [] [1; 2; 3; 4], Is.EqualTo(Sublist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Anything is a superlist of empty`` () =
    Assert.That(sublist [1; 2; 3; 4] [], Is.EqualTo(Superlist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``1 is not 2`` () =
    Assert.That(sublist [1] [2], Is.EqualTo(Unequal))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Compare larger equal lists`` () =
    let xs = List.replicate 1000 'x'
    Assert.That(sublist xs xs, Is.EqualTo(Equal))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist at start`` () =
    Assert.That(sublist [1; 2; 3] [1; 2; 3; 4; 5], Is.EqualTo(Sublist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist in middle`` () =
    Assert.That(sublist [4; 3; 2] [5; 4; 3; 2; 1], Is.EqualTo(Sublist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist at end`` () =
    Assert.That(sublist [3; 4; 5] [1; 2; 3; 4; 5], Is.EqualTo(Sublist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Partially matching sublist at start`` () =
    Assert.That(sublist [1; 1; 2] [1; 1; 1; 2], Is.EqualTo(Sublist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Sublist early in huge list`` () =
    Assert.That(sublist [3; 4; 5] [1 .. 1000000] , Is.EqualTo(Sublist))
 
[<Test>]
[<Ignore("Remove to run test")>]
let ``Huge sublist not in huge list`` () =
    Assert.That(sublist [10 .. 1000001] [1 .. 1000000], Is.EqualTo(Unequal))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist at start`` () =
    Assert.That(sublist [1; 2; 3; 4; 5] [1; 2; 3], Is.EqualTo(Superlist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist in middle`` () =
    Assert.That(sublist [5; 4; 3; 2; 1] [4; 3; 2], Is.EqualTo(Superlist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist at end`` () =
    Assert.That(sublist [1; 2; 3; 4; 5] [3; 4; 5], Is.EqualTo(Superlist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Partially matching superlist at start`` () =
    Assert.That(sublist [1; 1; 1; 2] [1; 1; 2], Is.EqualTo(Superlist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Superlist early in huge list`` () =
    Assert.That(sublist [1 .. 1000000] [3; 4; 5], Is.EqualTo(Superlist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recurring values sublist`` () =
    Assert.That(sublist [1; 2; 1; 2; 3] [1; 2; 3; 1; 2; 1; 2; 3; 2; 1], Is.EqualTo(Sublist))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Recurring values unequal`` () =
    Assert.That(sublist [1; 2; 1; 2; 3] [1; 2; 3; 1; 2; 3; 2; 3; 2; 1], Is.EqualTo(Unequal))