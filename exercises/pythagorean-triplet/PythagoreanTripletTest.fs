// This file was created manually and its version is 1.0.0.

module PythagoreanTripletTest

open Xunit
open FsUnit.Xunit

open PythagoreanTriplet
    
[<Theory(Skip = "Remove to run test")>]
[<InlineData(3, 4, 5, true)>]
[<InlineData(3, 5, 4, true)>]
[<InlineData(4, 3, 5, true)>]
[<InlineData(4, 5, 3, true)>]
[<InlineData(5, 3, 4, true)>]
[<InlineData(5, 4, 3, true)>]
[<InlineData(3, 3, 3, false)>]
[<InlineData(5, 6, 7, false)>]
let ``Can recognize a valid pythagorean`` (x: int) (y: int) (z: int) (expected: bool) =
    let actual = triplet x y z
    isPythagorean actual |> should equal expected
   
[<Fact(Skip = "Remove to run test")>]
let ``Can create simple triplets`` () =
    let actual = pythagoreanTriplets 1 10
    actual |> should equal [triplet 3 4 5; triplet 6 8 10]

[<Fact(Skip = "Remove to run test")>]
let ``Can create more triplets`` () =
    let actual = pythagoreanTriplets 11 20
    actual |> should equal [triplet 12 16 20]

[<Fact(Skip = "Remove to run test")>]
let ``Can create complex triplets`` () =
    let actual = pythagoreanTriplets 56 95
    actual |> should equal [triplet 57 76 95; triplet 60 63 87]