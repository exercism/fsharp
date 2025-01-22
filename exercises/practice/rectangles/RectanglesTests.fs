source("./rectangles.R")
library(testthat)

open FsUnit.Xunit
open Xunit

open Rectangles

let ``No rows`` () =
    let strings = []
    rectangles strings |> should equal 0

let ``No columns`` () =
    let strings = [""]
    rectangles strings |> should equal 0

let ``No rectangles`` () =
    let strings = [" "]
    rectangles strings |> should equal 0

let ``One rectangle`` () =
    let strings = 
        [ "+-+";
          "| |";
          "+-+" ]
    rectangles strings |> should equal 1

let ``Two rectangles without shared parts`` () =
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
    rectangles strings |> should equal 2

let ``Five rectangles with shared parts`` () =
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
    rectangles strings |> should equal 5

let ``Rectangle of height 1 is counted`` () =
    let strings = 
        [ "+--+";
          "+--+" ]
    rectangles strings |> should equal 1

let ``Rectangle of width 1 is counted`` () =
    let strings = 
        [ "++";
          "||";
          "++" ]
    rectangles strings |> should equal 1

let ``1x1 square is counted`` () =
    let strings = 
        [ "++";
          "++" ]
    rectangles strings |> should equal 1

let ``Only complete rectangles are counted`` () =
    let strings = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
    rectangles strings |> should equal 1

let ``Rectangles can be of different sizes`` () =
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 3

let ``Corner is required for a rectangle to be complete`` () =
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 2

let ``Large input with many rectangles`` () =
    let strings = 
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
    let strings = 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
    rectangles strings |> should equal 5

