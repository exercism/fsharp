source("./collatz-conjecture.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open CollatzConjecture

let ``Zero steps for one`` () =
    steps 1 |> should equal (Some 0)

let ``Divide if even`` () =
    steps 16 |> should equal (Some 4)

let ``Even and odd steps`` () =
    steps 12 |> should equal (Some 9)

let ``Large number of even and odd steps`` () =
    steps 1000000 |> should equal (Some 152)

let ``Zero is an error`` () =
    steps 0 |> should equal None

let ``Negative value is an error`` () =
    steps -15 |> should equal None

