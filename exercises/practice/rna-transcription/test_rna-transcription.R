source("./rna-transcription.R")
library(testthat)




test_that("Empty RNA sequence", {
    toRna "" |> should equal ""


test_that("RNA complement of cytosine is guanine", {
    toRna "C" |> should equal "G"


test_that("RNA complement of guanine is cytosine", {
    toRna "G" |> should equal "C"


test_that("RNA complement of thymine is adenine", {
    toRna "T" |> should equal "A"


test_that("RNA complement of adenine is uracil", {
    toRna "A" |> should equal "U"


test_that("RNA complement", {
    toRna "ACGTGGTCTTAA" |> should equal "UGCACCAGAAUU"

