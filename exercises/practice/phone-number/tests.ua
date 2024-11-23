~ "phone-number.ua" ~ PhoneNumber

# Cleans the number
    let expected: Result<uint64,string> = Ok 2234567890
⍤⤙≍ expected clean "(223) 456-7890"

# Cleans numbers with dots
    let expected: Result<uint64,string> = Ok 2234567890
⍤⤙≍ expected clean "223.456.7890"

# Cleans numbers with multiple spaces
    let expected: Result<uint64,string> = Ok 2234567890
⍤⤙≍ expected clean "223 456   7890   "

# Invalid when 9 digits
    let expected: Result<uint64,string> = Error "incorrect number of digits"
⍤⤙≍ expected clean "123456789"

# Invalid when 11 digits does not start with a 1
    let expected: Result<uint64,string> = Error "11 digits must start with 1"
⍤⤙≍ expected clean "22234567890"

# Valid when 11 digits and starting with 1
    let expected: Result<uint64,string> = Ok 2234567890
⍤⤙≍ expected clean "12234567890"

# Valid when 11 digits and starting with 1 even with punctuation
    let expected: Result<uint64,string> = Ok 2234567890
⍤⤙≍ expected clean "+1 (223) 456-7890"

# Invalid when more than 11 digits
    let expected: Result<uint64,string> = Error "more than 11 digits"
⍤⤙≍ expected clean "321234567890"

# Invalid with letters
    let expected: Result<uint64,string> = Error "letters not permitted"
⍤⤙≍ expected clean "523-abc-7890"

# Invalid with punctuations
    let expected: Result<uint64,string> = Error "punctuations not permitted"
⍤⤙≍ expected clean "523-@:!-7890"

# Invalid if area code starts with 0
    let expected: Result<uint64,string> = Error "area code cannot start with zero"
⍤⤙≍ expected clean "(023) 456-7890"

# Invalid if area code starts with 1
    let expected: Result<uint64,string> = Error "area code cannot start with one"
⍤⤙≍ expected clean "(123) 456-7890"

# Invalid if exchange code starts with 0
    let expected: Result<uint64,string> = Error "exchange code cannot start with zero"
⍤⤙≍ expected clean "(223) 056-7890"

# Invalid if exchange code starts with 1
    let expected: Result<uint64,string> = Error "exchange code cannot start with one"
⍤⤙≍ expected clean "(223) 156-7890"

# Invalid if area code starts with 0 on valid 11-digit number
    let expected: Result<uint64,string> = Error "area code cannot start with zero"
⍤⤙≍ expected clean "1 (023) 456-7890"

# Invalid if area code starts with 1 on valid 11-digit number
    let expected: Result<uint64,string> = Error "area code cannot start with one"
⍤⤙≍ expected clean "1 (123) 456-7890"

# Invalid if exchange code starts with 0 on valid 11-digit number
    let expected: Result<uint64,string> = Error "exchange code cannot start with zero"
⍤⤙≍ expected clean "1 (223) 056-7890"

# Invalid if exchange code starts with 1 on valid 11-digit number
    let expected: Result<uint64,string> = Error "exchange code cannot start with one"
⍤⤙≍ expected clean "1 (223) 156-7890"

