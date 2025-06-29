import "hamming"

-- Empty strands
-- ==
-- input { "" "" }
-- output { 0 }

-- Single letter identical strands
-- ==
-- input { "A" "A" }
-- output { 0 }

-- Single letter different strands
-- ==
-- input { "G" "T" }
-- output { 1 }

-- Long identical strands
-- ==
-- input { "GGACTGAAATCTG" "GGACTGAAATCTG" }
-- output { 0 }

-- Long different strands
-- ==
-- input { "GGACGGATTCTG" "AGGACGGATTCT" }
-- output { 9 }

-- Disallow first strand longer
-- ==
-- input { "AATG" "AAA" }
-- output { None }

-- Disallow second strand longer
-- ==
-- input { "ATA" "AGTG" }
-- output { None }

-- Disallow empty first strand
-- ==
-- input { "" "G" }
-- output { None }

-- Disallow empty second strand
-- ==
-- input { "G" "" }
-- output { None }

