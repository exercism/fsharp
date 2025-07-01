import "collatz_conjecture"

-- Zero steps for one
-- ==
-- input { 1 }
-- output { 0 }

-- Divide if even
-- ==
-- input { 16 }
-- output { 4 }

-- Even and odd steps
-- ==
-- input { 12 }
-- output { 9 }

-- Large number of even and odd steps
-- ==
-- input { 1000000 }
-- output { 152 }

-- Zero is an error
-- ==
-- input { 0 }
-- error: Error*

-- Negative value is an error
-- ==
-- input { -15 }
-- error: Error*

