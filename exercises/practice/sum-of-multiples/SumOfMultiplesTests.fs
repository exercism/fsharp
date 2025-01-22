source("./sum-of-multiples.R")
library(testthat)

let ``No multiples within limit`` () =
    expect_equal(sum [3; 5] 1, 0)

let ``One factor has multiples within limit`` () =
    expect_equal(sum [3; 5] 4, 3)

let ``More than one multiple within limit`` () =
    expect_equal(sum [3] 7, 9)

let ``More than one factor with multiples within limit`` () =
    expect_equal(sum [3; 5] 10, 23)

let ``Each multiple is only counted once`` () =
    expect_equal(sum [3; 5] 100, 2318)

let ``A much larger limit`` () =
    expect_equal(sum [3; 5] 1000, 233168)

let ``Three factors`` () =
    expect_equal(sum [7; 13; 17] 20, 51)

let ``Factors not relatively prime`` () =
    expect_equal(sum [4; 6] 15, 30)

let ``Some pairs of factors relatively prime and some not`` () =
    expect_equal(sum [5; 6; 8] 150, 4419)

let ``One factor is a multiple of another`` () =
    expect_equal(sum [5; 25] 51, 275)

let ``Much larger factors`` () =
    expect_equal(sum [43; 47] 10000, 2203160)

let ``All numbers are multiples of 1`` () =
    expect_equal(sum [1] 100, 4950)

let ``No factors means an empty sum`` () =
    expect_equal(sum [] 10000, 0)

let ``The only multiple of 0 is 0`` () =
    expect_equal(sum [0] 1, 0)

let ``The factor 0 does not affect the sum of multiples of other factors`` () =
    expect_equal(sum [3; 0] 4, 3)

let ``Solutions using include-exclude must extend to cardinality greater than 3`` () =
    expect_equal(sum [2; 3; 5; 7; 11] 10000, 39614537)

