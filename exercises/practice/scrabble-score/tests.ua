~ "scrabble-score.ua" ~ ScrabbleScore

# Lowercase letter
    score "a" |> should equal 1

# Uppercase letter
    score "A" |> should equal 1

# Valuable letter
    score "f" |> should equal 4

# Short word
    score "at" |> should equal 2

# Short, valuable word
    score "zoo" |> should equal 12

# Medium word
    score "street" |> should equal 6

# Medium, valuable word
    score "quirky" |> should equal 22

# Long, mixed-case word
    score "OxyphenButazone" |> should equal 41

# English-like word
    score "pinata" |> should equal 8

# Empty input
    score "" |> should equal 0

# Entire alphabet available
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87

