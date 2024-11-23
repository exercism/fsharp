~ "isogram.ua" ~ Isogram

# Empty string
    isIsogram "" |> should equal true

# Isogram with only lower case characters
    isIsogram "isogram" |> should equal true

# Word with one duplicated character
    isIsogram "eleven" |> should equal false

# Word with one duplicated character from the end of the alphabet
    isIsogram "zzyzx" |> should equal false

# Longest reported english isogram
    isIsogram "subdermatoglyphic" |> should equal true

# Word with duplicated character in mixed case
    isIsogram "Alphabet" |> should equal false

# Word with duplicated character in mixed case, lowercase first
    isIsogram "alphAbet" |> should equal false

# Hypothetical isogrammic word with hyphen
    isIsogram "thumbscrew-japingly" |> should equal true

# Hypothetical word with duplicated character following hyphen
    isIsogram "thumbscrew-jappingly" |> should equal false

# Isogram with duplicated hyphen
    isIsogram "six-year-old" |> should equal true

# Made-up name that is an isogram
    isIsogram "Emily Jung Schwartzkopf" |> should equal true

# Duplicated character in the middle
    isIsogram "accentor" |> should equal false

# Same first and last characters
    isIsogram "angola" |> should equal false

# Word with duplicated character and with two hyphens
    isIsogram "up-to-date" |> should equal false

