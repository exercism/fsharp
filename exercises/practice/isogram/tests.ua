~ "isogram.ua" ~ Isogram

# Empty string
⍤⤙≍ true isIsogram ""

# Isogram with only lower case characters
⍤⤙≍ true isIsogram "isogram"

# Word with one duplicated character
⍤⤙≍ false isIsogram "eleven"

# Word with one duplicated character from the end of the alphabet
⍤⤙≍ false isIsogram "zzyzx"

# Longest reported english isogram
⍤⤙≍ true isIsogram "subdermatoglyphic"

# Word with duplicated character in mixed case
⍤⤙≍ false isIsogram "Alphabet"

# Word with duplicated character in mixed case, lowercase first
⍤⤙≍ false isIsogram "alphAbet"

# Hypothetical isogrammic word with hyphen
⍤⤙≍ true isIsogram "thumbscrew-japingly"

# Hypothetical word with duplicated character following hyphen
⍤⤙≍ false isIsogram "thumbscrew-jappingly"

# Isogram with duplicated hyphen
⍤⤙≍ true isIsogram "six-year-old"

# Made-up name that is an isogram
⍤⤙≍ true isIsogram "Emily Jung Schwartzkopf"

# Duplicated character in the middle
⍤⤙≍ false isIsogram "accentor"

# Same first and last characters
⍤⤙≍ false isIsogram "angola"

# Word with duplicated character and with two hyphens
⍤⤙≍ false isIsogram "up-to-date"

