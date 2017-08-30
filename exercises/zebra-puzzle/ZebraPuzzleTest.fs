module ZebraPuzzleTest

open Xunit
open FsUnit

open ZebraPuzzle

[<Fact>]
let ``Who drinks water?`` () =
    let solution = solve()
    whoDrinksWater solution |> should equal Norwegian

[<Fact(Skip = "Remove to run test")>]
let ``Who owns the zebra?`` () =
    let solution = solve()
    whoOwnsZebra solution |> should equal Japanese