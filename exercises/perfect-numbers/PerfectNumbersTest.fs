module PerfectNumbersTest

open Xunit
open FsUnit.Xunit

open PerfectNumbers

[<Theory(Skip = "Remove to run test")>]
[<InlineData(3)>]
[<InlineData(7)>]
[<InlineData(13)>]
let ``Can classify deficient numbers`` (number) =
    classify number |> should equal Deficient

[<Theory(Skip = "Remove to run test")>]
[<InlineData(6)>]
[<InlineData(28)>]
[<InlineData(496)>]
let ``Can classify perfect numbers`` (number) =
    classify number |> should equal Perfect

[<Theory(Skip = "Remove to run test")>]
[<InlineData(12)>]
[<InlineData(18)>]
[<InlineData(20)>]
let ``Can classify abundant numbers`` (number) =
    classify number |> should equal Abundant