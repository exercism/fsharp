~ "series.ua" ~ Series

# Slices of one from one
    slices "1" 1 |> should equal (Some ["1"])

# Slices of one from two
    slices "12" 1 |> should equal (Some ["1"; "2"])

# Slices of two
    slices "35" 2 |> should equal (Some ["35"])

# Slices of two overlap
    slices "9142" 2 |> should equal (Some ["91"; "14"; "42"])

# Slices can include duplicates
    slices "777777" 3 |> should equal (Some ["777"; "777"; "777"; "777"])

# Slices of a long series
    slices "918493904243" 5 |> should equal (Some ["91849"; "18493"; "84939"; "49390"; "93904"; "39042"; "90424"; "04243"])

# Slice length is too large
    slices "12345" 6 |> should equal None

# Slice length is way too large
    slices "12345" 42 |> should equal None

# Slice length cannot be zero
    slices "12345" 0 |> should equal None

# Slice length cannot be negative
    slices "123" -1 |> should equal None

# Empty series is invalid
    slices "" 1 |> should equal None

