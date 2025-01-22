source("./protein-translation.R")
library(testthat)

test_that("Empty RNA sequence results in no proteins", {
    proteins "" |> should be Empty

test_that("Methionine RNA sequence", {
    expect_equal(proteins "AUG", c("Methionine"))
})

test_that("Phenylalanine RNA sequence 1", {
    expect_equal(proteins "UUU", c("Phenylalanine"))
})

test_that("Phenylalanine RNA sequence 2", {
    expect_equal(proteins "UUC", c("Phenylalanine"))
})

test_that("Leucine RNA sequence 1", {
    expect_equal(proteins "UUA", c("Leucine"))
})

test_that("Leucine RNA sequence 2", {
    expect_equal(proteins "UUG", c("Leucine"))
})

test_that("Serine RNA sequence 1", {
    expect_equal(proteins "UCU", c("Serine"))
})

test_that("Serine RNA sequence 2", {
    expect_equal(proteins "UCC", c("Serine"))
})

test_that("Serine RNA sequence 3", {
    expect_equal(proteins "UCA", c("Serine"))
})

test_that("Serine RNA sequence 4", {
    expect_equal(proteins "UCG", c("Serine"))
})

test_that("Tyrosine RNA sequence 1", {
    expect_equal(proteins "UAU", c("Tyrosine"))
})

test_that("Tyrosine RNA sequence 2", {
    expect_equal(proteins "UAC", c("Tyrosine"))
})

test_that("Cysteine RNA sequence 1", {
    expect_equal(proteins "UGU", c("Cysteine"))
})

test_that("Cysteine RNA sequence 2", {
    expect_equal(proteins "UGC", c("Cysteine"))
})

test_that("Tryptophan RNA sequence", {
    expect_equal(proteins "UGG", c("Tryptophan"))
})

test_that("STOP codon RNA sequence 1", {
    proteins "UAA" |> should be Empty

test_that("STOP codon RNA sequence 2", {
    proteins "UAG" |> should be Empty

test_that("STOP codon RNA sequence 3", {
    proteins "UGA" |> should be Empty

test_that("Sequence of two protein codons translates into proteins", {
    expect_equal(proteins "UUUUUU", c("Phenylalanine", "Phenylalanine"))
})

test_that("Sequence of two different protein codons translates into proteins", {
    expect_equal(proteins "UUAUUG", c("Leucine", "Leucine"))
})

test_that("Translate RNA strand into correct protein list", {
    expect_equal(proteins "AUGUUUUGG", c("Methionine", "Phenylalanine", "Tryptophan"))
})

test_that("Translation stops if STOP codon at beginning of sequence", {
    proteins "UAGUGG" |> should be Empty

test_that("Translation stops if STOP codon at end of two-codon sequence", {
    expect_equal(proteins "UGGUAG", c("Tryptophan"))
})

test_that("Translation stops if STOP codon at end of three-codon sequence", {
    expect_equal(proteins "AUGUUUUAA", c("Methionine", "Phenylalanine"))
})

test_that("Translation stops if STOP codon in middle of three-codon sequence", {
    expect_equal(proteins "UGGUAGUGG", c("Tryptophan"))
})

test_that("Translation stops if STOP codon in middle of six-codon sequence", {
    expect_equal(proteins "UGGUGUUAUUAAUGGUUU", c("Tryptophan", "Cysteine", "Tyrosine"))
})
