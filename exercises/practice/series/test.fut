import "series"

-- Slices of one from one
-- ==
-- input { "1" 1 }
-- output { ["1"] }

-- Slices of one from two
-- ==
-- input { "12" 1 }
-- output { ["1", "2"] }

-- Slices of two
-- ==
-- input { "35" 2 }
-- output { ["35"] }

-- Slices of two overlap
-- ==
-- input { "9142" 2 }
-- output { ["91", "14", "42"] }

-- Slices can include duplicates
-- ==
-- input { "777777" 3 }
-- output { ["777", "777", "777", "777"] }

-- Slices of a long series
-- ==
-- input { "918493904243" 5 }
-- output { ["91849", "18493", "84939", "49390", "93904", "39042", "90424", "04243"] }

-- Slice length is too large
-- ==
-- input { "12345" 6 }
-- error: Error*

-- Slice length is way too large
-- ==
-- input { "12345" 42 }
-- error: Error*

-- Slice length cannot be zero
-- ==
-- input { "12345" 0 }
-- error: Error*

-- Slice length cannot be negative
-- ==
-- input { "123" -1 }
-- error: Error*

-- Empty series is invalid
-- ==
-- input { "" 1 }
-- error: Error*

