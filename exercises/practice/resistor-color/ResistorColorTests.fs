source("./resistor-color.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open ResistorColor

let ``Black`` () =
    colorCode "black" |> should equal 0

let ``White`` () =
    colorCode "white" |> should equal 9

let ``Orange`` () =
    colorCode "orange" |> should equal 3

let ``Colors`` () =
    colors |> should equal ["black"; "brown"; "red"; "orange"; "yellow"; "green"; "blue"; "violet"; "grey"; "white"]

