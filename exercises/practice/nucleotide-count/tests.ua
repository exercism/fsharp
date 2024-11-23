~ "nucleotide-count.ua" ~ NucleotideCount

# Empty strand
strand = ""
expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 0);
          ('T', 0) ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Can count one nucleotide in single-character input
strand = "G"
expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 1);
          ('T', 0) ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Strand with repeated nucleotide
strand = "GGGGGGG"
expected = 
        [ ('A', 0);
          ('C', 0);
          ('G', 7);
          ('T', 0) ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Strand with multiple nucleotides
strand = "AGCTTTTCATTCTGACTGCAACGGGCAATATGTCTCTGTGTGGATTAAAAAAAGAGTGTCTGATAGCAGC"
expected = 
        [ ('A', 20);
          ('C', 12);
          ('G', 17);
          ('T', 21) ]
        |> Map.ofList
        |> Some
⍤⤙≍ expected nucleotideCounts strand

# Strand with invalid nucleotides
strand = "AGXXACT"
⍤⤙≍ "TODO: insert error message" ⍣(nucleotideCounts strand)

