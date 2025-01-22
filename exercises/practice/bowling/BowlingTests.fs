source("./bowling.R")
library(testthat)

let rollMany rolls game = List.fold (fun game pins -> roll pins game) game rolls

test_that("Should be able to score a game with all zeros", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 0))
})

test_that("Should be able to score a game with no strikes or spares", {
    rolls <- c(3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6, 3, 6)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 90))
})

test_that("A spare followed by zeros is worth ten points", {
    rolls <- c(6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 10))
})

test_that("Points scored in the roll after a spare are counted twice", {
    rolls <- c(6, 4, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 16))
})

test_that("Consecutive spares each get a one roll bonus", {
    rolls <- c(5, 5, 3, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 31))
})

test_that("A spare in the last frame gets a one roll bonus that is counted once", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 7)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 17))
})

test_that("A strike earns ten points in a frame with a single roll", {
    rolls <- c(10, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 10))
})

test_that("Points scored in the two rolls after a strike are counted twice as a bonus", {
    rolls <- c(10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 26))
})

test_that("Consecutive strikes each get the two roll bonus", {
    rolls <- c(10, 10, 10, 5, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 81))
})

test_that("A strike in the last frame gets a two roll bonus that is counted once", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 1)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 18))
})

test_that("Rolling a spare with the two roll bonus does not get a bonus roll", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 7, 3)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 20))
})

test_that("Strikes with the two roll bonus do not get bonus rolls", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 10)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 30))
})

test_that("Last two strikes followed by only last bonus with non strike points", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 0, 1)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 31))
})

test_that("A strike with the one roll bonus after a spare in the last frame does not get a bonus", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 10)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 20))
})

test_that("All strikes is a perfect game", {
    rolls <- c(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 300))
})

test_that("Rolls cannot score negative points", {
    rolls <- []
    startingRolls <- rollMany rolls (newGame())
    game <- roll -1 startingRolls
    expect_equal(score game, None)
})

test_that("A roll cannot score more than 10 points", {
    rolls <- []
    startingRolls <- rollMany rolls (newGame())
    game <- roll 11 startingRolls
    expect_equal(score game, None)
})

test_that("Two rolls in a frame cannot score more than 10 points", {
    rolls <- c(5)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 6 startingRolls
    expect_equal(score game, None)
})

test_that("Bonus roll after a strike in the last frame cannot score more than 10 points", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 11 startingRolls
    expect_equal(score game, None)
})

test_that("Two bonus rolls after a strike in the last frame cannot score more than 10 points", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 5)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 6 startingRolls
    expect_equal(score game, None)
})

test_that("Two bonus rolls after a strike in the last frame can score more than 10 points if one is a strike", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10, 6)
    game <- rollMany rolls (newGame())
    expect_equal(score game, (Some 26))
})

test_that("The second bonus rolls after a strike in the last frame cannot be a strike if the first one is not a strike", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 6)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 10 startingRolls
    expect_equal(score game, None)
})

test_that("Second bonus roll after a strike in the last frame cannot score more than 10 points", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 11 startingRolls
    expect_equal(score game, None)
})

test_that("An unstarted game cannot be scored", {
    rolls <- []
    game <- rollMany rolls (newGame())
    expect_equal(score game, None)
})

test_that("An incomplete game cannot be scored", {
    rolls <- c(0, 0)
    game <- rollMany rolls (newGame())
    expect_equal(score game, None)
})

test_that("Cannot roll if game already has ten frames", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 0 startingRolls
    expect_equal(score game, None)
})

test_that("Bonus rolls for a strike in the last frame must be rolled before score can be calculated", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10)
    game <- rollMany rolls (newGame())
    expect_equal(score game, None)
})

test_that("Both bonus rolls for a strike in the last frame must be rolled before score can be calculated", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 10)
    game <- rollMany rolls (newGame())
    expect_equal(score game, None)
})

test_that("Bonus roll for a spare in the last frame must be rolled before score can be calculated", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3)
    game <- rollMany rolls (newGame())
    expect_equal(score game, None)
})

test_that("Cannot roll after bonus roll for spare", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 3, 2)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 2 startingRolls
    expect_equal(score game, None)
})

test_that("Cannot roll after bonus rolls for strike", {
    rolls <- c(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 3, 2)
    startingRolls <- rollMany rolls (newGame())
    game <- roll 2 startingRolls
    expect_equal(score game, None)
})
