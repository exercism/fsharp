module GigasecondTest

open NUnit.Framework
open FsUnit
open Gigasecond
open System
    
[<Test>]
let ``First date`` () =
    let input = DateTime(2011, 4, 25)
    gigasecond input |> should equal (DateTime(2043, 1, 1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Another date`` () =
    let input = DateTime(1977, 6, 13)
    gigasecond input |> should equal (DateTime(2009, 2, 19))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Yet another date`` () =
    let input = DateTime(1959, 7, 19)
    gigasecond input |> should equal (DateTime(1991, 3, 27))