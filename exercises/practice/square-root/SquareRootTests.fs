source("./square-root.R")
library(testthat)

let ``Root of 1`` () =
    expect_equal(squareRoot 1, 1)

let ``Root of 4`` () =
    expect_equal(squareRoot 4, 2)

let ``Root of 25`` () =
    expect_equal(squareRoot 25, 5)

let ``Root of 81`` () =
    expect_equal(squareRoot 81, 9)

let ``Root of 196`` () =
    expect_equal(squareRoot 196, 14)

let ``Root of 65025`` () =
    expect_equal(squareRoot 65025, 255)

