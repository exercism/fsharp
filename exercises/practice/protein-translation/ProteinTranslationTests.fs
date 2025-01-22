source("./protein-translation.R")
library(testthat)

let ``Empty RNA sequence results in no proteins`` () =
    proteins "" |> should be Empty

let ``Methionine RNA sequence`` () =
    expect_equal(proteins "AUG", ["Methionine"])

let ``Phenylalanine RNA sequence 1`` () =
    expect_equal(proteins "UUU", ["Phenylalanine"])

let ``Phenylalanine RNA sequence 2`` () =
    expect_equal(proteins "UUC", ["Phenylalanine"])

let ``Leucine RNA sequence 1`` () =
    expect_equal(proteins "UUA", ["Leucine"])

let ``Leucine RNA sequence 2`` () =
    expect_equal(proteins "UUG", ["Leucine"])

let ``Serine RNA sequence 1`` () =
    expect_equal(proteins "UCU", ["Serine"])

let ``Serine RNA sequence 2`` () =
    expect_equal(proteins "UCC", ["Serine"])

let ``Serine RNA sequence 3`` () =
    expect_equal(proteins "UCA", ["Serine"])

let ``Serine RNA sequence 4`` () =
    expect_equal(proteins "UCG", ["Serine"])

let ``Tyrosine RNA sequence 1`` () =
    expect_equal(proteins "UAU", ["Tyrosine"])

let ``Tyrosine RNA sequence 2`` () =
    expect_equal(proteins "UAC", ["Tyrosine"])

let ``Cysteine RNA sequence 1`` () =
    expect_equal(proteins "UGU", ["Cysteine"])

let ``Cysteine RNA sequence 2`` () =
    expect_equal(proteins "UGC", ["Cysteine"])

let ``Tryptophan RNA sequence`` () =
    expect_equal(proteins "UGG", ["Tryptophan"])

let ``STOP codon RNA sequence 1`` () =
    proteins "UAA" |> should be Empty

let ``STOP codon RNA sequence 2`` () =
    proteins "UAG" |> should be Empty

let ``STOP codon RNA sequence 3`` () =
    proteins "UGA" |> should be Empty

let ``Sequence of two protein codons translates into proteins`` () =
    expect_equal(proteins "UUUUUU", ["Phenylalanine"; "Phenylalanine"])

let ``Sequence of two different protein codons translates into proteins`` () =
    expect_equal(proteins "UUAUUG", ["Leucine"; "Leucine"])

let ``Translate RNA strand into correct protein list`` () =
    expect_equal(proteins "AUGUUUUGG", ["Methionine"; "Phenylalanine"; "Tryptophan"])

let ``Translation stops if STOP codon at beginning of sequence`` () =
    proteins "UAGUGG" |> should be Empty

let ``Translation stops if STOP codon at end of two-codon sequence`` () =
    expect_equal(proteins "UGGUAG", ["Tryptophan"])

let ``Translation stops if STOP codon at end of three-codon sequence`` () =
    expect_equal(proteins "AUGUUUUAA", ["Methionine"; "Phenylalanine"])

let ``Translation stops if STOP codon in middle of three-codon sequence`` () =
    expect_equal(proteins "UGGUAGUGG", ["Tryptophan"])

let ``Translation stops if STOP codon in middle of six-codon sequence`` () =
    expect_equal(proteins "UGGUGUUAUUAAUGGUUU", ["Tryptophan"; "Cysteine"; "Tyrosine"])

