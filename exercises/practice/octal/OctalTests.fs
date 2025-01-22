// This file was created manually and its version is 1.0.0.

source("./octal-test.R")
library(testthat)

let ``Octal 1 is decimal 1`` () =
    expect_equal(toDecimal "1", 1)

let ``Octal 10 is decimal 8`` () =
    expect_equal(toDecimal "10", 8)

let ``Octal 17 is decimal 15`` () =
    expect_equal(toDecimal "17", 15)

let ``Octal 11 is decimal 9`` () =
    expect_equal(toDecimal "11", 9)

let ``Octal 130 is decimal 88`` () =
    expect_equal(toDecimal "130", 88)

let ``Octal 2047 is decimal 1063`` () =
    expect_equal(toDecimal "2047", 1063)

let ``Octal 7777 is decimal 4095`` () =
    expect_equal(toDecimal "7777", 4095)

let ``Octal 1234567 is decimal 342391`` () =
    expect_equal(toDecimal "1234567", 342391)

let ``Invalid Octal carrot is decimal 0`` () =
    expect_equal(toDecimal "carrot", 0)

let ``Invalid Octal 8 is decimal 0`` () =
    expect_equal(toDecimal "8", 0)

let ``Invalid Octal 9 is decimal 0`` () =
    expect_equal(toDecimal "9", 0)

let ``Invalid Octal 6789 is decimal 0`` () =
    expect_equal(toDecimal "6789", 0)

let ``Invalid Octal abc1z is decimal 0`` () =
    expect_equal(toDecimal "abc1z", 0)

