module LeapYearTest

open Xunit
open FsUnit.Xunit
open LeapYear
    
[<Fact>]
let ``Is 1996 a valid leap year`` () = 
    isLeapYear 1996 |> should equal true
    
[<Fact(Skip = "Remove to run test")>]
let ``Is 1997 an invalid leap year`` () = 
    isLeapYear 1997 |> should equal false
    
[<Fact(Skip = "Remove to run test")>]
let ``Is the turn of the 20th century an invalid leap year`` () = 
    isLeapYear 1900 |> should equal false
    
[<Fact(Skip = "Remove to run test")>]
let ``Is the turn of the 25th century a valid leap year`` () = 
    isLeapYear 2400 |> should equal true