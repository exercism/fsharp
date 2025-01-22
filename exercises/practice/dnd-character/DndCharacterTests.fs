source("./dnd-character.R")
library(testthat)

let ``Ability modifier for score 3 is -4`` () =
    expect_equal(modifier 3, -4)

let ``Ability modifier for score 4 is -3`` () =
    expect_equal(modifier 4, -3)

let ``Ability modifier for score 5 is -3`` () =
    expect_equal(modifier 5, -3)

let ``Ability modifier for score 6 is -2`` () =
    expect_equal(modifier 6, -2)

let ``Ability modifier for score 7 is -2`` () =
    expect_equal(modifier 7, -2)

let ``Ability modifier for score 8 is -1`` () =
    expect_equal(modifier 8, -1)

let ``Ability modifier for score 9 is -1`` () =
    expect_equal(modifier 9, -1)

let ``Ability modifier for score 10 is 0`` () =
    expect_equal(modifier 10, 0)

let ``Ability modifier for score 11 is 0`` () =
    expect_equal(modifier 11, 0)

let ``Ability modifier for score 12 is +1`` () =
    expect_equal(modifier 12, 1)

let ``Ability modifier for score 13 is +1`` () =
    expect_equal(modifier 13, 1)

let ``Ability modifier for score 14 is +2`` () =
    expect_equal(modifier 14, 2)

let ``Ability modifier for score 15 is +2`` () =
    expect_equal(modifier 15, 2)

let ``Ability modifier for score 16 is +3`` () =
    expect_equal(modifier 16, 3)

let ``Ability modifier for score 17 is +3`` () =
    expect_equal(modifier 17, 3)

let ``Ability modifier for score 18 is +4`` () =
    expect_equal(modifier 18, 4)

let ``Random ability is within range`` () =
    for i in 1 .. 10 do
        ability <- ability()
        ability |> should be (greaterThanOrEqualTo 3)
        ability |> should be (lessThanOrEqualTo  18)

let ``Random character is valid`` () =
    for i in 1 .. 10 do
        character <- createCharacter()
        character.Strength |> should be (greaterThanOrEqualTo 3)
        character.Strength |> should be (lessThanOrEqualTo  18)
        character.Dexterity |> should be (greaterThanOrEqualTo 3)
        character.Dexterity |> should be (lessThanOrEqualTo  18)
        character.Constitution |> should be (greaterThanOrEqualTo 3)
        character.Constitution |> should be (lessThanOrEqualTo  18)
        character.Intelligence |> should be (greaterThanOrEqualTo 3)
        character.Intelligence |> should be (lessThanOrEqualTo  18)
        character.Wisdom |> should be (greaterThanOrEqualTo 3)
        character.Wisdom |> should be (lessThanOrEqualTo  18)
        character.Charisma |> should be (greaterThanOrEqualTo 3)
        character.Charisma |> should be (lessThanOrEqualTo  18)
    expect_equal(character.Hitpoints, (10 + modifier(character.Constitution)))

let ``Each ability is only calculated once`` () =
    for i in 1 .. 10 do
        character <- createCharacter()
    expect_equal(character.Strength, character.Strength)
    expect_equal(character.Dexterity, character.Dexterity)
    expect_equal(character.Constitution, character.Constitution)
    expect_equal(character.Intelligence, character.Intelligence)
    expect_equal(character.Wisdom, character.Wisdom)
    expect_equal(character.Charisma, character.Charisma)
    expect_equal(character.Hitpoints, character.Hitpoints)

