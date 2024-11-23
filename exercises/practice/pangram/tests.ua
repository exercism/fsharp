~ "pangram.ua" ~ Pangram

# Empty sentence
⍤⤙≍ false isPangram ""

# Perfect lower case
⍤⤙≍ true isPangram "abcdefghijklmnopqrstuvwxyz"

# Only lower case
⍤⤙≍ true isPangram "the quick brown fox jumps over the lazy dog"

# Missing the letter 'x'
⍤⤙≍ false isPangram "a quick movement of the enemy will jeopardize five gunboats"

# Missing the letter 'h'
⍤⤙≍ false isPangram "five boxing wizards jump quickly at it"

# With underscores
⍤⤙≍ true isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog"

# With numbers
⍤⤙≍ true isPangram "the 1 quick brown fox jumps over the 2 lazy dogs"

# Missing letters replaced by numbers
⍤⤙≍ false isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"

# Mixed case and punctuation
⍤⤙≍ true isPangram "\"Five quacking Zephyrs jolt my wax bed.\""

# A-m and A-M are 26 different characters but not a pangram
⍤⤙≍ false isPangram "abcdefghijklm ABCDEFGHIJKLM"

