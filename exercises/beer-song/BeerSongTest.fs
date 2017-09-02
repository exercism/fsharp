module BeerSongTest

open Xunit
open FsUnit.Xunit
open BeerSong
    
[<Fact>]
let ``Test a typical verse`` () = 
    let expected = 
        "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n"
    verse 8 |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Test another typical verse`` () = 
    let expected = 
        "3 bottles of beer on the wall, 3 bottles of beer.\nTake one down and pass it around, 2 bottles of beer on the wall.\n"
    verse 3 |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Test verse 1`` () = 
    let expected = 
        "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"
    verse 1 |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Test verse 2`` () = 
    let expected = 
        "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n"
    verse 2 |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Test verse 0`` () = 
    let expected = 
        "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"
    verse 0 |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Test several verses`` () = 
    let expected = 
        "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n\n7 bottles of beer on the wall, 7 bottles of beer.\nTake one down and pass it around, 6 bottles of beer on the wall.\n\n6 bottles of beer on the wall, 6 bottles of beer.\nTake one down and pass it around, 5 bottles of beer on the wall.\n\n"
    verses 8 6 |> should equal expected
    
[<Fact(Skip = "Remove to run test")>]
let ``Test the whole song`` () = 
    verses 99 0 |> should equal sing