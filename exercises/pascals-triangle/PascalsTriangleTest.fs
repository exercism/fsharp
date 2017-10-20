// This file was auto-generated based on version 1.1.0 of the canonical data.

module PascalsTriangleTest

open FsUnit.Xunit
open Xunit

open PascalsTriangle

[<Fact>]
let ``Zero rows`` () =
    triangle 0 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Single row`` () =
    triangle 1 |> should equal [[1]]

[<Fact(Skip = "Remove to run test")>]
let ``Two rows`` () =
    triangle 2 |> should equal [[1]; [1; 1]]

[<Fact(Skip = "Remove to run test")>]
let ``Three rows`` () =
    triangle 3 |> should equal [[1]; [1; 1]; [1; 2; 1]]

[<Fact(Skip = "Remove to run test")>]
let ``Four rows`` () =
    triangle 4 |> should equal [[1]; [1; 1]; [1; 2; 1]; [1; 3; 3; 1]]

[<Fact(Skip = "Remove to run test")>]
let ``Negative rows`` () =
    (fun () -> triangle -1 |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>

