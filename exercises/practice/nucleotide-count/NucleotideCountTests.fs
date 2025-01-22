source("./nucleotide-count.R")
library(testthat)

test_that("Empty strand", {
    strand <- ""
    expected <- 
        [ ('A', 0);
          ('C', 0);
          ('G', 0);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    expect_equal(nucleotideCounts(strand), expected)
})

test_that("Can count one nucleotide in single-character input", {
    strand <- "G"
    expected <- 
        [ ('A', 0);
          ('C', 0);
          ('G', 1);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    expect_equal(nucleotideCounts(strand), expected)
})

test_that("Strand with repeated nucleotide", {
    strand <- "GGGGGGG"
    expected <- 
        [ ('A', 0);
          ('C', 0);
          ('G', 7);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    expect_equal(nucleotideCounts(strand), expected)
})

test_that("Strand with multiple nucleotides", {
    strand <- "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    expected <- 
        [ ('A', 20);
          ('C', 12);
          ('G', 17);
          ('T', 21) ]
        |> Map.ofList
        |> Some
    expect_equal(nucleotideCounts(strand), expected)
})

test_that("Strand with invalid nucleotides", {
    strand <- "AGXXACT"
    expected <- None
    expect_equal(nucleotideCounts(strand), expected)
})
