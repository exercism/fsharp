module TriangleTests

open FsUnit.Xunit
open Xunit

open Triangle

[<Fact>]
let ``Equilateral returns all sides are equal`` () =
    equilateral [2.0; 2.0; 2.0] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Equilateral returns any side is unequal`` () =
    equilateral [2.0; 3.0; 2.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Equilateral returns no sides are equal`` () =
    equilateral [5.0; 4.0; 6.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Equilateral returns all zero sides is not a triangle`` () =
    equilateral [0.0; 0.0; 0.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Equilateral returns sides may be floats`` () =
    equilateral [0.5; 0.5; 0.5] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns last two sides are equal`` () =
    isosceles [3.0; 4.0; 4.0] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns first two sides are equal`` () =
    isosceles [4.0; 4.0; 3.0] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns first and last sides are equal`` () =
    isosceles [4.0; 3.0; 4.0] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Equilateral triangles are also isosceles`` () =
    isosceles [4.0; 4.0; 4.0] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns no sides are equal`` () =
    isosceles [2.0; 3.0; 4.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns first triangle inequality violation`` () =
    isosceles [1.0; 1.0; 3.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns second triangle inequality violation`` () =
    isosceles [1.0; 3.0; 1.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns third triangle inequality violation`` () =
    isosceles [3.0; 1.0; 1.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Isosceles returns sides may be floats`` () =
    isosceles [0.5; 0.4; 0.5] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns no sides are equal`` () =
    scalene [5.0; 4.0; 6.0] |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns all sides are equal`` () =
    scalene [4.0; 4.0; 4.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns first and second sides are equal`` () =
    scalene [4.0; 4.0; 3.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns first and third sides are equal`` () =
    scalene [3.0; 4.0; 3.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns second and third sides are equal`` () =
    scalene [4.0; 3.0; 3.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns may not violate triangle inequality`` () =
    scalene [7.0; 3.0; 2.0] |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Scalene returns sides may be floats`` () =
    scalene [0.5; 0.4; 0.6] |> should equal true

