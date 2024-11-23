~ "matrix.ua" ~ Matrix

# Extract row from one number matrix
⍤⤙≍ [1] row 1 "1"

# Can extract row
⍤⤙≍ [3 4] row 2 "1 2\n3 4"

# Extract row where numbers have different widths
⍤⤙≍ [10 20] row 2 "1 2\n10 20"

# Can extract row from non-square matrix with no corresponding column
⍤⤙≍ [8 7 6] row 4 "1 2 3\n4 5 6\n7 8 9\n8 7 6"

# Extract column from one number matrix
⍤⤙≍ [1] column 1 "1"

# Can extract column
⍤⤙≍ [3 6 9] column 3 "1 2 3\n4 5 6\n7 8 9"

# Can extract column from non-square matrix with no corresponding row
⍤⤙≍ [4 8 6] column 4 "1 2 3 4\n5 6 7 8\n9 8 7 6"

# Extract column where numbers have different widths
⍤⤙≍ [1903 3 4] column 2 "89 1903 3\n18 3 1\n9 4 800"

