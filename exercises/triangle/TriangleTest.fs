// This file was auto-generated based on version 1.1.0 of the canonical data.

module TriangleTest

open FsUnit.Xunit
open Xunit

open Triangle

[<Fact>]
let ``Equilateral returns true if all sides are equal`` () =
    equilateral [2.0; 2.0; 2.0] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Equilateral returns false if any side is unequal`` () =
    equilateral [2.0; 3.0; 2.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Equilateral returns false if no sides are equal`` () =
    equilateral [5.0; 4.0; 6.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``All zero sides are illegal, so the triangle is not equilateral`` () =
    equilateral [0.0; 0.0; 0.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Equilateral returns sides may be floats`` () =
    equilateral [0.5; 0.5; 0.5] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Isosceles returns true if last two sides are equal`` () =
    isosceles [3.0; 4.0; 4.0] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Isosceles returns true if first two sides are equal`` () =
    isosceles [4.0; 4.0; 3.0] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Isosceles returns true if first and last sides are equal`` () =
    isosceles [4.0; 3.0; 4.0] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Equilateral triangles are also isosceles`` () =
    isosceles [4.0; 4.0; 4.0] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Isosceles returns false if no sides are equal`` () =
    isosceles [2.0; 3.0; 4.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Sides that violate triangle inequality are not isosceles, even if two are equal`` () =
    isosceles [1.0; 1.0; 3.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Isosceles returns sides may be floats`` () =
    isosceles [0.5; 0.4; 0.5] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Scalene returns true if no sides are equal`` () =
    scalene [5.0; 4.0; 6.0] |> should equal true

[<Fact(Skip = "Remove to run test")>]
let ``Scalene returns false if all sides are equal`` () =
    scalene [4.0; 4.0; 4.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Scalene returns false if two sides are equal`` () =
    scalene [4.0; 4.0; 3.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Sides that violate triangle inequality are not scalene, even if they are all different`` () =
    scalene [7.0; 3.0; 2.0] |> should equal false

[<Fact(Skip = "Remove to run test")>]
let ``Scalene returns sides may be floats`` () =
    scalene [0.5; 0.4; 0.6] |> should equal true

