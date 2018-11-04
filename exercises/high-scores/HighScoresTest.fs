// This file was auto-generated based on version 1.0.0 of the canonical data.

module HighScoresTest

open FsUnit.Xunit
open Xunit

open HighScores

[<Fact>]
let ``List of scores`` () =
    scores [30; 50; 20; 70] |> should equal [30; 50; 20; 70]

[<Fact(Skip = "Remove to run test")>]
let ``Latest score`` () =
    latest [100; 0; 90; 30] |> should equal 30

[<Fact(Skip = "Remove to run test")>]
let ``Highest score`` () =
    highest [40; 100; 70] |> should equal 100

[<Fact(Skip = "Remove to run test")>]
let ``Personal bests`` () =
    top [50; 30; 10] |> should equal [50; 30; 10]

[<Fact(Skip = "Remove to run test")>]
let ``Personal bests highest to lowest`` () =
    top [20; 10; 30] |> should equal [30; 20; 10]

[<Fact(Skip = "Remove to run test")>]
let ``Personal bests when there is a tie`` () =
    top [40; 20; 40; 30] |> should equal [40; 40; 30]

[<Fact(Skip = "Remove to run test")>]
let ``Personal bests when there are less than 3`` () =
    top [30; 70] |> should equal [70; 30]

[<Fact(Skip = "Remove to run test")>]
let ``Personal bests when there is only one`` () =
    top [40] |> should equal [40]

[<Fact(Skip = "Remove to run test")>]
let ``Personal bests from a long list`` () =
    top [10; 30; 90; 30; 100; 20; 10; 0; 30; 40; 40; 70; 70] |> should equal [100; 90; 70]

[<Fact(Skip = "Remove to run test")>]
let ``Message for new personal best`` () =
    report [20; 40; 0; 30; 70] |> should equal "Your latest score was 70. That's your personal best!"

[<Fact(Skip = "Remove to run test")>]
let ``Message when latest score is not the highest score`` () =
    report [20; 100; 0; 30; 70] |> should equal "Your latest score was 70. That's 30 short of your personal best!"

[<Fact(Skip = "Remove to run test")>]
let ``Message for repeated personal best`` () =
    report [20; 70; 50; 70; 30] |> should equal "Your latest score was 30. That's 40 short of your personal best!"

