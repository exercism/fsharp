import "perfect_numbers"

-- Smallest perfect number is classified correctly
-- ==
-- input { 6 }
-- output { Classification.Perfect }

-- Medium perfect number is classified correctly
-- ==
-- input { 28 }
-- output { Classification.Perfect }

-- Large perfect number is classified correctly
-- ==
-- input { 33550336 }
-- output { Classification.Perfect }

-- Smallest abundant number is classified correctly
-- ==
-- input { 12 }
-- output { Classification.Abundant }

-- Medium abundant number is classified correctly
-- ==
-- input { 30 }
-- output { Classification.Abundant }

-- Large abundant number is classified correctly
-- ==
-- input { 33550335 }
-- output { Classification.Abundant }

-- Smallest prime deficient number is classified correctly
-- ==
-- input { 2 }
-- output { Classification.Deficient }

-- Smallest non-prime deficient number is classified correctly
-- ==
-- input { 4 }
-- output { Classification.Deficient }

-- Medium deficient number is classified correctly
-- ==
-- input { 32 }
-- output { Classification.Deficient }

-- Large deficient number is classified correctly
-- ==
-- input { 33550337 }
-- output { Classification.Deficient }

-- Edge case (no factors other than itself) is classified correctly
-- ==
-- input { 1 }
-- output { Classification.Deficient }

-- Zero is rejected (as it is not a positive integer)
-- ==
-- input { 0 }
-- output { None }

-- Negative integer is rejected (as it is not a positive integer)
-- ==
-- input { -1 }
-- output { None }

