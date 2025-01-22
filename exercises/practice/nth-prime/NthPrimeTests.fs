source("./nth-prime.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open NthPrime

let ``First prime`` () =
    prime 1 |> should equal (Some 2)

let ``Second prime`` () =
    prime 2 |> should equal (Some 3)

let ``Sixth prime`` () =
    prime 6 |> should equal (Some 13)

let ``Big prime`` () =
    prime 10001 |> should equal (Some 104743)

let ``There is no zeroth prime`` () =
    prime 0 |> should equal None

