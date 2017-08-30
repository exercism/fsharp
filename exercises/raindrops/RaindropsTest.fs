module RaindropsTest
    
open Xunit
open FsUnit
open Raindrops

[<Theory(Skip = "Remove to run test")>]
[<InlineData(1, "1")>]
[<InlineData(52, "52")>]
[<InlineData(12121, "12121")>]
let ``Non primes pass through`` number expected =
    convert number |> should equal expected

[<Theory(Skip = "Remove to run test")>]
[<InlineData(3)>]
[<InlineData(6)>]
[<InlineData(9)>]
let ``Numbers containing 3 as a prime factor give pling`` (number) =
    convert number |> should equal "Pling"

[<Theory(Skip = "Remove to run test")>]
[<InlineData(5)>]
[<InlineData(10)>]
[<InlineData(25)>]
let ``Numbers containing 5 as a prime factor give plang`` (number) =
    convert number |> should equal "Plang"

[<Theory(Skip = "Remove to run test")>]
[<InlineData(7)>]
[<InlineData(14)>]
[<InlineData(49)>]
let ``Numbers containing 7 as a prime factor give plong`` (number) =
    convert number |> should equal "Plong"

[<Theory(Skip = "Remove to run test")>]
[<InlineData(15, "PlingPlang")>]
[<InlineData(21, "PlingPlong")>]
[<InlineData(35, "PlangPlong")>]
[<InlineData(105, "PlingPlangPlong")>]    
let ``Numbers containing multiple prime factors give all results concatenated`` number expected =
    convert number |> should equal expected