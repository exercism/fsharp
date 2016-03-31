module PascalsTriangleTest

open NUnit.Framework

open PascalsTriangle

[<Test>]
let ``One row`` () =
    Assert.That(triangle 1, Is.EqualTo([[1]]))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Two rows`` () =
    Assert.That(triangle 2, Is.EqualTo([[1]; [1; 1]]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three rows`` () =
    Assert.That(triangle 3, Is.EqualTo([[1]; [1; 1]; [1; 2; 1]]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Four rows`` () =
    Assert.That(triangle 4, Is.EqualTo([[1]; [1; 1]; [1; 2; 1]; [1; 3; 3; 1]]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Five rows`` () =
    Assert.That(triangle 5, Is.EqualTo([[1]; [1; 1]; [1; 2; 1]; [1; 3; 3; 1]; [1; 4; 6; 4; 1]]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Twenty rows`` () =
    Assert.That(triangle 20 |> List.last, Is.EqualTo([1; 19; 171; 969; 3876; 11628; 27132; 50388; 75582; 92378; 92378; 75582; 50388; 27132; 11628; 3876; 969; 171; 19; 1]))