module ResistorColorTests

open FsUnit.Xunit
open Xunit

open ResistorColor

[<Fact>]
let ``Black`` () =
    colorCode "black" |> should equal 0

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``White`` () =
    colorCode "white" |> should equal 9

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Orange`` () =
    colorCode "orange" |> should equal 3

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``Colors`` () =
    colors |> should equal ["black"; "brown"; "red"; "orange"; "yellow"; "green"; "blue"; "violet"; "grey"; "white"]

