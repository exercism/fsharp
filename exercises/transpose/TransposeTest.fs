module TransposeTest

open NUnit.Framework

open Transpose

[<Test>]
let ``Empty list`` () = 
    let input = []
    let expected = []
    Assert.That(transpose input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]  
let ``One row`` () = 
    let input = 
        [ 
            [2; 3; 5; 7; 11; 13] 
        ]
    let expected = 
        [ 
            [2];
            [3];
            [5];
            [7];
            [11];
            [13] 
        ]
    Assert.That(transpose input, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]  
let ``One column`` () = 
    let input = 
        [ 
            [2];
            [3];
            [5];
            [7];
            [11];
            [13] 
        ]
    let expected = 
        [ 
            [2; 3; 5; 7; 11; 13] 
        ]
    Assert.That(transpose input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]  
let ``Square`` () = 
    let input = 
        [ 
            [ 2;  3;  5]; 
            [ 7; 11; 13]; 
            [19; 21; 23] 
        ]
    let expected = 
        [ 
            [2;  7; 19];
            [3; 11; 21];
            [5; 13; 23] 
        ]
    Assert.That(transpose input, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]  
let ``Rectangle`` () = 
    let input = 
        [ 
            [ 2;  3]; 
            [ 5;  7]; 
            [11; 13]; 
            [19; 21]; 
            [23; 29] 
        ]
    let expected = 
        [ 
            [2; 5; 11; 19; 23];
            [3; 7; 13; 21; 29] 
        ]
    Assert.That(transpose input, Is.EqualTo(expected))