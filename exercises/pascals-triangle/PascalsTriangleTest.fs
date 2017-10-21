// This file was auto-generated based on version 1.1.0 of the canonical data.

module PascalsTriangleTest

open FsUnit.Xunit
open Xunit

open PascalsTriangle

[<Fact>]
let ``Zero rows`` () =
    rows 0 |> should equal (Some ([]: int list list))

[<Fact(Skip = "Remove to run test")>]
let ``Single row`` () =
    rows 1 |> should equal (Some [[1]])

[<Fact(Skip = "Remove to run test")>]
let ``Two rows`` () =
    rows 2 |> should equal (Some [[1]; [1; 1]])

[<Fact(Skip = "Remove to run test")>]
let ``Three rows`` () =
    rows 3 |> should equal (Some [[1]; [1; 1]; [1; 2; 1]])

[<Fact(Skip = "Remove to run test")>]
let ``Four rows`` () =
    rows 4 |> should equal (Some [[1]; [1; 1]; [1; 2; 1]; [1; 3; 3; 1]])

[<Fact(Skip = "Remove to run test")>]
let ``Negative rows`` () =
    rows -1 |> should equal None

