module BookStoreTest

open System
open Xunit
open FsUnit.Xunit
open BookStore

[<Fact>]
let ``Basket with single book`` () =
    calculateTotalCost [1] |> should equal 8

[<Fact(Skip = "Remove to run test")>]
let ``Basket with two of same book`` () =
    calculateTotalCost [2; 2] |> should equal 16

[<Fact(Skip = "Remove to run test")>]
let ``Empty basket`` () =
    calculateTotalCost [] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Basket with two different books`` () =
    calculateTotalCost [1; 2] |> should equal 15.2

[<Fact(Skip = "Remove to run test")>]
let ``Basket with three different books`` () =
    calculateTotalCost [1; 2; 3] |> should equal 21.6

[<Fact(Skip = "Remove to run test")>]
let ``Basket with four different books`` () =
    calculateTotalCost [1; 2; 3; 4] |> should equal 25.6

[<Fact(Skip = "Remove to run test")>]
let ``Basket with five different books`` () =
    calculateTotalCost [1; 2; 3; 4; 5] |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Basket with eight books`` () =
    calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 5] |> should equal 51.20

[<Fact(Skip = "Remove to run test")>]
let ``Basket with nine books`` () =
    calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5] |> should equal 55.60

[<Fact(Skip = "Remove to run test")>]
let ``Basket with ten books`` () =
    calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5; 5] |> should equal 60

[<Fact(Skip = "Remove to run test")>]
let ``Basket with eleven books`` () =
    calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1] |> should equal 68

[<Fact(Skip = "Remove to run test")>]
let ``Basket with twelve books`` () =
    calculateTotalCost [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1; 2] |> should equal 75.20