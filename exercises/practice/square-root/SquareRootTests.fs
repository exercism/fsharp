module SquareRootTests

open FsUnit.Xunit
open Xunit

open SquareRoot

[<Fact>]
let ``Root of 1`` () =
    squareRoot 1 |> should equal 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Root of 4`` () =
    squareRoot 4 |> should equal 2

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Root of 25`` () =
    squareRoot 25 |> should equal 5

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Root of 81`` () =
    squareRoot 81 |> should equal 9

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Root of 196`` () =
    squareRoot 196 |> should equal 14

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Root of 65025`` () =
    squareRoot 65025 |> should equal 255

