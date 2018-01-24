// This file was auto-generated based on version 1.1.0 of the canonical data.

module TwelveDaysTest

open FsUnit.Xunit
open Xunit

open TwelveDays

[<Fact>]
let ``First day a partridge in a pear tree`` () =
    let expected = ["On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree."]
    recite 1 1 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Second day two turtle doves`` () =
    let expected = ["On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 2 2 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Third day three french hens`` () =
    let expected = ["On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 3 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Fourth day four calling birds`` () =
    let expected = ["On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 4 4 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Fifth day five gold rings`` () =
    let expected = ["On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 5 5 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Sixth day six geese-a-laying`` () =
    let expected = ["On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 6 6 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Seventh day seven swans-a-swimming`` () =
    let expected = ["On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 7 7 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Eighth day eight maids-a-milking`` () =
    let expected = ["On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 8 8 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Ninth day nine ladies dancing`` () =
    let expected = ["On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 9 9 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Tenth day ten lords-a-leaping`` () =
    let expected = ["On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 10 10 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Eleventh day eleven pipers piping`` () =
    let expected = ["On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 11 11 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Twelfth day twelve drummers drumming`` () =
    let expected = ["On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree."]
    recite 12 12 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Recites first three verses of the song`` () =
    let expected = 
        [ "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.";
          "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." ]
    recite 1 3 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Recites three verses from the middle of the song`` () =
    let expected = 
        [ "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." ]
    recite 4 6 |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Recites the whole song`` () =
    let expected = 
        [ "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.";
          "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.";
          "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree." ]
    recite 1 12 |> should equal expected

