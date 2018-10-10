// This file was auto-generated based on version 1.0.0 of the canonical data.

module PythagoreanTripletTest

open FsUnit.Xunit
open Xunit

open PythagoreanTriplet

[<Fact>]
let ``Triplets whose sum is 12`` () =
    tripletsWithSum 12 |> should equal [(3, 4, 5)]

[<Fact(Skip = "Remove to run test")>]
let ``Triplets whose sum is 108`` () =
    tripletsWithSum 108 |> should equal [(27, 36, 45)]

[<Fact(Skip = "Remove to run test")>]
let ``Triplets whose sum is 1000`` () =
    tripletsWithSum 1000 |> should equal [(200, 375, 425)]

[<Fact(Skip = "Remove to run test")>]
let ``No matching triplets for 1001`` () =
    tripletsWithSum 1001 |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Returns all matching triplets`` () =
    tripletsWithSum 90 |> should equal [(9, 40, 41); (15, 36, 39)]

[<Fact(Skip = "Remove to run test")>]
let ``Several matching triplets`` () =
    tripletsWithSum 840 |> should equal [(40, 399, 401); (56, 390, 394); (105, 360, 375); (120, 350, 370); (140, 336, 364); (168, 315, 357); (210, 280, 350); (240, 252, 348)]

[<Fact(Skip = "Remove to run test")>]
let ``Triplets for large number`` () =
    tripletsWithSum 30000 |> should equal [(1200, 14375, 14425); (1875, 14000, 14125); (5000, 12000, 13000); (6000, 11250, 12750); (7500, 10000, 12500)]

