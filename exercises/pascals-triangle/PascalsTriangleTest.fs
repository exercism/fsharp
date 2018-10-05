// This file was auto-generated based on version 1.5.0 of the canonical data.

module PascalsTriangleTest

open FsUnit.Xunit
open Xunit

open PascalsTriangle

[<Fact>]
let ``Zero rows`` () =
    let expected: int list list = []
    rows 0 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single row`` () =
    let expected = [[1]]
    rows 1 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Two rows`` () =
    let expected = 
        [ [1];
          [1; 1] ]
    rows 2 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Three rows`` () =
    let expected = 
        [ [1];
          [1; 1];
          [1; 2; 1] ]
    rows 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Four rows`` () =
    let expected = 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1] ]
    rows 4 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Five rows`` () =
    let expected = 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1];
          [1; 4; 6; 4; 1] ]
    rows 5 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Six rows`` () =
    let expected = 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1];
          [1; 4; 6; 4; 1];
          [1; 5; 10; 10; 5; 1] ]
    rows 6 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Ten rows`` () =
    let expected = 
        [ [1];
          [1; 1];
          [1; 2; 1];
          [1; 3; 3; 1];
          [1; 4; 6; 4; 1];
          [1; 5; 10; 10; 5; 1];
          [1; 6; 15; 20; 15; 6; 1];
          [1; 7; 21; 35; 35; 21; 7; 1];
          [1; 8; 28; 56; 70; 56; 28; 8; 1];
          [1; 9; 36; 84; 126; 126; 84; 36; 9; 1] ]
    rows 10 |> should equal expected

