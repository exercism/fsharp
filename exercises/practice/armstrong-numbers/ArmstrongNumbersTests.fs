source("./armstrong-numbers.R")
library(testthat)

let ``Zero is an Armstrong number`` () =
    expect_equal(isArmstrongNumber 0, true)

let ``Single-digit numbers are Armstrong numbers`` () =
    expect_equal(isArmstrongNumber 5, true)

let ``There are no two-digit Armstrong numbers`` () =
    expect_equal(isArmstrongNumber 10, false)

let ``Three-digit number that is an Armstrong number`` () =
    expect_equal(isArmstrongNumber 153, true)

let ``Three-digit number that is not an Armstrong number`` () =
    expect_equal(isArmstrongNumber 100, false)

let ``Four-digit number that is an Armstrong number`` () =
    expect_equal(isArmstrongNumber 9474, true)

let ``Four-digit number that is not an Armstrong number`` () =
    expect_equal(isArmstrongNumber 9475, false)

let ``Seven-digit number that is an Armstrong number`` () =
    expect_equal(isArmstrongNumber 9926315, true)

let ``Seven-digit number that is not an Armstrong number`` () =
    expect_equal(isArmstrongNumber 9926314, false)

