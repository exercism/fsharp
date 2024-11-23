~ "rectangles.ua" ~ Rectangles

# No rows
strings ← []
⍤⤙≍ 0 rectangles strings

# No columns
strings ← [""]
⍤⤙≍ 0 rectangles strings

# No rectangles
strings ← [" "]
⍤⤙≍ 0 rectangles strings

# One rectangle
strings ←
["+-+""| |""+-+"]
⍤⤙≍ 1 rectangles strings

# Two rectangles without shared parts
strings ←
["  +-+""  | |""+-+-+""| |  ""+-+  "]
⍤⤙≍ 2 rectangles strings

# Five rectangles with shared parts
strings ←
["  +-+""  | |""+-+-+""| | |""+-+-+"]
⍤⤙≍ 5 rectangles strings

# Rectangle of height 1 is counted
strings ←
["+--+""+--+"]
⍤⤙≍ 1 rectangles strings

# Rectangle of width 1 is counted
strings ←
["++""||""++"]
⍤⤙≍ 1 rectangles strings

# 1x1 square is counted
strings ←
["++""++"]
⍤⤙≍ 1 rectangles strings

# Only complete rectangles are counted
strings ←
["  +-+""    |""+-+-+""| | -""+-+-+"]
⍤⤙≍ 1 rectangles strings

# Rectangles can be of different sizes
strings ←
["+------+----+""|      |    |""+---+--+    |""|   |       |""+---+-------+"]
⍤⤙≍ 3 rectangles strings

# Corner is required for a rectangle to be complete
strings ←
["+------+----+""|      |    |""+------+    |""|   |       |""+---+-------+"]
⍤⤙≍ 2 rectangles strings

# Large input with many rectangles
strings ←
["+---+--+----+""|   +--+----+""+---+--+    |""|   +--+----+""+---+--+--+-+""+---+--+--+-+""+------+  | |""          +-+"]
⍤⤙≍ 60 rectangles strings

# Rectangles must have four sides
strings ←
["+-+ +-+""| | | |""+-+-+-+""  | |  ""+-+-+-+""| | | |""+-+ +-+"]
⍤⤙≍ 5 rectangles strings
