~ "isbn-verifier.ua" ~ IsbnVerifier

# Valid isbn
⍤⤙≍ 1 isValid "3-598-21508-8"

# Invalid isbn check digit
⍤⤙≍ 0 isValid "3-598-21508-9"

# Valid isbn with a check digit of 10
⍤⤙≍ 1 isValid "3-598-21507-X"

# Check digit is a character other than X
⍤⤙≍ 0 isValid "3-598-21507-A"

# Invalid check digit in isbn is not treated as zero
⍤⤙≍ 0 isValid "4-598-21507-B"

# Invalid character in isbn is not treated as zero
⍤⤙≍ 0 isValid "3-598-P1581-X"

# X is only valid as a check digit
⍤⤙≍ 0 isValid "3-598-2X507-9"

# Valid isbn without separating dashes
⍤⤙≍ 1 isValid "3598215088"

# Isbn without separating dashes and X as check digit
⍤⤙≍ 1 isValid "359821507X"

# Isbn without check digit and dashes
⍤⤙≍ 0 isValid "359821507"

# Too long isbn and no dashes
⍤⤙≍ 0 isValid "3598215078X"

# Too short isbn
⍤⤙≍ 0 isValid "00"

# Isbn without check digit
⍤⤙≍ 0 isValid "3-598-21507"

# Check digit of X should not be used for 0
⍤⤙≍ 0 isValid "3-598-21515-X"

# Empty isbn
⍤⤙≍ 0 isValid ""

# Input is 9 characters
⍤⤙≍ 0 isValid "134456729"

# Invalid characters are not ignored after checking length
⍤⤙≍ 0 isValid "3132P34035"

# Invalid characters are not ignored before checking length
⍤⤙≍ 0 isValid "3598P215088"

# Input is too long but contains a valid isbn
⍤⤙≍ 0 isValid "98245726788"

