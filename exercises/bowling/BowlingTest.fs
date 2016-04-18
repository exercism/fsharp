module BowlingTest

open NUnit.Framework

open Bowling

let rollMany pins count game =
    List.replicate count pins
    |> List.fold (fun acc item -> roll item acc) game

let rollSpare game = 
    game
    |> roll 5
    |> roll 5

let rollStrike game = game |> roll 10

[<Test>]
let ``Gutter game`` () =
    let result = newGame |> rollMany 0 20
    Assert.That(score result, Is.EqualTo(0))

[<Test>]
[<Ignore("Remove to run test")>]
let ``All ones game`` () =
    let result = newGame |> rollMany 1 20
    Assert.That(score result, Is.EqualTo(20))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One spare game`` () =
    let result = 
        newGame
        |> rollSpare
        |> roll 3
        |> rollMany 0 17

    Assert.That(score result, Is.EqualTo(16))

[<Test>]
[<Ignore("Remove to run test")>]
let ``One strike game`` () =
    let result = 
        newGame
        |> rollStrike
        |> roll 3
        |> roll 4
        |> rollMany 0 16

    Assert.That(score result, Is.EqualTo(24))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Perfect game`` () =
    let result = newGame |> rollMany 10 12

    Assert.That(score result, Is.EqualTo(300))
  

