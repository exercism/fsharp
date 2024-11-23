~ "octal.ua" ~ Octal

# Octal 1 is decimal 1
⍤⤙≍ 1 toDecimal "1"

# Octal 10 is decimal 8
⍤⤙≍ 8 toDecimal "10"

# Octal 17 is decimal 15
⍤⤙≍ 15 toDecimal "17"

# Octal 11 is decimal 9
⍤⤙≍ 9 toDecimal "11"

# Octal 130 is decimal 88
⍤⤙≍ 88 toDecimal "130"

# Octal 2047 is decimal 1063
⍤⤙≍ 1063 toDecimal "2047"

# Octal 7777 is decimal 4095
⍤⤙≍ 4095 toDecimal "7777"

# Octal 1234567 is decimal 342391
⍤⤙≍ 342391 toDecimal "1234567"

# Invalid Octal carrot is decimal 0
⍤⤙≍ 0 toDecimal "carrot"

# Invalid Octal 8 is decimal 0
⍤⤙≍ 0 toDecimal "8"

# Invalid Octal 9 is decimal 0
⍤⤙≍ 0 toDecimal "9"

# Invalid Octal 6789 is decimal 0
⍤⤙≍ 0 toDecimal "6789"

# Invalid Octal abc1z is decimal 0
⍤⤙≍ 0 toDecimal "abc1z"
