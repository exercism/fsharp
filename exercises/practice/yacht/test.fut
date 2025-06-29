import "yacht"

let ``Yacht`` () =
    score Category.Yacht [Die.Five; Die.Five; Die.Five; Die.Five; Die.Five] |> should equal 50

let ``Not Yacht`` () =
    score Category.Yacht [Die.One; Die.Three; Die.Three; Die.Two; Die.Five] |> should equal 0

let ``Ones`` () =
    score Category.Ones [Die.One; Die.One; Die.One; Die.Three; Die.Five] |> should equal 3

let ``Ones, out of order`` () =
    score Category.Ones [Die.Three; Die.One; Die.One; Die.Five; Die.One] |> should equal 3

let ``No ones`` () =
    score Category.Ones [Die.Four; Die.Three; Die.Six; Die.Five; Die.Five] |> should equal 0

let ``Twos`` () =
    score Category.Twos [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] |> should equal 2

let ``Fours`` () =
    score Category.Fours [Die.One; Die.Four; Die.One; Die.Four; Die.One] |> should equal 8

let ``Yacht counted as threes`` () =
    score Category.Threes [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three] |> should equal 15

let ``Yacht of 3s counted as fives`` () =
    score Category.Fives [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three] |> should equal 0

let ``Fives`` () =
    score Category.Fives [Die.One; Die.Five; Die.Three; Die.Five; Die.Three] |> should equal 10

let ``Sixes`` () =
    score Category.Sixes [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] |> should equal 6

let ``Full house two small, three big`` () =
    score Category.FullHouse [Die.Two; Die.Two; Die.Four; Die.Four; Die.Four] |> should equal 16

let ``Full house three small, two big`` () =
    score Category.FullHouse [Die.Five; Die.Three; Die.Three; Die.Five; Die.Three] |> should equal 19

let ``Two pair is not a full house`` () =
    score Category.FullHouse [Die.Two; Die.Two; Die.Four; Die.Four; Die.Five] |> should equal 0

let ``Four of a kind is not a full house`` () =
    score Category.FullHouse [Die.One; Die.Four; Die.Four; Die.Four; Die.Four] |> should equal 0

let ``Yacht is not a full house`` () =
    score Category.FullHouse [Die.Two; Die.Two; Die.Two; Die.Two; Die.Two] |> should equal 0

let ``Four of a Kind`` () =
    score Category.FourOfAKind [Die.Six; Die.Six; Die.Four; Die.Six; Die.Six] |> should equal 24

let ``Yacht can be scored as Four of a Kind`` () =
    score Category.FourOfAKind [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three] |> should equal 12

let ``Full house is not Four of a Kind`` () =
    score Category.FourOfAKind [Die.Three; Die.Three; Die.Three; Die.Five; Die.Five] |> should equal 0

let ``Little Straight`` () =
    score Category.LittleStraight [Die.Three; Die.Five; Die.Four; Die.One; Die.Two] |> should equal 30

let ``Little Straight as Big Straight`` () =
    score Category.BigStraight [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] |> should equal 0

let ``Four in order but not a little straight`` () =
    score Category.LittleStraight [Die.One; Die.One; Die.Two; Die.Three; Die.Four] |> should equal 0

let ``No pairs but not a little straight`` () =
    score Category.LittleStraight [Die.One; Die.Two; Die.Three; Die.Four; Die.Six] |> should equal 0

let ``Minimum is 1, maximum is 5, but not a little straight`` () =
    score Category.LittleStraight [Die.One; Die.One; Die.Three; Die.Four; Die.Five] |> should equal 0

let ``Big Straight`` () =
    score Category.BigStraight [Die.Four; Die.Six; Die.Two; Die.Five; Die.Three] |> should equal 30

let ``Big Straight as little straight`` () =
    score Category.LittleStraight [Die.Six; Die.Five; Die.Four; Die.Three; Die.Two] |> should equal 0

let ``No pairs but not a big straight`` () =
    score Category.BigStraight [Die.Six; Die.Five; Die.Four; Die.Three; Die.One] |> should equal 0

let ``Choice`` () =
    score Category.Choice [Die.Three; Die.Three; Die.Five; Die.Six; Die.Six] |> should equal 23

let ``Yacht as choice`` () =
    score Category.Choice [Die.Two; Die.Two; Die.Two; Die.Two; Die.Two] |> should equal 10

