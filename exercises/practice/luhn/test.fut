import "luhn"

-- Single digit strings can not be valid
-- ==
-- input { "1" }
-- output { false }

-- A single zero is invalid
-- ==
-- input { "0" }
-- output { false }

-- A simple valid SIN that remains valid if reversed
-- ==
-- input { "059" }
-- output { true }

-- A simple valid SIN that becomes invalid if reversed
-- ==
-- input { "59" }
-- output { true }

-- A valid Canadian SIN
-- ==
-- input { "055 444 285" }
-- output { true }

-- Invalid Canadian SIN
-- ==
-- input { "055 444 286" }
-- output { false }

-- Invalid credit card
-- ==
-- input { "8273 1232 7352 0569" }
-- output { false }

-- Invalid long number with an even remainder
-- ==
-- input { "1 2345 6789 1234 5678 9012" }
-- output { false }

-- Invalid long number with a remainder divisible by 5
-- ==
-- input { "1 2345 6789 1234 5678 9013" }
-- output { false }

-- Valid number with an even number of digits
-- ==
-- input { "095 245 88" }
-- output { true }

-- Valid number with an odd number of spaces
-- ==
-- input { "234 567 891 234" }
-- output { true }

-- Valid strings with a non-digit added at the end become invalid
-- ==
-- input { "059a" }
-- output { false }

-- Valid strings with punctuation included become invalid
-- ==
-- input { "055-444-285" }
-- output { false }

-- Valid strings with symbols included become invalid
-- ==
-- input { "055# 444$ 285" }
-- output { false }

-- Single zero with space is invalid
-- ==
-- input { " 0" }
-- output { false }

-- More than a single zero is valid
-- ==
-- input { "0000 0" }
-- output { true }

-- Input digit 9 is correctly converted to output digit 9
-- ==
-- input { "091" }
-- output { true }

-- Very long input is valid
-- ==
-- input { "9999999999 9999999999 9999999999 9999999999" }
-- output { true }

-- Valid luhn with an odd number of digits and non zero first digit
-- ==
-- input { "109" }
-- output { true }

-- Using ascii value for non-doubled non-digit isn't allowed
-- ==
-- input { "055b 444 285" }
-- output { false }

-- Using ascii value for doubled non-digit isn't allowed
-- ==
-- input { ":9" }
-- output { false }

-- Non-numeric, non-space char in the middle with a sum that's divisible by 10 isn't allowed
-- ==
-- input { "59%59" }
-- output { false }

