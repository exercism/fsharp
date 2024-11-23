~ "rectangles.ua" ~ Rectangles

# No rows
    let strings = []
    rectangles strings |> should equal 0

# No columns
    let strings = [""]
    rectangles strings |> should equal 0

# No rectangles
    let strings = [" "]
    rectangles strings |> should equal 0

# One rectangle
    let strings = 
        [ "+-+";
          "| |";
          "+-+" ]
    rectangles strings |> should equal 1

# Two rectangles without shared parts
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| |  ";
          "+-+  " ]
    rectangles strings |> should equal 2

# Five rectangles with shared parts
    let strings = 
        [ "  +-+";
          "  | |";
          "+-+-+";
          "| | |";
          "+-+-+" ]
    rectangles strings |> should equal 5

# Rectangle of height 1 is counted
    let strings = 
        [ "+--+";
          "+--+" ]
    rectangles strings |> should equal 1

# Rectangle of width 1 is counted
    let strings = 
        [ "++";
          "||";
          "++" ]
    rectangles strings |> should equal 1

# 1x1 square is counted
    let strings = 
        [ "++";
          "++" ]
    rectangles strings |> should equal 1

# Only complete rectangles are counted
    let strings = 
        [ "  +-+";
          "    |";
          "+-+-+";
          "| | -";
          "+-+-+" ]
    rectangles strings |> should equal 1

# Rectangles can be of different sizes
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+---+--+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 3

# Corner is required for a rectangle to be complete
    let strings = 
        [ "+------+----+";
          "|      |    |";
          "+------+    |";
          "|   |       |";
          "+---+-------+" ]
    rectangles strings |> should equal 2

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
    rectangles strings |> should equal 60

# Rectangles must have four sides
    let strings = 
        [ "+-+ +-+";
          "| | | |";
          "+-+-+-+";
          "  | |  ";
          "+-+-+-+";
          "| | | |";
          "+-+ +-+" ]
    rectangles strings |> should equal 5

