module BeerSongTest

open NUnit.Framework
open BeerSong
    
[<Test>]
let ``Test a typical verse`` () = 
    let expected = 
        "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n"
    Assert.That(verse 8, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test another typical verse`` () = 
    let expected = 
        "3 bottles of beer on the wall, 3 bottles of beer.\nTake one down and pass it around, 2 bottles of beer on the wall.\n"
    Assert.That(verse 3, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test verse 1`` () = 
    let expected = 
        "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"
    Assert.That(verse 1, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test verse 2`` () = 
    let expected = 
        "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n"
    Assert.That(verse 2, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test verse 0`` () = 
    let expected = 
        "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"
    Assert.That(verse 0, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test several verses`` () = 
    let expected = 
        "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n\n7 bottles of beer on the wall, 7 bottles of beer.\nTake one down and pass it around, 6 bottles of beer on the wall.\n\n6 bottles of beer on the wall, 6 bottles of beer.\nTake one down and pass it around, 5 bottles of beer on the wall.\n\n"
    Assert.That(verses 8 6, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test the whole song`` () = 
    Assert.That(verses 99 0, Is.EqualTo(sing))