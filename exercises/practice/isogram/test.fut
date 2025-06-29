import "isogram"

-- Empty string
-- ==
-- input { "" }
-- output { true }

-- Isogram with only lower case characters
-- ==
-- input { "isogram" }
-- output { true }

-- Word with one duplicated character
-- ==
-- input { "eleven" }
-- output { false }

-- Word with one duplicated character from the end of the alphabet
-- ==
-- input { "zzyzx" }
-- output { false }

-- Longest reported english isogram
-- ==
-- input { "subdermatoglyphic" }
-- output { true }

-- Word with duplicated character in mixed case
-- ==
-- input { "Alphabet" }
-- output { false }

-- Word with duplicated character in mixed case, lowercase first
-- ==
-- input { "alphAbet" }
-- output { false }

-- Hypothetical isogrammic word with hyphen
-- ==
-- input { "thumbscrew-japingly" }
-- output { true }

-- Hypothetical word with duplicated character following hyphen
-- ==
-- input { "thumbscrew-jappingly" }
-- output { false }

-- Isogram with duplicated hyphen
-- ==
-- input { "six-year-old" }
-- output { true }

-- Made-up name that is an isogram
-- ==
-- input { "Emily Jung Schwartzkopf" }
-- output { true }

-- Duplicated character in the middle
-- ==
-- input { "accentor" }
-- output { false }

-- Same first and last characters
-- ==
-- input { "angola" }
-- output { false }

-- Word with duplicated character and with two hyphens
-- ==
-- input { "up-to-date" }
-- output { false }

