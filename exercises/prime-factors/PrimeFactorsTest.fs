// This file was auto-generated based on version 1.0.0 of the canonical data.

module PrimeFactorsTest

open FsUnit.Xunit
open Xunit

open PrimeFactors

[<Fact>]
let ``No factors`` () =
    primeFactorsFor 1L |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Prime number`` () =
    primeFactorsFor 2L |> should equal [2]

[<Fact(Skip = "Remove to run test")>]
let ``Square of a prime`` () =
    primeFactorsFor 9L |> should equal [3; 3]

[<Fact(Skip = "Remove to run test")>]
let ``Cube of a prime`` () =
    primeFactorsFor 8L |> should equal [2; 2; 2]

[<Fact(Skip = "Remove to run test")>]
let ``Product of primes and non-primes`` () =
    primeFactorsFor 12L |> should equal [2; 2; 3]

[<Fact(Skip = "Remove to run test")>]
let ``Product of primes`` () =
    primeFactorsFor 901255L |> should equal [5; 17; 23; 461]

[<Fact(Skip = "Remove to run test")>]
let ``Factors include a large prime`` () =
    primeFactorsFor 93819012551L |> should equal [11; 9539; 894119]

