source("./wordy.R")
library(testthat)

let ``Just a number`` () =
    expect_equal(answer "What is 5?", (Some 5))

let ``Addition`` () =
    expect_equal(answer "What is 1 plus 1?", (Some 2))

let ``More addition`` () =
    expect_equal(answer "What is 53 plus 2?", (Some 55))

let ``Addition with negative numbers`` () =
    expect_equal(answer "What is -1 plus -10?", (Some -11))

let ``Large addition`` () =
    expect_equal(answer "What is 123 plus 45678?", (Some 45801))

let ``Subtraction`` () =
    expect_equal(answer "What is 4 minus -12?", (Some 16))

let ``Multiplication`` () =
    expect_equal(answer "What is -3 multiplied by 25?", (Some -75))

let ``Division`` () =
    expect_equal(answer "What is 33 divided by -3?", (Some -11))

let ``Multiple additions`` () =
    expect_equal(answer "What is 1 plus 1 plus 1?", (Some 3))

let ``Addition and subtraction`` () =
    expect_equal(answer "What is 1 plus 5 minus -2?", (Some 8))

let ``Multiple subtraction`` () =
    expect_equal(answer "What is 20 minus 4 minus 13?", (Some 3))

let ``Subtraction then addition`` () =
    expect_equal(answer "What is 17 minus 6 plus 3?", (Some 14))

let ``Multiple multiplication`` () =
    expect_equal(answer "What is 2 multiplied by -2 multiplied by 3?", (Some -12))

let ``Addition and multiplication`` () =
    expect_equal(answer "What is -3 plus 7 multiplied by -2?", (Some -8))

let ``Multiple division`` () =
    expect_equal(answer "What is -12 divided by 2 divided by -3?", (Some 2))

let ``Unknown operation`` () =
    expect_equal(answer "What is 52 cubed?", None)

let ``Non math question`` () =
    expect_equal(answer "Who is the President of the United States?", None)

let ``Reject problem missing an operand`` () =
    expect_equal(answer "What is 1 plus?", None)

let ``Reject problem with no operands or operators`` () =
    expect_equal(answer "What is?", None)

let ``Reject two operations in a row`` () =
    expect_equal(answer "What is 1 plus plus 2?", None)

let ``Reject two numbers in a row`` () =
    expect_equal(answer "What is 1 plus 2 1?", None)

let ``Reject postfix notation`` () =
    expect_equal(answer "What is 1 2 plus?", None)

let ``Reject prefix notation`` () =
    expect_equal(answer "What is plus 1 2?", None)

