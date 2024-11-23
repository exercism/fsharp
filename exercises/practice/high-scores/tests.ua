module HighScoresTests

open FsUnit.Xunit
open Xunit

open HighScores

[<Fact>]
let ``List of scores`` () =
    scores [30; 50; 20; 70] |> should equal [30; 50; 20; 70]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Latest score`` () =
    latest [100; 0; 90; 30] |> should equal 30

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Personal best`` () =
    personalBest [40; 100; 70] |> should equal 100

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Personal top three from a list of scores`` () =
    personalTopThree [10; 30; 90; 30; 100; 20; 10; 0; 30; 40; 40; 70; 70] |> should equal [100; 90; 70]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Personal top highest to lowest`` () =
    personalTopThree [20; 10; 30] |> should equal [30; 20; 10]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Personal top when there is a tie`` () =
    personalTopThree [40; 20; 40; 30] |> should equal [40; 40; 30]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Personal top when there are less than 3`` () =
    personalTopThree [30; 70] |> should equal [70; 30]

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Personal top when there is only one`` () =
    personalTopThree [40] |> should equal [40]

