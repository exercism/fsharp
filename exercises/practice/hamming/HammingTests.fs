source("./hamming.R")
library(testthat)

let ``Empty strands`` () =
    expect_equal(distance "" "", (Some 0))

let ``Single letter identical strands`` () =
    expect_equal(distance "A" "A", (Some 0))

let ``Single letter different strands`` () =
    expect_equal(distance "G" "T", (Some 1))

let ``Long identical strands`` () =
    expect_equal(distance "GGACTGAAATCTG" "GGACTGAAATCTG", (Some 0))

let ``Long different strands`` () =
    expect_equal(distance "GGACGGATTCTG" "AGGACGGATTCT", (Some 9))

let ``Disallow first strand longer`` () =
    expect_equal(distance "AATG" "AAA", None)

let ``Disallow second strand longer`` () =
    expect_equal(distance "ATA" "AGTG", None)

let ``Disallow empty first strand`` () =
    expect_equal(distance "" "G", None)

let ``Disallow empty second strand`` () =
    expect_equal(distance "G" "", None)

