module DifferenceOfSquaresTests

open FsUnit.Xunit
open Xunit

open DifferenceOfSquares

[<Fact>]
let ``Square of sum 1`` () =
    squareOfSum 1 |> should equal 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Square of sum 5`` () =
    squareOfSum 5 |> should equal 225

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Square of sum 100`` () =
    squareOfSum 100 |> should equal 25502500

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Sum of squares 1`` () =
    sumOfSquares 1 |> should equal 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Sum of squares 5`` () =
    sumOfSquares 5 |> should equal 55

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Sum of squares 100`` () =
    sumOfSquares 100 |> should equal 338350

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Difference of squares 1`` () =
    differenceOfSquares 1 |> should equal 0

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Difference of squares 5`` () =
    differenceOfSquares 5 |> should equal 170

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Difference of squares 100`` () =
    differenceOfSquares 100 |> should equal 25164150

