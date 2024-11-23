~ "sum-of-multiples.ua" ~ SumOfMultiples

# No multiples within limit
⍤⤙≍ 0 sum [3 5] 1

# One factor has multiples within limit
⍤⤙≍ 3 sum [3 5] 4

# More than one multiple within limit
⍤⤙≍ 9 sum [3] 7

# More than one factor with multiples within limit
⍤⤙≍ 23 sum [3 5] 10

# Each multiple is only counted once
⍤⤙≍ 2318 sum [3 5] 100

# A much larger limit
⍤⤙≍ 233168 sum [3 5] 1000

# Three factors
⍤⤙≍ 51 sum [7 13 17] 20

# Factors not relatively prime
⍤⤙≍ 30 sum [4 6] 15

# pairs of factors relatively prime and not
⍤⤙≍ 4419 sum [5 6 8] 150

# One factor is a multiple of another
⍤⤙≍ 275 sum [5 25] 51

# Much larger factors
⍤⤙≍ 2203160 sum [43 47] 10000

# All numbers are multiples of 1
⍤⤙≍ 4950 sum [1] 100

# No factors means an empty sum
⍤⤙≍ 0 sum [] 10000

# The only multiple of 0 is 0
⍤⤙≍ 0 sum [0] 1

# The factor 0 does not affect the sum of multiples of other factors
⍤⤙≍ 3 sum [3 0] 4

# Solutions using include-exclude must extend to cardinality greater than 3
⍤⤙≍ 39614537 sum [2 3 5 7 11] 10000

