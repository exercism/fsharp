import "perfect_numbers"

-- Smallest perfect number is classified correctly
-- ==
-- input { 6 }
-- output { "Perfect" }

-- Medium perfect number is classified correctly
-- ==
-- input { 28 }
-- output { "Perfect" }

-- Large perfect number is classified correctly
-- ==
-- input { 33550336 }
-- output { "Perfect" }

-- Smallest abundant number is classified correctly
-- ==
-- input { 12 }
-- output { "Abundant" }

-- Medium abundant number is classified correctly
-- ==
-- input { 30 }
-- output { "Abundant" }

-- Large abundant number is classified correctly
-- ==
-- input { 33550335 }
-- output { "Abundant" }

-- Smallest prime deficient number is classified correctly
-- ==
-- input { 2 }
-- output { "Deficient" }

-- Smallest non-prime deficient number is classified correctly
-- ==
-- input { 4 }
-- output { "Deficient" }

-- Medium deficient number is classified correctly
-- ==
-- input { 32 }
-- output { "Deficient" }

-- Large deficient number is classified correctly
-- ==
-- input { 33550337 }
-- output { "Deficient" }

-- Edge case (no factors other than itself) is classified correctly
-- ==
-- input { 1 }
-- output { "Deficient" }

-- Zero is rejected (as it is not a positive integer)
-- ==
-- input { 0 }
-- output { None }

-- Negative integer is rejected (as it is not a positive integer)
-- ==
-- input { -1 }
-- output { None }

