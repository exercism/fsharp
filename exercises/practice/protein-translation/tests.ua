~ "protein-translation.ua" ~ ProteinTranslation

# Empty RNA sequence results in no proteins
    proteins "" |> should be Empty

# Methionine RNA sequence
⍤⤙≍ ["Methionine"] proteins "AUG"

# Phenylalanine RNA sequence 1
⍤⤙≍ ["Phenylalanine"] proteins "UUU"

# Phenylalanine RNA sequence 2
⍤⤙≍ ["Phenylalanine"] proteins "UUC"

# Leucine RNA sequence 1
⍤⤙≍ ["Leucine"] proteins "UUA"

# Leucine RNA sequence 2
⍤⤙≍ ["Leucine"] proteins "UUG"

# Serine RNA sequence 1
⍤⤙≍ ["Serine"] proteins "UCU"

# Serine RNA sequence 2
⍤⤙≍ ["Serine"] proteins "UCC"

# Serine RNA sequence 3
⍤⤙≍ ["Serine"] proteins "UCA"

# Serine RNA sequence 4
⍤⤙≍ ["Serine"] proteins "UCG"

# Tyrosine RNA sequence 1
⍤⤙≍ ["Tyrosine"] proteins "UAU"

# Tyrosine RNA sequence 2
⍤⤙≍ ["Tyrosine"] proteins "UAC"

# Cysteine RNA sequence 1
⍤⤙≍ ["Cysteine"] proteins "UGU"

# Cysteine RNA sequence 2
⍤⤙≍ ["Cysteine"] proteins "UGC"

# Tryptophan RNA sequence
⍤⤙≍ ["Tryptophan"] proteins "UGG"

# STOP codon RNA sequence 1
    proteins "UAA" |> should be Empty

# STOP codon RNA sequence 2
    proteins "UAG" |> should be Empty

# STOP codon RNA sequence 3
    proteins "UGA" |> should be Empty

# Sequence of two protein codons translates into proteins
⍤⤙≍ ["Phenylalanine" "Phenylalanine"] proteins "UUUUUU"

# Sequence of two different protein codons translates into proteins
⍤⤙≍ ["Leucine" "Leucine"] proteins "UUAUUG"

# Translate RNA strand into correct protein list
⍤⤙≍ ["Methionine" "Phenylalanine" "Tryptophan"] proteins "AUGUUUUGG"

# Translation stops if STOP codon at beginning of sequence
    proteins "UAGUGG" |> should be Empty

# Translation stops if STOP codon at end of two-codon sequence
⍤⤙≍ ["Tryptophan"] proteins "UGGUAG"

# Translation stops if STOP codon at end of three-codon sequence
⍤⤙≍ ["Methionine" "Phenylalanine"] proteins "AUGUUUUAA"

# Translation stops if STOP codon in middle of three-codon sequence
⍤⤙≍ ["Tryptophan"] proteins "UGGUAGUGG"

# Translation stops if STOP codon in middle of six-codon sequence
⍤⤙≍ ["Tryptophan" "Cysteine" "Tyrosine"] proteins "UGGUGUUAUUAAUGGUUU"

