module TwelveDaysTest

open NUnit.Framework

open TwelveDaysSong

[<Test>]
let ``Return verse 1`` () =
    let expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n"
    Assert.That(verse 1, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 2`` () =
    let expected = "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 2, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 3`` () =
    let expected = "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 3, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 4`` () =
    let expected = "On the fourth day of Christmas my true love gave to me, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 4, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 5`` () =
    let expected = "On the fifth day of Christmas my true love gave to me, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 5, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 6`` () =
    let expected = "On the sixth day of Christmas my true love gave to me, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 6, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 7`` () =
    let expected = "On the seventh day of Christmas my true love gave to me, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 7, Is.EqualTo(expected))
        
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 8`` () =
    let expected = "On the eighth day of Christmas my true love gave to me, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 8, Is.EqualTo(expected))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 9`` () =
    let expected = "On the ninth day of Christmas my true love gave to me, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 9, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 10`` () =
    let expected = "On the tenth day of Christmas my true love gave to me, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 10, Is.EqualTo(expected))
   
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 11`` () =
    let expected = "On the eleventh day of Christmas my true love gave to me, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 11, Is.EqualTo(expected))
   
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return verse 12`` () =
    let expected = "On the twelfth day of Christmas my true love gave to me, twelve Drummers Drumming, eleven Pipers Piping, ten Lords-a-Leaping, nine Ladies Dancing, eight Maids-a-Milking, seven Swans-a-Swimming, six Geese-a-Laying, five Gold Rings, four Calling Birds, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n"
    Assert.That(verse 12, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return multiple verses`` () =
    let expected = "On the first day of Christmas my true love gave to me, a Partridge in a Pear Tree.\n\n" +
                   "On the second day of Christmas my true love gave to me, two Turtle Doves, and a Partridge in a Pear Tree.\n\n" +
                   "On the third day of Christmas my true love gave to me, three French Hens, two Turtle Doves, and a Partridge in a Pear Tree.\n\n"

    Assert.That(verses 1 3, Is.EqualTo(expected))
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Return entire song`` () =
    Assert.That(verses 1 12, Is.EqualTo(song))