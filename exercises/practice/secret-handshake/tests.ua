~ "secret-handshake.ua" ~ SecretHandshake

# Wink for 1
⍤⤙≍ ["wink"] commands 1

# Double blink for 10
⍤⤙≍ ["double blink"] commands 2

# Close your eyes for 100
⍤⤙≍ ["close your eyes"] commands 4

# Jump for 1000
⍤⤙≍ ["jump"] commands 8

# Combine two actions
⍤⤙≍ ["wink" "double blink"] commands 3

# Reverse two actions
⍤⤙≍ ["double blink" "wink"] commands 19

# Reversing one action gives the same action
⍤⤙≍ ["jump"] commands 24

# Reversing no actions still gives no actions
    commands 16 |> should be Empty

# All possible actions
⍤⤙≍ ["wink" "double blink" "close your eyes" "jump"] commands 15

# Reverse all possible actions
⍤⤙≍ ["jump" "close your eyes" "double blink" "wink"] commands 31

# Do nothing for zero
    commands 0 |> should be Empty

