source("./rational-numbers.R")
library(testthat)

let ``Add two positive rational numbers`` () =
    add (create 1 2) (create 2 3) |> should equal (create 7 6)

let ``Add a positive rational number and a negative rational number`` () =
    add (create 1 2) (create -2 3) |> should equal (create -1 6)

let ``Add two negative rational numbers`` () =
    add (create -1 2) (create -2 3) |> should equal (create -7 6)

let ``Add a rational number to its additive inverse`` () =
    add (create 1 2) (create -1 2) |> should equal (create 0 1)

let ``Subtract two positive rational numbers`` () =
    sub (create 1 2) (create 2 3) |> should equal (create -1 6)

let ``Subtract a positive rational number and a negative rational number`` () =
    sub (create 1 2) (create -2 3) |> should equal (create 7 6)

let ``Subtract two negative rational numbers`` () =
    sub (create -1 2) (create -2 3) |> should equal (create 1 6)

let ``Subtract a rational number from itself`` () =
    sub (create 1 2) (create 1 2) |> should equal (create 0 1)

let ``Multiply two positive rational numbers`` () =
    mul (create 1 2) (create 2 3) |> should equal (create 1 3)

let ``Multiply a negative rational number by a positive rational number`` () =
    mul (create -1 2) (create 2 3) |> should equal (create -1 3)

let ``Multiply two negative rational numbers`` () =
    mul (create -1 2) (create -2 3) |> should equal (create 1 3)

let ``Multiply a rational number by its reciprocal`` () =
    mul (create 1 2) (create 2 1) |> should equal (create 1 1)

let ``Multiply a rational number by 1`` () =
    mul (create 1 2) (create 1 1) |> should equal (create 1 2)

let ``Multiply a rational number by 0`` () =
    mul (create 1 2) (create 0 1) |> should equal (create 0 1)

let ``Divide two positive rational numbers`` () =
    div (create 1 2) (create 2 3) |> should equal (create 3 4)

let ``Divide a positive rational number by a negative rational number`` () =
    div (create 1 2) (create -2 3) |> should equal (create -3 4)

let ``Divide two negative rational numbers`` () =
    div (create -1 2) (create -2 3) |> should equal (create 3 4)

let ``Divide a rational number by 1`` () =
    div (create 1 2) (create 1 1) |> should equal (create 1 2)

let ``Absolute value of a positive rational number`` () =
    abs (create 1 2) |> should equal (create 1 2)

let ``Absolute value of a positive rational number with negative numerator and denominator`` () =
    abs (create -1 -2) |> should equal (create 1 2)

let ``Absolute value of a negative rational number`` () =
    abs (create -1 2) |> should equal (create 1 2)

let ``Absolute value of a negative rational number with negative denominator`` () =
    abs (create 1 -2) |> should equal (create 1 2)

let ``Absolute value of zero`` () =
    abs (create 0 1) |> should equal (create 0 1)

let ``Absolute value of a rational number is reduced to lowest terms`` () =
    abs (create 2 4) |> should equal (create 1 2)

let ``Raise a positive rational number to a positive integer power`` () =
    exprational 3 (create 1 2) |> should equal (create 1 8)

let ``Raise a negative rational number to a positive integer power`` () =
    exprational 3 (create -1 2) |> should equal (create -1 8)

let ``Raise a positive rational number to a negative integer power`` () =
    exprational -2 (create 3 5) |> should equal (create 25 9)

let ``Raise a negative rational number to an even negative integer power`` () =
    exprational -2 (create -3 5) |> should equal (create 25 9)

let ``Raise a negative rational number to an odd negative integer power`` () =
    exprational -3 (create -3 5) |> should equal (create -125 27)

let ``Raise zero to an integer power`` () =
    exprational 5 (create 0 1) |> should equal (create 0 1)

let ``Raise one to an integer power`` () =
    exprational 4 (create 1 1) |> should equal (create 1 1)

let ``Raise a positive rational number to the power of zero`` () =
    exprational 0 (create 1 2) |> should equal (create 1 1)

let ``Raise a negative rational number to the power of zero`` () =
    exprational 0 (create -1 2) |> should equal (create 1 1)

let ``Raise a real number to a positive rational number`` () =
    expreal (create 4 3) 8 |> should (equalWithin 0.01) 16

let ``Raise a real number to a negative rational number`` () =
    expreal (create -1 2) 9 |> should (equalWithin 0.01) 0.3333333333333333

let ``Raise a real number to a zero rational number`` () =
    expreal (create 0 1) 2 |> should (equalWithin 0.01) 1

let ``Reduce a positive rational number to lowest terms`` () =
    reduce (create 2 4) |> should equal (create 1 2)

let ``Reduce places the minus sign on the numerator`` () =
    reduce (create 3 -4) |> should equal (create -3 4)

let ``Reduce a negative rational number to lowest terms`` () =
    reduce (create -4 6) |> should equal (create -2 3)

let ``Reduce a rational number with a negative denominator to lowest terms`` () =
    reduce (create 3 -9) |> should equal (create -1 3)

let ``Reduce zero to lowest terms`` () =
    reduce (create 0 6) |> should equal (create 0 1)

let ``Reduce an integer to lowest terms`` () =
    reduce (create -14 7) |> should equal (create -2 1)

let ``Reduce one to lowest terms`` () =
    reduce (create 13 13) |> should equal (create 1 1)

