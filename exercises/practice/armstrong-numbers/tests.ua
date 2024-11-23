~ "armstrong-numbers.ua" ~ ArmstrongNumbers

# Zero is an Armstrong number
⍤⤙≍ true isArmstrongNumber 0

# Single-digit numbers are Armstrong numbers
⍤⤙≍ true isArmstrongNumber 5

# There are no two-digit Armstrong numbers
⍤⤙≍ false isArmstrongNumber 10

# Three-digit number that is an Armstrong number
⍤⤙≍ true isArmstrongNumber 153

# Three-digit number that is not an Armstrong number
⍤⤙≍ false isArmstrongNumber 100

# Four-digit number that is an Armstrong number
⍤⤙≍ true isArmstrongNumber 9474

# Four-digit number that is not an Armstrong number
⍤⤙≍ false isArmstrongNumber 9475

# Seven-digit number that is an Armstrong number
⍤⤙≍ true isArmstrongNumber 9926315

# Seven-digit number that is not an Armstrong number
⍤⤙≍ false isArmstrongNumber 9926314

