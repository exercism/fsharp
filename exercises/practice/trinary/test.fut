import "trinary"

-- Trinary 1 is decimal 1
-- ==
-- input { "1" }
-- output { 1 }

-- Trinary 2 is decimal 2
-- ==
-- input { "2" }
-- output { 2 }

-- Trinary 10 is decimal 3
-- ==
-- input { "10" }
-- output { 3 }

-- Trinary 11 is decimal 4
-- ==
-- input { "11" }
-- output { 4 }

-- Trinary 100 is decimal 9
-- ==
-- input { "100" }
-- output { 9 }

-- Trinary 112 is decimal 14
-- ==
-- input { "112" }
-- output { 14 }

-- Trinary 222 is decimal 26
-- ==
-- input { "222" }
-- output { 26 }

-- Trinary 1122000120 is decimal 32091
-- ==
-- input { "1122000120" }
-- output { 32091 }

-- Invalid trinary digits returns 0
-- ==
-- input { "1234" }
-- output { 0 }

-- Invalid word as input returns 0
-- ==
-- input { "carrot" }
-- output { 0 }

-- Invalid numbers with letters as input returns 0
-- ==
-- input { "0a1b2c" }
-- output { 0 }

