~ "pascals-triangle.ua" ~ PascalsTriangle

# Zero rows
expected: int list list = []
⍤⤙≍ expected rows 0

# Single row
expected = [[1]]
⍤⤙≍ expected rows 1

# Two rows
expected = 
        [ [1]
          [1 1] ]
⍤⤙≍ expected rows 2

# Three rows
expected = 
        [ [1]
          [1 1]
          [1 2 1] ]
⍤⤙≍ expected rows 3

# Four rows
expected = 
        [ [1]
          [1 1]
          [1 2 1]
          [1 3 3 1] ]
⍤⤙≍ expected rows 4

# Five rows
expected = 
        [ [1]
          [1 1]
          [1 2 1]
          [1 3 3 1]
          [1 4 6 4 1] ]
⍤⤙≍ expected rows 5

# Six rows
expected = 
        [ [1]
          [1 1]
          [1 2 1]
          [1 3 3 1]
          [1 4 6 4 1]
          [1 5 10 10 5 1] ]
⍤⤙≍ expected rows 6

# Ten rows
expected = 
        [ [1]
          [1 1]
          [1 2 1]
          [1 3 3 1]
          [1 4 6 4 1]
          [1 5 10 10 5 1]
          [1 6 15 20 15 6 1]
          [1 7 21 35 35 21 7 1]
          [1 8 28 56 70 56 28 8 1]
          [1 9 36 84 126 126 84 36 9 1] ]
⍤⤙≍ expected rows 10

