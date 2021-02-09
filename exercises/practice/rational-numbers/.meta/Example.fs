module RationalNumbers

open System

type RationalNumber = { numerator: int; denominator: int }

let rec private gcd x y =
    if y = 0 then x
    else gcd y (x % y)

let private nthroot n a =
    let rec f x =
        let m = n - 1.
        let x' = (m * x + a / x ** m) / n
        match abs(x' - x) with
        | t when t < abs(x * 1e-9) -> x'
        | _ -> f x'
    f (a / float n)

let create numerator denominator = { numerator = numerator; denominator = denominator }

let reduce r = 
  let divisor = gcd (abs r.numerator) (abs r.denominator)

  if r.denominator >= 0 then
    create (r.numerator / divisor) (r.denominator / divisor)
  else
    create (r.numerator * -1 / divisor) (r.denominator * -1 / divisor)

let add r1 r2 = create (r1.numerator * r2.denominator + r2.numerator * r1.denominator) (r1.denominator * r2.denominator) |> reduce

let sub r1 r2 = create (r1.numerator * r2.denominator - r2.numerator * r1.denominator) (r1.denominator * r2.denominator) |> reduce

let mul r1 r2 = create (r1.numerator * r2.numerator) (r1.denominator * r2.denominator) |> reduce

let div r1 r2 = create (r1.numerator * r2.denominator) (r2.numerator * r1.denominator) |> reduce

let abs r = create (Math.Abs(r.numerator)) (Math.Abs(r.denominator))

let exprational n r = 
  if n >= 0 then
    create (float r.numerator ** float n |> int) (float r.denominator ** float n |> int) |> reduce
  else
    create (float r.denominator ** Math.Abs(float n) |> int) (float r.numerator ** Math.Abs(float n) |> int) |> reduce

let expreal r n = nthroot (float r.denominator) (float n ** (float r.numerator))