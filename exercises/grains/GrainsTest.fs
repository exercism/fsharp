module GrainsTest

open NUnit.Framework
open FsUnit
open Grains
    
[<Test>]
let ``Test square 1`` () = 
    square 1 |> should equal 1I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 2`` () = 
    square 2 |> should equal 2I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 3`` () = 
    square 3 |> should equal 4I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 4`` () = 
    square 4 |> should equal 8I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 16`` () = 
    square 16 |> should equal 32768I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 32`` () = 
    square 32 |> should equal 2147483648I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test square 64`` () = 
    square 64 |> should equal 9223372036854775808I
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Test total grains`` () = 
    total |> should equal 18446744073709551615I