module ScrabbleScoreTest

open Xunit
open FsUnit
open ScrabbleScore
  
[<Fact>]
let ``Empty word scores zero`` () =
    score "" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Whitespace scores zero`` () =
    score " \t\n" |> should equal 0

[<Fact(Skip = "Remove to run test")>]
let ``Scores very short word`` () =
    score "a" |> should equal 1

[<Fact(Skip = "Remove to run test")>]
let ``Scores other very short word`` () =
    score "f" |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``Simple word scores the number of letters`` () =
    score "street" |> should equal 6

[<Fact(Skip = "Remove to run test")>]
let ``Complicated word scores more`` () =
    score "quirky" |> should equal 22

[<Fact(Skip = "Remove to run test")>]
let ``Scores are case insensitive`` () =
    score "OXYPHENBUTAZONE" |> should equal 41
    
[<Fact(Skip = "Remove to run test")>]
let ``Entire alphabet`` () =
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87