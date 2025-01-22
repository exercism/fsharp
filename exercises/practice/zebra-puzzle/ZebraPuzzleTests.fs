source("./zebra-puzzle.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open ZebraPuzzle

let ``Resident who drinks water`` () =
    drinksWater |> should equal Norwegian

let ``Resident who owns zebra`` () =
    ownsZebra |> should equal Japanese

