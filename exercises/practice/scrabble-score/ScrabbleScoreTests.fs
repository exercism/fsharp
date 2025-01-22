source("./scrabble-score.R")
library(testthat)

let ``Lowercase letter`` () =
    expect_equal(score "a", 1)

let ``Uppercase letter`` () =
    expect_equal(score "A", 1)

let ``Valuable letter`` () =
    expect_equal(score "f", 4)

let ``Short word`` () =
    expect_equal(score "at", 2)

let ``Short, valuable word`` () =
    expect_equal(score "zoo", 12)

let ``Medium word`` () =
    expect_equal(score "street", 6)

let ``Medium, valuable word`` () =
    expect_equal(score "quirky", 22)

let ``Long, mixed-case word`` () =
    expect_equal(score "OxyphenButazone", 41)

let ``English-like word`` () =
    expect_equal(score "pinata", 8)

let ``Empty input`` () =
    expect_equal(score "", 0)

let ``Entire alphabet available`` () =
    expect_equal(score "abcdefghijklmnopqrstuvwxyz", 87)

