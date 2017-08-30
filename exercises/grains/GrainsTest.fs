module GrainsTest

open Xunit
open FsUnit
open Grains
    
[<Fact>]
let ``Test square 1`` () = 
    square 1 |> should equal 1I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test square 2`` () = 
    square 2 |> should equal 2I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test square 3`` () = 
    square 3 |> should equal 4I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test square 4`` () = 
    square 4 |> should equal 8I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test square 16`` () = 
    square 16 |> should equal 32768I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test square 32`` () = 
    square 32 |> should equal 2147483648I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test square 64`` () = 
    square 64 |> should equal 9223372036854775808I
    
[<Fact(Skip = "Remove to run test")>]
let ``Test total grains`` () = 
    total |> should equal 18446744073709551615I