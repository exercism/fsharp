~ "nucleotide-count.ua" ~ NucleotideCount

# Empty strand
strand = ""
expected = 
        [ 'A'_0;
          'C'_0;
          'G'_0;
          'T'_0 ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Can count one nucleotide in single-character input
strand = "G"
expected = 
        [ 'A'_0;
          'C'_0;
          'G'_1;
          'T'_0 ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Strand with repeated nucleotide
strand = "GGGGGGG"
expected = 
        [ 'A'_0;
          'C'_0;
          'G'_7;
          'T'_0 ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Strand with multiple nucleotides
strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
expected = 
        [ 'A'_20;
          'C'_12;
          'G'_17;
          'T'_21 ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Strand with invalid nucleotides
strand = "AGXXACT"
⍤⤙≍ "TODO: insert error message" ⍣(nucleotideCounts strand)

