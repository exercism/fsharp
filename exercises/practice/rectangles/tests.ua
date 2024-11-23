~ "rectangles.ua" ~ Rectangles

# No rows
    let strings = []
⍤⤙≍ 0 rectangles strings

# No columns
    let strings = [""]
⍤⤙≍ 0 rectangles strings

# No rectangles
    let strings = [" "]
⍤⤙≍ 0 rectangles strings

# One rectangle
    let strings = 
        [ "+-+";
          "| |";
          "+-+" ]
⍤⤙≍ 1 rectangles strings

# Two rectangles without shared parts
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
⍤⤙≍ 2 rectangles strings

# Five rectangles with shared parts
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
⍤⤙≍ 5 rectangles strings

# Rectangle of height 1 is counted
    let strings = 
        [ "+--+";
          "+--+" ]
⍤⤙≍ 1 rectangles strings

# Rectangle of width 1 is counted
    let strings = 
        [ "++";
          "||";
          "++" ]
⍤⤙≍ 1 rectangles strings

# 1x1 square is counted
    let strings = 
        [ "++";
          "++" ]
⍤⤙≍ 1 rectangles strings

# Only complete rectangles are counted
    let strings = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
⍤⤙≍ 1 rectangles strings

# Rectangles can be of different sizes
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
⍤⤙≍ 3 rectangles strings

# Corner is required for a rectangle to be complete
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
⍤⤙≍ 2 rectangles strings

# Large input with many rectangles
    let strings = 
        [ "+---+--+----+";
          "|   +--+----+";
          "+---+--+    |";
          "|   +--+----+";
          "+---+--+--+-+";
          "+---+--+--+-+";
          "+------+  | |";
          "          +-+" ]
⍤⤙≍ 60 rectangles strings

# Rectangles must have four sides
    let strings = 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
⍤⤙≍ 5 rectangles strings

