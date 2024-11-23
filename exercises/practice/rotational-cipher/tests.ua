~ "rotational-cipher.ua" ~ RotationalCipher

# Rotate a by 0, same output as input
⍤⤙≍ "a" rotate 0 "a"

# Rotate a by 1
⍤⤙≍ "b" rotate 1 "a"

# Rotate a by 26, same output as input
⍤⤙≍ "a" rotate 26 "a"

# Rotate m by 13
⍤⤙≍ "z" rotate 13 "m"

# Rotate n by 13 with wrap around alphabet
⍤⤙≍ "a" rotate 13 "n"

# Rotate capital letters
⍤⤙≍ "TRL" rotate 5 "OMG"

# Rotate spaces
⍤⤙≍ "T R L" rotate 5 "O M G"

# Rotate numbers
⍤⤙≍ "Xiwxmrk 1 2 3 xiwxmrk" rotate 4 "Testing 1 2 3 testing"

# Rotate punctuation
⍤⤙≍ "Gzo'n zvo, Bmviyhv!" rotate 21 "Let's eat, Grandma!"

# Rotate all letters
⍤⤙≍ "Gur dhvpx oebja sbk whzcf bire gur ynml qbt." rotate 13 "The quick brown fox jumps over the lazy dog."

