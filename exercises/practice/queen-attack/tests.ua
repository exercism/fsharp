~ "queen-attack.ua" ~ QueenAttack

# Queen with a valid position
⍤⤙≍ 1 create 2_2

# Queen must have positive row
⍤⤙≍ 0 create -2_2

# Queen must have row on board
⍤⤙≍ 0 create 8_4

# Queen must have positive column
⍤⤙≍ 0 create 2_-2

# Queen must have column on board
⍤⤙≍ 0 create 4_8

# Cannot attack
whiteQueen ← 2_4
blackQueen ← 6_6
⍤⤙≍ 0 canAttack blackQueen whiteQueen

# Can attack on same row
whiteQueen ← 2_4
blackQueen ← 2_6
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on same column
whiteQueen ← 4_5
blackQueen ← 2_5
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on first diagonal
whiteQueen ← 2_2
blackQueen ← 0_4
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on second diagonal
whiteQueen ← 2_2
blackQueen ← 3_1
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on third diagonal
whiteQueen ← 2_2
blackQueen ← 1_1
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on fourth diagonal
whiteQueen ← 1_7
blackQueen ← 0_6
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal
whiteQueen ← 4_1
blackQueen ← 2_5
⍤⤙≍ 0 canAttack blackQueen whiteQueen
