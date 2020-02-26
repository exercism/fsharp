// This file was auto-generated based on version 1.5.0 of the canonical data.

module SaddlePointsTests

open FsUnit.Xunit
open Xunit

open SaddlePoints

[<Fact>]
let ``Can identify single saddle point`` () =
    let matrix = 
        [ [9; 8; 7];
          [5; 3; 2];
          [6; 6; 7] ]
    saddlePoints matrix |> should equal [(2, 1)]

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
let ``Can identify multiple saddle points in a column`` () =
    let matrix = 
        [ [4; 5; 4];
          [3; 5; 5];
          [1; 5; 4] ]
    saddlePoints matrix |> should equal [(1, 2); (2, 2); (3, 2)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify multiple saddle points in a row`` () =
    let matrix = 
        [ [6; 7; 8];
          [5; 5; 5];
          [7; 5; 6] ]
    saddlePoints matrix |> should equal [(2, 1); (2, 2); (2, 3)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify saddle point in bottom right corner`` () =
    let matrix = 
        [ [8; 7; 9];
          [6; 7; 6];
          [3; 2; 5] ]
    saddlePoints matrix |> should equal [(3, 3)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify saddle points in a non square matrix`` () =
    let matrix = 
        [ [3; 1; 3];
          [3; 2; 4] ]
    saddlePoints matrix |> should equal [(1, 1); (1, 3)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify that saddle points in a single column matrix are those with the minimum value`` () =
    let matrix = 
        [ [2];
          [1];
          [4];
          [1] ]
    saddlePoints matrix |> should equal [(2, 1); (4, 1)]

[<Fact(Skip = "Remove to run test")>]
let ``Can identify that saddle points in a single row matrix are those with the maximum value`` () =
    let matrix = [[2; 5; 3; 5]]
    saddlePoints matrix |> should equal [(1, 2); (1, 4)]

