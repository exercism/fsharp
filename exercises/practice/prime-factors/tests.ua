~ "prime-factors.ua" ~ PrimeFactors

# No factors
    factors 1 |> should be Empty

# Prime number
⍤⤙≍ [2] factors 2

# Another prime number
⍤⤙≍ [3] factors 3

# Square of a prime
⍤⤙≍ [3 3] factors 9

# Product of first prime
⍤⤙≍ [2 2] factors 4

# Cube of a prime
⍤⤙≍ [2 2 2] factors 8

# Product of second prime
⍤⤙≍ [3 3 3] factors 27

# Product of third prime
⍤⤙≍ [5 5 5 5] factors 625

# Product of first and second prime
⍤⤙≍ [2 3] factors 6

# Product of primes and non-primes
⍤⤙≍ [2 2 3] factors 12

# Product of primes
⍤⤙≍ [5 17 23 461] factors 901255

# Factors include a large prime
⍤⤙≍ [11 9539 894119] factors 93819012551

