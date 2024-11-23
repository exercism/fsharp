~ "robot-simulator.ua" ~ RobotSimulator

# At origin facing north
    let expected = create Direction.North (0, 0)
⍤⤙≍ expected create Direction.North (0, 0)

# At negative position facing south
    let expected = create Direction.South (-1, -1)
⍤⤙≍ expected create Direction.South (-1, -1)

# Changes north to east
    let robot = create Direction.North (0, 0)
    let expected = create Direction.East (0, 0)
⍤⤙≍ expected move "R" robot

# Changes east to south
    let robot = create Direction.East (0, 0)
    let expected = create Direction.South (0, 0)
⍤⤙≍ expected move "R" robot

# Changes south to west
    let robot = create Direction.South (0, 0)
    let expected = create Direction.West (0, 0)
⍤⤙≍ expected move "R" robot

# Changes west to north
    let robot = create Direction.West (0, 0)
    let expected = create Direction.North (0, 0)
⍤⤙≍ expected move "R" robot

# Changes north to west
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (0, 0)
⍤⤙≍ expected move "L" robot

# Changes west to south
    let robot = create Direction.West (0, 0)
    let expected = create Direction.South (0, 0)
⍤⤙≍ expected move "L" robot

# Changes south to east
    let robot = create Direction.South (0, 0)
    let expected = create Direction.East (0, 0)
⍤⤙≍ expected move "L" robot

# Changes east to north
    let robot = create Direction.East (0, 0)
    let expected = create Direction.North (0, 0)
⍤⤙≍ expected move "L" robot

# Facing north increments Y
    let robot = create Direction.North (0, 0)
    let expected = create Direction.North (0, 1)
⍤⤙≍ expected move "A" robot

# Facing south decrements Y
    let robot = create Direction.South (0, 0)
    let expected = create Direction.South (0, -1)
⍤⤙≍ expected move "A" robot

# Facing east increments X
    let robot = create Direction.East (0, 0)
    let expected = create Direction.East (1, 0)
⍤⤙≍ expected move "A" robot

# Facing west decrements X
    let robot = create Direction.West (0, 0)
    let expected = create Direction.West (-1, 0)
⍤⤙≍ expected move "A" robot

# Moving east and north from README
    let robot = create Direction.North (7, 3)
    let expected = create Direction.West (9, 4)
⍤⤙≍ expected move "RAALAL" robot

# Moving west and north
    let robot = create Direction.North (0, 0)
    let expected = create Direction.West (-4, 1)
⍤⤙≍ expected move "LAAARALA" robot

# Moving west and south
    let robot = create Direction.East (2, -7)
    let expected = create Direction.South (-3, -8)
⍤⤙≍ expected move "RRAAAAALA" robot

# Moving east and north
    let robot = create Direction.South (8, 4)
    let expected = create Direction.North (11, 5)
⍤⤙≍ expected move "LAAARRRALLLL" robot

