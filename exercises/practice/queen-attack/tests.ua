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
    let whiteQueen = (2, 4)
    let blackQueen = (6, 6)
⍤⤙≍ 0 canAttack blackQueen whiteQueen

# Can attack on same row
    let whiteQueen = (2, 4)
    let blackQueen = (2, 6)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on same column
    let whiteQueen = (4, 5)
    let blackQueen = (2, 5)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on first diagonal
    let whiteQueen = (2, 2)
    let blackQueen = (0, 4)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on second diagonal
    let whiteQueen = (2, 2)
    let blackQueen = (3, 1)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on third diagonal
    let whiteQueen = (2, 2)
    let blackQueen = (1, 1)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Can attack on fourth diagonal
    let whiteQueen = (1, 7)
    let blackQueen = (0, 6)
⍤⤙≍ 1 canAttack blackQueen whiteQueen

# Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal
    let whiteQueen = (4, 1)
    let blackQueen = (2, 5)
⍤⤙≍ 0 canAttack blackQueen whiteQueen

