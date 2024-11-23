~ "phone-number.ua" ~ PhoneNumber

# Cleans the number
Expected ← 2234567890
⍤⤙≍ Expected clean "(223) 456-7890"

# Cleans numbers with dots
Expected ← 2234567890
⍤⤙≍ Expected clean "223.456.7890"

# Cleans numbers with multiple spaces
Expected ← 2234567890
⍤⤙≍ Expected clean "223 456   7890   "

# Invalid when 9 digits
⍤⤙≍ "incorrect number of digits" ⍣(clean "123456789")

# Invalid when 11 digits does not start with a 1
⍤⤙≍ "11 digits must start with 1" ⍣(clean "22234567890")

# Valid when 11 digits and starting with 1
Expected ← 2234567890
⍤⤙≍ Expected clean "12234567890"

# Valid when 11 digits and starting with 1 even with punctuation
Expected ← 2234567890
⍤⤙≍ Expected clean "+1 (223) 456-7890"

# Invalid when more than 11 digits
⍤⤙≍ "more than 11 digits" ⍣(clean "321234567890")

# Invalid with letters
⍤⤙≍ "letters not permitted" ⍣(clean "523-abc-7890")

# Invalid with punctuations
⍤⤙≍ "punctuations not permitted" ⍣(clean "523-@:!-7890")

# Invalid if area code starts with 0
⍤⤙≍ "area code cannot start with zero" ⍣(clean "(023) 456-7890")

# Invalid if area code starts with 1
⍤⤙≍ "area code cannot start with one" ⍣(clean "(123) 456-7890")

# Invalid if exchange code starts with 0
⍤⤙≍ "exchange code cannot start with zero" ⍣(clean "(223) 056-7890")

# Invalid if exchange code starts with 1
⍤⤙≍ "exchange code cannot start with one" ⍣(clean "(223) 156-7890")

# Invalid if area code starts with 0 on valid 11-digit number
⍤⤙≍ "area code cannot start with zero" ⍣(clean "1 (023) 456-7890")

# Invalid if area code starts with 1 on valid 11-digit number
⍤⤙≍ "area code cannot start with one" ⍣(clean "1 (123) 456-7890")

# Invalid if exchange code starts with 0 on valid 11-digit number
⍤⤙≍ "exchange code cannot start with zero" ⍣(clean "1 (223) 056-7890")

# Invalid if exchange code starts with 1 on valid 11-digit number
⍤⤙≍ "exchange code cannot start with one" ⍣(clean "1 (223) 156-7890")
