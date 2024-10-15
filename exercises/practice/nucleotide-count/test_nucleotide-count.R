source("./nucleotide-count.R")
library(testthat)

test_that("Empty strand", {
    let strand = ""
  expected <- 
        c( ('A', 0);
          ('C', 0);
          ('G', 0);
          ('T', 0) )
        |> Map.ofList
        |> Some
  expect_equal(nucleotideCounts strand, expected)
})

test_that("Can count one nucleotide in single-character input", {
    let strand = "G"
  expected <- 
        c( ('A', 0);
          ('C', 0);
          ('G', 1);
          ('T', 0) )
        |> Map.ofList
        |> Some
  expect_equal(nucleotideCounts strand, expected)
})

test_that("Strand with repeated nucleotide", {
    let strand = "GGGGGGG"
  expected <- 
        c( ('A', 0);
          ('C', 0);
          ('G', 7);
          ('T', 0) )
        |> Map.ofList
        |> Some
  expect_equal(nucleotideCounts strand, expected)
})

test_that("Strand with multiple nucleotides", {
    let strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
  expected <- 
        c( ('A', 20);
          ('C', 12);
          ('G', 17);
          ('T', 21) )
        |> Map.ofList
        |> Some
  expect_equal(nucleotideCounts strand, expected)
})

test_that("Strand with invalid nucleotides", {
    let strand = "AGXXACT"
  expected <- None
  expect_equal(nucleotideCounts strand, expected)
})