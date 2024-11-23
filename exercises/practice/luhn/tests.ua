~ "luhn.ua" ~ Luhn

# Single digit strings can not be valid
⍤⤙≍ false valid "1"

# A single zero is invalid
⍤⤙≍ false valid "0"

# A simple valid SIN that remains valid if reversed
⍤⤙≍ true valid "059"

# A simple valid SIN that becomes invalid if reversed
⍤⤙≍ true valid "59"

# A valid Canadian SIN
⍤⤙≍ true valid "055 444 285"

# Invalid Canadian SIN
⍤⤙≍ false valid "055 444 286"

# Invalid credit card
⍤⤙≍ false valid "8273 1232 7352 0569"

# Invalid long number with an even remainder
⍤⤙≍ false valid "1 2345 6789 1234 5678 9012"

# Invalid long number with a remainder divisible by 5
⍤⤙≍ false valid "1 2345 6789 1234 5678 9013"

# Valid number with an even number of digits
⍤⤙≍ true valid "095 245 88"

# Valid number with an odd number of spaces
⍤⤙≍ true valid "234 567 891 234"

# Valid strings with a non-digit added at the end become invalid
⍤⤙≍ false valid "059a"

# Valid strings with punctuation included become invalid
⍤⤙≍ false valid "055-444-285"

# Valid strings with symbols included become invalid
⍤⤙≍ false valid "055# 444$ 285"

# Single zero with space is invalid
⍤⤙≍ false valid " 0"

# More than a single zero is valid
⍤⤙≍ true valid "0000 0"

# Input digit 9 is correctly converted to output digit 9
⍤⤙≍ true valid "091"

# Very long input is valid
⍤⤙≍ true valid "9999999999 9999999999 9999999999 9999999999"

# Valid luhn with an odd number of digits and non zero first digit
⍤⤙≍ true valid "109"

# Using ascii value for non-doubled non-digit isn't allowed
⍤⤙≍ false valid "055b 444 285"

# Using ascii value for doubled non-digit isn't allowed
⍤⤙≍ false valid ":9"

# Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed
⍤⤙≍ false valid "59%59"

