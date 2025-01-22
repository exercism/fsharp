source("./yacht.R")
library(testthat)

let ``Yacht`` () =
    expect_equal(score Category.Yacht [Die.Five; Die.Five; Die.Five; Die.Five; Die.Five], 50)

let ``Not Yacht`` () =
    expect_equal(score Category.Yacht [Die.One; Die.Three; Die.Three; Die.Two; Die.Five], 0)

let ``Ones`` () =
    expect_equal(score Category.Ones [Die.One; Die.One; Die.One; Die.Three; Die.Five], 3)

let ``Ones, out of order`` () =
    expect_equal(score Category.Ones [Die.Three; Die.One; Die.One; Die.Five; Die.One], 3)

let ``No ones`` () =
    expect_equal(score Category.Ones [Die.Four; Die.Three; Die.Six; Die.Five; Die.Five], 0)

let ``Twos`` () =
    expect_equal(score Category.Twos [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six], 2)

let ``Fours`` () =
    expect_equal(score Category.Fours [Die.One; Die.Four; Die.One; Die.Four; Die.One], 8)

let ``Yacht counted as threes`` () =
    expect_equal(score Category.Threes [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three], 15)

let ``Yacht of 3s counted as fives`` () =
    expect_equal(score Category.Fives [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three], 0)

let ``Fives`` () =
    expect_equal(score Category.Fives [Die.One; Die.Five; Die.Three; Die.Five; Die.Three], 10)

let ``Sixes`` () =
    expect_equal(score Category.Sixes [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six], 6)

let ``Full house two small, three big`` () =
    expect_equal(score Category.FullHouse [Die.Two; Die.Two; Die.Four; Die.Four; Die.Four], 16)

let ``Full house three small, two big`` () =
    expect_equal(score Category.FullHouse [Die.Five; Die.Three; Die.Three; Die.Five; Die.Three], 19)

let ``Two pair is not a full house`` () =
    expect_equal(score Category.FullHouse [Die.Two; Die.Two; Die.Four; Die.Four; Die.Five], 0)

let ``Four of a kind is not a full house`` () =
    expect_equal(score Category.FullHouse [Die.One; Die.Four; Die.Four; Die.Four; Die.Four], 0)

let ``Yacht is not a full house`` () =
    expect_equal(score Category.FullHouse [Die.Two; Die.Two; Die.Two; Die.Two; Die.Two], 0)

let ``Four of a Kind`` () =
    expect_equal(score Category.FourOfAKind [Die.Six; Die.Six; Die.Four; Die.Six; Die.Six], 24)

let ``Yacht can be scored as Four of a Kind`` () =
    expect_equal(score Category.FourOfAKind [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three], 12)

let ``Full house is not Four of a Kind`` () =
    expect_equal(score Category.FourOfAKind [Die.Three; Die.Three; Die.Three; Die.Five; Die.Five], 0)

let ``Little Straight`` () =
    expect_equal(score Category.LittleStraight [Die.Three; Die.Five; Die.Four; Die.One; Die.Two], 30)

let ``Little Straight as Big Straight`` () =
    expect_equal(score Category.BigStraight [Die.One; Die.Two; Die.Three; Die.Four; Die.Five], 0)

let ``Four in order but not a little straight`` () =
    expect_equal(score Category.LittleStraight [Die.One; Die.One; Die.Two; Die.Three; Die.Four], 0)

let ``No pairs but not a little straight`` () =
    expect_equal(score Category.LittleStraight [Die.One; Die.Two; Die.Three; Die.Four; Die.Six], 0)

let ``Minimum is 1, maximum is 5, but not a little straight`` () =
    expect_equal(score Category.LittleStraight [Die.One; Die.One; Die.Three; Die.Four; Die.Five], 0)

let ``Big Straight`` () =
    expect_equal(score Category.BigStraight [Die.Four; Die.Six; Die.Two; Die.Five; Die.Three], 30)

let ``Big Straight as little straight`` () =
    expect_equal(score Category.LittleStraight [Die.Six; Die.Five; Die.Four; Die.Three; Die.Two], 0)

let ``No pairs but not a big straight`` () =
    expect_equal(score Category.BigStraight [Die.Six; Die.Five; Die.Four; Die.Three; Die.One], 0)

let ``Choice`` () =
    expect_equal(score Category.Choice [Die.Three; Die.Three; Die.Five; Die.Six; Die.Six], 23)

let ``Yacht as choice`` () =
    expect_equal(score Category.Choice [Die.Two; Die.Two; Die.Two; Die.Two; Die.Two], 10)

