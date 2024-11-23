~ "grains.ua" ~ Grains

# Grains on square 1
expected: Result<uint64,string> = Ok 1
⍤⤙≍ expected square 1

# Grains on square 2
expected: Result<uint64,string> = Ok 2
⍤⤙≍ expected square 2

# Grains on square 3
expected: Result<uint64,string> = Ok 4
⍤⤙≍ expected square 3

# Grains on square 4
expected: Result<uint64,string> = Ok 8
⍤⤙≍ expected square 4

# Grains on square 16
expected: Result<uint64,string> = Ok 32768
⍤⤙≍ expected square 16

# Grains on square 32
expected: Result<uint64,string> = Ok 2147483648
⍤⤙≍ expected square 32

# Grains on square 64
expected: Result<uint64,string> = Ok 9223372036854775808
⍤⤙≍ expected square 64

# Square 0 is invalid
expected: Result<uint64,string> = Error "square must be between 1 and 64"
⍤⤙≍ expected square 0

# Negative square is invalid
expected: Result<uint64,string> = Error "square must be between 1 and 64"
⍤⤙≍ expected square -1

# Square greater than 64 is invalid
expected: Result<uint64,string> = Error "square must be between 1 and 64"
⍤⤙≍ expected square 65

# Returns the total number of grains on the board
expected: Result<uint64,string> = Ok 18446744073709551615
⍤⤙≍ expected total

