source("./prime-factors.R")
library(testthat)

let ``No factors`` () =
    factors 1L |> should be Empty

let ``Prime number`` () =
    expect_equal(factors 2L, [2])

let ``Another prime number`` () =
    expect_equal(factors 3L, [3])

let ``Square of a prime`` () =
    expect_equal(factors 9L, [3; 3])

let ``Product of first prime`` () =
    expect_equal(factors 4L, [2; 2])

let ``Cube of a prime`` () =
    expect_equal(factors 8L, [2; 2; 2])

let ``Product of second prime`` () =
    expect_equal(factors 27L, [3; 3; 3])

let ``Product of third prime`` () =
    expect_equal(factors 625L, [5; 5; 5; 5])

let ``Product of first and second prime`` () =
    expect_equal(factors 6L, [2; 3])

let ``Product of primes and non-primes`` () =
    expect_equal(factors 12L, [2; 2; 3])

let ``Product of primes`` () =
    expect_equal(factors 901255L, [5; 17; 23; 461])

let ``Factors include a large prime`` () =
    expect_equal(factors 93819012551L, [11; 9539; 894119])

