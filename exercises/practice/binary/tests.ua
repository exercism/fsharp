~ "SOLUTION" ~ Binary

# Binary_0_is_decimal_0
⍤⤙≍ 0 toDecimal "0"

# Binary_1_is_decimal_1
⍤⤙≍ 1 toDecimal "1"

# Binary_10_is_decimal_2
⍤⤙≍ 2 toDecimal "10"

# Binary_11_is_decimal_3
⍤⤙≍ 3 toDecimal "11"

# Binary_100_is_decimal_4
⍤⤙≍ 4 toDecimal "100"

# Binary_1001_is_decimal_9
⍤⤙≍ 9 toDecimal "1001"

# Binary_11010_is_decimal_26
⍤⤙≍ 26 toDecimal "11010"

# Binary_10001101000_is_decimal_1128
⍤⤙≍ 1128 toDecimal "10001101000"

# Binary_ignores_leading_zeros
⍤⤙≍ 31 toDecimal "000011111"

# 2_is_not_a_valid_binary_digit
⍤⤙≍ 0 toDecimal "2"

# A_number_containing_a_non_binary_digit_is_invalid
⍤⤙≍ 0 toDecimal "01201"

# A_number_with_trailing_non_binary_characters_is_invalid
⍤⤙≍ 0 toDecimal "10nope"

# A_number_with_leading_non_binary_characters_is_invalid
⍤⤙≍ 0 toDecimal "nope10"

# A_number_with_internal_non_binary_characters_is_invalid
⍤⤙≍ 0 toDecimal "10nope10"

# A_number_and_a_word_whitespace_separated_is_invalid
⍤⤙≍ 0 toDecimal "001 nope"

