import "scrabble_score"

-- Lowercase letter
-- ==
-- input { "a" }
-- output { 1 }

-- Uppercase letter
-- ==
-- input { "A" }
-- output { 1 }

-- Valuable letter
-- ==
-- input { "f" }
-- output { 4 }

-- Short word
-- ==
-- input { "at" }
-- output { 2 }

-- Short, valuable word
-- ==
-- input { "zoo" }
-- output { 12 }

-- Medium word
-- ==
-- input { "street" }
-- output { 6 }

-- Medium, valuable word
-- ==
-- input { "quirky" }
-- output { 22 }

-- Long, mixed-case word
-- ==
-- input { "OxyphenButazone" }
-- output { 41 }

-- English-like word
-- ==
-- input { "pinata" }
-- output { 8 }

-- Empty input
-- ==
-- input { "" }
-- output { 0 }

-- Entire alphabet available
-- ==
-- input { "abcdefghijklmnopqrstuvwxyz" }
-- output { 87 }

