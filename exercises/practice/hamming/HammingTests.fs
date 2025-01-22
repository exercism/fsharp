source("./hamming.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open Hamming

let ``Empty strands`` () =
    distance "" "" |> should equal (Some 0)

let ``Single letter identical strands`` () =
    distance "A" "A" |> should equal (Some 0)

let ``Single letter different strands`` () =
    distance "G" "T" |> should equal (Some 1)

let ``Long identical strands`` () =
    distance "GGACTGAAATCTG" "GGACTGAAATCTG" |> should equal (Some 0)

let ``Long different strands`` () =
    distance "GGACGGATTCTG" "AGGACGGATTCT" |> should equal (Some 9)

let ``Disallow first strand longer`` () =
    distance "AATG" "AAA" |> should equal None

let ``Disallow second strand longer`` () =
    distance "ATA" "AGTG" |> should equal None

let ``Disallow empty first strand`` () =
    distance "" "G" |> should equal None

let ``Disallow empty second strand`` () =
    distance "G" "" |> should equal None

