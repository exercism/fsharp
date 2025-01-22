source("./secret-handshake.R")
library(testthat)

let ``Wink for 1`` () =
    expect_equal(commands 1, ["wink"])

let ``Double blink for 10`` () =
    expect_equal(commands 2, ["double blink"])

let ``Close your eyes for 100`` () =
    expect_equal(commands 4, ["close your eyes"])

let ``Jump for 1000`` () =
    expect_equal(commands 8, ["jump"])

let ``Combine two actions`` () =
    expect_equal(commands 3, ["wink"; "double blink"])

let ``Reverse two actions`` () =
    expect_equal(commands 19, ["double blink"; "wink"])

let ``Reversing one action gives the same action`` () =
    expect_equal(commands 24, ["jump"])

let ``Reversing no actions still gives no actions`` () =
    commands 16 |> should be Empty

let ``All possible actions`` () =
    expect_equal(commands 15, ["wink"; "double blink"; "close your eyes"; "jump"])

let ``Reverse all possible actions`` () =
    expect_equal(commands 31, ["jump"; "close your eyes"; "double blink"; "wink"])

let ``Do nothing for zero`` () =
    commands 0 |> should be Empty

