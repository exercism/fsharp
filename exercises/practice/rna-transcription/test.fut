import "rna_transcription"

-- Empty RNA sequence
-- ==
-- input { "" }
-- output { "" }

-- RNA complement of cytosine is guanine
-- ==
-- input { "C" }
-- output { "G" }

-- RNA complement of guanine is cytosine
-- ==
-- input { "G" }
-- output { "C" }

-- RNA complement of thymine is adenine
-- ==
-- input { "T" }
-- output { "A" }

-- RNA complement of adenine is uracil
-- ==
-- input { "A" }
-- output { "U" }

-- RNA complement
-- ==
-- input { "ACGTGGTCTTAA" }
-- output { "UGCACCAGAAUU" }

