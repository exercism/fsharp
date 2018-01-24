// This file was auto-generated based on version 1.3.0 of the canonical data.

module BookStoreTest

open FsUnit.Xunit
open Xunit

open BookStore

[<Fact>]
let ``Only a single book`` () =
    total [1] |> should equal 8.00

[<Fact(Skip = "Remove to run test")>]
let ``Two of the same book`` () =
    total [2; 2] |> should equal 16.00

[<Fact(Skip = "Remove to run test")>]
let ``Empty basket`` () =
    total [] |> should equal 0.00

[<Fact(Skip = "Remove to run test")>]
let ``Two different books`` () =
    total [1; 2] |> should equal 15.20

[<Fact(Skip = "Remove to run test")>]
let ``Three different books`` () =
    total [1; 2; 3] |> should equal 21.60

[<Fact(Skip = "Remove to run test")>]
let ``Four different books`` () =
    total [1; 2; 3; 4] |> should equal 25.60

[<Fact(Skip = "Remove to run test")>]
let ``Five different books`` () =
    total [1; 2; 3; 4; 5] |> should equal 30.00

[<Fact(Skip = "Remove to run test")>]
let ``Two groups of four is cheaper than group of five plus group of three`` () =
    total [1; 1; 2; 2; 3; 3; 4; 5] |> should equal 51.20

[<Fact(Skip = "Remove to run test")>]
let ``Group of four plus group of two is cheaper than two groups of three`` () =
    total [1; 1; 2; 2; 3; 4] |> should equal 40.80

[<Fact(Skip = "Remove to run test")>]
let ``Two each of first 4 books and 1 copy each of rest`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5] |> should equal 55.60

[<Fact(Skip = "Remove to run test")>]
let ``Two copies of each book`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5] |> should equal 60.00

[<Fact(Skip = "Remove to run test")>]
let ``Three copies of first book and 2 each of remaining`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1] |> should equal 68.00

[<Fact(Skip = "Remove to run test")>]
let ``Three each of first 2 books and 2 each of remaining books`` () =
    total [1; 1; 2; 2; 3; 3; 4; 4; 5; 5; 1; 2] |> should equal 75.20

[<Fact(Skip = "Remove to run test")>]
let ``Four groups of four are cheaper than two groups each of five and three`` () =
    total [1; 1; 2; 2; 3; 3; 4; 5; 1; 1; 2; 2; 3; 3; 4; 5] |> should equal 102.40

