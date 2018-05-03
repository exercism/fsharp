// This file was auto-generated based on version 1.1.0 of the canonical data.

module YachtTest

open FsUnit.Xunit
open Xunit

open Yacht

[<Fact>]
let ``Yacht`` () =
    score Category.Yacht [5; 5; 5; 5; 5] |> should equal 50

[<Fact(Skip = "Remove to run test")>]
let ``Not Yacht`` () =
    score Category.Yacht [1; 3; 3; 2; 5] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Ones`` () =
    score Category.Ones [1; 1; 1; 3; 5] |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Ones, out of order`` () =
    score Category.Ones [3; 1; 1; 5; 1] |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``No ones`` () =
    score Category.Ones [4; 3; 6; 5; 5] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Twos`` () =
    score Category.Twos [2; 3; 4; 5; 6] |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Fours`` () =
    score Category.Fours [1; 4; 1; 4; 1] |> should equal 8

[<Fact(Skip = "Remove to run test")>]
let ``Yacht counted as threes`` () =
    score Category.Threes [3; 3; 3; 3; 3] |> should equal 15

[<Fact(Skip = "Remove to run test")>]
let ``Yacht of 3s counted as fives`` () =
    score Category.Fives [3; 3; 3; 3; 3] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Sixes`` () =
    score Category.Sixes [2; 3; 4; 5; 6] |> should equal 6

[<Fact(Skip = "Remove to run test")>]
let ``Full house two small, three big`` () =
    score Category.FullHouse [2; 2; 4; 4; 4] |> should equal 16

[<Fact(Skip = "Remove to run test")>]
let ``Full house three small, two big`` () =
    score Category.FullHouse [5; 3; 3; 5; 3] |> should equal 19

[<Fact(Skip = "Remove to run test")>]
let ``Two pair is not a full house`` () =
    score Category.FullHouse [2; 2; 4; 4; 5] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Four of a kind is not a full house`` () =
    score Category.FullHouse [1; 4; 4; 4; 4] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Yacht is not a full house`` () =
    score Category.FullHouse [2; 2; 2; 2; 2] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Four of a Kind`` () =
    score Category.FourOfAKind [6; 6; 4; 6; 6] |> should equal 24

[<Fact(Skip = "Remove to run test")>]
let ``Yacht can be scored as Four of a Kind`` () =
    score Category.FourOfAKind [3; 3; 3; 3; 3] |> should equal 12

[<Fact(Skip = "Remove to run test")>]
let ``Full house is not Four of a Kind`` () =
    score Category.FourOfAKind [3; 3; 3; 5; 5] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Little Straight`` () =
    score Category.LittleStraight [3; 5; 4; 1; 2] |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Little Straight as Big Straight`` () =
    score Category.BigStraight [1; 2; 3; 4; 5] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Four in order but not a little straight`` () =
    score Category.LittleStraight [1; 1; 2; 3; 4] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``No pairs but not a little straight`` () =
    score Category.LittleStraight [1; 2; 3; 4; 6] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Minimum is 1, maximum is 5, but not a little straight`` () =
    score Category.LittleStraight [1; 1; 3; 4; 5] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Big Straight`` () =
    score Category.BigStraight [4; 6; 2; 5; 3] |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Big Straight as little straight`` () =
    score Category.LittleStraight [6; 5; 4; 3; 2] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Choice`` () =
    score Category.Choice [3; 3; 5; 6; 6] |> should equal 23

[<Fact(Skip = "Remove to run test")>]
let ``Yacht as choice`` () =
    score Category.Choice [2; 2; 2; 2; 2] |> should equal 10

