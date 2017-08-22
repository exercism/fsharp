module QueenAttackTest

open System
open NUnit.Framework
open FsUnit

open QueenAttack

[<Test>]
let ``Cannot occupy same space`` () =
    let white = (2, 4)
    let black = (2, 4)
    (fun () -> canAttack white black |> ignore) |> should throw typeof<Exception>

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cannot attack`` () =
    canAttack (2, 3) (4, 7) |> should be False

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on same row`` () =
    canAttack (2, 4) (2, 7) |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on same column`` () =
    canAttack (5, 4) (2, 4) |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on diagonal`` () =
    canAttack (1, 1) (6, 6) |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on other diagonal`` () =
    canAttack (0, 6) (1, 7) |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on yet another diagonal`` () =
    canAttack (4, 1) (6, 3) |> should be True

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on a diagonal slanted the other way`` () =
    canAttack (6, 1) (1, 6) |> should be True