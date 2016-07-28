module TournamentTest
    
open NUnit.Framework

open Tournament

[<Test>]
let ``Correctly displays the tournament table`` () =
    let actual = 
        ["Αllegoric Alaskians;Blithering Badgers;win";
         "Devastating Donkeys;Courageous Californians;draw";
         "Devastating Donkeys;Αllegoric Alaskians;win";
         "Courageous Californians;Blithering Badgers;loss";
         "Blithering Badgers;Devastating Donkeys;loss";
         "Αllegoric Alaskians;Courageous Californians;win"]

    let expected = 
        ["Team                           | MP |  W |  D |  L |  P";
         "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7";
         "Αllegoric Alaskians            |  3 |  2 |  0 |  1 |  6";
         "Blithering Badgers             |  3 |  1 |  0 |  2 |  3";
         "Courageous Californians        |  3 |  0 |  1 |  2 |  1"]

    Assert.That(tally actual, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Ignores incorrect input`` () =
    let actual = 
        ["Allegoric Alaskians;Blithering Badgers;win";
         "Devastating Donkeys_Courageous Californians;draw";
         "Devastating Donkeys;Allegoric Alaskians;win";
         "";
         "Courageous Californians;Blithering Badgers;loss";
         "Bla;Bla;Bla";
         "Blithering Badgers;Devastating Donkeys;loss";
         "# Yackity yackity yack";
         "Allegoric Alaskians;Courageous Californians;win";
         "Devastating Donkeys;Courageous Californians;draw";
         "Devastating Donkeys@Courageous Californians;draw"]

    let expected = 
        ["Team                           | MP |  W |  D |  L |  P";
         "Devastating Donkeys            |  3 |  2 |  1 |  0 |  7";
         "Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6";
         "Blithering Badgers             |  3 |  1 |  0 |  2 |  3";
         "Courageous Californians        |  3 |  0 |  1 |  2 |  1"]

    Assert.That(tally actual, Is.EqualTo(expected))    

[<Test>]
[<Ignore("Remove to run test")>]
let ``Correctly displays another tournament table`` () =
    let actual = 
        ["Allegoric Alaskians;Blithering Badgers;win";
         "Devastating Donkeys;Allegoric Alaskians;win";
         "Courageous Californians;Blithering Badgers;loss";
         "Allegoric Alaskians;Courageous Californians;win"]

    let expected = 
        ["Team                           | MP |  W |  D |  L |  P";
         "Allegoric Alaskians            |  3 |  2 |  0 |  1 |  6";
         "Blithering Badgers             |  2 |  1 |  0 |  1 |  3";
         "Devastating Donkeys            |  1 |  1 |  0 |  0 |  3";
         "Courageous Californians        |  2 |  0 |  0 |  2 |  0"]

    Assert.That(tally actual, Is.EqualTo(expected))