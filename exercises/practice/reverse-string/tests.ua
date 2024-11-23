~ "reverse-string.ua" ~ ReverseString

# An empty string
    reverse "" |> should equal ""

# A word
    reverse "robot" |> should equal "tobor"

# A capitalized word
    reverse "Ramen" |> should equal "nemaR"

# A sentence with punctuation
    reverse "I'm hungry!" |> should equal "!yrgnuh m'I"

# A palindrome
    reverse "racecar" |> should equal "racecar"

# An even-sized word
    reverse "drawer" |> should equal "reward"

