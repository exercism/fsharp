~ "dnd-character.ua" ~ DndCharacter

# Ability modifier for score 3 is -4
⍤⤙≍ -4 modifier 3

# Ability modifier for score 4 is -3
⍤⤙≍ -3 modifier 4

# Ability modifier for score 5 is -3
⍤⤙≍ -3 modifier 5

# Ability modifier for score 6 is -2
⍤⤙≍ -2 modifier 6

# Ability modifier for score 7 is -2
⍤⤙≍ -2 modifier 7

# Ability modifier for score 8 is -1
⍤⤙≍ -1 modifier 8

# Ability modifier for score 9 is -1
⍤⤙≍ -1 modifier 9

# Ability modifier for score 10 is 0
⍤⤙≍ 0 modifier 10

# Ability modifier for score 11 is 0
⍤⤙≍ 0 modifier 11

# Ability modifier for score 12 is +1
⍤⤙≍ 1 modifier 12

# Ability modifier for score 13 is +1
⍤⤙≍ 1 modifier 13

# Ability modifier for score 14 is +2
⍤⤙≍ 2 modifier 14

# Ability modifier for score 15 is +2
⍤⤙≍ 2 modifier 15

# Ability modifier for score 16 is +3
⍤⤙≍ 3 modifier 16

# Ability modifier for score 17 is +3
⍤⤙≍ 3 modifier 17

# Ability modifier for score 18 is +4
⍤⤙≍ 4 modifier 18

# Random ability is within range
    for i in 1 .. 10 do
ability = ability()
        ability |> should be (greaterThanOrEqualTo 3)
        ability |> should be (lessThanOrEqualTo  18)

# Random character is valid
    for i in 1 .. 10 do
character = createCharacter()
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
⍤⤙≍ (10 + modifier(character.Constitution)) character.Hitpoints

# Each ability is only calculated once
    for i in 1 .. 10 do
character = createCharacter()
⍤⤙≍ character.Strength character.Strength
⍤⤙≍ character.Dexterity character.Dexterity
⍤⤙≍ character.Constitution character.Constitution
⍤⤙≍ character.Intelligence character.Intelligence
⍤⤙≍ character.Wisdom character.Wisdom
⍤⤙≍ character.Charisma character.Charisma
⍤⤙≍ character.Hitpoints character.Hitpoints

