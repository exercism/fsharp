~ "collatz-conjecture.ua" ~ CollatzConjecture

# Zero steps for one
    steps 1 |> should equal (Some 0)

# Divide if even
    steps 16 |> should equal (Some 4)

# Even and odd steps
    steps 12 |> should equal (Some 9)

# Large number of even and odd steps
    steps 1000000 |> should equal (Some 152)

# Zero is an error
    steps 0 |> should equal None

# Negative value is an error
    steps -15 |> should equal None

