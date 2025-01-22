source("./difference-of-squares.R")
library(testthat)

let ``Square of sum 1`` () =
    expect_equal(squareOfSum 1, 1)

let ``Square of sum 5`` () =
    expect_equal(squareOfSum 5, 225)

let ``Square of sum 100`` () =
    expect_equal(squareOfSum 100, 25502500)

let ``Sum of squares 1`` () =
    expect_equal(sumOfSquares 1, 1)

let ``Sum of squares 5`` () =
    expect_equal(sumOfSquares 5, 55)

let ``Sum of squares 100`` () =
    expect_equal(sumOfSquares 100, 338350)

let ``Difference of squares 1`` () =
    expect_equal(differenceOfSquares 1, 0)

let ``Difference of squares 5`` () =
    expect_equal(differenceOfSquares 5, 170)

let ``Difference of squares 100`` () =
    expect_equal(differenceOfSquares 100, 25164150)

