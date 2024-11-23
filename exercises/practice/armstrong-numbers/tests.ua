~ "armstrong-numbers.ua" ~ ArmstrongNumbers

# Zero is an Armstrong number
    isArmstrongNumber 0 |> should equal true

# Single-digit numbers are Armstrong numbers
    isArmstrongNumber 5 |> should equal true

# There are no two-digit Armstrong numbers
    isArmstrongNumber 10 |> should equal false

# Three-digit number that is an Armstrong number
    isArmstrongNumber 153 |> should equal true

# Three-digit number that is not an Armstrong number
    isArmstrongNumber 100 |> should equal false

# Four-digit number that is an Armstrong number
    isArmstrongNumber 9474 |> should equal true

# Four-digit number that is not an Armstrong number
    isArmstrongNumber 9475 |> should equal false

# Seven-digit number that is an Armstrong number
    isArmstrongNumber 9926315 |> should equal true

# Seven-digit number that is not an Armstrong number
    isArmstrongNumber 9926314 |> should equal false

