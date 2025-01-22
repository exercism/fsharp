source("./eliuds-eggs.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open EliudsEggs

let ``0 eggs`` () =
    eggCount 0 |> should equal 0

let ``1 egg`` () =
    eggCount 16 |> should equal 1

let ``4 eggs`` () =
    eggCount 89 |> should equal 4

let ``13 eggs`` () =
    eggCount 2000000000 |> should equal 13

