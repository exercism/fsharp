module ComplexNumbers

open System

type ComplexNumber = { real: float; imaginary: float }

let create real imaginary = { real = real; imaginary = imaginary }

let mul z1 z2 = { real = z1.real * z2.real - z1.imaginary * z2.imaginary; imaginary = z1.imaginary * z2.real + z1.real * z2.imaginary }

let add z1 z2 = { real = z1.real + z2.real; imaginary = z1.imaginary + z2.imaginary }

let sub z1 z2 = { real = z1.real - z2.real; imaginary = z1.imaginary - z2.imaginary }

let div z1 z2 = 
    { real = (z1.real * z2.real + z1.imaginary * z2.imaginary) / (Math.Pow(z2.real, 2.0) + Math.Pow(z2.imaginary, 2.0))
      imaginary = (z1.imaginary * z2.real - z1.real * z2.imaginary) / (Math.Pow(z2.real, 2.0) + Math.Pow(z2.imaginary, 2.0)) }

let abs z = Math.Sqrt(Math.Pow(z.real, 2.0) + Math.Pow(z.imaginary, 2.0))

let conjugate z = { z with imaginary = -z.imaginary }

let real z = z.real

let imaginary z = z.imaginary

let exp z = { real = Math.Cos(z.imaginary) * Math.Exp(z.real); imaginary = Math.Sin(z.imaginary) * Math.Exp(z.real) }