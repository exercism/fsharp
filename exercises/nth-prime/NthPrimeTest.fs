module NthPrimeTest

open Xunit
open FsUnit
open NthPrime

[Fact]
let ``First prime`` () =
    nthPrime 1 |> should equal 2

[Fact(Skip = "Remove to run test")]
let ``Second prime`` () =
    nthPrime 2 |> should equal 3

[Fact(Skip = "Remove to run test")]
let ``Third prime`` () =
    nthPrime 3 |> should equal 5

[Fact(Skip = "Remove to run test")]
let ``4th prime`` () =
    nthPrime 4 |> should equal 7

[Fact(Skip = "Remove to run test")]
let ``5th prime`` () =
    nthPrime 5 |> should equal 11

[Fact(Skip = "Remove to run test")]
let ``6th prime`` () =
    nthPrime 6 |> should equal 13

[Fact(Skip = "Remove to run test")]
let ``7th prime`` () =
    nthPrime 7 |> should equal 17

[Fact(Skip = "Remove to run test")]
let ``8th prime`` () =
    nthPrime 8 |> should equal 19

[Fact(Skip = "Remove to run test")]
let ``1000th prime`` () =
    nthPrime 1000 |> should equal 7919

[Fact(Skip = "Remove to run test")]
let ``10000th prime`` () =
    nthPrime 10000 |> should equal 104729

[Fact(Skip = "Remove to run test")]
let ``10001th prime`` () =
    nthPrime 10001 |> should equal 104743