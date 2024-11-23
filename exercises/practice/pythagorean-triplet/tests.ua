~ "pythagorean-triplet.ua" ~ PythagoreanTriplet

# Triplets whose sum is 12
⍤⤙≍ [(3, 4, 5)] tripletsWithSum 12

# Triplets whose sum is 108
⍤⤙≍ [(27, 36, 45)] tripletsWithSum 108

# Triplets whose sum is 1000
⍤⤙≍ [(200, 375, 425)] tripletsWithSum 1000

# No matching triplets for 1001
⍤⤙≍ [] tripletsWithSum 1001

# Returns all matching triplets
⍤⤙≍ [(9, 40, 41) (15, 36, 39)] tripletsWithSum 90

# Several matching triplets
⍤⤙≍ [(40, 399, 401) (56, 390, 394) (105, 360, 375) (120, 350, 370) (140, 336, 364) (168, 315, 357) (210, 280, 350) (240, 252, 348)] tripletsWithSum 840

# Triplets for large number
⍤⤙≍ [(1200, 14375, 14425) (1875, 14000, 14125) (5000, 12000, 13000) (6000, 11250, 12750) (7500, 10000, 12500)] tripletsWithSum 30000

