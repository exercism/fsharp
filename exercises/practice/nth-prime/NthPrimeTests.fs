source("./nth-prime.R")
library(testthat)

let ``First prime`` () =
    expect_equal(prime 1, (Some 2))

let ``Second prime`` () =
    expect_equal(prime 2, (Some 3))

let ``Sixth prime`` () =
    expect_equal(prime 6, (Some 13))

let ``Big prime`` () =
    expect_equal(prime 10001, (Some 104743))

let ``There is no zeroth prime`` () =
    expect_equal(prime 0, None)

