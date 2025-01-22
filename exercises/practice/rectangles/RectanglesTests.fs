source("./rectangles.R")
library(testthat)

let ``No rows`` () =
    strings <- []
    rectangles strings |> should equal 0

let ``No columns`` () =
    strings <- [""]
    rectangles strings |> should equal 0

let ``No rectangles`` () =
    strings <- [" "]
    rectangles strings |> should equal 0

let ``One rectangle`` () =
    strings <- 
        [ "+-+";
          "| |";
          "+-+" ]
    rectangles strings |> should equal 1

let ``Two rectangles without shared parts`` () =
    strings <- 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
    rectangles strings |> should equal 2

let ``Five rectangles with shared parts`` () =
    strings <- 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
    rectangles strings |> should equal 5

let ``Rectangle of height 1 is counted`` () =
    strings <- 
        [ "+--+";
          "+--+" ]
    rectangles strings |> should equal 1

let ``Rectangle of width 1 is counted`` () =
    strings <- 
        [ "++";
          "||";
          "++" ]
    rectangles strings |> should equal 1

let ``1x1 square is counted`` () =
    strings <- 
        [ "++";
          "++" ]
    rectangles strings |> should equal 1

let ``Only complete rectangles are counted`` () =
    strings <- 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
    rectangles strings |> should equal 1

let ``Rectangles can be of different sizes`` () =
    strings <- 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 3

let ``Corner is required for a rectangle to be complete`` () =
    strings <- 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 2

let ``Large input with many rectangles`` () =
    strings <- 
        [ "+---+--+----+";
          "|   +--+----+";
          "+---+--+    |";
          "|   +--+----+";
          "+---+--+--+-+";
          "+---+--+--+-+";
          "+------+  | |";
          "          +-+" ]
    rectangles strings |> should equal 60

let ``Rectangles must have four sides`` () =
    strings <- 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
    rectangles strings |> should equal 5

