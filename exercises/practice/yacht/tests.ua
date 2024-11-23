~ "yacht.ua" ~ Yacht

# Yacht
    score Category.Yacht [Die.Five; Die.Five; Die.Five; Die.Five; Die.Five] |> should equal 50

# Not Yacht
    score Category.Yacht [Die.One; Die.Three; Die.Three; Die.Two; Die.Five] |> should equal 0

# Ones
    score Category.Ones [Die.One; Die.One; Die.One; Die.Three; Die.Five] |> should equal 3

# Ones, out of order
    score Category.Ones [Die.Three; Die.One; Die.One; Die.Five; Die.One] |> should equal 3

# No ones
    score Category.Ones [Die.Four; Die.Three; Die.Six; Die.Five; Die.Five] |> should equal 0

# Twos
    score Category.Twos [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] |> should equal 2

# Fours
    score Category.Fours [Die.One; Die.Four; Die.One; Die.Four; Die.One] |> should equal 8

# Yacht counted as threes
    score Category.Threes [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three] |> should equal 15

# Yacht of 3s counted as fives
    score Category.Fives [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three] |> should equal 0

# Fives
    score Category.Fives [Die.One; Die.Five; Die.Three; Die.Five; Die.Three] |> should equal 10

# Sixes
    score Category.Sixes [Die.Two; Die.Three; Die.Four; Die.Five; Die.Six] |> should equal 6

# Full house two small, three big
    score Category.FullHouse [Die.Two; Die.Two; Die.Four; Die.Four; Die.Four] |> should equal 16

# Full house three small, two big
    score Category.FullHouse [Die.Five; Die.Three; Die.Three; Die.Five; Die.Three] |> should equal 19

# Two pair is not a full house
    score Category.FullHouse [Die.Two; Die.Two; Die.Four; Die.Four; Die.Five] |> should equal 0

# Four of a kind is not a full house
    score Category.FullHouse [Die.One; Die.Four; Die.Four; Die.Four; Die.Four] |> should equal 0

# Yacht is not a full house
    score Category.FullHouse [Die.Two; Die.Two; Die.Two; Die.Two; Die.Two] |> should equal 0

# Four of a Kind
    score Category.FourOfAKind [Die.Six; Die.Six; Die.Four; Die.Six; Die.Six] |> should equal 24

# Yacht can be scored as Four of a Kind
    score Category.FourOfAKind [Die.Three; Die.Three; Die.Three; Die.Three; Die.Three] |> should equal 12

# Full house is not Four of a Kind
    score Category.FourOfAKind [Die.Three; Die.Three; Die.Three; Die.Five; Die.Five] |> should equal 0

# Little Straight
    score Category.LittleStraight [Die.Three; Die.Five; Die.Four; Die.One; Die.Two] |> should equal 30

# Little Straight as Big Straight
    score Category.BigStraight [Die.One; Die.Two; Die.Three; Die.Four; Die.Five] |> should equal 0

# Four in order but not a little straight
    score Category.LittleStraight [Die.One; Die.One; Die.Two; Die.Three; Die.Four] |> should equal 0

# No pairs but not a little straight
    score Category.LittleStraight [Die.One; Die.Two; Die.Three; Die.Four; Die.Six] |> should equal 0

# Minimum is 1, maximum is 5, but not a little straight
    score Category.LittleStraight [Die.One; Die.One; Die.Three; Die.Four; Die.Five] |> should equal 0

# Big Straight
    score Category.BigStraight [Die.Four; Die.Six; Die.Two; Die.Five; Die.Three] |> should equal 30

# Big Straight as little straight
    score Category.LittleStraight [Die.Six; Die.Five; Die.Four; Die.Three; Die.Two] |> should equal 0

# No pairs but not a big straight
    score Category.BigStraight [Die.Six; Die.Five; Die.Four; Die.Three; Die.One] |> should equal 0

# Choice
    score Category.Choice [Die.Three; Die.Three; Die.Five; Die.Six; Die.Six] |> should equal 23

# Yacht as choice
    score Category.Choice [Die.Two; Die.Two; Die.Two; Die.Two; Die.Two] |> should equal 10

