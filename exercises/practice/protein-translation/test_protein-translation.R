source("./protein-translation.R")
library(testthat)

test_that("Empty RNA sequence results in no proteins", {
    proteins "" |> should be Empty
})

test_that("Methionine RNA sequence", {
    proteins "AUG" |> should equal ["Methionine"]
})

test_that("Phenylalanine RNA sequence 1", {
    proteins "UUU" |> should equal ["Phenylalanine"]
})

test_that("Phenylalanine RNA sequence 2", {
    proteins "UUC" |> should equal ["Phenylalanine"]
})

test_that("Leucine RNA sequence 1", {
    proteins "UUA" |> should equal ["Leucine"]
})

test_that("Leucine RNA sequence 2", {
    proteins "UUG" |> should equal ["Leucine"]
})

test_that("Serine RNA sequence 1", {
    proteins "UCU" |> should equal ["Serine"]
})

test_that("Serine RNA sequence 2", {
    proteins "UCC" |> should equal ["Serine"]
})

test_that("Serine RNA sequence 3", {
    proteins "UCA" |> should equal ["Serine"]
})

test_that("Serine RNA sequence 4", {
    proteins "UCG" |> should equal ["Serine"]
})

test_that("Tyrosine RNA sequence 1", {
    proteins "UAU" |> should equal ["Tyrosine"]
})

test_that("Tyrosine RNA sequence 2", {
    proteins "UAC" |> should equal ["Tyrosine"]
})

test_that("Cysteine RNA sequence 1", {
    proteins "UGU" |> should equal ["Cysteine"]
})

test_that("Cysteine RNA sequence 2", {
    proteins "UGC" |> should equal ["Cysteine"]
})

test_that("Tryptophan RNA sequence", {
    proteins "UGG" |> should equal ["Tryptophan"]
})

test_that("STOP codon RNA sequence 1", {
    proteins "UAA" |> should be Empty
})

test_that("STOP codon RNA sequence 2", {
    proteins "UAG" |> should be Empty
})

test_that("STOP codon RNA sequence 3", {
    proteins "UGA" |> should be Empty
})

test_that("Sequence of two protein codons translates into proteins", {
    proteins "UUUUUU" |> should equal ["Phenylalanine"; "Phenylalanine"]
})

test_that("Sequence of two different protein codons translates into proteins", {
    proteins "UUAUUG" |> should equal ["Leucine"; "Leucine"]
})

test_that("Translate RNA strand into correct protein list", {
    proteins "AUGUUUUGG" |> should equal ["Methionine"; "Phenylalanine"; "Tryptophan"]
})

test_that("Translation stops if STOP codon at beginning of sequence", {
    proteins "UAGUGG" |> should be Empty
})

test_that("Translation stops if STOP codon at end of two-codon sequence", {
    proteins "UGGUAG" |> should equal ["Tryptophan"]
})

test_that("Translation stops if STOP codon at end of three-codon sequence", {
    proteins "AUGUUUUAA" |> should equal ["Methionine"; "Phenylalanine"]
})

test_that("Translation stops if STOP codon in middle of three-codon sequence", {
    proteins "UGGUAGUGG" |> should equal ["Tryptophan"]
})

test_that("Translation stops if STOP codon in middle of six-codon sequence", {
    proteins "UGGUGUUAUUAAUGGUUU" |> should equal ["Tryptophan"; "Cysteine"; "Tyrosine"]

