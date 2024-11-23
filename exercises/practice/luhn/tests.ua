~ "luhn.ua" ~ Luhn

# Single digit strings can not be valid
⍤⤙≍ 0 valid "1"

# A single zero is invalid
⍤⤙≍ 0 valid "0"

# A simple valid SIN that remains valid if reversed
⍤⤙≍ 1 valid "059"

# A simple valid SIN that becomes invalid if reversed
⍤⤙≍ 1 valid "59"

# A valid Canadian SIN
⍤⤙≍ 1 valid "055 444 285"

# Invalid Canadian SIN
⍤⤙≍ 0 valid "055 444 286"

# Invalid credit card
⍤⤙≍ 0 valid "8273 1232 7352 0569"

# Invalid long number with an even remainder
⍤⤙≍ 0 valid "1 2345 6789 1234 5678 9012"

# Invalid long number with a remainder divisible by 5
⍤⤙≍ 0 valid "1 2345 6789 1234 5678 9013"

# Valid number with an even number of digits
⍤⤙≍ 1 valid "095 245 88"

# Valid number with an odd number of spaces
⍤⤙≍ 1 valid "234 567 891 234"

# Valid strings with a non-digit added at the end become invalid
⍤⤙≍ 0 valid "059a"

# Valid strings with punctuation included become invalid
⍤⤙≍ 0 valid "055-444-285"

# Valid strings with symbols included become invalid
⍤⤙≍ 0 valid "055# 444$ 285"

# Single zero with space is invalid
⍤⤙≍ 0 valid " 0"

# More than a single zero is valid
⍤⤙≍ 1 valid "0000 0"

# Input digit 9 is correctly converted to output digit 9
⍤⤙≍ 1 valid "091"

# Very long input is valid
⍤⤙≍ 1 valid "9999999999 9999999999 9999999999 9999999999"

# Valid luhn with an odd number of digits and non zero first digit
⍤⤙≍ 1 valid "109"

# Using ascii value for non-doubled non-digit isn't allowed
⍤⤙≍ 0 valid "055b 444 285"

# Using ascii value for doubled non-digit isn't allowed
⍤⤙≍ 0 valid ":9"

# Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed
⍤⤙≍ 0 valid "59%59"

