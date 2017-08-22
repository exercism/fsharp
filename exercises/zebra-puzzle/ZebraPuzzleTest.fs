module ZebraPuzzleTest

open NUnit.Framework
open FsUnit

open ZebraPuzzle

[<Test>]
let ``Who drinks water?`` () =
    let solution = solve
    whoDrinksWater solution |> should equal Norwegian

[<Test>]
[<Ignore("Remove to run test")>]
let ``Who owns the zebra?`` () =
    let solution = solve
    whoOwnsZebra solution |> should equal Japanese