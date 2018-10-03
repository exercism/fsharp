// This file was auto-generated based on version 1.1.0 of the canonical data.

module YachtTest

open FsUnit.Xunit
open Xunit

open Yacht

[<Fact>]
let ``Yacht`` () =
    score Category.Yacht [DieValue.Five; DieValue.Five; DieValue.Five; DieValue.Five; DieValue.Five] |> should equal 50

[<Fact(Skip = "Remove to run test")>]
let ``Not Yacht`` () =
    score Category.Yacht [DieValue.One; DieValue.Three; DieValue.Three; DieValue.Two; DieValue.Five] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Ones`` () =
    score Category.Ones [DieValue.One; DieValue.One; DieValue.One; DieValue.Three; DieValue.Five] |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Ones, out of order`` () =
    score Category.Ones [DieValue.Three; DieValue.One; DieValue.One; DieValue.Five; DieValue.One] |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``No ones`` () =
    score Category.Ones [DieValue.Four; DieValue.Three; DieValue.Six; DieValue.Five; DieValue.Five] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Twos`` () =
    score Category.Twos [DieValue.Two; DieValue.Three; DieValue.Four; DieValue.Five; DieValue.Six] |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Fours`` () =
    score Category.Fours [DieValue.One; DieValue.Four; DieValue.One; DieValue.Four; DieValue.One] |> should equal 8

[<Fact(Skip = "Remove to run test")>]
let ``Yacht counted as threes`` () =
    score Category.Threes [DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Three] |> should equal 15

[<Fact(Skip = "Remove to run test")>]
let ``Yacht of 3s counted as fives`` () =
    score Category.Fives [DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Three] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Sixes`` () =
    score Category.Sixes [DieValue.Two; DieValue.Three; DieValue.Four; DieValue.Five; DieValue.Six] |> should equal 6

[<Fact(Skip = "Remove to run test")>]
let ``Full house two small, three big`` () =
    score Category.FullHouse [DieValue.Two; DieValue.Two; DieValue.Four; DieValue.Four; DieValue.Four] |> should equal 16

[<Fact(Skip = "Remove to run test")>]
let ``Full house three small, two big`` () =
    score Category.FullHouse [DieValue.Five; DieValue.Three; DieValue.Three; DieValue.Five; DieValue.Three] |> should equal 19

[<Fact(Skip = "Remove to run test")>]
let ``Two pair is not a full house`` () =
    score Category.FullHouse [DieValue.Two; DieValue.Two; DieValue.Four; DieValue.Four; DieValue.Five] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Four of a kind is not a full house`` () =
    score Category.FullHouse [DieValue.One; DieValue.Four; DieValue.Four; DieValue.Four; DieValue.Four] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Yacht is not a full house`` () =
    score Category.FullHouse [DieValue.Two; DieValue.Two; DieValue.Two; DieValue.Two; DieValue.Two] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Four of a Kind`` () =
    score Category.FourOfAKind [DieValue.Six; DieValue.Six; DieValue.Four; DieValue.Six; DieValue.Six] |> should equal 24

[<Fact(Skip = "Remove to run test")>]
let ``Yacht can be scored as Four of a Kind`` () =
    score Category.FourOfAKind [DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Three] |> should equal 12

[<Fact(Skip = "Remove to run test")>]
let ``Full house is not Four of a Kind`` () =
    score Category.FourOfAKind [DieValue.Three; DieValue.Three; DieValue.Three; DieValue.Five; DieValue.Five] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Little Straight`` () =
    score Category.LittleStraight [DieValue.Three; DieValue.Five; DieValue.Four; DieValue.One; DieValue.Two] |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Little Straight as Big Straight`` () =
    score Category.BigStraight [DieValue.One; DieValue.Two; DieValue.Three; DieValue.Four; DieValue.Five] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Four in order but not a little straight`` () =
    score Category.LittleStraight [DieValue.One; DieValue.One; DieValue.Two; DieValue.Three; DieValue.Four] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``No pairs but not a little straight`` () =
    score Category.LittleStraight [DieValue.One; DieValue.Two; DieValue.Three; DieValue.Four; DieValue.Six] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Minimum is 1, maximum is 5, but not a little straight`` () =
    score Category.LittleStraight [DieValue.One; DieValue.One; DieValue.Three; DieValue.Four; DieValue.Five] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Big Straight`` () =
    score Category.BigStraight [DieValue.Four; DieValue.Six; DieValue.Two; DieValue.Five; DieValue.Three] |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Big Straight as little straight`` () =
    score Category.LittleStraight [DieValue.Six; DieValue.Five; DieValue.Four; DieValue.Three; DieValue.Two] |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Choice`` () =
    score Category.Choice [DieValue.Three; DieValue.Three; DieValue.Five; DieValue.Six; DieValue.Six] |> should equal 23

[<Fact(Skip = "Remove to run test")>]
let ``Yacht as choice`` () =
    score Category.Choice [DieValue.Two; DieValue.Two; DieValue.Two; DieValue.Two; DieValue.Two] |> should equal 10

