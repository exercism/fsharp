// This file was auto-generated based on version 1.2.0 of the canonical data.

module SumOfMultiplesTest

open FsUnit.Xunit
open Xunit

open SumOfMultiples

[<Fact>]
let ``Multiples of 3 or 5 up to 1`` () =
    sum [3; 5] 1 |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 3 or 5 up to 4`` () =
    sum [3; 5] 4 |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 3 up to 7`` () =
    sum [3] 7 |> should equal 9

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 3 or 5 up to 10`` () =
    sum [3; 5] 10 |> should equal 23

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 3 or 5 up to 100`` () =
    sum [3; 5] 100 |> should equal 2318

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 3 or 5 up to 1000`` () =
    sum [3; 5] 1000 |> should equal 233168

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 7, 13 or 17 up to 20`` () =
    sum [7; 13; 17] 20 |> should equal 51

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 4 or 6 up to 15`` () =
    sum [4; 6] 15 |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 5, 6 or 8 up to 150`` () =
    sum [5; 6; 8] 150 |> should equal 4419

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 5 or 25 up to 51`` () =
    sum [5; 25] 51 |> should equal 275

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 43 or 47 up to 10000`` () =
    sum [43; 47] 10000 |> should equal 2203160

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of 1 up to 100`` () =
    sum [1] 100 |> should equal 4950

[<Fact(Skip = "Remove to run test")>]
let ``Multiples of an empty list up to 10000`` () =
    sum [] 10000 |> should equal 0

