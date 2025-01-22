// This file was created manually and its version is 1.0.0.

source("./hexadecimal-test.R")
library(testthat)

let ``Hexadecimal 1 is decimal 1`` () =
    expect_equal(toDecimal "1", 1)

let ``Hexadecimal c is decimal 12`` () =
    expect_equal(toDecimal "c", 12)

let ``Hexadecimal 10 is decimal 16`` () =
    expect_equal(toDecimal "10", 16)

let ``Hexadecimal af is decimal 175`` () =
    expect_equal(toDecimal "af", 175)

let ``Hexadecimal 100 is decimal 256`` () =
    expect_equal(toDecimal "100", 256)

let ``Hexadecimal 19ace is decimal 105166`` () =
    expect_equal(toDecimal "19ace", 105166)

let ``Hexadecimal 000000 is decimal 0`` () =
    expect_equal(toDecimal "000000", 0)

let ``Hexadecimal ffffff is decimal 16777215`` () =
    expect_equal(toDecimal "ffffff", 16777215)

let ``Hexadecimal ffff00 is decimal 16776960`` () =
    expect_equal(toDecimal "ffff00", 16776960)

let ``Hexadecimal carrot is decimal 0`` () =
    expect_equal(toDecimal "carrot", 0)

