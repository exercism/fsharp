~ "say.ua" ~ Say

# Zero
    say 0 |> should equal (Some "zero")

# One
    say 1 |> should equal (Some "one")

# Fourteen
    say 14 |> should equal (Some "fourteen")

# Twenty
    say 20 |> should equal (Some "twenty")

# Twenty-two
    say 22 |> should equal (Some "twenty-two")

# Thirty
    say 30 |> should equal (Some "thirty")

# Ninety-nine
    say 99 |> should equal (Some "ninety-nine")

# One hundred
    say 100 |> should equal (Some "one hundred")

# One hundred twenty-three
    say 123 |> should equal (Some "one hundred twenty-three")

# Two hundred
    say 200 |> should equal (Some "two hundred")

# Nine hundred ninety-nine
    say 999 |> should equal (Some "nine hundred ninety-nine")

# One thousand
    say 1000 |> should equal (Some "one thousand")

# One thousand two hundred thirty-four
    say 1234 |> should equal (Some "one thousand two hundred thirty-four")

# One million
    say 1000000 |> should equal (Some "one million")

# One million two thousand three hundred forty-five
    say 1002345 |> should equal (Some "one million two thousand three hundred forty-five")

# One billion
    say 1000000000 |> should equal (Some "one billion")

# A big number
    say 987654321123 |> should equal (Some "nine hundred eighty-seven billion six hundred fifty-four million three hundred twenty-one thousand one hundred twenty-three")

# Numbers below zero are out of range
    say -1 |> should equal None

# Numbers above 999,999,999,999 are out of range
    say 1000000000000 |> should equal None

