~ "game-of-life.ua" ~ GameOfLife

# Empty matrix
matrix: int[,] = array2D []
expected: int[,] = array2D []
⍤⤙≍ expected tick matrix

# Live cells with zero live neighbors die
matrix = 
        array2D [ [0 0 0]
                  [0 1 0]
                  [0 0 0] ]
expected = 
        array2D [ [0 0 0]
                  [0 0 0]
                  [0 0 0] ]
⍤⤙≍ expected tick matrix

# Live cells with only one live neighbor die
matrix = 
        array2D [ [0 0 0]
                  [0 1 0]
                  [0 1 0] ]
expected = 
        array2D [ [0 0 0]
                  [0 0 0]
                  [0 0 0] ]
⍤⤙≍ expected tick matrix

# Live cells with two live neighbors stay alive
matrix = 
        array2D [ [1 0 1]
                  [1 0 1]
                  [1 0 1] ]
expected = 
        array2D [ [0 0 0]
                  [1 0 1]
                  [0 0 0] ]
⍤⤙≍ expected tick matrix

# Live cells with three live neighbors stay alive
matrix = 
        array2D [ [0 1 0]
                  [1 0 0]
                  [1 1 0] ]
expected = 
        array2D [ [0 0 0]
                  [1 0 0]
                  [1 1 0] ]
⍤⤙≍ expected tick matrix

# Dead cells with three live neighbors become alive
matrix = 
        array2D [ [1 1 0]
                  [0 0 0]
                  [1 0 0] ]
expected = 
        array2D [ [0 0 0]
                  [1 1 0]
                  [0 0 0] ]
⍤⤙≍ expected tick matrix

# Live cells with four or more neighbors die
matrix = 
        array2D [ [1 1 1]
                  [1 1 1]
                  [1 1 1] ]
expected = 
        array2D [ [1 0 1]
                  [0 0 0]
                  [1 0 1] ]
⍤⤙≍ expected tick matrix

# Bigger matrix
matrix = 
        array2D [ [1 1 0 1 1 0 0 0]
                  [1 0 1 1 0 0 0 0]
                  [1 1 1 0 0 1 1 1]
                  [0 0 0 0 0 1 1 0]
                  [1 0 0 0 1 1 0 0]
                  [1 1 0 0 0 1 1 1]
                  [0 0 1 0 1 0 0 1]
                  [1 0 0 0 0 0 1 1] ]
expected = 
        array2D [ [1 1 0 1 1 0 0 0]
                  [0 0 0 0 0 1 1 0]
                  [1 0 1 1 1 1 0 1]
                  [1 0 0 0 0 0 0 1]
                  [1 1 0 0 1 0 0 1]
                  [1 1 0 1 0 0 0 1]
                  [1 0 0 0 0 0 0 0]
                  [0 0 0 0 0 0 1 1] ]
⍤⤙≍ expected tick matrix

