module PerfectNumbersTest

open Xunit
open FsUnit

open PerfectNumbers

[<TestCase(3)>]
[<TestCase(7, Ignore = "Remove to run test case")>]
[<TestCase(13, Ignore = "Remove to run test case")>]
let ``Can classify deficient numbers`` (number) =
    classify number |> should equal Deficient

[<TestCase(6, Ignore = "Remove to run test case")>]
[<TestCase(28, Ignore = "Remove to run test case")>]
[<TestCase(496, Ignore = "Remove to run test case")>]
let ``Can classify perfect numbers`` (number) =
    classify number |> should equal Perfect

[<TestCase(12, Ignore = "Remove to run test case")>]
[<TestCase(18, Ignore = "Remove to run test case")>]
[<TestCase(20, Ignore = "Remove to run test case")>]
let ``Can classify abundant numbers`` (number) =
    classify number |> should equal Abundant