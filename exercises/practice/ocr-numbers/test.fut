import "ocr_numbers"

let ``Recognizes 0`` () =
    let rows = 
        [ " _ ";
          "| |";
          "|_|";
          "   " ]
    convert rows |> should equal "0"

let ``Recognizes 1`` () =
    let rows = 
        [ "   ";
          "  |";
          "  |";
          "   " ]
    convert rows |> should equal "1"

let ``Unreadable but correctly sized inputs return ?`` () =
    let rows = 
        [ "   ";
          "  _";
          "  |";
          "   " ]
    convert rows |> should equal "?"

let ``Input with a number of lines that is not a multiple of four raises an error`` () =
    let rows = 
        [ " _ ";
          "| |";
          "   " ]
    convert rows |> should equal None

let ``Input with a number of columns that is not a multiple of three raises an error`` () =
    let rows = 
        [ "    ";
          "   |";
          "   |";
          "    " ]
    convert rows |> should equal None

let ``Recognizes 110101100`` () =
    let rows = 
        [ "       _     _        _  _ ";
          "  |  || |  || |  |  || || |";
          "  |  ||_|  ||_|  |  ||_||_|";
          "                           " ]
    convert rows |> should equal "110101100"

let ``Garbled numbers in a string are replaced with ?`` () =
    let rows = 
        [ "       _     _           _ ";
          "  |  || |  || |     || || |";
          "  |  | _|  ||_|  |  ||_||_|";
          "                           " ]
    convert rows |> should equal "11?10?1?0"

let ``Recognizes 2`` () =
    let rows = 
        [ " _ ";
          " _|";
          "|_ ";
          "   " ]
    convert rows |> should equal "2"

let ``Recognizes 3`` () =
    let rows = 
        [ " _ ";
          " _|";
          " _|";
          "   " ]
    convert rows |> should equal "3"

let ``Recognizes 4`` () =
    let rows = 
        [ "   ";
          "|_|";
          "  |";
          "   " ]
    convert rows |> should equal "4"

let ``Recognizes 5`` () =
    let rows = 
        [ " _ ";
          "|_ ";
          " _|";
          "   " ]
    convert rows |> should equal "5"

let ``Recognizes 6`` () =
    let rows = 
        [ " _ ";
          "|_ ";
          "|_|";
          "   " ]
    convert rows |> should equal "6"

let ``Recognizes 7`` () =
    let rows = 
        [ " _ ";
          "  |";
          "  |";
          "   " ]
    convert rows |> should equal "7"

let ``Recognizes 8`` () =
    let rows = 
        [ " _ ";
          "|_|";
          "|_|";
          "   " ]
    convert rows |> should equal "8"

let ``Recognizes 9`` () =
    let rows = 
        [ " _ ";
          "|_|";
          " _|";
          "   " ]
    convert rows |> should equal "9"

let ``Recognizes string of decimal numbers`` () =
    let rows = 
        [ "    _  _     _  _  _  _  _  _ ";
          "  | _| _||_||_ |_   ||_||_|| |";
          "  ||_  _|  | _||_|  ||_| _||_|";
          "                              " ]
    convert rows |> should equal "1234567890"

let ``Numbers separated by empty lines are recognized. Lines are joined by commas.`` () =
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
    convert rows |> should equal "123,456,789"

