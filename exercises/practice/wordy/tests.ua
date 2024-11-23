~ "wordy.ua" ~ Wordy

# Just a number
    answer "What is 5?" |> should equal (Some 5)

# Addition
    answer "What is 1 plus 1?" |> should equal (Some 2)

# More addition
    answer "What is 53 plus 2?" |> should equal (Some 55)

# Addition with negative numbers
    answer "What is -1 plus -10?" |> should equal (Some -11)

# Large addition
    answer "What is 123 plus 45678?" |> should equal (Some 45801)

# Subtraction
    answer "What is 4 minus -12?" |> should equal (Some 16)

# Multiplication
    answer "What is -3 multiplied by 25?" |> should equal (Some -75)

# Division
    answer "What is 33 divided by -3?" |> should equal (Some -11)

# Multiple additions
    answer "What is 1 plus 1 plus 1?" |> should equal (Some 3)

# Addition and subtraction
    answer "What is 1 plus 5 minus -2?" |> should equal (Some 8)

# Multiple subtraction
    answer "What is 20 minus 4 minus 13?" |> should equal (Some 3)

# Subtraction then addition
    answer "What is 17 minus 6 plus 3?" |> should equal (Some 14)

# Multiple multiplication
    answer "What is 2 multiplied by -2 multiplied by 3?" |> should equal (Some -12)

# Addition and multiplication
    answer "What is -3 plus 7 multiplied by -2?" |> should equal (Some -8)

# Multiple division
    answer "What is -12 divided by 2 divided by -3?" |> should equal (Some 2)

# Unknown operation
    answer "What is 52 cubed?" |> should equal None

# Non math question
    answer "Who is the President of the United States?" |> should equal None

# Reject problem missing an operand
    answer "What is 1 plus?" |> should equal None

# Reject problem with no operands or operators
    answer "What is?" |> should equal None

# Reject two operations in a row
    answer "What is 1 plus plus 2?" |> should equal None

# Reject two numbers in a row
    answer "What is 1 plus 2 1?" |> should equal None

# Reject postfix notation
    answer "What is 1 2 plus?" |> should equal None

# Reject prefix notation
    answer "What is plus 1 2?" |> should equal None

