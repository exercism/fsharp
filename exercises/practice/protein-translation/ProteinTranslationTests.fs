source("./protein-translation.R")
library(testthat)

test_that("Empty RNA sequence results in no proteins", {
    proteins "" |> should be Empty

test_that("Methionine RNA sequence", {
    expect_equal(proteins "AUG", ["Methionine"])
})

test_that("Phenylalanine RNA sequence 1", {
    expect_equal(proteins "UUU", ["Phenylalanine"])
})

test_that("Phenylalanine RNA sequence 2", {
    expect_equal(proteins "UUC", ["Phenylalanine"])
})

test_that("Leucine RNA sequence 1", {
    expect_equal(proteins "UUA", ["Leucine"])
})

test_that("Leucine RNA sequence 2", {
    expect_equal(proteins "UUG", ["Leucine"])
})

test_that("Serine RNA sequence 1", {
    expect_equal(proteins "UCU", ["Serine"])
})

test_that("Serine RNA sequence 2", {
    expect_equal(proteins "UCC", ["Serine"])
})

test_that("Serine RNA sequence 3", {
    expect_equal(proteins "UCA", ["Serine"])
})

test_that("Serine RNA sequence 4", {
    expect_equal(proteins "UCG", ["Serine"])
})

test_that("Tyrosine RNA sequence 1", {
    expect_equal(proteins "UAU", ["Tyrosine"])
})

test_that("Tyrosine RNA sequence 2", {
    expect_equal(proteins "UAC", ["Tyrosine"])
})

test_that("Cysteine RNA sequence 1", {
    expect_equal(proteins "UGU", ["Cysteine"])
})

test_that("Cysteine RNA sequence 2", {
    expect_equal(proteins "UGC", ["Cysteine"])
})

test_that("Tryptophan RNA sequence", {
    expect_equal(proteins "UGG", ["Tryptophan"])
})

test_that("STOP codon RNA sequence 1", {
    proteins "UAA" |> should be Empty

test_that("STOP codon RNA sequence 2", {
    proteins "UAG" |> should be Empty

test_that("STOP codon RNA sequence 3", {
    proteins "UGA" |> should be Empty

test_that("Sequence of two protein codons translates into proteins", {
    expect_equal(proteins "UUUUUU", ["Phenylalanine"; "Phenylalanine"])
})

test_that("Sequence of two different protein codons translates into proteins", {
    expect_equal(proteins "UUAUUG", ["Leucine"; "Leucine"])
})

test_that("Translate RNA strand into correct protein list", {
    expect_equal(proteins "AUGUUUUGG", ["Methionine"; "Phenylalanine"; "Tryptophan"])
})

test_that("Translation stops if STOP codon at beginning of sequence", {
    proteins "UAGUGG" |> should be Empty

test_that("Translation stops if STOP codon at end of two-codon sequence", {
    expect_equal(proteins "UGGUAG", ["Tryptophan"])
})

test_that("Translation stops if STOP codon at end of three-codon sequence", {
    expect_equal(proteins "AUGUUUUAA", ["Methionine"; "Phenylalanine"])
})

test_that("Translation stops if STOP codon in middle of three-codon sequence", {
    expect_equal(proteins "UGGUAGUGG", ["Tryptophan"])
})

test_that("Translation stops if STOP codon in middle of six-codon sequence", {
    expect_equal(proteins "UGGUGUUAUUAAUGGUUU", ["Tryptophan"; "Cysteine"; "Tyrosine"])
})
