// This file was created manually and its version is 1.0.0.

module SaddlePointTest

open Xunit
open FsUnit.Xunit

open SaddlePoints

[<Fact>]
let ``Readme example`` () =
    let values = [ [ 9; 8; 7 ]; 
                   [ 5; 3; 2 ]; 
                   [ 6; 6; 7 ] ]
    let actual = saddlePoints values
    actual |> should equal [(1, 0)]

[<Fact(Skip = "Remove to run test")>]
let ``No saddle point`` () =
    let values = [ [ 2; 1 ]; 
                   [ 1; 2 ] ]
    let actual = saddlePoints values
    actual |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Saddle point`` () =
    let values = [ [ 1; 2 ]; 
                   [ 3; 4 ] ]
    let actual = saddlePoints values
    actual |> should equal [(0, 1)]

[<Fact(Skip = "Remove to run test")>]
let ``Another saddle point`` () =
    let values = [ [ 18;  3; 39; 19;  91 ]; 
                   [ 38; 10;  8; 77; 320 ]; 
                   [  3;  4;  8;  6;   7 ] ]
    let actual = saddlePoints values
    actual |> should equal [(2, 2)]

[<Fact(Skip = "Remove to run test")>]
let ``Multiple saddle points`` () =
    let values = [ [ 4; 5; 4 ];
                   [ 3; 5; 5 ];
                   [ 1; 5; 4 ] ]
    let actual = saddlePoints values
    actual |> should equal [(0, 1); (1, 1); (2, 1)]   