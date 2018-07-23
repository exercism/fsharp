// This file was auto-generated based on version 1.3.0 of the canonical data.

module ComplexNumbersTest

open FsUnit.Xunit
open Xunit
open System

open ComplexNumbers

[<Fact>]
let ``Imaginary unit`` () =
    let sut = mul (create 0.0 1.0) (create 0.0 1.0)
    real sut |> should (equalWithin 0.01) -1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Real part of a purely real number`` () =
    real (create 1.0 0.0) |> should equal 1.0

[<Fact(Skip = "Remove to run test")>]
let ``Real part of a purely imaginary number`` () =
    real (create 0.0 1.0) |> should equal 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Real part of a number with real and imaginary part`` () =
    real (create 1.0 2.0) |> should equal 1.0

[<Fact(Skip = "Remove to run test")>]
let ``Imaginary part of a purely real number`` () =
    imaginary (create 1.0 0.0) |> should equal 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Imaginary part of a purely imaginary number`` () =
    imaginary (create 0.0 1.0) |> should equal 1.0

[<Fact(Skip = "Remove to run test")>]
let ``Imaginary part of a number with real and imaginary part`` () =
    imaginary (create 1.0 2.0) |> should equal 2.0

[<Fact(Skip = "Remove to run test")>]
let ``Add purely real numbers`` () =
    let sut = add (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) 3.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Add purely imaginary numbers`` () =
    let sut = add (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) 0.0
    imaginary sut |> should (equalWithin 0.01) 3.0

[<Fact(Skip = "Remove to run test")>]
let ``Add numbers with real and imaginary part`` () =
    let sut = add (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) 4.0
    imaginary sut |> should (equalWithin 0.01) 6.0

[<Fact(Skip = "Remove to run test")>]
let ``Subtract purely real numbers`` () =
    let sut = sub (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) -1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Subtract purely imaginary numbers`` () =
    let sut = sub (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) 0.0
    imaginary sut |> should (equalWithin 0.01) -1.0

[<Fact(Skip = "Remove to run test")>]
let ``Subtract numbers with real and imaginary part`` () =
    let sut = sub (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) -2.0
    imaginary sut |> should (equalWithin 0.01) -2.0

[<Fact(Skip = "Remove to run test")>]
let ``Multiply purely real numbers`` () =
    let sut = mul (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) 2.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Multiply purely imaginary numbers`` () =
    let sut = mul (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) -2.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Multiply numbers with real and imaginary part`` () =
    let sut = mul (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) -5.0
    imaginary sut |> should (equalWithin 0.01) 10.0

[<Fact(Skip = "Remove to run test")>]
let ``Divide purely real numbers`` () =
    let sut = div (create 1.0 0.0) (create 2.0 0.0)
    real sut |> should (equalWithin 0.01) 0.5
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Divide purely imaginary numbers`` () =
    let sut = div (create 0.0 1.0) (create 0.0 2.0)
    real sut |> should (equalWithin 0.01) 0.5
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Divide numbers with real and imaginary part`` () =
    let sut = div (create 1.0 2.0) (create 3.0 4.0)
    real sut |> should (equalWithin 0.01) 0.44
    imaginary sut |> should (equalWithin 0.01) 0.08

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a positive purely real number`` () =
    abs (create 5.0 0.0) |> should equal 5.0

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a negative purely real number`` () =
    abs (create -5.0 0.0) |> should equal 5.0

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a purely imaginary number with positive imaginary part`` () =
    abs (create 0.0 5.0) |> should equal 5.0

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a purely imaginary number with negative imaginary part`` () =
    abs (create 0.0 -5.0) |> should equal 5.0

[<Fact(Skip = "Remove to run test")>]
let ``Absolute value of a number with real and imaginary part`` () =
    abs (create 3.0 4.0) |> should equal 5.0

[<Fact(Skip = "Remove to run test")>]
let ``Conjugate a purely real number`` () =
    let sut = conjugate (create 5.0 0.0)
    real sut |> should (equalWithin 0.01) 5.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Conjugate a purely imaginary number`` () =
    let sut = conjugate (create 0.0 5.0)
    real sut |> should (equalWithin 0.01) 0.0
    imaginary sut |> should (equalWithin 0.01) -5.0

[<Fact(Skip = "Remove to run test")>]
let ``Conjugate a number with real and imaginary part`` () =
    let sut = conjugate (create 1.0 1.0)
    real sut |> should (equalWithin 0.01) 1.0
    imaginary sut |> should (equalWithin 0.01) -1.0

[<Fact(Skip = "Remove to run test")>]
let ``Euler's identity/formula`` () =
    let sut = exp (create 0.0 Math.PI)
    real sut |> should (equalWithin 0.01) -1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Exponential of 0`` () =
    let sut = exp (create 0.0 0.0)
    real sut |> should (equalWithin 0.01) 1.0
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Exponential of a purely real number`` () =
    let sut = exp (create 1.0 0.0)
    real sut |> should (equalWithin 0.01) Math.E
    imaginary sut |> should (equalWithin 0.01) 0.0

[<Fact(Skip = "Remove to run test")>]
let ``Exponential of a number with real and imaginary part`` () =
    let sut = exp (create (Math.Log(2.0)) Math.PI)
    real sut |> should (equalWithin 0.01) -2.0
    imaginary sut |> should (equalWithin 0.01) 0.0

