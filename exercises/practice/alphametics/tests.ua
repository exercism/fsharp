~ "alphametics.ua" ~ Alphametics

# Puzzle with three letters
puzzle   ← "I + BB == ILL"
expected ←
[’I’_1’B’_9’L’_0]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Solution must have unique value for each letter
puzzle ← "A == B"
⍤⤙≍ "TODO: insert error message" ⍣(solve puzzle)

# Leading zero solution is invalid
puzzle ← "ACA + DD == BD"
⍤⤙≍ "TODO: insert error message" ⍣(solve puzzle)

# Puzzle with two digits final carry
puzzle   ← "A + A + A + A + A + A + A + A + A + A + A + B == BCC"
expected ←
[’A’_9’B’_1’C’_0]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Puzzle with four letters
puzzle   ← "AS + A == MOM"
expected ←
[’A’_9’S’_2’M’_1’O’_0]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Puzzle with six letters
puzzle   ← "NO + NO + TOO == LATE"
expected ←
[’N’_7’O’_4’T’_9’L’_1’A’_0’E’_2]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Puzzle with seven letters
puzzle   ← "HE + SEES + THE == LIGHT"
expected ←
[’E’_4’G’_2’H’_5’I’_0’L’_1’S’_9’T’_7]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Puzzle with eight letters
puzzle   ← "SEND + MORE == MONEY"
expected ←
[’S’_9’E’_5’N’_6’D’_7’M’_1’O’_0’R’_8’Y’_2]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Puzzle with ten letters
puzzle   ← "AND + A + STRONG + OFFENSE + AS + A + GOOD == DEFENSE"
expected ←
[’A’_5’D’_3’E’_4’F’_7’G’_8’N’_0’O’_2’R’_1’S’_6’T’_9]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle

# Puzzle with ten letters and 199 addends
puzzle   ← "THIS + A + FIRE + THEREFORE + FOR + ALL + HISTORIES + I + TELL + A + TALE + THAT + FALSIFIES + ITS + TITLE + TIS + A + LIE + THE + TALE + OF + THE + LAST + FIRE + HORSES + LATE + AFTER + THE + FIRST + FATHERS + FORESEE + THE + HORRORS + THE + LAST + FREE + TROLL + TERRIFIES + THE + HORSES + OF + FIRE + THE + TROLL + RESTS + AT + THE + HOLE + OF + LOSSES + IT + IS + THERE + THAT + SHE + STORES + ROLES + OF + LEATHERS + AFTER + SHE + SATISFIES + HER + HATE + OFF + THOSE + FEARS + A + TASTE + RISES + AS + SHE + HEARS + THE + LEAST + FAR + HORSE + THOSE + FAST + HORSES + THAT + FIRST + HEAR + THE + TROLL + FLEE + OFF + TO + THE + FOREST + THE + HORSES + THAT + ALERTS + RAISE + THE + STARES + OF + THE + OTHERS + AS + THE + TROLL + ASSAILS + AT + THE + TOTAL + SHIFT + HER + TEETH + TEAR + HOOF + OFF + TORSO + AS + THE + LAST + HORSE + FORFEITS + ITS + LIFE + THE + FIRST + FATHERS + HEAR + OF + THE + HORRORS + THEIR + FEARS + THAT + THE + FIRES + FOR + THEIR + FEASTS + ARREST + AS + THE + FIRST + FATHERS + RESETTLE + THE + LAST + OF + THE + FIRE + HORSES + THE + LAST + TROLL + HARASSES + THE + FOREST + HEART + FREE + AT + LAST + OF + THE + LAST + TROLL + ALL + OFFER + THEIR + FIRE + HEAT + TO + THE + ASSISTERS + FAR + OFF + THE + TROLL + FASTS + ITS + LIFE + SHORTER + AS + STARS + RISE + THE + HORSES + REST + SAFE + AFTER + ALL + SHARE + HOT + FISH + AS + THEIR + AFFILIATES + TAILOR + A + ROOFS + FOR + THEIR + SAFE == FORTRESSES"
expected ←
[’A’_1’E’_0’F’_5’H’_8’I’_7’L’_2’O’_6’R’_3’S’_4’T’_9]
| > Map.ofList
| > Some
⍤⤙≍ expected solve puzzle
