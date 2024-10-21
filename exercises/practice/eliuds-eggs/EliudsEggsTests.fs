module EliudsEggsTests

open FsUnit.Xunit
open Xunit

open EliudsEggs

[<Fact>]
let ``0 eggs`` () =
    eggCount 0 |> should equal 0

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``1 egg`` () =
    eggCount 16 |> should equal 1

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``4 eggs`` () =
    eggCount 89 |> should equal 4

[<Fact(Skip = "Remove this Skip property to run this test")>]
let ``13 eggs`` () =
    eggCount 2000000000 |> should equal 13

