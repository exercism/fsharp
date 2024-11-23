~ "hamming.ua" ~ Hamming

# Empty strands
    distance "" "" |> should equal (Some 0)

# Single letter identical strands
    distance "A" "A" |> should equal (Some 0)

# Single letter different strands
    distance "G" "T" |> should equal (Some 1)

# Long identical strands
    distance "GGACTGAAATCTG" "GGACTGAAATCTG" |> should equal (Some 0)

# Long different strands
    distance "GGACGGATTCTG" "AGGACGGATTCT" |> should equal (Some 9)

# Disallow first strand longer
    distance "AATG" "AAA" |> should equal None

# Disallow second strand longer
    distance "ATA" "AGTG" |> should equal None

# Disallow empty first strand
    distance "" "G" |> should equal None

# Disallow empty second strand
    distance "G" "" |> should equal None

