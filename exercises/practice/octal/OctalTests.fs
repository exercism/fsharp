// This file was created manually and its version is 1.0.0.

source("./octal-test.R")
library(testthat)

let ``Octal 1 is decimal 1`` () =
    toDecimal "1" |> should equal 1

let ``Octal 10 is decimal 8`` () =
    toDecimal "10" |> should equal 8

let ``Octal 17 is decimal 15`` () =
    toDecimal "17" |> should equal 15

let ``Octal 11 is decimal 9`` () =
    toDecimal "11" |> should equal 9

let ``Octal 130 is decimal 88`` () =
    toDecimal "130" |> should equal 88

let ``Octal 2047 is decimal 1063`` () =
    toDecimal "2047" |> should equal 1063

let ``Octal 7777 is decimal 4095`` () =
    toDecimal "7777" |> should equal 4095

let ``Octal 1234567 is decimal 342391`` () =
    toDecimal "1234567" |> should equal 342391

let ``Invalid Octal carrot is decimal 0`` () =
    toDecimal "carrot" |> should equal 0

let ``Invalid Octal 8 is decimal 0`` () =
    toDecimal "8" |> should equal 0

let ``Invalid Octal 9 is decimal 0`` () =
    toDecimal "9" |> should equal 0

let ``Invalid Octal 6789 is decimal 0`` () =
    toDecimal "6789" |> should equal 0

let ``Invalid Octal abc1z is decimal 0`` () =
    toDecimal "abc1z" |> should equal 0

