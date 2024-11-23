~ "etl.ua" ~ Etl

# Single letter
lettersByScore ← [1_[’A’]]
| > Map.ofList
expected ← [’a’_1]
| > Map.ofList
⍤⤙≍ expected transform lettersByScore

# Single score with multiple letters
lettersByScore ← [1_[’A’ ’E’ ’I’ ’O’ ’U’]]
| > Map.ofList
expected ←
[’a’_1’e’_1’i’_1’o’_1’u’_1]
| > Map.ofList
⍤⤙≍ expected transform lettersByScore

# Multiple scores with multiple letters
lettersByScore ←
[1_[’A’ ’E’]2_[’D’ ’G’]]
| > Map.ofList
expected ←
[’a’_1’d’_2’e’_1’g’_2]
| > Map.ofList
⍤⤙≍ expected transform lettersByScore

# Multiple scores with differing numbers of letters
lettersByScore ←
[1_[’A’ ’E’ ’I’ ’O’ ’U’ ’L’ ’N’ ’R’ ’S’ ’T’]2_[’D’ ’G’]3_[’B’ ’C’ ’M’ ’P’]4_[’F’ ’H’ ’V’ ’W’ ’Y’]5_[’K’]8_[’J’ ’X’]10_[’Q’ ’Z’]]
| > Map.ofList
expected ←
[’a’_1’b’_3’c’_3’d’_2’e’_1’f’_4’g’_2’h’_4’i’_1’j’_8’k’_5’l’_1’m’_3’n’_1’o’_1’p’_3’q’_10’r’_1’s’_1’t’_1’u’_1’v’_4’w’_4’x’_8’y’_4’z’_10]
| > Map.ofList
⍤⤙≍ expected transform lettersByScore
