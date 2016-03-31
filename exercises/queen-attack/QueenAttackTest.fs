module QueenAttackTest

open System
open NUnit.Framework

open QueenAttack

[<Test>]
let ``Cannot occupy same space`` () =
    let white = (2, 4)
    let black = (2, 4)
    Assert.That((fun () -> canAttack white black |> ignore), Throws.Exception)

[<Test>]
[<Ignore("Remove to run test")>]
let ``Cannot attack`` () =
    Assert.False(canAttack (2, 3) (4, 7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on same row`` () =
    Assert.True(canAttack (2, 4) (2, 7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on same column`` () =
    Assert.True(canAttack (5, 4) (2, 4))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on diagonal`` () =
    Assert.True(canAttack (1, 1) (6, 6))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on other diagonal`` () =
    Assert.True(canAttack (0, 6) (1, 7))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on yet another diagonal`` () =
    Assert.True(canAttack (4, 1) (6, 3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Can attack on a diagonal slanted the other way`` () =
    Assert.True(canAttack (6, 1) (1, 6))