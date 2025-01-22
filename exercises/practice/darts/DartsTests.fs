source("./darts.R")
library(testthat)

let ``Missed target`` () =
    expect_equal(score -9.0 9.0, 0)

let ``On the outer circle`` () =
    expect_equal(score 0.0 10.0, 1)

let ``On the middle circle`` () =
    expect_equal(score -5.0 0.0, 5)

let ``On the inner circle`` () =
    expect_equal(score 0.0 -1.0, 10)

let ``Exactly on center`` () =
    expect_equal(score 0.0 0.0, 10)

let ``Near the center`` () =
    expect_equal(score -0.1 -0.1, 10)

let ``Just within the inner circle`` () =
    expect_equal(score 0.7 0.7, 10)

let ``Just outside the inner circle`` () =
    expect_equal(score 0.8 -0.8, 5)

let ``Just within the middle circle`` () =
    expect_equal(score -3.5 3.5, 5)

let ``Just outside the middle circle`` () =
    expect_equal(score -3.6 -3.6, 1)

let ``Just within the outer circle`` () =
    expect_equal(score -7.0 7.0, 1)

let ``Just outside the outer circle`` () =
    expect_equal(score 7.1 -7.1, 0)

let ``Asymmetric position between the inner and middle circles`` () =
    expect_equal(score 0.5 -4.0, 5)

