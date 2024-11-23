~ "nth-prime.ua" ~ NthPrime

# First prime
    prime 1 |> should equal (Some 2)

# Second prime
    prime 2 |> should equal (Some 3)

# Sixth prime
    prime 6 |> should equal (Some 13)

# Big prime
    prime 10001 |> should equal (Some 104743)

# There is no zeroth prime
    prime 0 |> should equal None

