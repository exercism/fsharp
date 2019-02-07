// This file was auto-generated based on version 1.1.0 of the canonical data.

module DndCharacterTest

open FsUnit.Xunit
open Xunit

open DndCharacter

[<Fact>]
let ``Ability modifier for score 3 is -4`` () =
    modifier 3 |> should equal -4

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 4 is -3`` () =
    modifier 4 |> should equal -3

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 5 is -3`` () =
    modifier 5 |> should equal -3

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 6 is -2`` () =
    modifier 6 |> should equal -2

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 7 is -2`` () =
    modifier 7 |> should equal -2

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 8 is -1`` () =
    modifier 8 |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 9 is -1`` () =
    modifier 9 |> should equal -1

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 10 is 0`` () =
    modifier 10 |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 11 is 0`` () =
    modifier 11 |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 12 is +1`` () =
    modifier 12 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 13 is +1`` () =
    modifier 13 |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 14 is +2`` () =
    modifier 14 |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 15 is +2`` () =
    modifier 15 |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 16 is +3`` () =
    modifier 16 |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 17 is +3`` () =
    modifier 17 |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Ability modifier for score 18 is +4`` () =
    modifier 18 |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``Random ability is within range`` () =
    let ability = ability()
    for i in 1 .. 10 do
        ability |> should be (greaterThanOrEqualTo 3)
        ability |> should be (lessThanOrEqualTo  18)

[<Fact(Skip = "Remove to run test")>]
let ``Random character is valid`` () =
    for i in 1 .. 10 do
        let character = DndCharacter()
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
        character.Hitpoints |> should equal (10 + modifier(character.Constitution))

[<Fact(Skip = "Remove to run test")>]
let ``Each ability is only calculated once`` () =
    for i in 1 .. 10 do
        let character = DndCharacter()
        character.Strength |> should equal character.Strength
        character.Dexterity |> should equal character.Dexterity
        character.Constitution |> should equal character.Constitution
        character.Intelligence |> should equal character.Intelligence
        character.Wisdom |> should equal character.Wisdom
        character.Charisma |> should equal character.Charisma
        character.Hitpoints |> should equal character.Hitpoints

