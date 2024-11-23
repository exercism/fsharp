~ "perfect-numbers.ua" ~ PerfectNumbers

# Smallest perfect number is classified correctly
    classify 6 |> should equal (Some Classification.Perfect)

# Medium perfect number is classified correctly
    classify 28 |> should equal (Some Classification.Perfect)

# Large perfect number is classified correctly
    classify 33550336 |> should equal (Some Classification.Perfect)

# Smallest abundant number is classified correctly
    classify 12 |> should equal (Some Classification.Abundant)

# Medium abundant number is classified correctly
    classify 30 |> should equal (Some Classification.Abundant)

# Large abundant number is classified correctly
    classify 33550335 |> should equal (Some Classification.Abundant)

# Smallest prime deficient number is classified correctly
    classify 2 |> should equal (Some Classification.Deficient)

# Smallest non-prime deficient number is classified correctly
    classify 4 |> should equal (Some Classification.Deficient)

# Medium deficient number is classified correctly
    classify 32 |> should equal (Some Classification.Deficient)

# Large deficient number is classified correctly
    classify 33550337 |> should equal (Some Classification.Deficient)

# Edge case (no factors other than itself) is classified correctly
    classify 1 |> should equal (Some Classification.Deficient)

# Zero is rejected (as it is not a positive integer)
    classify 0 |> should equal None

# Negative integer is rejected (as it is not a positive integer)
    classify -1 |> should equal None

