source("./transpose.R")
library(testthat)

let ``Empty string`` () =
    let lines: string list = []
    let expected: string list = []
    transpose lines |> should equal expected

let ``Two characters in a row`` () =
    lines <- ["A1"]
    expected <- 
        [ "A";
          "1" ]
    transpose lines |> should equal expected

let ``Two characters in a column`` () =
    lines <- 
        [ "A";
          "1" ]
    expected <- ["A1"]
    transpose lines |> should equal expected

let ``Simple`` () =
    lines <- 
        [ "ABC";
          "123" ]
    expected <- 
        [ "A1";
          "B2";
          "C3" ]
    transpose lines |> should equal expected

let ``Single line`` () =
    lines <- ["Single line."]
    expected <- 
        [ "S";
          "i";
          "n";
          "g";
          "l";
          "e";
          " ";
          "l";
          "i";
          "n";
          "e";
          "." ]
    transpose lines |> should equal expected

let ``First line longer than second line`` () =
    lines <- 
        [ "The fourth line.";
          "The fifth line." ]
    expected <- 
        [ "TT";
          "hh";
          "ee";
          "  ";
          "ff";
          "oi";
          "uf";
          "rt";
          "th";
          "h ";
          " l";
          "li";
          "in";
          "ne";
          "e.";
          "." ]
    transpose lines |> should equal expected

let ``Second line longer than first line`` () =
    lines <- 
        [ "The first line.";
          "The second line." ]
    expected <- 
        [ "TT";
          "hh";
          "ee";
          "  ";
          "fs";
          "ie";
          "rc";
          "so";
          "tn";
          " d";
          "l ";
          "il";
          "ni";
          "en";
          ".e";
          " ." ]
    transpose lines |> should equal expected

let ``Mixed line length`` () =
    lines <- 
        [ "The longest line.";
          "A long line.";
          "A longer line.";
          "A line." ]
    expected <- 
        [ "TAAA";
          "h   ";
          "elll";
          " ooi";
          "lnnn";
          "ogge";
          "n e.";
          "glr";
          "ei ";
          "snl";
          "tei";
          " .n";
          "l e";
          "i .";
          "n";
          "e";
          "." ]
    transpose lines |> should equal expected

let ``Square`` () =
    lines <- 
        [ "HEART";
          "EMBER";
          "ABUSE";
          "RESIN";
          "TREND" ]
    expected <- 
        [ "HEART";
          "EMBER";
          "ABUSE";
          "RESIN";
          "TREND" ]
    transpose lines |> should equal expected

let ``Rectangle`` () =
    lines <- 
        [ "FRACTURE";
          "OUTLINED";
          "BLOOMING";
          "SEPTETTE" ]
    expected <- 
        [ "FOBS";
          "RULE";
          "ATOP";
          "CLOT";
          "TIME";
          "UNIT";
          "RENT";
          "EDGE" ]
    transpose lines |> should equal expected

let ``Triangle`` () =
    lines <- 
        [ "T";
          "EE";
          "AAA";
          "SSSS";
          "EEEEE";
          "RRRRRR" ]
    expected <- 
        [ "TEASER";
          " EASER";
          "  ASER";
          "   SER";
          "    ER";
          "     R" ]
    transpose lines |> should equal expected

let ``Jagged triangle`` () =
    lines <- 
        [ "11";
          "2";
          "3333";
          "444";
          "555555";
          "66666" ]
    expected <- 
        [ "123456";
          "1 3456";
          "  3456";
          "  3 56";
          "    56";
          "    5" ]
    transpose lines |> should equal expected

