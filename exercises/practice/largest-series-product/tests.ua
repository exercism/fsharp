~ "largest-series-product.ua" ~ LargestSeriesProduct

# Finds the largest product if span equals length
digits = "29"
span = 2
⍤⤙≍ 18 largestProduct digits span

# Can find the largest product of 2 with numbers in order
digits = "0123456789"
span = 2
⍤⤙≍ 72 largestProduct digits span

# Can find the largest product of 2
digits = "576802143"
span = 2
⍤⤙≍ 48 largestProduct digits span

# Can find the largest product of 3 with numbers in order
digits = "0123456789"
span = 3
⍤⤙≍ 504 largestProduct digits span

# Can find the largest product of 3
digits = "1027839564"
span = 3
⍤⤙≍ 270 largestProduct digits span

# Can find the largest product of 5 with numbers in order
digits = "0123456789"
span = 5
⍤⤙≍ 15120 largestProduct digits span

# Can get the largest product of a big number
digits = "73167176531330624919225119674426574742355349194934"
span = 6
⍤⤙≍ 23520 largestProduct digits span

# Reports zero if the only digits are zero
digits = "0000"
span = 2
⍤⤙≍ 0 largestProduct digits span

# Reports zero if all spans include zero
digits = "99099"
span = 3
⍤⤙≍ 0 largestProduct digits span

# Rejects span longer than string length
digits = "123"
span = 4
⍤⤙≍ "TODO: insert error message" ⍣(largestProduct digits span)

# Rejects empty string and nonzero span
digits = ""
span = 1
⍤⤙≍ "TODO: insert error message" ⍣(largestProduct digits span)

# Rejects invalid character in digits
digits = "1234a5"
span = 2
⍤⤙≍ "TODO: insert error message" ⍣(largestProduct digits span)

# Rejects negative span
digits = "12345"
span = -1
⍤⤙≍ "TODO: insert error message" ⍣(largestProduct digits span)

