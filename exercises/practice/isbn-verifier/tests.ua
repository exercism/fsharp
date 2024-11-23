~ "isbn-verifier.ua" ~ IsbnVerifier

# Valid isbn
⍤⤙≍ true isValid "3-598-21508-8"

# Invalid isbn check digit
⍤⤙≍ false isValid "3-598-21508-9"

# Valid isbn with a check digit of 10
⍤⤙≍ true isValid "3-598-21507-X"

# Check digit is a character other than X
⍤⤙≍ false isValid "3-598-21507-A"

# Invalid check digit in isbn is not treated as zero
⍤⤙≍ false isValid "4-598-21507-B"

# Invalid character in isbn is not treated as zero
⍤⤙≍ false isValid "3-598-P1581-X"

# X is only valid as a check digit
⍤⤙≍ false isValid "3-598-2X507-9"

# Valid isbn without separating dashes
⍤⤙≍ true isValid "3598215088"

# Isbn without separating dashes and X as check digit
⍤⤙≍ true isValid "359821507X"

# Isbn without check digit and dashes
⍤⤙≍ false isValid "359821507"

# Too long isbn and no dashes
⍤⤙≍ false isValid "3598215078X"

# Too short isbn
⍤⤙≍ false isValid "00"

# Isbn without check digit
⍤⤙≍ false isValid "3-598-21507"

# Check digit of X should not be used for 0
⍤⤙≍ false isValid "3-598-21515-X"

# Empty isbn
⍤⤙≍ false isValid ""

# Input is 9 characters
⍤⤙≍ false isValid "134456729"

# Invalid characters are not ignored after checking length
⍤⤙≍ false isValid "3132P34035"

# Invalid characters are not ignored before checking length
⍤⤙≍ false isValid "3598P215088"

# Input is too long but contains a valid isbn
⍤⤙≍ false isValid "98245726788"

