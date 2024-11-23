~ "largest-series-product.ua" ~ LargestSeriesProduct

# Finds the largest product if span equals length
    let digits = "29"
    let span = 2
⍤⤙≍ (Some 18) largestProduct digits span

# Can find the largest product of 2 with numbers in order
    let digits = "0123456789"
    let span = 2
⍤⤙≍ (Some 72) largestProduct digits span

# Can find the largest product of 2
    let digits = "576802143"
    let span = 2
⍤⤙≍ (Some 48) largestProduct digits span

# Can find the largest product of 3 with numbers in order
    let digits = "0123456789"
    let span = 3
⍤⤙≍ (Some 504) largestProduct digits span

# Can find the largest product of 3
    let digits = "1027839564"
    let span = 3
⍤⤙≍ (Some 270) largestProduct digits span

# Can find the largest product of 5 with numbers in order
    let digits = "0123456789"
    let span = 5
⍤⤙≍ (Some 15120) largestProduct digits span

# Can get the largest product of a big number
    let digits = "73167176531330624919225119674426574742355349194934"
    let span = 6
⍤⤙≍ (Some 23520) largestProduct digits span

# Reports zero if the only digits are zero
    let digits = "0000"
    let span = 2
⍤⤙≍ (Some 0) largestProduct digits span

# Reports zero if all spans include zero
    let digits = "99099"
    let span = 3
⍤⤙≍ (Some 0) largestProduct digits span

# Rejects span longer than string length
    let digits = "123"
    let span = 4
⍤⤙≍ None largestProduct digits span

# Rejects empty string and nonzero span
    let digits = ""
    let span = 1
⍤⤙≍ None largestProduct digits span

# Rejects invalid character in digits
    let digits = "1234a5"
    let span = 2
⍤⤙≍ None largestProduct digits span

# Rejects negative span
    let digits = "12345"
    let span = -1
⍤⤙≍ None largestProduct digits span

