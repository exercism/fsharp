~ "protein-translation.ua" ~ ProteinTranslation

# Empty RNA sequence results in no proteins
    proteins "" |> should be Empty

# Methionine RNA sequence
    proteins "AUG" |> should equal ["Methionine"]

# Phenylalanine RNA sequence 1
    proteins "UUU" |> should equal ["Phenylalanine"]

# Phenylalanine RNA sequence 2
    proteins "UUC" |> should equal ["Phenylalanine"]

# Leucine RNA sequence 1
    proteins "UUA" |> should equal ["Leucine"]

# Leucine RNA sequence 2
    proteins "UUG" |> should equal ["Leucine"]

# Serine RNA sequence 1
    proteins "UCU" |> should equal ["Serine"]

# Serine RNA sequence 2
    proteins "UCC" |> should equal ["Serine"]

# Serine RNA sequence 3
    proteins "UCA" |> should equal ["Serine"]

# Serine RNA sequence 4
    proteins "UCG" |> should equal ["Serine"]

# Tyrosine RNA sequence 1
    proteins "UAU" |> should equal ["Tyrosine"]

# Tyrosine RNA sequence 2
    proteins "UAC" |> should equal ["Tyrosine"]

# Cysteine RNA sequence 1
    proteins "UGU" |> should equal ["Cysteine"]

# Cysteine RNA sequence 2
    proteins "UGC" |> should equal ["Cysteine"]

# Tryptophan RNA sequence
    proteins "UGG" |> should equal ["Tryptophan"]

# STOP codon RNA sequence 1
    proteins "UAA" |> should be Empty

# STOP codon RNA sequence 2
    proteins "UAG" |> should be Empty

# STOP codon RNA sequence 3
    proteins "UGA" |> should be Empty

# Sequence of two protein codons translates into proteins
    proteins "UUUUUU" |> should equal ["Phenylalanine"; "Phenylalanine"]

# Sequence of two different protein codons translates into proteins
    proteins "UUAUUG" |> should equal ["Leucine"; "Leucine"]

# Translate RNA strand into correct protein list
    proteins "AUGUUUUGG" |> should equal ["Methionine"; "Phenylalanine"; "Tryptophan"]

# Translation stops if STOP codon at beginning of sequence
    proteins "UAGUGG" |> should be Empty

# Translation stops if STOP codon at end of two-codon sequence
    proteins "UGGUAG" |> should equal ["Tryptophan"]

# Translation stops if STOP codon at end of three-codon sequence
    proteins "AUGUUUUAA" |> should equal ["Methionine"; "Phenylalanine"]

# Translation stops if STOP codon in middle of three-codon sequence
    proteins "UGGUAGUGG" |> should equal ["Tryptophan"]

# Translation stops if STOP codon in middle of six-codon sequence
    proteins "UGGUGUUAUUAAUGGUUU" |> should equal ["Tryptophan"; "Cysteine"; "Tyrosine"]

