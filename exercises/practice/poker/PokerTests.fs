source("./poker.R")
library(testthat)

test_that("Single hand always wins", {
    hands <- c("4S 5S 7H 8D JC")
    expected <- c("4S 5S 7H 8D JC")
    expect_equal(bestHands hands, expected)
})

test_that("Highest card out of all hands wins", {
    hands <- c("4D 5S 6S 8D 3C", "2S 4C 7S 9H 10H", "3S 4S 5D 6H JH")
    expected <- c("3S 4S 5D 6H JH")
    expect_equal(bestHands hands, expected)
})

test_that("A tie has multiple winners", {
    hands <- c("4D 5S 6S 8D 3C", "2S 4C 7S 9H 10H", "3S 4S 5D 6H JH", "3H 4H 5C 6C JD")
    expected <- c("3S 4S 5D 6H JH", "3H 4H 5C 6C JD")
    expect_equal(bestHands hands, expected)
})

test_that("Multiple hands with the same high cards, tie compares next highest ranked, down to last card", {
    hands <- c("3S 5H 6S 8D 7H", "2S 5D 6D 8C 7S")
    expected <- c("3S 5H 6S 8D 7H")
    expect_equal(bestHands hands, expected)
})

test_that("One pair beats high card", {
    hands <- c("4S 5H 6C 8D KH", "2S 4H 6S 4D JH")
    expected <- c("2S 4H 6S 4D JH")
    expect_equal(bestHands hands, expected)
})

test_that("Highest pair wins", {
    hands <- c("4S 2H 6S 2D JH", "2S 4H 6C 4D JD")
    expected <- c("2S 4H 6C 4D JD")
    expect_equal(bestHands hands, expected)
})

test_that("Two pairs beats one pair", {
    hands <- c("2S 8H 6S 8D JH", "4S 5H 4C 8C 5C")
    expected <- c("4S 5H 4C 8C 5C")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have two pairs, highest ranked pair wins", {
    hands <- c("2S 8H 2D 8D 3H", "4S 5H 4C 8S 5D")
    expected <- c("2S 8H 2D 8D 3H")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have two pairs, with the same highest ranked pair, tie goes to low pair", {
    hands <- c("2S QS 2C QD JH", "JD QH JS 8D QC")
    expected <- c("JD QH JS 8D QC")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have two identically ranked pairs, tie goes to remaining card (kicker)", {
    hands <- c("JD QH JS 8D QC", "JS QS JC 2D QD")
    expected <- c("JD QH JS 8D QC")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have two pairs that add to the same value, win goes to highest pair", {
    hands <- c("6S 6H 3S 3H AS", "7H 7S 2H 2S AC")
    expected <- c("7H 7S 2H 2S AC")
    expect_equal(bestHands hands, expected)
})

test_that("Two pairs first ranked by largest pair", {
    hands <- c("5C 2S 5S 4H 4C", "6S 2S 6H 7C 2C")
    expected <- c("6S 2S 6H 7C 2C")
    expect_equal(bestHands hands, expected)
})

test_that("Three of a kind beats two pair", {
    hands <- c("2S 8H 2H 8D JH", "4S 5H 4C 8S 4H")
    expected <- c("4S 5H 4C 8S 4H")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have three of a kind, tie goes to highest ranked triplet", {
    hands <- c("2S 2H 2C 8D JH", "4S AH AS 8C AD")
    expected <- c("4S AH AS 8C AD")
    expect_equal(bestHands hands, expected)
})

test_that("With multiple decks, two players can have same three of a kind, ties go to highest remaining cards", {
    hands <- c("4S AH AS 7C AD", "4S AH AS 8C AD")
    expected <- c("4S AH AS 8C AD")
    expect_equal(bestHands hands, expected)
})

test_that("A straight beats three of a kind", {
    hands <- c("4S 5H 4C 8D 4H", "3S 4D 2S 6D 5C")
    expected <- c("3S 4D 2S 6D 5C")
    expect_equal(bestHands hands, expected)
})

test_that("Aces can end a straight (10 J Q K A)", {
    hands <- c("4S 5H 4C 8D 4H", "10D JH QS KD AC")
    expected <- c("10D JH QS KD AC")
    expect_equal(bestHands hands, expected)
})

test_that("Aces can start a straight (A 2 3 4 5)", {
    hands <- c("4S 5H 4C 8D 4H", "4D AH 3S 2D 5C")
    expected <- c("4D AH 3S 2D 5C")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands with a straight, tie goes to highest ranked card", {
    hands <- c("4S 6C 7S 8D 5H", "5S 7H 8S 9D 6H")
    expected <- c("5S 7H 8S 9D 6H")
    expect_equal(bestHands hands, expected)
})

test_that("Even though an ace is usually high, a 5-high straight is the lowest-scoring straight", {
    hands <- c("2H 3C 4D 5D 6H", "4S AH 3S 2D 5H")
    expected <- c("2H 3C 4D 5D 6H")
    expect_equal(bestHands hands, expected)
})

test_that("Flush beats a straight", {
    hands <- c("4C 6H 7D 8D 5H", "2S 4S 5S 6S 7S")
    expected <- c("2S 4S 5S 6S 7S")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have a flush, tie goes to high card, down to the last one if necessary", {
    hands <- c("4H 7H 8H 9H 6H", "2S 4S 5S 6S 7S")
    expected <- c("4H 7H 8H 9H 6H")
    expect_equal(bestHands hands, expected)
})

test_that("Full house beats a flush", {
    hands <- c("3H 6H 7H 8H 5H", "4S 5H 4C 5D 4H")
    expected <- c("4S 5H 4C 5D 4H")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have a full house, tie goes to highest-ranked triplet", {
    hands <- c("4H 4S 4D 9S 9D", "5H 5S 5D 8S 8D")
    expected <- c("5H 5S 5D 8S 8D")
    expect_equal(bestHands hands, expected)
})

test_that("With multiple decks, both hands have a full house with the same triplet, tie goes to the pair", {
    hands <- c("5H 5S 5D 9S 9D", "5H 5S 5D 8S 8D")
    expected <- c("5H 5S 5D 9S 9D")
    expect_equal(bestHands hands, expected)
})

test_that("Four of a kind beats a full house", {
    hands <- c("4S 5H 4D 5D 4H", "3S 3H 2S 3D 3C")
    expected <- c("3S 3H 2S 3D 3C")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have four of a kind, tie goes to high quad", {
    hands <- c("2S 2H 2C 8D 2D", "4S 5H 5S 5D 5C")
    expected <- c("4S 5H 5S 5D 5C")
    expect_equal(bestHands hands, expected)
})

test_that("With multiple decks, both hands with identical four of a kind, tie determined by kicker", {
    hands <- c("3S 3H 2S 3D 3C", "3S 3H 4S 3D 3C")
    expected <- c("3S 3H 4S 3D 3C")
    expect_equal(bestHands hands, expected)
})

test_that("Straight flush beats four of a kind", {
    hands <- c("4S 5H 5S 5D 5C", "7S 8S 9S 6S 10S")
    expected <- c("7S 8S 9S 6S 10S")
    expect_equal(bestHands hands, expected)
})

test_that("Both hands have a straight flush, tie goes to highest-ranked card", {
    hands <- c("4H 6H 7H 8H 5H", "5S 7S 8S 9S 6S")
    expected <- c("5S 7S 8S 9S 6S")
    expect_equal(bestHands hands, expected)
})
