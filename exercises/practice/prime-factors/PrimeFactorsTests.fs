source("./prime-factors.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open PrimeFactors

let ``No factors`` () =
    factors 1L |> should be Empty

let ``Prime number`` () =
    factors 2L |> should equal [2]

let ``Another prime number`` () =
    factors 3L |> should equal [3]

let ``Square of a prime`` () =
    factors 9L |> should equal [3; 3]

let ``Product of first prime`` () =
    factors 4L |> should equal [2; 2]

let ``Cube of a prime`` () =
    factors 8L |> should equal [2; 2; 2]

let ``Product of second prime`` () =
    factors 27L |> should equal [3; 3; 3]

let ``Product of third prime`` () =
    factors 625L |> should equal [5; 5; 5; 5]

let ``Product of first and second prime`` () =
    factors 6L |> should equal [2; 3]

let ``Product of primes and non-primes`` () =
    factors 12L |> should equal [2; 2; 3]

let ``Product of primes`` () =
    factors 901255L |> should equal [5; 17; 23; 461]

let ``Factors include a large prime`` () =
    factors 93819012551L |> should equal [11; 9539; 894119]

