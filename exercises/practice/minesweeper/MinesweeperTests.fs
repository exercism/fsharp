source("./minesweeper.R")
library(testthat)

let ``No rows`` () =
    let minefield: string list = []
    let expected: string list = []
    annotate minefield |> should equal expected

let ``No columns`` () =
    minefield <- [""]
    expected <- [""]
    annotate minefield |> should equal expected

let ``No mines`` () =
    minefield <- 
        [ "   ";
          "   ";
          "   " ]
    expected <- 
        [ "   ";
          "   ";
          "   " ]
    annotate minefield |> should equal expected

let ``Minefield with only mines`` () =
    minefield <- 
        [ "***";
          "***";
          "***" ]
    expected <- 
        [ "***";
          "***";
          "***" ]
    annotate minefield |> should equal expected

let ``Mine surrounded by spaces`` () =
    minefield <- 
        [ "   ";
          " * ";
          "   " ]
    expected <- 
        [ "111";
          "1*1";
          "111" ]
    annotate minefield |> should equal expected

let ``Space surrounded by mines`` () =
    minefield <- 
        [ "***";
          "* *";
          "***" ]
    expected <- 
        [ "***";
          "*8*";
          "***" ]
    annotate minefield |> should equal expected

let ``Horizontal line`` () =
    minefield <- [" * * "]
    expected <- ["1*2*1"]
    annotate minefield |> should equal expected

let ``Horizontal line, mines at edges`` () =
    minefield <- ["*   *"]
    expected <- ["*1 1*"]
    annotate minefield |> should equal expected

let ``Vertical line`` () =
    minefield <- 
        [ " ";
          "*";
          " ";
          "*";
          " " ]
    expected <- 
        [ "1";
          "*";
          "2";
          "*";
          "1" ]
    annotate minefield |> should equal expected

let ``Vertical line, mines at edges`` () =
    minefield <- 
        [ "*";
          " ";
          " ";
          " ";
          "*" ]
    expected <- 
        [ "*";
          "1";
          " ";
          "1";
          "*" ]
    annotate minefield |> should equal expected

let ``Cross`` () =
    minefield <- 
        [ "  *  ";
          "  *  ";
          "*****";
          "  *  ";
          "  *  " ]
    expected <- 
        [ " 2*2 ";
          "25*52";
          "*****";
          "25*52";
          " 2*2 " ]
    annotate minefield |> should equal expected

let ``Large minefield`` () =
    minefield <- 
        [ " *  * ";
          "  *   ";
          "    * ";
          "   * *";
          " *  * ";
          "      " ]
    expected <- 
        [ "1*22*1";
          "12*322";
          " 123*2";
          "112*4*";
          "1*22*2";
          "111111" ]
    annotate minefield |> should equal expected

