module PokerTest

open Xunit
open FsUnit.Xunit

open Poker

[<Fact>]
let ``One hand`` () =
    let hand = "4S 5S 7H 8D JC"
    bestHands [hand] |> should equal [hand]

[<Fact(Skip = "Remove to run test")>]
let ``Nothing vs one pair`` () =
    let nothing = "4S 5H 6S 8D JH"
    let pairOf4 = "2S 4H 6S 4D JH"
    bestHands [nothing; pairOf4] |> should equal [pairOf4]

[<Fact(Skip = "Remove to run test")>]
let ``Two pairs`` () =
    let pairOf2 = "4S 2H 6S 2D JH"
    let pairOf4 = "2S 4H 6S 4D JH"
    bestHands [pairOf2; pairOf4] |> should equal [pairOf4]

[<Fact(Skip = "Remove to run test")>]
let ``One pair vs double pair`` () =
    let pairOf8 = "2S 8H 6S 8D JH"
    let doublePair = "4S 5H 4S 8D 5H"
    bestHands [pairOf8; doublePair] |> should equal [doublePair]

[<Fact(Skip = "Remove to run test")>]
let ``Two double pairs`` () =
    let doublePair2and8 = "2S 8H 2S 8D JH"
    let doublePair4and5 = "4S 5H 4S 8D 5H"
    bestHands [doublePair2and8; doublePair4and5] |> should equal [doublePair2and8]

[<Fact(Skip = "Remove to run test")>]
let ``Double pair vs three`` () =
    let doublePair2and8 = "2S 8H 2S 8D JH"
    let threeOf4 = "4S 5H 4S 8D 4H"
    bestHands [doublePair2and8; threeOf4] |> should equal [threeOf4]

[<Fact(Skip = "Remove to run test")>]
let ``Two threes`` () =
    let threeOf2 = "2S 2H 2S 8D JH"
    let threeOf1 = "4S AH AS 8D AH"
    bestHands [threeOf2; threeOf1] |> should equal [threeOf1]

[<Fact(Skip = "Remove to run test")>]
let ``Three vs straight`` () =
    let threeOf4 = "4S 5H 4S 8D 4H"
    let straight = "3S 4H 2S 6D 5H"
    bestHands [threeOf4; straight] |> should equal [straight]

[<Fact(Skip = "Remove to run test")>]
let ``Two straights`` () =
    let straightTo8 = "4S 6H 7S 8D 5H"
    let straightTo9 = "5S 7H 8S 9D 6H"
    bestHands [straightTo8; straightTo9] |> should equal [straightTo9]

    let straightTo1 = "AS QH KS TD JH"
    let straightTo5 = "4S AH 3S 2D 5H"
    bestHands [straightTo1; straightTo5] |> should equal [straightTo1]

[<Fact(Skip = "Remove to run test")>]
let ``Straight vs flush`` () =
    let straightTo8 = "4S 6H 7S 8D 5H"
    let flushTo7 = "2S 4S 5S 6S 7S"
    bestHands [straightTo8; flushTo7] |> should equal [flushTo7]

[<Fact(Skip = "Remove to run test")>]
let ``Two flushes`` () =
    let flushTo8 = "3H 6H 7H 8H 5H"
    let flushTo7 = "2S 4S 5S 6S 7S"
    bestHands [flushTo8; flushTo7] |> should equal [flushTo8]

[<Fact(Skip = "Remove to run test")>]
let ``Flush vs full`` () =
    let flushTo8 = "3H 6H 7H 8H 5H"
    let full = "4S 5H 4S 5D 4H"
    bestHands [full; flushTo8] |> should equal [full]

[<Fact(Skip = "Remove to run test")>]
let ``Two fulls`` () =
    let fullOf4by9 = "4H 4S 4D 9S 9D"
    let fullOf5by8 = "5H 5S 5D 8S 8D"
    bestHands [fullOf4by9; fullOf5by8] |> should equal [fullOf5by8]

[<Fact(Skip = "Remove to run test")>]
let ``Full vs square`` () =
    let full = "4S 5H 4S 5D 4H"
    let squareOf3 = "3S 3H 2S 3D 3H"
    bestHands [full; squareOf3] |> should equal [squareOf3]

[<Fact(Skip = "Remove to run test")>]
let ``Two squares`` () =
    let squareOf2 = "2S 2H 2S 8D 2H"
    let squareOf5 = "4S 5H 5S 5D 5H"
    bestHands [squareOf2; squareOf5] |> should equal [squareOf5]

[<Fact(Skip = "Remove to run test")>]
let ``Square vs straight flush`` () =
    let squareOf5 = "4S 5H 5S 5D 5H"
    let straightFlushTo9 = "5S 7S 8S 9S 6S"
    bestHands [squareOf5; straightFlushTo9] |> should equal [straightFlushTo9]

[<Fact(Skip = "Remove to run test")>]
let ``Two straight flushes`` () =
    let straightFlushTo8 = "4H 6H 7H 8H 5H"
    let straightFlushTo9 = "5S 7S 8S 9S 6S"
    bestHands [straightFlushTo8; straightFlushTo9] |> should equal [straightFlushTo9]

[<Fact(Skip = "Remove to run test")>]
let ``Three hand with tie`` () =
    let spadeStraightTo9 = "9S 8S 7S 6S 5S"
    let diamondStraightTo9 = "9D 8D 7D 6D 5D"
    let threeOf4 = "4D 4S 4H QS KS"
    bestHands [spadeStraightTo9; diamondStraightTo9; threeOf4] |> should equal [spadeStraightTo9; diamondStraightTo9]