~ "luhn.ua" ~ Luhn

# Single digit strings can not be valid
    valid "1" |> should equal false

# A single zero is invalid
    valid "0" |> should equal false

# A simple valid SIN that remains valid if reversed
    valid "059" |> should equal true

# A simple valid SIN that becomes invalid if reversed
    valid "59" |> should equal true

# A valid Canadian SIN
    valid "055 444 285" |> should equal true

# Invalid Canadian SIN
    valid "055 444 286" |> should equal false

# Invalid credit card
    valid "8273 1232 7352 0569" |> should equal false

# Invalid long number with an even remainder
    valid "1 2345 6789 1234 5678 9012" |> should equal false

# Invalid long number with a remainder divisible by 5
    valid "1 2345 6789 1234 5678 9013" |> should equal false

# Valid number with an even number of digits
    valid "095 245 88" |> should equal true

# Valid number with an odd number of spaces
    valid "234 567 891 234" |> should equal true

# Valid strings with a non-digit added at the end become invalid
    valid "059a" |> should equal false

# Valid strings with punctuation included become invalid
    valid "055-444-285" |> should equal false

# Valid strings with symbols included become invalid
    valid "055# 444$ 285" |> should equal false

# Single zero with space is invalid
    valid " 0" |> should equal false

# More than a single zero is valid
    valid "0000 0" |> should equal true

# Input digit 9 is correctly converted to output digit 9
    valid "091" |> should equal true

# Very long input is valid
    valid "9999999999 9999999999 9999999999 9999999999" |> should equal true

# Valid luhn with an odd number of digits and non zero first digit
    valid "109" |> should equal true

# Using ascii value for non-doubled non-digit isn't allowed
    valid "055b 444 285" |> should equal false

# Using ascii value for doubled non-digit isn't allowed
    valid ":9" |> should equal false

# Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed
    valid "59%59" |> should equal false

