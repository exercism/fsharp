module RectanglesTest

open Xunit
open FsUnit

open System

open Rectangle

[Fact]
let ``No rows`` () =
    let input = []
    rectangles input |> should equal 0

[Fact(Skip = "Remove to run test")]
let ``No columns`` () =
    let input = [""]
    rectangles input |> should equal 0

[Fact(Skip = "Remove to run test")]
let ``No rectangles`` () =
    let input = [" "]
    rectangles input |> should equal 0

[Fact(Skip = "Remove to run test")]
let ``One rectangle`` () =
    let input = 
        [ "+-+";
          "| |";
          "+-+" ]        
    rectangles input |> should equal 1

[Fact(Skip = "Remove to run test")]
let ``two rectangles without shared parts`` () =
    let input = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]        
    rectangles input |> should equal 2

[Fact(Skip = "Remove to run test")]
let ``Five rectangles with shared parts`` () =
    let input = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]        
    rectangles input |> should equal 5

[Fact(Skip = "Remove to run test")]
let ``Only complete rectangles are counted`` () =
    let input = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]       
    rectangles input |> should equal 1

[Fact(Skip = "Remove to run test")]
let ``Rectangles can be of different sizes`` () =
    let input =
         ["+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]       
    rectangles input |> should equal 3

[Fact(Skip = "Remove to run test")]
let ``Corner is required for a rectangle to be complete`` () =
    let input = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]       
    rectangles input |> should equal 2

[Fact(Skip = "Remove to run test")]
let ``Large input with many rectangles`` () =
    let input = 
        [ "+---+--+----+";
          "|   +--+----+";
          "+---+--+    |";
          "|   +--+----+";
          "+---+--+--+-+";
          "+---+--+--+-+";
          "+------+  | |";
          "          +-+" ]       
    rectangles input |> should equal 60