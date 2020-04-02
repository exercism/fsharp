// This file was auto-generated based on version 1.1.0 of the canonical data.

module PrimeFactorsTests

open FsUnit.Xunit
open Xunit

open PrimeFactors

[<Fact>]
let ``No factors`` () =
    factors 1L |> should be Empty

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Prime number`` () =
    factors 2L |> should equal [2]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Square of a prime`` () =
    factors 9L |> should equal [3; 3]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Cube of a prime`` () =
    factors 8L |> should equal [2; 2; 2]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Product of primes and non-primes`` () =
    factors 12L |> should equal [2; 2; 3]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Product of primes`` () =
    factors 901255L |> should equal [5; 17; 23; 461]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Factors include a large prime`` () =
    factors 93819012551L |> should equal [11; 9539; 894119]

