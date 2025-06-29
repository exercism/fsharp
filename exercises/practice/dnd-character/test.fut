import "dnd_character"

-- Ability modifier for score 3 is -4
-- ==
-- input { 3 }
-- output { -4 }

-- Ability modifier for score 4 is -3
-- ==
-- input { 4 }
-- output { -3 }

-- Ability modifier for score 5 is -3
-- ==
-- input { 5 }
-- output { -3 }

-- Ability modifier for score 6 is -2
-- ==
-- input { 6 }
-- output { -2 }

-- Ability modifier for score 7 is -2
-- ==
-- input { 7 }
-- output { -2 }

-- Ability modifier for score 8 is -1
-- ==
-- input { 8 }
-- output { -1 }

-- Ability modifier for score 9 is -1
-- ==
-- input { 9 }
-- output { -1 }

-- Ability modifier for score 10 is 0
-- ==
-- input { 10 }
-- output { 0 }

-- Ability modifier for score 11 is 0
-- ==
-- input { 11 }
-- output { 0 }

-- Ability modifier for score 12 is +1
-- ==
-- input { 12 }
-- output { 1 }

-- Ability modifier for score 13 is +1
-- ==
-- input { 13 }
-- output { 1 }

-- Ability modifier for score 14 is +2
-- ==
-- input { 14 }
-- output { 2 }

-- Ability modifier for score 15 is +2
-- ==
-- input { 15 }
-- output { 2 }

-- Ability modifier for score 16 is +3
-- ==
-- input { 16 }
-- output { 3 }

-- Ability modifier for score 17 is +3
-- ==
-- input { 17 }
-- output { 3 }

-- Ability modifier for score 18 is +4
-- ==
-- input { 18 }
-- output { 4 }

let ``Random ability is within range`` () =
    for i in 1 .. 10 do
        let ability = ability()
        ability |> should be (greaterThanOrEqualTo 3)
        ability |> should be (lessThanOrEqualTo  18)

let ``Random character is valid`` () =
    for i in 1 .. 10 do
        let character = createCharacter()
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

let ``Each ability is only calculated once`` () =
    for i in 1 .. 10 do
        let character = createCharacter()
        character.Strength |> should equal character.Strength
        character.Dexterity |> should equal character.Dexterity
        character.Constitution |> should equal character.Constitution
        character.Intelligence |> should equal character.Intelligence
        character.Wisdom |> should equal character.Wisdom
        character.Charisma |> should equal character.Charisma
        character.Hitpoints |> should equal character.Hitpoints

