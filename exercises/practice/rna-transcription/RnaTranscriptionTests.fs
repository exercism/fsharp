source("./rna-transcription.R")
library(testthat)

test_that("Empty RNA sequence", {
    expect_equal(toRna "", "")

test_that("RNA complement of cytosine is guanine", {
    expect_equal(toRna "C", "G")

test_that("RNA complement of guanine is cytosine", {
    expect_equal(toRna "G", "C")

test_that("RNA complement of thymine is adenine", {
    expect_equal(toRna "T", "A")

test_that("RNA complement of adenine is uracil", {
    expect_equal(toRna "A", "U")

test_that("RNA complement", {
    expect_equal(toRna "ACGTGGTCTTAA", "UGCACCAGAAUU")

