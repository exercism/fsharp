# Difference Of Squares

Find the difference between the square of the sum and the sum of the squares of the first N natural numbers.

The square of the sum of the first ten natural numbers is
(1 + 2 + ... + 10)² = 55² = 3025.

The sum of the squares of the first ten natural numbers is
1² + 2² + ... + 10² = 385.

Hence the difference between the square of the sum of the first
ten natural numbers and the sum of the squares of the first ten
natural numbers is 3025 - 385 = 2640.

## Hints
For this exercise the following F# features come in handy:
- The [range operator](https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/operators.%5B-..-%5D%5B%5Et%5D-function-%5Bfsharp%5D) allows you to succinctly create a range of values.
- [List.sumBy](https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/list.sumby%5B't,%5Eu%5D-function-%5Bfsharp%5D) is a condensed format to apply a function to a list and then sum the results.

## Source

Problem 6 at Project Euler [http://projecteuler.net/problem=6](http://projecteuler.net/problem=6)

## Submitting Incomplete Solutions
It's possible to submit an incomplete solution so you can see how others have completed the exercise.
