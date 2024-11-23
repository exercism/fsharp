~ "ocr-numbers.ua" ~ OcrNumbers

# Recognizes 0
≡=
[" _ ""| |""|_|""   "]
⍤⤙≍ "0" convert ≡

# Recognizes 1
≡=
["   ""  |""  |""   "]
⍤⤙≍ "1" convert ≡

# Unreadable but correctly sized inputs return ?
≡=
["   ""  _""  |""   "]
⍤⤙≍ "?" convert ≡

# Input with a number of lines that is not a multiple of four raises an error
≡=
[" _ ""| |""   "]
⍤⤙≍ "TODO: insert error message" ⍣(convert ≡)

# Input with a number of columns that is not a multiple of three raises an error
≡=
["    ""   |""   |""    "]
⍤⤙≍ "TODO: insert error message" ⍣(convert ≡)

# Recognizes 110101100
≡=
["       _     _        _  _ ""  |  || |  || |  |  || || |""  |  ||_|  ||_|  |  ||_||_|""                           "]
⍤⤙≍ "110101100" convert ≡

# Garbled numbers in a string are replaced with ?
≡=
["       _     _           _ ""  |  || |  || |     || || |""  |  | _|  ||_|  |  ||_||_|""                           "]
⍤⤙≍ "11?10?1?0" convert ≡

# Recognizes 2
≡=
[" _ "" _|""|_ ""   "]
⍤⤙≍ "2" convert ≡

# Recognizes 3
≡=
[" _ "" _|"" _|""   "]
⍤⤙≍ "3" convert ≡

# Recognizes 4
≡=
["   ""|_|""  |""   "]
⍤⤙≍ "4" convert ≡

# Recognizes 5
≡=
[" _ ""|_ "" _|""   "]
⍤⤙≍ "5" convert ≡

# Recognizes 6
≡=
[" _ ""|_ ""|_|""   "]
⍤⤙≍ "6" convert ≡

# Recognizes 7
≡=
[" _ ""  |""  |""   "]
⍤⤙≍ "7" convert ≡

# Recognizes 8
≡=
[" _ ""|_|""|_|""   "]
⍤⤙≍ "8" convert ≡

# Recognizes 9
≡=
[" _ ""|_|"" _|""   "]
⍤⤙≍ "9" convert ≡

# Recognizes string of decimal numbers
≡=
["    _  _     _  _  _  _  _  _ ""  | _| _||_||_ |_   ||_||_|| |""  ||_  _|  | _||_|  ||_| _||_|""                              "]
⍤⤙≍ "1234567890" convert ≡

# Numbers separated by empty lines are recognized. Lines are joined by commas.
≡=
["    _  _ ""  | _| _|""  ||_  _|""         ""    _  _ ""|_||_ |_ ""  | _||_|""         "" _  _  _ ""  ||_||_|""  ||_| _|""         "]
⍤⤙≍ "123,456,789" convert ≡
