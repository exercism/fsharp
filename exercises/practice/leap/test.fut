import "leap"

-- Year not divisible by 4 in common year
-- ==
-- input { 2015 }
-- output { false }

-- Year divisible by 2, not divisible by 4 in common year
-- ==
-- input { 1970 }
-- output { false }

-- Year divisible by 4, not divisible by 100 in leap year
-- ==
-- input { 1996 }
-- output { true }

-- Year divisible by 4 and 5 is still a leap year
-- ==
-- input { 1960 }
-- output { true }

-- Year divisible by 100, not divisible by 400 in common year
-- ==
-- input { 2100 }
-- output { false }

-- Year divisible by 100 but not by 3 is still not a leap year
-- ==
-- input { 1900 }
-- output { false }

-- Year divisible by 400 is leap year
-- ==
-- input { 2000 }
-- output { true }

-- Year divisible by 400 but not by 125 is still a leap year
-- ==
-- input { 2400 }
-- output { true }

-- Year divisible by 200, not divisible by 400 in common year
-- ==
-- input { 1800 }
-- output { false }

