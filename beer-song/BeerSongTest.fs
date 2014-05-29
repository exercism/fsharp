module BeerSongTest

open NUnit.Framework
open BeerSong

[<TestFixture>]
type BeerSongTest() = 
    let beersong = BeerSong()

    [<Test>]
    member tests.Test_a_typical_verse() =
        let expected = "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n"

        Assert.That(beersong.verse(8), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Test_another_typical_verse() =
        let expected = "3 bottles of beer on the wall, 3 bottles of beer.\nTake one down and pass it around, 2 bottles of beer on the wall.\n"

        Assert.That(beersong.verse(3), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Test_verse_1() =
        let expected = "1 bottle of beer on the wall, 1 bottle of beer.\nTake it down and pass it around, no more bottles of beer on the wall.\n"

        Assert.That(beersong.verse(1), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Test_verse_2() =
        let expected = "2 bottles of beer on the wall, 2 bottles of beer.\nTake one down and pass it around, 1 bottle of beer on the wall.\n"

        Assert.That(beersong.verse(2), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Test_verse_0() =
        let expected = "No more bottles of beer on the wall, no more bottles of beer.\nGo to the store and buy some more, 99 bottles of beer on the wall.\n"

        Assert.That(beersong.verse(0), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Test_several_verses() =
        let expected = "8 bottles of beer on the wall, 8 bottles of beer.\nTake one down and pass it around, 7 bottles of beer on the wall.\n\n7 bottles of beer on the wall, 7 bottles of beer.\nTake one down and pass it around, 6 bottles of beer on the wall.\n\n6 bottles of beer on the wall, 6 bottles of beer.\nTake one down and pass it around, 5 bottles of beer on the wall.\n\n"

        Assert.That(beersong.verses(8, 6), Is.EqualTo(expected))

    [<Test>]
    [<Ignore>]
    member tests.Test_the_whole_song() =
        Assert.That(beersong.verses(99, 0), Is.EqualTo(beersong.sing()))