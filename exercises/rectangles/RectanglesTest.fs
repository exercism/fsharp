// This file was auto-generated based on version 1.0.0 of the canonical data.

module RectanglesTest

open FsUnit.Xunit
open Xunit

open Rectangles

[<Fact>]
let ``No rows`` () =
    let input = []
    rectangles input |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``No columns`` () =
    let input = [""]
    rectangles input |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``No rectangles`` () =
    let input = [" "]
    rectangles input |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``One rectangle`` () =
    let input = 
      [ "+-+"; 
        "| |"; 
        "+-+" ]
    rectangles input |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Two rectangles without shared parts`` () =
    let input = 
      [ "  +-+"; 
        "  | |"; 
        "+-+-+"; 
        "| |  "; 
        "+-+  " ]
    rectangles input |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Five rectangles with shared parts`` () =
    let input = 
      [ "  +-+"; 
        "  | |"; 
        "+-+-+"; 
        "| | |"; 
        "+-+-+" ]
    rectangles input |> should equal 5

[<Fact(Skip = "Remove to run test")>]
let ``Rectangle of height 1 is counted`` () =
    let input = 
      [ "+--+"; 
        "+--+" ]
    rectangles input |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Rectangle of width 1 is counted`` () =
    let input = 
      [ "++"; 
        "||"; 
        "++" ]
    rectangles input |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``1x1 square is counted`` () =
    let input = 
      [ "++"; 
        "++" ]
    rectangles input |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Only complete rectangles are counted`` () =
    let input = 
      [ "  +-+"; 
        "    |"; 
        "+-+-+"; 
        "| | -"; 
        "+-+-+" ]
    rectangles input |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Rectangles can be of different sizes`` () =
    let input = 
      [ "+------+----+"; 
        "|      |    |"; 
        "+---+--+    |"; 
        "|   |       |"; 
        "+---+-------+" ]
    rectangles input |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Corner is required for a rectangle to be complete`` () =
    let input = 
      [ "+------+----+"; 
        "|      |    |"; 
        "+------+    |"; 
        "|   |       |"; 
        "+---+-------+" ]
    rectangles input |> should equal 2

[<Fact(Skip = "Remove to run test")>]
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

