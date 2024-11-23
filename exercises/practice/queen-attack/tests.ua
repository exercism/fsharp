~ "queen-attack.ua" ~ QueenAttack

# Queen with a valid position
⍤⤙≍ 1 create (2, 2)

# Queen must have positive row
⍤⤙≍ 0 create (-2, 2)

# Queen must have row on board
⍤⤙≍ 0 create (8, 4)

# Queen must have positive column
⍤⤙≍ 0 create (2, -2)

# Queen must have column on board
⍤⤙≍ 0 create (4, 8)

# Cannot attack
whiteQueen = (2, 4)
blackQueen = (6, 6)
⍤⤙≍ 0 canAttack blackQueen whiteQueen

# Can attack on same row
whiteQueen = (2, 4)
blackQueen = (2, 6)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on same column
whiteQueen = (4, 5)
blackQueen = (2, 5)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on first diagonal
whiteQueen = (2, 2)
blackQueen = (0, 4)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on second diagonal
whiteQueen = (2, 2)
blackQueen = (3, 1)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on third diagonal
whiteQueen = (2, 2)
blackQueen = (1, 1)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on fourth diagonal
whiteQueen = (1, 7)
blackQueen = (0, 6)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal
whiteQueen = (4, 1)
blackQueen = (2, 5)
⍤⤙≍ 0 canAttack blackQueen whiteQueen

