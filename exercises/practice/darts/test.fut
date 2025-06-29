import "darts"

-- Missed target
-- ==
-- input { -9.0 9.0 }
-- output { 0 }

-- On the outer circle
-- ==
-- input { 0.0 10.0 }
-- output { 1 }

-- On the middle circle
-- ==
-- input { -5.0 0.0 }
-- output { 5 }

-- On the inner circle
-- ==
-- input { 0.0 -1.0 }
-- output { 10 }

-- Exactly on center
-- ==
-- input { 0.0 0.0 }
-- output { 10 }

-- Near the center
-- ==
-- input { -0.1 -0.1 }
-- output { 10 }

-- Just within the inner circle
-- ==
-- input { 0.7 0.7 }
-- output { 10 }

-- Just outside the inner circle
-- ==
-- input { 0.8 -0.8 }
-- output { 5 }

-- Just within the middle circle
-- ==
-- input { -3.5 3.5 }
-- output { 5 }

-- Just outside the middle circle
-- ==
-- input { -3.6 -3.6 }
-- output { 1 }

-- Just within the outer circle
-- ==
-- input { -7.0 7.0 }
-- output { 1 }

-- Just outside the outer circle
-- ==
-- input { 7.1 -7.1 }
-- output { 0 }

-- Asymmetric position between the inner and middle circles
-- ==
-- input { 0.5 -4.0 }
-- output { 5 }

