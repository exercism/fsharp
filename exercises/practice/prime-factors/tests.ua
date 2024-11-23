~ "prime-factors.ua" ~ PrimeFactors

# No factors
    factors 1 |> should be Empty

# Prime number
    factors 2 |> should equal [2]

# Another prime number
    factors 3 |> should equal [3]

# Square of a prime
    factors 9 |> should equal [3 3]

# Product of first prime
    factors 4 |> should equal [2 2]

# Cube of a prime
    factors 8 |> should equal [2 2 2]

# Product of second prime
    factors 27 |> should equal [3 3 3]

# Product of third prime
    factors 625 |> should equal [5 5 5 5]

# Product of first and second prime
    factors 6 |> should equal [2 3]

# Product of primes and non-primes
    factors 12 |> should equal [2 2 3]

# Product of primes
    factors 901255 |> should equal [5 17 23 461]

# Factors include a large prime
    factors 93819012551 |> should equal [11 9539 894119]

