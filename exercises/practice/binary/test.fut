import "binary"

-- Binary 0 is decimal 0
-- ==
-- input { "0" }
-- output { 0 }

-- Binary 1 is decimal 1
-- ==
-- input { "1" }
-- output { 1 }

-- Binary 10 is decimal 2
-- ==
-- input { "10" }
-- output { 2 }

-- Binary 11 is decimal 3
-- ==
-- input { "11" }
-- output { 3 }

-- Binary 100 is decimal 4
-- ==
-- input { "100" }
-- output { 4 }

-- Binary 1001 is decimal 9
-- ==
-- input { "1001" }
-- output { 9 }

-- Binary 11010 is decimal 26
-- ==
-- input { "11010" }
-- output { 26 }

-- Binary 10001101000 is decimal 1128
-- ==
-- input { "10001101000" }
-- output { 1128 }

-- Binary ignores leading zeros
-- ==
-- input { "000011111" }
-- output { 31 }

-- 2 is not a valid binary digit
-- ==
-- input { "2" }
-- output { 0 }

-- A number containing a non binary digit is invalid
-- ==
-- input { "01201" }
-- output { 0 }

-- A number with trailing non binary characters is invalid
-- ==
-- input { "10nope" }
-- output { 0 }

-- A number with leading non binary characters is invalid
-- ==
-- input { "nope10" }
-- output { 0 }

-- A number with internal non binary characters is invalid
-- ==
-- input { "10nope10" }
-- output { 0 }

-- A number and a word whitespace separated is invalid
-- ==
-- input { "001 nope" }
-- output { 0 }

