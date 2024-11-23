~ "queen-attack.ua" ~ QueenAttack

# Queen with a valid position
⍤⤙≍ true create (2, 2)

# Queen must have positive row
⍤⤙≍ false create (-2, 2)

# Queen must have row on board
⍤⤙≍ false create (8, 4)

# Queen must have positive column
⍤⤙≍ false create (2, -2)

# Queen must have column on board
⍤⤙≍ false create (4, 8)

# Cannot attack
    let whiteQueen = (2, 4)
    let blackQueen = (6, 6)
⍤⤙≍ false canAttack blackQueen whiteQueen

# Can attack on same row
    let whiteQueen = (2, 4)
    let blackQueen = (2, 6)
⍤⤙≍ true canAttack blackQueen whiteQueen

# Can attack on same column
    let whiteQueen = (4, 5)
    let blackQueen = (2, 5)
⍤⤙≍ true canAttack blackQueen whiteQueen

# Can attack on first diagonal
    let whiteQueen = (2, 2)
    let blackQueen = (0, 4)
⍤⤙≍ true canAttack blackQueen whiteQueen

# Can attack on second diagonal
    let whiteQueen = (2, 2)
    let blackQueen = (3, 1)
⍤⤙≍ true canAttack blackQueen whiteQueen

# Can attack on third diagonal
    let whiteQueen = (2, 2)
    let blackQueen = (1, 1)
⍤⤙≍ true canAttack blackQueen whiteQueen

# Can attack on fourth diagonal
    let whiteQueen = (1, 7)
    let blackQueen = (0, 6)
⍤⤙≍ true canAttack blackQueen whiteQueen

# Cannot attack if falling diagonals are only the same when reflected across the longest falling diagonal
    let whiteQueen = (4, 1)
    let blackQueen = (2, 5)
⍤⤙≍ false canAttack blackQueen whiteQueen

