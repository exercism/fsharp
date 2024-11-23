~ "rna-transcription.ua" ~ RnaTranscription

# Empty RNA sequence
    toRna "" |> should equal ""

# RNA complement of cytosine is guanine
    toRna "C" |> should equal "G"

# RNA complement of guanine is cytosine
    toRna "G" |> should equal "C"

# RNA complement of thymine is adenine
    toRna "T" |> should equal "A"

# RNA complement of adenine is uracil
    toRna "A" |> should equal "U"

# RNA complement
    toRna "ACGTGGTCTTAA" |> should equal "UGCACCAGAAUU"

