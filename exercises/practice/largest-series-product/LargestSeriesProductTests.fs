source("./largest-series-product.R")
library(testthat)

let ``Finds the largest product if span equals length`` () =
    digits <- "29"
    span <- 2
    expect_equal(largestProduct digits span, (Some 18))

let ``Can find the largest product of 2 with numbers in order`` () =
    digits <- "0123456789"
    span <- 2
    expect_equal(largestProduct digits span, (Some 72))

let ``Can find the largest product of 2`` () =
    digits <- "576802143"
    span <- 2
    expect_equal(largestProduct digits span, (Some 48))

let ``Can find the largest product of 3 with numbers in order`` () =
    digits <- "0123456789"
    span <- 3
    expect_equal(largestProduct digits span, (Some 504))

let ``Can find the largest product of 3`` () =
    digits <- "1027839564"
    span <- 3
    expect_equal(largestProduct digits span, (Some 270))

let ``Can find the largest product of 5 with numbers in order`` () =
    digits <- "0123456789"
    span <- 5
    expect_equal(largestProduct digits span, (Some 15120))

let ``Can get the largest product of a big number`` () =
    digits <- "73167176531330624919225119674426574742355349194934"
    span <- 6
    expect_equal(largestProduct digits span, (Some 23520))

let ``Reports zero if the only digits are zero`` () =
    digits <- "0000"
    span <- 2
    expect_equal(largestProduct digits span, (Some 0))

let ``Reports zero if all spans include zero`` () =
    digits <- "99099"
    span <- 3
    expect_equal(largestProduct digits span, (Some 0))

let ``Rejects span longer than string length`` () =
    digits <- "123"
    span <- 4
    expect_equal(largestProduct digits span, None)

let ``Rejects empty string and nonzero span`` () =
    digits <- ""
    span <- 1
    expect_equal(largestProduct digits span, None)

let ``Rejects invalid character in digits`` () =
    digits <- "1234a5"
    span <- 2
    expect_equal(largestProduct digits span, None)

let ``Rejects negative span`` () =
    digits <- "12345"
    span <- -1
    expect_equal(largestProduct digits span, None)

