// This file was auto-generated based on version 1.0.0 of the canonical data.

module RationalNumbersTest

open FsUnit.Xunit
open Xunit

open RationalNumbers

[<Fact>]
let ``Add two positive rational numbers`` () =
    add (create 1 2) (create 2 3) |> should equal (create 7 6)

[<Fact(Skip = "Remove to run test")>]
let ``Add a positive rational number and a negative rational number`` () =
    add (create 1 2) (create -2 3) |> should equal (create -1 6)

[<Fact(Skip = "Remove to run test")>]
let ``Add two negative rational numbers`` () =
    add (create -1 2) (create -2 3) |> should equal (create -7 6)

[<Fact(Skip = "Remove to run test")>]
let ``Add a rational number to its additive inverse`` () =
    add (create 1 2) (create -1 2) |> should equal (create 0 1)

[<Fact(Skip = "Remove to run test")>]
let ``Subtract two positive rational numbers`` () =
    sub (create 1 2) (create 2 3) |> should equal (create -1 6)

[<Fact(Skip = "Remove to run test")>]
let ``Subtract a positive rational number and a negative rational number`` () =
    sub (create 1 2) (create -2 3) |> should equal (create 7 6)

[<Fact(Skip = "Remove to run test")>]
let ``Subtract two negative rational numbers`` () =
    sub (create -1 2) (create -2 3) |> should equal (create 1 6)

[<Fact(Skip = "Remove to run test")>]
let ``Subtract a rational number from itself`` () =
    sub (create 1 2) (create 1 2) |> should equal (create 0 1)

[<Fact(Skip = "Remove to run test")>]
let ``Multiply two positive rational numbers`` () =
    mul (create 1 2) (create 2 3) |> should equal (create 1 3)

[<Fact(Skip = "Remove to run test")>]
let ``Multiply a negative rational number by a positive rational number`` () =
    mul (create -1 2) (create 2 3) |> should equal (create -1 3)

[<Fact(Skip = "Remove to run test")>]
let ``Multiply two negative rational numbers`` () =
    mul (create -1 2) (create -2 3) |> should equal (create 1 3)

[<Fact(Skip = "Remove to run test")>]
let ``Multiply a rational number by its reciprocal`` () =
    mul (create 1 2) (create 2 1) |> should equal (create 1 1)

[<Fact(Skip = "Remove to run test")>]
let ``Multiply a rational number by 1`` () =
    mul (create 1 2) (create 1 1) |> should equal (create 1 2)

[<Fact(Skip = "Remove to run test")>]
let ``Multiply a rational number by 0`` () =
    mul (create 1 2) (create 0 1) |> should equal (create 0 1)

[<Fact(Skip = "Remove to run test")>]
let ``Divide two positive rational numbers`` () =
    div (create 1 2) (create 2 3) |> should equal (create 3 4)

[<Fact(Skip = "Remove to run test")>]
let ``Divide a positive rational number by a negative rational number`` () =
    div (create 1 2) (create -2 3) |> should equal (create -3 4)

[<Fact(Skip = "Remove to run test")>]
let ``Divide two negative rational numbers`` () =
    div (create -1 2) (create -2 3) |> should equal (create 3 4)

[<Fact(Skip = "Remove to run test")>]
let ``Divide a rational number by 1`` () =
    div (create 1 2) (create 1 1) |> should equal (create 1 2)

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a positive rational number`` () =
    abs (create 1 2) |> should equal (create 1 2)

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a negative rational number`` () =
    abs (create -1 2) |> should equal (create 1 2)

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of zero`` () =
    abs (create 0 1) |> should equal (create 0 1)

[<Fact(Skip = "Remove to run test")>]
let ``Raise a positive rational number to a positive integer power`` () =
    exprational 3 (create 1 2) |> should equal (create 1 8)

[<Fact(Skip = "Remove to run test")>]
let ``Raise a negative rational number to a positive integer power`` () =
    exprational 3 (create -1 2) |> should equal (create -1 8)

[<Fact(Skip = "Remove to run test")>]
let ``Raise zero to an integer power`` () =
    exprational 5 (create 0 1) |> should equal (create 0 1)

[<Fact(Skip = "Remove to run test")>]
let ``Raise one to an integer power`` () =
    exprational 4 (create 1 1) |> should equal (create 1 1)

[<Fact(Skip = "Remove to run test")>]
let ``Raise a positive rational number to the power of zero`` () =
    exprational 0 (create 1 2) |> should equal (create 1 1)

[<Fact(Skip = "Remove to run test")>]
let ``Raise a negative rational number to the power of zero`` () =
    exprational 0 (create -1 2) |> should equal (create 1 1)

[<Fact(Skip = "Remove to run test")>]
let ``Raise a real number to a positive rational number`` () =
    expreal (create 4 3) 8 |> should (equalWithin 0.000000001) 16

[<Fact(Skip = "Remove to run test")>]
let ``Raise a real number to a negative rational number`` () =
    expreal (create -1 2) 9 |> should (equalWithin 0.000000001) 0.333333333333333

[<Fact(Skip = "Remove to run test")>]
let ``Raise a real number to a zero rational number`` () =
    expreal (create 0 1) 2 |> should (equalWithin 0.000000001) 1

[<Fact(Skip = "Remove to run test")>]
let ``Reduce a positive rational number to lowest terms`` () =
    reduce (create 2 4) |> should equal (create 1 2)

[<Fact(Skip = "Remove to run test")>]
let ``Reduce a negative rational number to lowest terms`` () =
    reduce (create -4 6) |> should equal (create -2 3)

[<Fact(Skip = "Remove to run test")>]
let ``Reduce a rational number with a negative denominator to lowest terms`` () =
    reduce (create 3 -9) |> should equal (create -1 3)

[<Fact(Skip = "Remove to run test")>]
let ``Reduce zero to lowest terms`` () =
    reduce (create 0 6) |> should equal (create 0 1)

[<Fact(Skip = "Remove to run test")>]
let ``Reduce an integer to lowest terms`` () =
    reduce (create -14 7) |> should equal (create -2 1)

[<Fact(Skip = "Remove to run test")>]
let ``Reduce one to lowest terms`` () =
    reduce (create 13 13) |> should equal (create 1 1)

