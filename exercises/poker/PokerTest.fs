module PokerTest

open NUnit.Framework

open Poker

[<Test>]
let ``One hand`` () =
    let hand = "4S 5S 7H 8D JC"
    Assert.That(bestHands [hand], Is.EqualTo([hand]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Nothing vs one pair`` () =
    let nothing = "4S 5H 6S 8D JH"
    let pairOf4 = "2S 4H 6S 4D JH"
    Assert.That(bestHands [nothing; pairOf4], Is.EqualTo([pairOf4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two pairs`` () =
    let pairOf2 = "4S 2H 6S 2D JH"
    let pairOf4 = "2S 4H 6S 4D JH"
    Assert.That(bestHands [pairOf2; pairOf4], Is.EqualTo([pairOf4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One pair vs double pair`` () =
    let pairOf8 = "2S 8H 6S 8D JH"
    let doublePair = "4S 5H 4S 8D 5H"
    Assert.That(bestHands [pairOf8; doublePair], Is.EqualTo([doublePair]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two double pairs`` () =
    let doublePair2and8 = "2S 8H 2S 8D JH"
    let doublePair4and5 = "4S 5H 4S 8D 5H"
    Assert.That(bestHands [doublePair2and8; doublePair4and5], Is.EqualTo([doublePair2and8]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Double pair vs three`` () =
    let doublePair2and8 = "2S 8H 2S 8D JH"
    let threeOf4 = "4S 5H 4S 8D 4H"
    Assert.That(bestHands [doublePair2and8; threeOf4], Is.EqualTo([threeOf4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two threes`` () =
    let threeOf2 = "2S 2H 2S 8D JH"
    let threeOf1 = "4S AH AS 8D AH"
    Assert.That(bestHands [threeOf2; threeOf1], Is.EqualTo([threeOf1]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three vs straight`` () =
    let threeOf4 = "4S 5H 4S 8D 4H"
    let straight = "3S 4H 2S 6D 5H"
    Assert.That(bestHands [threeOf4; straight], Is.EqualTo([straight]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two straights`` () =
    let straightTo8 = "4S 6H 7S 8D 5H"
    let straightTo9 = "5S 7H 8S 9D 6H"
    Assert.That(bestHands [straightTo8; straightTo9], Is.EqualTo([straightTo9]))

    let straightTo1 = "AS QH KS TD JH"
    let straightTo5 = "4S AH 3S 2D 5H"
    Assert.That(bestHands [straightTo1; straightTo5], Is.EqualTo([straightTo1]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Straight vs flush`` () =
    let straightTo8 = "4S 6H 7S 8D 5H"
    let flushTo7 = "2S 4S 5S 6S 7S"
    Assert.That(bestHands [straightTo8; flushTo7], Is.EqualTo([flushTo7]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two flushes`` () =
    let flushTo8 = "3H 6H 7H 8H 5H"
    let flushTo7 = "2S 4S 5S 6S 7S"
    Assert.That(bestHands [flushTo8; flushTo7], Is.EqualTo([flushTo8]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Flush vs full`` () =
    let flushTo8 = "3H 6H 7H 8H 5H"
    let full = "4S 5H 4S 5D 4H"
    Assert.That(bestHands [full; flushTo8], Is.EqualTo([full]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two fulls`` () =
    let fullOf4by9 = "4H 4S 4D 9S 9D"
    let fullOf5by8 = "5H 5S 5D 8S 8D"
    Assert.That(bestHands [fullOf4by9; fullOf5by8], Is.EqualTo([fullOf5by8]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Full vs square`` () =
    let full = "4S 5H 4S 5D 4H"
    let squareOf3 = "3S 3H 2S 3D 3H"
    Assert.That(bestHands [full; squareOf3], Is.EqualTo([squareOf3]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two squares`` () =
    let squareOf2 = "2S 2H 2S 8D 2H"
    let squareOf5 = "4S 5H 5S 5D 5H"
    Assert.That(bestHands [squareOf2; squareOf5], Is.EqualTo([squareOf5]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Square vs straight flush`` () =
    let squareOf5 = "4S 5H 5S 5D 5H"
    let straightFlushTo9 = "5S 7S 8S 9S 6S"
    Assert.That(bestHands [squareOf5; straightFlushTo9], Is.EqualTo([straightFlushTo9]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Two straight flushes`` () =
    let straightFlushTo8 = "4H 6H 7H 8H 5H"
    let straightFlushTo9 = "5S 7S 8S 9S 6S"
    Assert.That(bestHands [straightFlushTo8; straightFlushTo9], Is.EqualTo([straightFlushTo9]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Three hand with tie`` () =
    let spadeStraightTo9 = "9S 8S 7S 6S 5S"
    let diamondStraightTo9 = "9D 8D 7D 6D 5D"
    let threeOf4 = "4D 4S 4H QS KS"
    Assert.That(bestHands [spadeStraightTo9; diamondStraightTo9; threeOf4], Is.EqualTo([spadeStraightTo9; diamondStraightTo9]))