// This file was auto-generated based on version 1.1.0 of the canonical data.

module GigasecondTest

open FsUnit.Xunit
open Xunit
open System

open Gigasecond

[<Fact>]
let ``Date only specification of time`` () =
    add (DateTime(2011, 4, 25)) |> should equal (DateTime(2043, 1, 1, 1, 46, 40))

[<Fact(Skip = "Remove to run test")>]
let ``Second test for date only specification of time`` () =
    add (DateTime(1977, 6, 13)) |> should equal (DateTime(2009, 2, 19, 1, 46, 40))

[<Fact(Skip = "Remove to run test")>]
let ``Third test for date only specification of time`` () =
    add (DateTime(1959, 7, 19)) |> should equal (DateTime(1991, 3, 27, 1, 46, 40))

[<Fact(Skip = "Remove to run test")>]
let ``Full time specified`` () =
    add (DateTime(2015, 1, 24, 22, 0, 0)) |> should equal (DateTime(2046, 10, 2, 23, 46, 40))

[<Fact(Skip = "Remove to run test")>]
let ``Full time with day roll-over`` () =
    add (DateTime(2015, 1, 24, 23, 59, 59)) |> should equal (DateTime(2046, 10, 3, 1, 46, 39))

