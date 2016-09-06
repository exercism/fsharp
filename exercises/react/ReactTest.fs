﻿module ReactTest

open NUnit.Framework

open React

[<Test>]
let ``Setting the value of an input cell changes the observable value`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1

  Assert.That(inputCell1.Value, Is.EqualTo(1))
  inputCell1.Value <- 2
  Assert.That(inputCell1.Value, Is.EqualTo(2))

[<Test>]
[<Ignore("Remove to run test")>]
let ``The value of a compute is determined by the value of the dependencies`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1    
  let computeCell1 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] + 1)

  Assert.That(computeCell1.Value, Is.EqualTo(2))  
  inputCell1.Value <- 2
  Assert.That(computeCell1.Value, Is.EqualTo(3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Compute cells can depend on other compute cells`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1
  let computeCell1 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] + 1)
  let computeCell2 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] - 1)
  let computeCell3 = reactor.createComputeCell [computeCell1; computeCell2] (fun values -> values.[0] * values.[1])
  
  Assert.That(computeCell3.Value, Is.EqualTo(0))  
  inputCell1.Value <- 3
  Assert.That(computeCell3.Value, Is.EqualTo(8))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Compute cells can have callbacks`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1
  let computeCell1 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] + 1)
  let mutable observed = []
  computeCell1.Changed.Add(fun value -> observed <- observed @ [value]) |> ignore
  
  Assert.That(observed, Is.EqualTo([]))
  inputCell1.Value <- 2
  Assert.That(observed, Is.EqualTo([3]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Callbacks only trigger on change`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1
  let computecell1 = reactor.createComputeCell [inputCell1] (fun values -> if values.[0] > 2 then values.[0] + 1 else 2)
  let mutable observerCalled = 0
  computecell1.Changed.Add(fun value -> observerCalled <- observerCalled + 1) |> ignore

  inputCell1.Value <- 1
  Assert.That(observerCalled, Is.EqualTo(0))
  inputCell1.Value <- 2
  Assert.That(observerCalled, Is.EqualTo(0))
  inputCell1.Value <- 3
  Assert.That(observerCalled, Is.EqualTo(1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Callbacks can be removed`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1
  let computeCell1 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] + 1)
  let mutable observed1 = []
  let mutable observed2 = []

  let changedHandler1 = Handler<int>(fun _ value -> observed1 <- observed1 @ [value])
  computeCell1.Changed.AddHandler changedHandler1
  computeCell1.Changed.Add(fun value -> observed2 <- observed2 @ [value]) |> ignore
    
  inputCell1.Value <- 2
  Assert.That(observed1, Is.EqualTo([3]))  
  Assert.That(observed2, Is.EqualTo([3]))

  computeCell1.Changed.RemoveHandler changedHandler1
  inputCell1.Value <- 3
  Assert.That(observed1, Is.EqualTo([3]))  
  Assert.That(observed2, Is.EqualTo([3; 4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Callbacks should only be called once even if multiple dependencies have changed`` () =
  let reactor = new Reactor()
  let inputCell1 = reactor.createInputCell 1
  let computeCell1 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] + 1)
  let computeCell2 = reactor.createComputeCell [inputCell1] (fun values -> values.[0] - 1)
  let computeCell3 = reactor.createComputeCell [computeCell2] (fun values -> values.[0] - 1)
  let computeCell4 = reactor.createComputeCell [computeCell1; computeCell3] (fun values -> values.[0] * values.[1])
  let mutable changed4 = 0
  computeCell4.Changed.Add(fun value -> changed4 <- changed4 + 1) |> ignore
  inputCell1.Value <- 3
  Assert.That(changed4, Is.EqualTo(1))  