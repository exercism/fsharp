~ "all-your-base.ua" ~ AllYourBase

# Single bit one to decimal
digits = [1]
inputBase = 2
outputBase = 10
expected = Some [1]
⍤⤙≍ expected rebase digits inputBase outputBase

# Binary to single decimal
digits = [1 0 1]
inputBase = 2
outputBase = 10
expected = Some [5]
⍤⤙≍ expected rebase digits inputBase outputBase

# Single decimal to binary
digits = [5]
inputBase = 10
outputBase = 2
expected = Some [1 0 1]
⍤⤙≍ expected rebase digits inputBase outputBase

# Binary to multiple decimal
digits = [1 0 1 0 1 0]
inputBase = 2
outputBase = 10
expected = Some [4 2]
⍤⤙≍ expected rebase digits inputBase outputBase

# Decimal to binary
digits = [4 2]
inputBase = 10
outputBase = 2
expected = Some [1 0 1 0 1 0]
⍤⤙≍ expected rebase digits inputBase outputBase

# Trinary to hexadecimal
digits = [1 1 2 0]
inputBase = 3
outputBase = 16
expected = Some [2 10]
⍤⤙≍ expected rebase digits inputBase outputBase

# Hexadecimal to trinary
digits = [2 10]
inputBase = 16
outputBase = 3
expected = Some [1 1 2 0]
⍤⤙≍ expected rebase digits inputBase outputBase

# 15-bit integer
digits = [3 46 60]
inputBase = 97
outputBase = 73
expected = Some [6 10 45]
⍤⤙≍ expected rebase digits inputBase outputBase

# Empty list
digits = []
inputBase = 2
outputBase = 10
expected = Some [0]
⍤⤙≍ expected rebase digits inputBase outputBase

# Single zero
digits = [0]
inputBase = 10
outputBase = 2
expected = Some [0]
⍤⤙≍ expected rebase digits inputBase outputBase

# Multiple zeros
digits = [0 0 0]
inputBase = 10
outputBase = 2
expected = Some [0]
⍤⤙≍ expected rebase digits inputBase outputBase

# Leading zeros
digits = [0 6 0]
inputBase = 7
outputBase = 10
expected = Some [4 2]
⍤⤙≍ expected rebase digits inputBase outputBase

# Input base is one
digits = [0]
inputBase = 1
outputBase = 10
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Input base is zero
digits = []
inputBase = 0
outputBase = 10
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Input base is negative
digits = [1]
inputBase = -2
outputBase = 10
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Negative digit
digits = [1 -1 1 0 1 0]
inputBase = 2
outputBase = 10
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Invalid positive digit
digits = [1 2 1 0 1 0]
inputBase = 2
outputBase = 10
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Output base is one
digits = [1 0 1 0 1 0]
inputBase = 2
outputBase = 1
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Output base is zero
digits = [7]
inputBase = 10
outputBase = 0
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Output base is negative
digits = [1]
inputBase = 2
outputBase = -7
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

# Both bases are negative
digits = [1]
inputBase = -2
outputBase = -7
⍤⤙≍ "TODO: insert error message" ⍣(rebase digits inputBase outputBase)

