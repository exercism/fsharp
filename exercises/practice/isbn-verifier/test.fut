import "isbn_verifier"

-- Valid isbn
-- ==
-- input { "3-598-21508-8" }
-- output { true }

-- Invalid isbn check digit
-- ==
-- input { "3-598-21508-9" }
-- output { false }

-- Valid isbn with a check digit of 10
-- ==
-- input { "3-598-21507-X" }
-- output { true }

-- Check digit is a character other than X
-- ==
-- input { "3-598-21507-A" }
-- output { false }

-- Invalid check digit in isbn is not treated as zero
-- ==
-- input { "4-598-21507-B" }
-- output { false }

-- Invalid character in isbn is not treated as zero
-- ==
-- input { "3-598-P1581-X" }
-- output { false }

-- X is only valid as a check digit
-- ==
-- input { "3-598-2X507-9" }
-- output { false }

-- Valid isbn without separating dashes
-- ==
-- input { "3598215088" }
-- output { true }

-- Isbn without separating dashes and X as check digit
-- ==
-- input { "359821507X" }
-- output { true }

-- Isbn without check digit and dashes
-- ==
-- input { "359821507" }
-- output { false }

-- Too long isbn and no dashes
-- ==
-- input { "3598215078X" }
-- output { false }

-- Too short isbn
-- ==
-- input { "00" }
-- output { false }

-- Isbn without check digit
-- ==
-- input { "3-598-21507" }
-- output { false }

-- Check digit of X should not be used for 0
-- ==
-- input { "3-598-21515-X" }
-- output { false }

-- Empty isbn
-- ==
-- input { "" }
-- output { false }

-- Input is 9 characters
-- ==
-- input { "134456729" }
-- output { false }

-- Invalid characters are not ignored after checking length
-- ==
-- input { "3132P34035" }
-- output { false }

-- Invalid characters are not ignored before checking length
-- ==
-- input { "3598P215088" }
-- output { false }

-- Input is too long but contains a valid isbn
-- ==
-- input { "98245726788" }
-- output { false }

