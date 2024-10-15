source("./nucleotide-count.R")
library(testthat)

test_that("Empty strand", {
    let strand = ""
    let expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 0);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected
})

test_that("Can count one nucleotide in single-character input", {
    let strand = "G"
    let expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 1);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected
})

test_that("Strand with repeated nucleotide", {
    let strand = "GGGGGGG"
    let expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 7);
          ('T', 0) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected
})

test_that("Strand with multiple nucleotides", {
    let strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
    let expected = 
        [ ('A', 20);
          ('C', 12);
          ('G', 17);
          ('T', 21) ]
        |> Map.ofList
        |> Some
    nucleotideCounts strand |> should equal expected
})

test_that("Strand with invalid nucleotides", {
    let strand = "AGXXACT"
    let expected = None
    nucleotideCounts strand |> should equal expected

