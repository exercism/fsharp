source("./rectangles.R")
library(testthat)

let ``No rows`` () =
    strings <- []
    expect_equal(rectangles strings, 0)

let ``No columns`` () =
    strings <- [""]
    expect_equal(rectangles strings, 0)

let ``No rectangles`` () =
    strings <- [" "]
    expect_equal(rectangles strings, 0)

let ``One rectangle`` () =
    strings <- 
        [ "+-+";
          "| |";
          "+-+" ]
    expect_equal(rectangles strings, 1)

let ``Two rectangles without shared parts`` () =
    strings <- 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
    expect_equal(rectangles strings, 2)

let ``Five rectangles with shared parts`` () =
    strings <- 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
    expect_equal(rectangles strings, 5)

let ``Rectangle of height 1 is counted`` () =
    strings <- 
        [ "+--+";
          "+--+" ]
    expect_equal(rectangles strings, 1)

let ``Rectangle of width 1 is counted`` () =
    strings <- 
        [ "++";
          "||";
          "++" ]
    expect_equal(rectangles strings, 1)

let ``1x1 square is counted`` () =
    strings <- 
        [ "++";
          "++" ]
    expect_equal(rectangles strings, 1)

let ``Only complete rectangles are counted`` () =
    strings <- 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
    expect_equal(rectangles strings, 1)

let ``Rectangles can be of different sizes`` () =
    strings <- 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
    expect_equal(rectangles strings, 3)

let ``Corner is required for a rectangle to be complete`` () =
    strings <- 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
    expect_equal(rectangles strings, 2)

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
    expect_equal(rectangles strings, 60)

let ``Rectangles must have four sides`` () =
    strings <- 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
    expect_equal(rectangles strings, 5)

