// This file was created manually and its version is 1.0.0.

source("./hexadecimal-test.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open Hexadecimal

let ``Hexadecimal 1 is decimal 1`` () =
    toDecimal "1" |> should equal 1

let ``Hexadecimal c is decimal 12`` () =
    toDecimal "c" |> should equal 12

let ``Hexadecimal 10 is decimal 16`` () =
    toDecimal "10" |> should equal 16

let ``Hexadecimal af is decimal 175`` () =
    toDecimal "af" |> should equal 175

let ``Hexadecimal 100 is decimal 256`` () =
    toDecimal "100" |> should equal 256

let ``Hexadecimal 19ace is decimal 105166`` () =
    toDecimal "19ace" |> should equal 105166

let ``Hexadecimal 000000 is decimal 0`` () =
    toDecimal "000000" |> should equal 0

let ``Hexadecimal ffffff is decimal 16777215`` () =
    toDecimal "ffffff" |> should equal 16777215

let ``Hexadecimal ffff00 is decimal 16776960`` () =
    toDecimal "ffff00" |> should equal 16776960

let ``Hexadecimal carrot is decimal 0`` () =
    toDecimal "carrot" |> should equal 0

