// This file was auto-generated based on version 1.1.0 of the canonical data.

module SaddlePointsTest

open FsUnit.Xunit
open Xunit

open SaddlePoints

[<Fact>]
let ``Can identify single saddle point`` () =
    let matrix = 
        [ [9; 8; 7];
          [5; 3; 2];
          [6; 6; 7] ]
    saddlePoints matrix |> should equal [(1, 0)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify that empty matrix has no saddle points`` () =
    let matrix = [[]]
    saddlePoints matrix |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Can identify lack of saddle points when there are none`` () =
    let matrix = 
        [ [1; 2; 3];
          [3; 1; 2];
          [2; 3; 1] ]
    saddlePoints matrix |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Can identify multiple saddle points`` () =
    let matrix = 
        [ [4; 5; 4];
          [3; 5; 5];
          [1; 5; 4] ]
    saddlePoints matrix |> should equal [(0, 1); (1, 1); (2, 1)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify saddle point in bottom right corner`` () =
    let matrix = 
        [ [8; 7; 9];
          [6; 7; 6];
          [3; 2; 5] ]
    saddlePoints matrix |> should equal [(2, 2)]

