~ "hamming.ua" ~ Hamming

# Empty strands
⍤⤙≍ 0 distance "" ""

# Single letter identical strands
⍤⤙≍ 0 distance "A" "A"

# Single letter different strands
⍤⤙≍ 1 distance "G" "T"

# Long identical strands
⍤⤙≍ 0 distance "GGACTGAAATCTG" "GGACTGAAATCTG"

# Long different strands
⍤⤙≍ 9 distance "GGACGGATTCTG" "AGGACGGATTCT"

# Disallow first strand longer
⍤⤙≍ "TODO: insert error message" ⍣(distance "AATG" "AAA")

# Disallow second strand longer
⍤⤙≍ "TODO: insert error message" ⍣(distance "ATA" "AGTG")

# Disallow empty first strand
⍤⤙≍ "TODO: insert error message" ⍣(distance "" "G")

# Disallow empty second strand
⍤⤙≍ "TODO: insert error message" ⍣(distance "G" "")

