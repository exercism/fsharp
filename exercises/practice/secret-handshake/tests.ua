~ "secret-handshake.ua" ~ SecretHandshake

# Wink for 1
    commands 1 |> should equal ["wink"]

# Double blink for 10
    commands 2 |> should equal ["double blink"]

# Close your eyes for 100
    commands 4 |> should equal ["close your eyes"]

# Jump for 1000
    commands 8 |> should equal ["jump"]

# Combine two actions
    commands 3 |> should equal ["wink"; "double blink"]

# Reverse two actions
    commands 19 |> should equal ["double blink"; "wink"]

# Reversing one action gives the same action
    commands 24 |> should equal ["jump"]

# Reversing no actions still gives no actions
    commands 16 |> should be Empty

# All possible actions
    commands 15 |> should equal ["wink"; "double blink"; "close your eyes"; "jump"]

# Reverse all possible actions
    commands 31 |> should equal ["jump"; "close your eyes"; "double blink"; "wink"]

# Do nothing for zero
    commands 0 |> should be Empty

