import "protein_translation"

let ``Empty RNA sequence results in no proteins`` () =
    proteins "" |> should be Empty

-- Methionine RNA sequence
-- ==
-- input { "AUG" }
-- output { ["Methionine"] }

-- Phenylalanine RNA sequence 1
-- ==
-- input { "UUU" }
-- output { ["Phenylalanine"] }

-- Phenylalanine RNA sequence 2
-- ==
-- input { "UUC" }
-- output { ["Phenylalanine"] }

-- Leucine RNA sequence 1
-- ==
-- input { "UUA" }
-- output { ["Leucine"] }

-- Leucine RNA sequence 2
-- ==
-- input { "UUG" }
-- output { ["Leucine"] }

-- Serine RNA sequence 1
-- ==
-- input { "UCU" }
-- output { ["Serine"] }

-- Serine RNA sequence 2
-- ==
-- input { "UCC" }
-- output { ["Serine"] }

-- Serine RNA sequence 3
-- ==
-- input { "UCA" }
-- output { ["Serine"] }

-- Serine RNA sequence 4
-- ==
-- input { "UCG" }
-- output { ["Serine"] }

-- Tyrosine RNA sequence 1
-- ==
-- input { "UAU" }
-- output { ["Tyrosine"] }

-- Tyrosine RNA sequence 2
-- ==
-- input { "UAC" }
-- output { ["Tyrosine"] }

-- Cysteine RNA sequence 1
-- ==
-- input { "UGU" }
-- output { ["Cysteine"] }

-- Cysteine RNA sequence 2
-- ==
-- input { "UGC" }
-- output { ["Cysteine"] }

-- Tryptophan RNA sequence
-- ==
-- input { "UGG" }
-- output { ["Tryptophan"] }

let ``STOP codon RNA sequence 1`` () =
    proteins "UAA" |> should be Empty

let ``STOP codon RNA sequence 2`` () =
    proteins "UAG" |> should be Empty

let ``STOP codon RNA sequence 3`` () =
    proteins "UGA" |> should be Empty

-- Sequence of two protein codons translates into proteins
-- ==
-- input { "UUUUUU" }
-- output { ["Phenylalanine", "Phenylalanine"] }

-- Sequence of two different protein codons translates into proteins
-- ==
-- input { "UUAUUG" }
-- output { ["Leucine", "Leucine"] }

-- Translate RNA strand into correct protein list
-- ==
-- input { "AUGUUUUGG" }
-- output { ["Methionine", "Phenylalanine", "Tryptophan"] }

let ``Translation stops if STOP codon at beginning of sequence`` () =
    proteins "UAGUGG" |> should be Empty

-- Translation stops if STOP codon at end of two-codon sequence
-- ==
-- input { "UGGUAG" }
-- output { ["Tryptophan"] }

-- Translation stops if STOP codon at end of three-codon sequence
-- ==
-- input { "AUGUUUUAA" }
-- output { ["Methionine", "Phenylalanine"] }

-- Translation stops if STOP codon in middle of three-codon sequence
-- ==
-- input { "UGGUAGUGG" }
-- output { ["Tryptophan"] }

-- Translation stops if STOP codon in middle of six-codon sequence
-- ==
-- input { "UGGUGUUAUUAAUGGUUU" }
-- output { ["Tryptophan", "Cysteine", "Tyrosine"] }

