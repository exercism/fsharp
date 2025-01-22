source("./secret-handshake.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open SecretHandshake

let ``Wink for 1`` () =
    commands 1 |> should equal ["wink"]

let ``Double blink for 10`` () =
    commands 2 |> should equal ["double blink"]

let ``Close your eyes for 100`` () =
    commands 4 |> should equal ["close your eyes"]

let ``Jump for 1000`` () =
    commands 8 |> should equal ["jump"]

let ``Combine two actions`` () =
    commands 3 |> should equal ["wink"; "double blink"]

let ``Reverse two actions`` () =
    commands 19 |> should equal ["double blink"; "wink"]

let ``Reversing one action gives the same action`` () =
    commands 24 |> should equal ["jump"]

let ``Reversing no actions still gives no actions`` () =
    commands 16 |> should be Empty

let ``All possible actions`` () =
    commands 15 |> should equal ["wink"; "double blink"; "close your eyes"; "jump"]

let ``Reverse all possible actions`` () =
    commands 31 |> should equal ["jump"; "close your eyes"; "double blink"; "wink"]

let ``Do nothing for zero`` () =
    commands 0 |> should be Empty

