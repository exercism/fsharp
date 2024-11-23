~ "series.ua" ~ Series

# Slices of one from one
⍤⤙≍ ["1"] slices "1" 1

# Slices of one from two
⍤⤙≍ ["1" "2"] slices "12" 1

# Slices of two
⍤⤙≍ ["35"] slices "35" 2

# Slices of two overlap
⍤⤙≍ ["91" "14" "42"] slices "9142" 2

# Slices can include duplicates
⍤⤙≍ ["777" "777" "777" "777"] slices "777777" 3

# Slices of a long series
⍤⤙≍ ["91849" "18493" "84939" "49390" "93904" "39042" "90424" "04243"] slices "918493904243" 5

# Slice length is too large
⍤⤙≍ "TODO: insert error message" ⍣(slices "12345" 6)

# Slice length is way too large
⍤⤙≍ "TODO: insert error message" ⍣(slices "12345" 42)

# Slice length cannot be zero
⍤⤙≍ "TODO: insert error message" ⍣(slices "12345" 0)

# Slice length cannot be negative
⍤⤙≍ "TODO: insert error message" ⍣(slices "123" -1)

# Empty series is invalid
⍤⤙≍ "TODO: insert error message" ⍣(slices "" 1)

