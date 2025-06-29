import "matrix"

-- Extract row from one number matrix
-- ==
-- input { 1 "1" }
-- output { [1] }

-- Can extract row
-- ==
-- input { 2 "1 2\n3 4" }
-- output { [3, 4] }

-- Extract row where numbers have different widths
-- ==
-- input { 2 "1 2\n10 20" }
-- output { [10, 20] }

-- Can extract row from non-square matrix with no corresponding column
-- ==
-- input { 4 "1 2 3\n4 5 6\n7 8 9\n8 7 6" }
-- output { [8, 7, 6] }

-- Extract column from one number matrix
-- ==
-- input { 1 "1" }
-- output { [1] }

-- Can extract column
-- ==
-- input { 3 "1 2 3\n4 5 6\n7 8 9" }
-- output { [3, 6, 9] }

-- Can extract column from non-square matrix with no corresponding row
-- ==
-- input { 4 "1 2 3 4\n5 6 7 8\n9 8 7 6" }
-- output { [4, 8, 6] }

-- Extract column where numbers have different widths
-- ==
-- input { 2 "89 1903 3\n18 3 1\n9 4 800" }
-- output { [1903, 3, 4] }

