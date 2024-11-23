~ "rational-numbers.ua" ~ RationalNumbers

# Add two positive rational numbers
⍤⤙≍ (create 7 6) add (create 1 2) (create 2 3)

# Add a positive rational number and a negative rational number
⍤⤙≍ (create -1 6) add (create 1 2) (create -2 3)

# Add two negative rational numbers
⍤⤙≍ (create -7 6) add (create -1 2) (create -2 3)

# Add a rational number to its additive inverse
⍤⤙≍ (create 0 1) add (create 1 2) (create -1 2)

# Subtract two positive rational numbers
⍤⤙≍ (create -1 6) sub (create 1 2) (create 2 3)

# Subtract a positive rational number and a negative rational number
⍤⤙≍ (create 7 6) sub (create 1 2) (create -2 3)

# Subtract two negative rational numbers
⍤⤙≍ (create 1 6) sub (create -1 2) (create -2 3)

# Subtract a rational number from itself
⍤⤙≍ (create 0 1) sub (create 1 2) (create 1 2)

# Multiply two positive rational numbers
⍤⤙≍ (create 1 3) mul (create 1 2) (create 2 3)

# Multiply a negative rational number by a positive rational number
⍤⤙≍ (create -1 3) mul (create -1 2) (create 2 3)

# Multiply two negative rational numbers
⍤⤙≍ (create 1 3) mul (create -1 2) (create -2 3)

# Multiply a rational number by its reciprocal
⍤⤙≍ (create 1 1) mul (create 1 2) (create 2 1)

# Multiply a rational number by 1
⍤⤙≍ (create 1 2) mul (create 1 2) (create 1 1)

# Multiply a rational number by 0
⍤⤙≍ (create 0 1) mul (create 1 2) (create 0 1)

# Divide two positive rational numbers
⍤⤙≍ (create 3 4) div (create 1 2) (create 2 3)

# Divide a positive rational number by a negative rational number
⍤⤙≍ (create -3 4) div (create 1 2) (create -2 3)

# Divide two negative rational numbers
⍤⤙≍ (create 3 4) div (create -1 2) (create -2 3)

# Divide a rational number by 1
⍤⤙≍ (create 1 2) div (create 1 2) (create 1 1)

# Absolute value of a positive rational number
⍤⤙≍ (create 1 2) abs (create 1 2)

# Absolute value of a positive rational number with negative numerator and denominator
⍤⤙≍ (create 1 2) abs (create -1 -2)

# Absolute value of a negative rational number
⍤⤙≍ (create 1 2) abs (create -1 2)

# Absolute value of a negative rational number with negative denominator
⍤⤙≍ (create 1 2) abs (create 1 -2)

# Absolute value of zero
⍤⤙≍ (create 0 1) abs (create 0 1)

# Absolute value of a rational number is reduced to lowest terms
⍤⤙≍ (create 1 2) abs (create 2 4)

# Raise a positive rational number to a positive integer power
⍤⤙≍ (create 1 8) exprational 3 (create 1 2)

# Raise a negative rational number to a positive integer power
⍤⤙≍ (create -1 8) exprational 3 (create -1 2)

# Raise a positive rational number to a negative integer power
⍤⤙≍ (create 25 9) exprational -2 (create 3 5)

# Raise a negative rational number to an even negative integer power
⍤⤙≍ (create 25 9) exprational -2 (create -3 5)

# Raise a negative rational number to an odd negative integer power
⍤⤙≍ (create -125 27) exprational -3 (create -3 5)

# Raise zero to an integer power
⍤⤙≍ (create 0 1) exprational 5 (create 0 1)

# Raise one to an integer power
⍤⤙≍ (create 1 1) exprational 4 (create 1 1)

# Raise a positive rational number to the power of zero
⍤⤙≍ (create 1 1) exprational 0 (create 1 2)

# Raise a negative rational number to the power of zero
⍤⤙≍ (create 1 1) exprational 0 (create -1 2)

# Raise a real number to a positive rational number
    expreal (create 4 3) 8 |> should (equalWithin 0.01) 16

# Raise a real number to a negative rational number
    expreal (create -1 2) 9 |> should (equalWithin 0.01) 0.3333333333333333

# Raise a real number to a zero rational number
    expreal (create 0 1) 2 |> should (equalWithin 0.01) 1

# Reduce a positive rational number to lowest terms
⍤⤙≍ (create 1 2) reduce (create 2 4)

# Reduce places the minus sign on the numerator
⍤⤙≍ (create -3 4) reduce (create 3 -4)

# Reduce a negative rational number to lowest terms
⍤⤙≍ (create -2 3) reduce (create -4 6)

# Reduce a rational number with a negative denominator to lowest terms
⍤⤙≍ (create -1 3) reduce (create 3 -9)

# Reduce zero to lowest terms
⍤⤙≍ (create 0 1) reduce (create 0 6)

# Reduce an integer to lowest terms
⍤⤙≍ (create -2 1) reduce (create -14 7)

# Reduce one to lowest terms
⍤⤙≍ (create 1 1) reduce (create 13 13)

