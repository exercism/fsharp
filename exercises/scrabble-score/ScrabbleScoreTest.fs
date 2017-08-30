module ScrabbleScoreTest

open Xunit
open FsUnit
open ScrabbleScore
  
[<Test>]
let ``Empty word scores zero`` () =
    score "" |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``Whitespace scores zero`` () =
    score " \t\n" |> should equal 0

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scores very short word`` () =
    score "a" |> should equal 1

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scores other very short word`` () =
    score "f" |> should equal 4

[<Test>]
[<Ignore("Remove to run test")>]
let ``Simple word scores the number of letters`` () =
    score "street" |> should equal 6

[<Test>]
[<Ignore("Remove to run test")>]
let ``Complicated word scores more`` () =
    score "quirky" |> should equal 22

[<Test>]
[<Ignore("Remove to run test")>]
let ``Scores are case insensitive`` () =
    score "OXYPHENBUTAZONE" |> should equal 41
    
[<Test>]
[<Ignore("Remove to run test")>]
let ``Entire alphabet`` () =
    score "abcdefghijklmnopqrstuvwxyz" |> should equal 87