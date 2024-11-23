module BottleSongTests

open FsUnit.Xunit
open Xunit

open BottleSong

[<Fact>]
let ``First generic verse`` () =
    let expected = 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall." ]
    recite 10 1 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Last generic verse`` () =
    let expected = 
        [ "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall." ]
    recite 3 1 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Verse with 2 bottles`` () =
    let expected = 
        [ "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall." ]
    recite 2 1 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Verse with 1 bottle`` () =
    let expected = 
        [ "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
    recite 1 1 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``First two verses`` () =
    let expected = 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall.";
          "";
          "Nine green bottles hanging on the wall,";
          "Nine green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be eight green bottles hanging on the wall." ]
    recite 10 2 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Last three verses`` () =
    let expected = 
        [ "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall.";
          "";
          "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall.";
          "";
          "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
    recite 3 3 |> should equal expected

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``All verses`` () =
    let expected = 
        [ "Ten green bottles hanging on the wall,";
          "Ten green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be nine green bottles hanging on the wall.";
          "";
          "Nine green bottles hanging on the wall,";
          "Nine green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be eight green bottles hanging on the wall.";
          "";
          "Eight green bottles hanging on the wall,";
          "Eight green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be seven green bottles hanging on the wall.";
          "";
          "Seven green bottles hanging on the wall,";
          "Seven green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be six green bottles hanging on the wall.";
          "";
          "Six green bottles hanging on the wall,";
          "Six green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be five green bottles hanging on the wall.";
          "";
          "Five green bottles hanging on the wall,";
          "Five green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be four green bottles hanging on the wall.";
          "";
          "Four green bottles hanging on the wall,";
          "Four green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be three green bottles hanging on the wall.";
          "";
          "Three green bottles hanging on the wall,";
          "Three green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be two green bottles hanging on the wall.";
          "";
          "Two green bottles hanging on the wall,";
          "Two green bottles hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be one green bottle hanging on the wall.";
          "";
          "One green bottle hanging on the wall,";
          "One green bottle hanging on the wall,";
          "And if one green bottle should accidentally fall,";
          "There'll be no green bottles hanging on the wall." ]
    recite 10 10 |> should equal expected

