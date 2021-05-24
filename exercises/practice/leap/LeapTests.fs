module LeapTests

open FsUnit.Xunit
open Xunit

open Leap

[<Fact>]
let ``Year not divisible by 4 in common year`` () =
    leapYear 2015 |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 2, not divisible by 4 in common year`` () =
    leapYear 1970 |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 4, not divisible by 100 in leap year`` () =
    leapYear 1996 |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 4 and 5 is still a leap year`` () =
    leapYear 1960 |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 100, not divisible by 400 in common year`` () =
    leapYear 2100 |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 100 but not by 3 is still not a leap year`` () =
    leapYear 1900 |> should equal false

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 400 is leap year`` () =
    leapYear 2000 |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 400 but not by 125 is still a leap year`` () =
    leapYear 2400 |> should equal true

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Year divisible by 200, not divisible by 400 in common year`` () =
    leapYear 1800 |> should equal false

