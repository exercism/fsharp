~ "ocr-numbers.ua" ~ OcrNumbers

# Recognizes 0
    let rows = 
        [ " _ ";
          "| |";
          "|_|";
          "   " ]
    convert rows |> should equal (Some "0")

# Recognizes 1
    let rows = 
        [ "   ";
          "  |";
          "  |";
          "   " ]
    convert rows |> should equal (Some "1")

# Unreadable but correctly sized inputs return ?
    let rows = 
        [ "   ";
          "  _";
          "  |";
          "   " ]
    convert rows |> should equal (Some "?")

# Input with a number of lines that is not a multiple of four raises an error
    let rows = 
        [ " _ ";
          "| |";
          "   " ]
    convert rows |> should equal None

# Input with a number of columns that is not a multiple of three raises an error
    let rows = 
        [ "    ";
          "   |";
          "   |";
          "    " ]
    convert rows |> should equal None

# Recognizes 110101100
    let rows = 
        [ "       _     _        _  _ ";
          "  |  || |  || |  |  || || |";
          "  |  ||_|  ||_|  |  ||_||_|";
          "                           " ]
    convert rows |> should equal (Some "110101100")

# Garbled numbers in a string are replaced with ?
    let rows = 
        [ "       _     _           _ ";
          "  |  || |  || |     || || |";
          "  |  | _|  ||_|  |  ||_||_|";
          "                           " ]
    convert rows |> should equal (Some "11?10?1?0")

# Recognizes 2
    let rows = 
        [ " _ ";
          " _|";
          "|_ ";
          "   " ]
    convert rows |> should equal (Some "2")

# Recognizes 3
    let rows = 
        [ " _ ";
          " _|";
          " _|";
          "   " ]
    convert rows |> should equal (Some "3")

# Recognizes 4
    let rows = 
        [ "   ";
          "|_|";
          "  |";
          "   " ]
    convert rows |> should equal (Some "4")

# Recognizes 5
    let rows = 
        [ " _ ";
          "|_ ";
          " _|";
          "   " ]
    convert rows |> should equal (Some "5")

# Recognizes 6
    let rows = 
        [ " _ ";
          "|_ ";
          "|_|";
          "   " ]
    convert rows |> should equal (Some "6")

# Recognizes 7
    let rows = 
        [ " _ ";
          "  |";
          "  |";
          "   " ]
    convert rows |> should equal (Some "7")

# Recognizes 8
    let rows = 
        [ " _ ";
          "|_|";
          "|_|";
          "   " ]
    convert rows |> should equal (Some "8")

# Recognizes 9
    let rows = 
        [ " _ ";
          "|_|";
          " _|";
          "   " ]
    convert rows |> should equal (Some "9")

# Recognizes string of decimal numbers
    let rows = 
        [ "    _  _     _  _  _  _  _  _ ";
          "  | _| _||_||_ |_   ||_||_|| |";
          "  ||_  _|  | _||_|  ||_| _||_|";
          "                              " ]
    convert rows |> should equal (Some "1234567890")

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
    convert rows |> should equal (Some "123,456,789")

