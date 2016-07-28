module RectanglesTest

open NUnit.Framework

open System

open Rectangle

[<Test>]
let ``No rows`` () =
    let input = []
    Assert.That(rectangles input, Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``No columns`` () =
    let input = [""]
    Assert.That(rectangles input, Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``No rectangles`` () =
    let input = [" "]
    Assert.That(rectangles input, Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One rectangle`` () =
    let input = 
        [ "+-+";
          "| |";
          "+-+" ]        
    Assert.That(rectangles input, Is.EqualTo(1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``two rectangles without shared parts`` () =
    let input = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]        
    Assert.That(rectangles input, Is.EqualTo(2))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Five rectangles with shared parts`` () =
    let input = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]        
    Assert.That(rectangles input, Is.EqualTo(5))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Only complete rectangles are counted`` () =
    let input = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]       
    Assert.That(rectangles input, Is.EqualTo(1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Rectangles can be of different sizes`` () =
    let input =
         ["+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]       
    Assert.That(rectangles input, Is.EqualTo(3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Corner is required for a rectangle to be complete`` () =
    let input = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]       
    Assert.That(rectangles input, Is.EqualTo(2))

[<Test>]
[<Ignore("Remove to run test")>]
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
    Assert.That(rectangles input, Is.EqualTo(60))