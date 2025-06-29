import "octal"

-- Octal 1 is decimal 1
-- ==
-- input { "1" }
-- output { 1 }

-- Octal 10 is decimal 8
-- ==
-- input { "10" }
-- output { 8 }

-- Octal 17 is decimal 15
-- ==
-- input { "17" }
-- output { 15 }

-- Octal 11 is decimal 9
-- ==
-- input { "11" }
-- output { 9 }

-- Octal 130 is decimal 88
-- ==
-- input { "130" }
-- output { 88 }

-- Octal 2047 is decimal 1063
-- ==
-- input { "2047" }
-- output { 1063 }

-- Octal 7777 is decimal 4095
-- ==
-- input { "7777" }
-- output { 4095 }

-- Octal 1234567 is decimal 342391
-- ==
-- input { "1234567" }
-- output { 342391 }

-- Invalid Octal carrot is decimal 0
-- ==
-- input { "carrot" }
-- output { 0 }

-- Invalid Octal 8 is decimal 0
-- ==
-- input { "8" }
-- output { 0 }

-- Invalid Octal 9 is decimal 0
-- ==
-- input { "9" }
-- output { 0 }

-- Invalid Octal 6789 is decimal 0
-- ==
-- input { "6789" }
-- output { 0 }

-- Invalid Octal abc1z is decimal 0
-- ==
-- input { "abc1z" }
-- output { 0 }

