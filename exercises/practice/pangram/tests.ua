~ "pangram.ua" ~ Pangram

# Empty sentence
⍤⤙≍ 0 isPangram ""

# Perfect lower case
⍤⤙≍ 1 isPangram "abcdefghijklmnopqrstuvwxyz"

# Only lower case
⍤⤙≍ 1 isPangram "the quick brown fox jumps over the lazy dog"

# Missing the letter 'x'
⍤⤙≍ 0 isPangram "a quick movement of the enemy will jeopardize five gunboats"

# Missing the letter 'h'
⍤⤙≍ 0 isPangram "five boxing wizards jump quickly at it"

# With underscores
⍤⤙≍ 1 isPangram "the_quick_brown_fox_jumps_over_the_lazy_dog"

# With numbers
⍤⤙≍ 1 isPangram "the 1 quick brown fox jumps over the 2 lazy dogs"

# Missing letters replaced by numbers
⍤⤙≍ 0 isPangram "7h3 qu1ck brown fox jumps ov3r 7h3 lazy dog"

# Mixed case and punctuation
⍤⤙≍ 1 isPangram "\"Five quacking Zephyrs jolt my wax bed.\""

# A-m and A-M are 26 different characters but not a pangram
⍤⤙≍ 0 isPangram "abcdefghijklm ABCDEFGHIJKLM"

