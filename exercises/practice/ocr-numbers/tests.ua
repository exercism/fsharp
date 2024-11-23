~ "ocr-numbers.ua" ~ OcrNumbers

# Recognizes 0
    let rows = 
        [ " _ ";
          "| |";
          "|_|";
          "   " ]
⍤⤙≍ (Some "0") convert rows

# Recognizes 1
    let rows = 
        [ "   ";
          "  |";
          "  |";
          "   " ]
⍤⤙≍ (Some "1") convert rows

# Unreadable but correctly sized inputs return ?
    let rows = 
        [ "   ";
          "  _";
          "  |";
          "   " ]
⍤⤙≍ (Some "?") convert rows

# Input with a number of lines that is not a multiple of four raises an error
    let rows = 
        [ " _ ";
          "| |";
          "   " ]
⍤⤙≍ None convert rows

# Input with a number of columns that is not a multiple of three raises an error
    let rows = 
        [ "    ";
          "   |";
          "   |";
          "    " ]
⍤⤙≍ None convert rows

# Recognizes 110101100
    let rows = 
        [ "       _     _        _  _ ";
          "  |  || |  || |  |  || || |";
          "  |  ||_|  ||_|  |  ||_||_|";
          "                           " ]
⍤⤙≍ (Some "110101100") convert rows

# Garbled numbers in a string are replaced with ?
    let rows = 
        [ "       _     _           _ ";
          "  |  || |  || |     || || |";
          "  |  | _|  ||_|  |  ||_||_|";
          "                           " ]
⍤⤙≍ (Some "11?10?1?0") convert rows

# Recognizes 2
    let rows = 
        [ " _ ";
          " _|";
          "|_ ";
          "   " ]
⍤⤙≍ (Some "2") convert rows

# Recognizes 3
    let rows = 
        [ " _ ";
          " _|";
          " _|";
          "   " ]
⍤⤙≍ (Some "3") convert rows

# Recognizes 4
    let rows = 
        [ "   ";
          "|_|";
          "  |";
          "   " ]
⍤⤙≍ (Some "4") convert rows

# Recognizes 5
    let rows = 
        [ " _ ";
          "|_ ";
          " _|";
          "   " ]
⍤⤙≍ (Some "5") convert rows

# Recognizes 6
    let rows = 
        [ " _ ";
          "|_ ";
          "|_|";
          "   " ]
⍤⤙≍ (Some "6") convert rows

# Recognizes 7
    let rows = 
        [ " _ ";
          "  |";
          "  |";
          "   " ]
⍤⤙≍ (Some "7") convert rows

# Recognizes 8
    let rows = 
        [ " _ ";
          "|_|";
          "|_|";
          "   " ]
⍤⤙≍ (Some "8") convert rows

# Recognizes 9
    let rows = 
        [ " _ ";
          "|_|";
          " _|";
          "   " ]
⍤⤙≍ (Some "9") convert rows

# Recognizes string of decimal numbers
    let rows = 
        [ "    _  _     _  _  _  _  _  _ ";
          "  | _| _||_||_ |_   ||_||_|| |";
          "  ||_  _|  | _||_|  ||_| _||_|";
          "                              " ]
⍤⤙≍ (Some "1234567890") convert rows

# Numbers separated by empty lines are recognized. Lines are joined by commas.
    let rows = 
        [ "    _  _ ";
          "  | _| _|";
          "  ||_  _|";
          "         ";
          "    _  _ ";
          "|_||_ |_ ";
          "  | _||_|";
          "         ";
          " _  _  _ ";
          "  ||_||_|";
          "  ||_| _|";
          "         " ]
⍤⤙≍ (Some "123,456,789") convert rows

