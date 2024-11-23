~ "prime-factors.ua" ~ PrimeFactors

# No factors
    factors 1L |> should be Empty

# Prime number
    factors 2L |> should equal [2]

# Another prime number
    factors 3L |> should equal [3]

# Square of a prime
    factors 9L |> should equal [3 3]

# Product of first prime
    factors 4L |> should equal [2 2]

# Cube of a prime
    factors 8L |> should equal [2 2 2]

# Product of second prime
    factors 27L |> should equal [3 3 3]

# Product of third prime
    factors 625L |> should equal [5 5 5 5]

# Product of first and second prime
    factors 6L |> should equal [2 3]

# Product of primes and non-primes
    factors 12L |> should equal [2 2 3]

# Product of primes
    factors 901255L |> should equal [5 17 23 461]

# Factors include a large prime
    factors 93819012551L |> should equal [11 9539 894119]

