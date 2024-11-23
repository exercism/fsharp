~ "robot-simulator.ua" ~ RobotSimulator

# At origin facing north
expected = create Direction.North 0_0
⍤⤙≍ expected create Direction.North 0_0

# At negative position facing south
expected = create Direction.South -1_-1
⍤⤙≍ expected create Direction.South -1_-1

# Changes north to east
robot = create Direction.North 0_0
expected = create Direction.East 0_0
⍤⤙≍ expected move "R" robot

# Changes east to south
robot = create Direction.East 0_0
expected = create Direction.South 0_0
⍤⤙≍ expected move "R" robot

# Changes south to west
robot = create Direction.South 0_0
expected = create Direction.West 0_0
⍤⤙≍ expected move "R" robot

# Changes west to north
robot = create Direction.West 0_0
expected = create Direction.North 0_0
⍤⤙≍ expected move "R" robot

# Changes north to west
robot = create Direction.North 0_0
expected = create Direction.West 0_0
⍤⤙≍ expected move "L" robot

# Changes west to south
robot = create Direction.West 0_0
expected = create Direction.South 0_0
⍤⤙≍ expected move "L" robot

# Changes south to east
robot = create Direction.South 0_0
expected = create Direction.East 0_0
⍤⤙≍ expected move "L" robot

# Changes east to north
robot = create Direction.East 0_0
expected = create Direction.North 0_0
⍤⤙≍ expected move "L" robot

# Facing north increments Y
robot = create Direction.North 0_0
expected = create Direction.North 0_1
⍤⤙≍ expected move "A" robot

# Facing south decrements Y
robot = create Direction.South 0_0
expected = create Direction.South 0_-1
⍤⤙≍ expected move "A" robot

# Facing east increments X
robot = create Direction.East 0_0
expected = create Direction.East 1_0
⍤⤙≍ expected move "A" robot

# Facing west decrements X
robot = create Direction.West 0_0
expected = create Direction.West -1_0
⍤⤙≍ expected move "A" robot

# Moving east and north from README
robot = create Direction.North 7_3
expected = create Direction.West 9_4
⍤⤙≍ expected move "RAALAL" robot

# Moving west and north
robot = create Direction.North 0_0
expected = create Direction.West -4_1
⍤⤙≍ expected move "LAAARALA" robot

# Moving west and south
robot = create Direction.East 2_-7
expected = create Direction.South -3_-8
⍤⤙≍ expected move "RRAAAAALA" robot

# Moving east and north
robot = create Direction.South 8_4
expected = create Direction.North 11_5
⍤⤙≍ expected move "LAAARRRALLLL" robot

