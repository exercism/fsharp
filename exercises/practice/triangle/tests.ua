~ "triangle.ua" ~ Triangle

# Equilateral returns all sides are equal
⍤⤙≍ true equilateral [2.0 2.0 2.0]

# Equilateral returns any side is unequal
⍤⤙≍ false equilateral [2.0 3.0 2.0]

# Equilateral returns no sides are equal
⍤⤙≍ false equilateral [5.0 4.0 6.0]

# Equilateral returns all zero sides is not a triangle
⍤⤙≍ false equilateral [0.0 0.0 0.0]

# Equilateral returns sides may be floats
⍤⤙≍ true equilateral [0.5 0.5 0.5]

# Isosceles returns last two sides are equal
⍤⤙≍ true isosceles [3.0 4.0 4.0]

# Isosceles returns first two sides are equal
⍤⤙≍ true isosceles [4.0 4.0 3.0]

# Isosceles returns first and last sides are equal
⍤⤙≍ true isosceles [4.0 3.0 4.0]

# Equilateral triangles are also isosceles
⍤⤙≍ true isosceles [4.0 4.0 4.0]

# Isosceles returns no sides are equal
⍤⤙≍ false isosceles [2.0 3.0 4.0]

# Isosceles returns first triangle inequality violation
⍤⤙≍ false isosceles [1.0 1.0 3.0]

# Isosceles returns second triangle inequality violation
⍤⤙≍ false isosceles [1.0 3.0 1.0]

# Isosceles returns third triangle inequality violation
⍤⤙≍ false isosceles [3.0 1.0 1.0]

# Isosceles returns sides may be floats
⍤⤙≍ true isosceles [0.5 0.4 0.5]

# Scalene returns no sides are equal
⍤⤙≍ true scalene [5.0 4.0 6.0]

# Scalene returns all sides are equal
⍤⤙≍ false scalene [4.0 4.0 4.0]

# Scalene returns first and second sides are equal
⍤⤙≍ false scalene [4.0 4.0 3.0]

# Scalene returns first and third sides are equal
⍤⤙≍ false scalene [3.0 4.0 3.0]

# Scalene returns second and third sides are equal
⍤⤙≍ false scalene [4.0 3.0 3.0]

# Scalene returns may not violate triangle inequality
⍤⤙≍ false scalene [7.0 3.0 2.0]

# Scalene returns sides may be floats
⍤⤙≍ true scalene [0.5 0.4 0.6]

