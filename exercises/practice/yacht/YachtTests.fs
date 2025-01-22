source("./yacht.R")
library(testthat)

test_that("Yacht", {
    expect_equal(score Category.Yacht c(Die.Five, Die.Five, Die.Five, Die.Five, Die.Five), 50)
})

test_that("Not Yacht", {
    expect_equal(score Category.Yacht c(Die.One, Die.Three, Die.Three, Die.Two, Die.Five), 0)
})

test_that("Ones", {
    expect_equal(score Category.Ones c(Die.One, Die.One, Die.One, Die.Three, Die.Five), 3)
})

test_that("Ones, out of order", {
    expect_equal(score Category.Ones c(Die.Three, Die.One, Die.One, Die.Five, Die.One), 3)
})

test_that("No ones", {
    expect_equal(score Category.Ones c(Die.Four, Die.Three, Die.Six, Die.Five, Die.Five), 0)
})

test_that("Twos", {
    expect_equal(score Category.Twos c(Die.Two, Die.Three, Die.Four, Die.Five, Die.Six), 2)
})

test_that("Fours", {
    expect_equal(score Category.Fours c(Die.One, Die.Four, Die.One, Die.Four, Die.One), 8)
})

test_that("Yacht counted as threes", {
    expect_equal(score Category.Threes c(Die.Three, Die.Three, Die.Three, Die.Three, Die.Three), 15)
})

test_that("Yacht of 3s counted as fives", {
    expect_equal(score Category.Fives c(Die.Three, Die.Three, Die.Three, Die.Three, Die.Three), 0)
})

test_that("Fives", {
    expect_equal(score Category.Fives c(Die.One, Die.Five, Die.Three, Die.Five, Die.Three), 10)
})

test_that("Sixes", {
    expect_equal(score Category.Sixes c(Die.Two, Die.Three, Die.Four, Die.Five, Die.Six), 6)
})

test_that("Full house two small, three big", {
    expect_equal(score Category.FullHouse c(Die.Two, Die.Two, Die.Four, Die.Four, Die.Four), 16)
})

test_that("Full house three small, two big", {
    expect_equal(score Category.FullHouse c(Die.Five, Die.Three, Die.Three, Die.Five, Die.Three), 19)
})

test_that("Two pair is not a full house", {
    expect_equal(score Category.FullHouse c(Die.Two, Die.Two, Die.Four, Die.Four, Die.Five), 0)
})

test_that("Four of a kind is not a full house", {
    expect_equal(score Category.FullHouse c(Die.One, Die.Four, Die.Four, Die.Four, Die.Four), 0)
})

test_that("Yacht is not a full house", {
    expect_equal(score Category.FullHouse c(Die.Two, Die.Two, Die.Two, Die.Two, Die.Two), 0)
})

test_that("Four of a Kind", {
    expect_equal(score Category.FourOfAKind c(Die.Six, Die.Six, Die.Four, Die.Six, Die.Six), 24)
})

test_that("Yacht can be scored as Four of a Kind", {
    expect_equal(score Category.FourOfAKind c(Die.Three, Die.Three, Die.Three, Die.Three, Die.Three), 12)
})

test_that("Full house is not Four of a Kind", {
    expect_equal(score Category.FourOfAKind c(Die.Three, Die.Three, Die.Three, Die.Five, Die.Five), 0)
})

test_that("Little Straight", {
    expect_equal(score Category.LittleStraight c(Die.Three, Die.Five, Die.Four, Die.One, Die.Two), 30)
})

test_that("Little Straight as Big Straight", {
    expect_equal(score Category.BigStraight c(Die.One, Die.Two, Die.Three, Die.Four, Die.Five), 0)
})

test_that("Four in order but not a little straight", {
    expect_equal(score Category.LittleStraight c(Die.One, Die.One, Die.Two, Die.Three, Die.Four), 0)
})

test_that("No pairs but not a little straight", {
    expect_equal(score Category.LittleStraight c(Die.One, Die.Two, Die.Three, Die.Four, Die.Six), 0)
})

test_that("Minimum is 1, maximum is 5, but not a little straight", {
    expect_equal(score Category.LittleStraight c(Die.One, Die.One, Die.Three, Die.Four, Die.Five), 0)
})

test_that("Big Straight", {
    expect_equal(score Category.BigStraight c(Die.Four, Die.Six, Die.Two, Die.Five, Die.Three), 30)
})

test_that("Big Straight as little straight", {
    expect_equal(score Category.LittleStraight c(Die.Six, Die.Five, Die.Four, Die.Three, Die.Two), 0)
})

test_that("No pairs but not a big straight", {
    expect_equal(score Category.BigStraight c(Die.Six, Die.Five, Die.Four, Die.Three, Die.One), 0)
})

test_that("Choice", {
    expect_equal(score Category.Choice c(Die.Three, Die.Three, Die.Five, Die.Six, Die.Six), 23)
})

test_that("Yacht as choice", {
    expect_equal(score Category.Choice c(Die.Two, Die.Two, Die.Two, Die.Two, Die.Two), 10)
})
