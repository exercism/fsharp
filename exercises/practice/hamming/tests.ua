~ "hamming.ua" ~ Hamming

# Empty strands
⍤⤙≍ (Some 0) distance "" ""

# Single letter identical strands
⍤⤙≍ (Some 0) distance "A" "A"

# Single letter different strands
⍤⤙≍ (Some 1) distance "G" "T"

# Long identical strands
⍤⤙≍ (Some 0) distance "GGACTGAAATCTG" "GGACTGAAATCTG"

# Long different strands
⍤⤙≍ (Some 9) distance "GGACGGATTCTG" "AGGACGGATTCT"

# Disallow first strand longer
⍤⤙≍ None distance "AATG" "AAA"

# Disallow second strand longer
⍤⤙≍ None distance "ATA" "AGTG"

# Disallow empty first strand
⍤⤙≍ None distance "" "G"

# Disallow empty second strand
⍤⤙≍ None distance "G" ""

