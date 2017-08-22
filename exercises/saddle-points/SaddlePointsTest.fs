module SaddlePointTest

open NUnit.Framework

open SaddlePoints

[<Test>]
let ``Readme example`` () =
    let values = [ [ 9; 8; 7 ]; 
                   [ 5; 3; 2 ]; 
                   [ 6; 6; 7 ] ]
    let actual = saddlePoints values
    Assert.That(actual, Is.EqualTo([(1, 0)]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``No saddle point`` () =
    let values = [ [ 2; 1 ]; 
                   [ 1; 2 ] ]
    let actual = saddlePoints values
    Assert.That(actual, Is.Empty)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Saddle point`` () =
    let values = [ [ 1; 2 ]; 
                   [ 3; 4 ] ]
    let actual = saddlePoints values
    Assert.That(actual, Is.EqualTo([(0, 1)]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Another saddle point`` () =
    let values = [ [ 18;  3; 39; 19;  91 ]; 
                   [ 38; 10;  8; 77; 320 ]; 
                   [  3;  4;  8;  6;   7 ] ]
    let actual = saddlePoints values
    Assert.That(actual, Is.EqualTo([(2, 2)]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Multiple saddle points`` () =
    let values = [ [ 4; 5; 4 ];
                   [ 3; 5; 5 ];
                   [ 1; 5; 4 ] ]
    let actual = saddlePoints values
    Assert.That(actual, Is.EqualTo([(0, 1); (1, 1); (2, 1)]))   