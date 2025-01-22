source("./ocr-numbers.R")
library(testthat)

let ``Recognizes 0`` () =
    rows <- 
        [ " _ ";
          "| |";
          "|_|";
          "   " ]
    expect_equal(convert rows, (Some "0"))

let ``Recognizes 1`` () =
    rows <- 
        [ "   ";
          "  |";
          "  |";
          "   " ]
    expect_equal(convert rows, (Some "1"))

let ``Unreadable but correctly sized inputs return ?`` () =
    rows <- 
        [ "   ";
          "  _";
          "  |";
          "   " ]
    expect_equal(convert rows, (Some "?"))

let ``Input with a number of lines that is not a multiple of four raises an error`` () =
    rows <- 
        [ " _ ";
          "| |";
          "   " ]
    expect_equal(convert rows, None)

let ``Input with a number of columns that is not a multiple of three raises an error`` () =
    rows <- 
        [ "    ";
          "   |";
          "   |";
          "    " ]
    expect_equal(convert rows, None)

let ``Recognizes 110101100`` () =
    rows <- 
        [ "       _     _        _  _ ";
          "  |  || |  || |  |  || || |";
          "  |  ||_|  ||_|  |  ||_||_|";
          "                           " ]
    expect_equal(convert rows, (Some "110101100"))

let ``Garbled numbers in a string are replaced with ?`` () =
    rows <- 
        [ "       _     _           _ ";
          "  |  || |  || |     || || |";
          "  |  | _|  ||_|  |  ||_||_|";
          "                           " ]
    expect_equal(convert rows, (Some "11?10?1?0"))

let ``Recognizes 2`` () =
    rows <- 
        [ " _ ";
          " _|";
          "|_ ";
          "   " ]
    expect_equal(convert rows, (Some "2"))

let ``Recognizes 3`` () =
    rows <- 
        [ " _ ";
          " _|";
          " _|";
          "   " ]
    expect_equal(convert rows, (Some "3"))

let ``Recognizes 4`` () =
    rows <- 
        [ "   ";
          "|_|";
          "  |";
          "   " ]
    expect_equal(convert rows, (Some "4"))

let ``Recognizes 5`` () =
    rows <- 
        [ " _ ";
          "|_ ";
          " _|";
          "   " ]
    expect_equal(convert rows, (Some "5"))

let ``Recognizes 6`` () =
    rows <- 
        [ " _ ";
          "|_ ";
          "|_|";
          "   " ]
    expect_equal(convert rows, (Some "6"))

let ``Recognizes 7`` () =
    rows <- 
        [ " _ ";
          "  |";
          "  |";
          "   " ]
    expect_equal(convert rows, (Some "7"))

let ``Recognizes 8`` () =
    rows <- 
        [ " _ ";
          "|_|";
          "|_|";
          "   " ]
    expect_equal(convert rows, (Some "8"))

let ``Recognizes 9`` () =
    rows <- 
        [ " _ ";
          "|_|";
          " _|";
          "   " ]
    expect_equal(convert rows, (Some "9"))

let ``Recognizes string of decimal numbers`` () =
    rows <- 
        [ "    _  _     _  _  _  _  _  _ ";
          "  | _| _||_||_ |_   ||_||_|| |";
          "  ||_  _|  | _||_|  ||_| _||_|";
          "                              " ]
    expect_equal(convert rows, (Some "1234567890"))

let ``Numbers separated by empty lines are recognized. Lines are joined by commas.`` () =
    rows <- 
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
    expect_equal(convert rows, (Some "123,456,789"))

