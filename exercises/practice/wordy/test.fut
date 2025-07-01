import "wordy"

-- Just a number
-- ==
-- input { "What is 5?" }
-- output { 5 }

-- Addition
-- ==
-- input { "What is 1 plus 1?" }
-- output { 2 }

-- More addition
-- ==
-- input { "What is 53 plus 2?" }
-- output { 55 }

-- Addition with negative numbers
-- ==
-- input { "What is -1 plus -10?" }
-- output { -11 }

-- Large addition
-- ==
-- input { "What is 123 plus 45678?" }
-- output { 45801 }

-- Subtraction
-- ==
-- input { "What is 4 minus -12?" }
-- output { 16 }

-- Multiplication
-- ==
-- input { "What is -3 multiplied by 25?" }
-- output { -75 }

-- Division
-- ==
-- input { "What is 33 divided by -3?" }
-- output { -11 }

-- Multiple additions
-- ==
-- input { "What is 1 plus 1 plus 1?" }
-- output { 3 }

-- Addition and subtraction
-- ==
-- input { "What is 1 plus 5 minus -2?" }
-- output { 8 }

-- Multiple subtraction
-- ==
-- input { "What is 20 minus 4 minus 13?" }
-- output { 3 }

-- Subtraction then addition
-- ==
-- input { "What is 17 minus 6 plus 3?" }
-- output { 14 }

-- Multiple multiplication
-- ==
-- input { "What is 2 multiplied by -2 multiplied by 3?" }
-- output { -12 }

-- Addition and multiplication
-- ==
-- input { "What is -3 plus 7 multiplied by -2?" }
-- output { -8 }

-- Multiple division
-- ==
-- input { "What is -12 divided by 2 divided by -3?" }
-- output { 2 }

-- Unknown operation
-- ==
-- input { "What is 52 cubed?" }
-- error: Error*

-- Non math question
-- ==
-- input { "Who is the President of the United States?" }
-- error: Error*

-- Reject problem missing an operand
-- ==
-- input { "What is 1 plus?" }
-- error: Error*

-- Reject problem with no operands or operators
-- ==
-- input { "What is?" }
-- error: Error*

-- Reject two operations in a row
-- ==
-- input { "What is 1 plus plus 2?" }
-- error: Error*

-- Reject two numbers in a row
-- ==
-- input { "What is 1 plus 2 1?" }
-- error: Error*

-- Reject postfix notation
-- ==
-- input { "What is 1 2 plus?" }
-- error: Error*

-- Reject prefix notation
-- ==
-- input { "What is plus 1 2?" }
-- error: Error*

