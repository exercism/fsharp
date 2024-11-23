~ "isogram.ua" ~ Isogram

# Empty string
⍤⤙≍ 1 isIsogram ""

# Isogram with only lower case characters
⍤⤙≍ 1 isIsogram "isogram"

# Word with one duplicated character
⍤⤙≍ 0 isIsogram "eleven"

# Word with one duplicated character from the end of the alphabet
⍤⤙≍ 0 isIsogram "zzyzx"

# Longest reported english isogram
⍤⤙≍ 1 isIsogram "subdermatoglyphic"

# Word with duplicated character in mixed case
⍤⤙≍ 0 isIsogram "Alphabet"

# Word with duplicated character in mixed case, lowercase first
⍤⤙≍ 0 isIsogram "alphAbet"

# Hypothetical isogrammic word with hyphen
⍤⤙≍ 1 isIsogram "thumbscrew-japingly"

# Hypothetical word with duplicated character following hyphen
⍤⤙≍ 0 isIsogram "thumbscrew-jappingly"

# Isogram with duplicated hyphen
⍤⤙≍ 1 isIsogram "six-year-old"

# Made-up name that is an isogram
⍤⤙≍ 1 isIsogram "Emily Jung Schwartzkopf"

# Duplicated character in the middle
⍤⤙≍ 0 isIsogram "accentor"

# Same first and last characters
⍤⤙≍ 0 isIsogram "angola"

# Word with duplicated character and with two hyphens
⍤⤙≍ 0 isIsogram "up-to-date"

