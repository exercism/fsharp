source("./rna-transcription.R")
library(testthat)

let ``Empty RNA sequence`` () =
    expect_equal(toRna "", "")

let ``RNA complement of cytosine is guanine`` () =
    expect_equal(toRna "C", "G")

let ``RNA complement of guanine is cytosine`` () =
    expect_equal(toRna "G", "C")

let ``RNA complement of thymine is adenine`` () =
    expect_equal(toRna "T", "A")

let ``RNA complement of adenine is uracil`` () =
    expect_equal(toRna "A", "U")

let ``RNA complement`` () =
    expect_equal(toRna "ACGTGGTCTTAA", "UGCACCAGAAUU")

