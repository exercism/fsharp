source("./perfect-numbers.R")
library(testthat)

let ``Smallest perfect number is classified correctly`` () =
    expect_equal(classify 6, (Some Classification.Perfect))

let ``Medium perfect number is classified correctly`` () =
    expect_equal(classify 28, (Some Classification.Perfect))

let ``Large perfect number is classified correctly`` () =
    expect_equal(classify 33550336, (Some Classification.Perfect))

let ``Smallest abundant number is classified correctly`` () =
    expect_equal(classify 12, (Some Classification.Abundant))

let ``Medium abundant number is classified correctly`` () =
    expect_equal(classify 30, (Some Classification.Abundant))

let ``Large abundant number is classified correctly`` () =
    expect_equal(classify 33550335, (Some Classification.Abundant))

let ``Smallest prime deficient number is classified correctly`` () =
    expect_equal(classify 2, (Some Classification.Deficient))

let ``Smallest non-prime deficient number is classified correctly`` () =
    expect_equal(classify 4, (Some Classification.Deficient))

let ``Medium deficient number is classified correctly`` () =
    expect_equal(classify 32, (Some Classification.Deficient))

let ``Large deficient number is classified correctly`` () =
    expect_equal(classify 33550337, (Some Classification.Deficient))

let ``Edge case (no factors other than itself) is classified correctly`` () =
    expect_equal(classify 1, (Some Classification.Deficient))

let ``Zero is rejected (as it is not a positive integer)`` () =
    expect_equal(classify 0, None)

let ``Negative integer is rejected (as it is not a positive integer)`` () =
    expect_equal(classify -1, None)

