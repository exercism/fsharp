module DifferenceOfSquaresTest

open Xunit
open FsUnit.Xunit
open DifferenceOfSquares
    
[<Fact>]
let ``Square of sums to 5`` () =
    squareOfSums 5 |> should equal 225

[<Fact(Skip = "Remove to run test")>]
let ``Sum of squares to 5`` () =
    sumOfSquares 5 |> should equal 55

[<Fact(Skip = "Remove to run test")>]
let ``Difference of sums to 5`` () =
    difference 5 |> should equal 170

[<Fact(Skip = "Remove to run test")>]
let ``Square of sums to 10`` () =
    squareOfSums 10 |> should equal 3025

[<Fact(Skip = "Remove to run test")>]
let ``Sum of squares to 10`` () =
    sumOfSquares 10 |> should equal 385

[<Fact(Skip = "Remove to run test")>]
let ``Difference of sums to 10`` () =
    difference 10 |> should equal 2640

[<Fact(Skip = "Remove to run test")>]
let ``Square of sums to 100`` () =
    squareOfSums 100 |> should equal 25502500

[<Fact(Skip = "Remove to run test")>]
let ``Sum of squares to 100`` () =
    sumOfSquares 100 |> should equal 338350

[<Fact(Skip = "Remove to run test")>]
let ``Difference of sums to 100`` () =
    difference 100 |> should equal 25164150