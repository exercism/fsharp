~ "perfect-numbers.ua" ~ PerfectNumbers

# Smallest perfect number is classified correctly
⍤⤙≍ (Some Classification.Perfect) classify 6

# Medium perfect number is classified correctly
⍤⤙≍ (Some Classification.Perfect) classify 28

# Large perfect number is classified correctly
⍤⤙≍ (Some Classification.Perfect) classify 33550336

# Smallest abundant number is classified correctly
⍤⤙≍ (Some Classification.Abundant) classify 12

# Medium abundant number is classified correctly
⍤⤙≍ (Some Classification.Abundant) classify 30

# Large abundant number is classified correctly
⍤⤙≍ (Some Classification.Abundant) classify 33550335

# Smallest prime deficient number is classified correctly
⍤⤙≍ (Some Classification.Deficient) classify 2

# Smallest non-prime deficient number is classified correctly
⍤⤙≍ (Some Classification.Deficient) classify 4

# Medium deficient number is classified correctly
⍤⤙≍ (Some Classification.Deficient) classify 32

# Large deficient number is classified correctly
⍤⤙≍ (Some Classification.Deficient) classify 33550337

# Edge case (no factors other than itself) is classified correctly
⍤⤙≍ (Some Classification.Deficient) classify 1

# Zero is rejected (as it is not a positive integer)
⍤⤙≍ None classify 0

# Negative integer is rejected (as it is not a positive integer)
⍤⤙≍ None classify -1

