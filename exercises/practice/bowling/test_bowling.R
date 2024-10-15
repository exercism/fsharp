source("./bowling.R")
library(testthat)



let rollMany rolls game = List.fold (fun game pins -> roll pins game) game rolls
})

test_that("Should be able to score a game with all zeros", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 0)
})

test_that("Should be able to score a game with no strikes or spares", {
    let rolls = [3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6; 3; 6]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 90)
})

test_that("A spare followed by zeros is worth ten points", {
    let rolls = [6; 4; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 10)
})

test_that("Points scored in the roll after a spare are counted twice", {
    let rolls = [6; 4; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 16)
})

test_that("Consecutive spares each get a one roll bonus", {
    let rolls = [5; 5; 3; 7; 4; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 31)
})

test_that("A spare in the last frame gets a one roll bonus that is counted once", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3; 7]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 17)
})

test_that("A strike earns ten points in a frame with a single roll", {
    let rolls = [10; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 10)
})

test_that("Points scored in the two rolls after a strike are counted twice as a bonus", {
    let rolls = [10; 5; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 26)
})

test_that("Consecutive strikes each get the two roll bonus", {
    let rolls = [10; 10; 10; 5; 3; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 81)
})

test_that("A strike in the last frame gets a two roll bonus that is counted once", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 7; 1]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 18)
})

test_that("Rolling a spare with the two roll bonus does not get a bonus roll", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 7; 3]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 20)
})

test_that("Strikes with the two roll bonus do not get bonus rolls", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10; 10]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 30)
})

test_that("Last two strikes followed by only last bonus with non strike points", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10; 0; 1]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 31)
})

test_that("A strike with the one roll bonus after a spare in the last frame does not get a bonus", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3; 10]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 20)
})

test_that("All strikes is a perfect game", {
    let rolls = [10; 10; 10; 10; 10; 10; 10; 10; 10; 10; 10; 10]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 300)
})

test_that("Rolls cannot score negative points", {
    let rolls = []
    let startingRolls = rollMany rolls (newGame())
    let game = roll -1 startingRolls
    score game |> should equal None
})

test_that("A roll cannot score more than 10 points", {
    let rolls = []
    let startingRolls = rollMany rolls (newGame())
    let game = roll 11 startingRolls
    score game |> should equal None
})

test_that("Two rolls in a frame cannot score more than 10 points", {
    let rolls = [5]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 6 startingRolls
    score game |> should equal None
})

test_that("Bonus roll after a strike in the last frame cannot score more than 10 points", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 11 startingRolls
    score game |> should equal None
})

test_that("Two bonus rolls after a strike in the last frame cannot score more than 10 points", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 5]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 6 startingRolls
    score game |> should equal None
})

test_that("Two bonus rolls after a strike in the last frame can score more than 10 points if one is a strike", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10; 6]
    let game = rollMany rolls (newGame())
    score game |> should equal (Some 26)
})

test_that("The second bonus rolls after a strike in the last frame cannot be a strike if the first one is not a strike", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 6]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 10 startingRolls
    score game |> should equal None
})

test_that("Second bonus roll after a strike in the last frame cannot score more than 10 points", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 11 startingRolls
    score game |> should equal None
})

test_that("An unstarted game cannot be scored", {
    let rolls = []
    let game = rollMany rolls (newGame())
    score game |> should equal None
})

test_that("An incomplete game cannot be scored", {
    let rolls = [0; 0]
    let game = rollMany rolls (newGame())
    score game |> should equal None
})

test_that("Cannot roll if game already has ten frames", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 0 startingRolls
    score game |> should equal None
})

test_that("Bonus rolls for a strike in the last frame must be rolled before score can be calculated", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10]
    let game = rollMany rolls (newGame())
    score game |> should equal None
})

test_that("Both bonus rolls for a strike in the last frame must be rolled before score can be calculated", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 10]
    let game = rollMany rolls (newGame())
    score game |> should equal None
})

test_that("Bonus roll for a spare in the last frame must be rolled before score can be calculated", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3]
    let game = rollMany rolls (newGame())
    score game |> should equal None
})

test_that("Cannot roll after bonus roll for spare", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 7; 3; 2]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 2 startingRolls
    score game |> should equal None
})

test_that("Cannot roll after bonus rolls for strike", {
    let rolls = [0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 0; 10; 3; 2]
    let startingRolls = rollMany rolls (newGame())
    let game = roll 2 startingRolls
    score game |> should equal None

