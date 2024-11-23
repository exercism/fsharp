~ "triangle.ua" ~ Triangle

# IsEquilateral returns all sides are equal
⍤⤙≍ 1 IsEquilateral [2 2 2]

# IsEquilateral returns any side is unequal
⍤⤙≍ 0 IsEquilateral [2 3 2]

# IsEquilateral returns no sides are equal
⍤⤙≍ 0 IsEquilateral [5 4 6]

# IsEquilateral returns all zero sides is not a triangle
⍤⤙≍ 0 IsEquilateral [0 0 0]

# IsEquilateral returns sides may be floats
⍤⤙≍ 1 IsEquilateral [0.5 0.5 0.5]

# IsIsosceles returns last two sides are equal
⍤⤙≍ 1 IsIsosceles [3 4 4]

# IsIsosceles returns first two sides are equal
⍤⤙≍ 1 IsIsosceles [4 4 3]

# IsIsosceles returns first and last sides are equal
⍤⤙≍ 1 IsIsosceles [4 3 4]

# IsEquilateral triangles are also isosceles
⍤⤙≍ 1 IsIsosceles [4 4 4]

# IsIsosceles returns no sides are equal
⍤⤙≍ 0 IsIsosceles [2 3 4]

# IsIsosceles returns first triangle inequality violation
⍤⤙≍ 0 IsIsosceles [1 1 3]

# IsIsosceles returns second triangle inequality violation
⍤⤙≍ 0 IsIsosceles [1 3 1]

# IsIsosceles returns third triangle inequality violation
⍤⤙≍ 0 IsIsosceles [3 1 1]

# IsIsosceles returns sides may be floats
⍤⤙≍ 1 IsIsosceles [0.5 0.4 0.5]

# Scalene returns no sides are equal
⍤⤙≍ 1 IsScalene [5 4 6]

# Scalene returns all sides are equal
⍤⤙≍ 0 IsScalene [4 4 4]

# Scalene returns first and second sides are equal
⍤⤙≍ 0 IsScalene [4 4 3]

# Scalene returns first and third sides are equal
⍤⤙≍ 0 IsScalene [3 4 3]

# Scalene returns second and third sides are equal
⍤⤙≍ 0 IsScalene [4 3 3]

# Scalene returns may not violate triangle inequality
⍤⤙≍ 0 IsScalene [7 3 2]

# Scalene returns sides may be floats
⍤⤙≍ 1 IsScalene [0.5 0.4 0.6]
