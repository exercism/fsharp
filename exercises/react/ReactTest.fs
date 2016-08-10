module ReactTest

open NUnit.Framework

open React

[<Test>]
let ``Setting the value of an input cell changes the observable value`` () =
  let i1 = mkInputCell 1

  Assert.That(value i1 , Is.EqualTo(1))
  setValue 2 i1 |> ignore
  Assert.That(value i1 , Is.EqualTo(2))

[<Test>]
[<Ignore("Remove to run test")>]
let ``The value of a compute is determined by the value of the dependencies`` () =
  let i1 = mkInputCell 1    
  let c1 = mkComputeCell [i1] (fun values -> values.[0] + 1)

  Assert.That(c1.Value, Is.EqualTo(2))  
  setValue 2 i1 |> ignore
  Assert.That(c1.Value, Is.EqualTo(3))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Compute cells can depend on other compute cells`` () =
  let i1 = mkInputCell 1
  let c1 = mkComputeCell [i1] (fun values -> values.[0] + 1)
  let c2 = mkComputeCell [i1] (fun values -> values.[0] - 1)
  let c3 = mkComputeCell [c1; c2] (fun values -> values.[0] * values.[1])
  
  Assert.That(c3.Value, Is.EqualTo(0))  
  setValue 3 i1 |> ignore
  Assert.That(c3.Value, Is.EqualTo(8))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Compute cells can have callbacks`` () =
  let i1 = mkInputCell 1
  let c1 = mkComputeCell [i1] (fun values -> values.[0] + 1)
  let mutable observed = []
  c1.Changed.Add(fun value -> observed <- observed @ [value]) |> ignore
  
  Assert.That(observed, Is.EqualTo([]))
  setValue 2 i1 |> ignore
  Assert.That(observed, Is.EqualTo([3]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Callbacks only trigger on change`` () =
  let i1 = mkInputCell 1
  let c1 = mkComputeCell [i1] (fun values -> if values.[0] > 2 then values.[0] + 1 else 2)
  let mutable observerCalled = 0
  c1.Changed.Add(fun value -> observerCalled <- observerCalled + 1) |> ignore

  setValue 1 i1 |> ignore
  Assert.That(observerCalled, Is.EqualTo(0))
  setValue 2 i1 |> ignore
  Assert.That(observerCalled, Is.EqualTo(0))
  setValue 3 i1 |> ignore
  Assert.That(observerCalled, Is.EqualTo(1))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Callbacks can be removed`` () =
  let i1 = mkInputCell 1
  let c1 = mkComputeCell [i1] (fun values -> values.[0] + 1)
  let mutable observed1 = []
  let mutable observed2 = []

  let changedHandler1 = Handler<int>(fun _ value -> observed1 <- observed1 @ [value])
  c1.Changed.AddHandler changedHandler1
  c1.Changed.Add(fun value -> observed2 <- observed2 @ [value]) |> ignore
    
  setValue 2 i1 |> ignore
  Assert.That(observed1, Is.EqualTo([3]))  
  Assert.That(observed2, Is.EqualTo([3]))

  c1.Changed.RemoveHandler changedHandler1
  setValue 3 i1 |> ignore
  Assert.That(observed1, Is.EqualTo([3]))  
  Assert.That(observed2, Is.EqualTo([3; 4]))

[<Test>]
[<Ignore("Remove to run test")>]
let ``Callbacks should only be called once even if multiple dependencies have changed`` () =
  let i1 = mkInputCell 1
  let c1 = mkComputeCell [i1] (fun values -> values.[0] + 1)
  let c2 = mkComputeCell [i1] (fun values -> values.[0] - 1)
  let c3 = mkComputeCell [c2] (fun values -> values.[0] - 1)
  let c4 = mkComputeCell [c1; c3] (fun values -> values.[0] * values.[1])
  let mutable changed4 = 0
  c1.Changed.Add(fun value -> changed4 <- changed4 + 1) |> ignore
  setValue 3 i1 |> ignore
  Assert.That(changed4, Is.EqualTo(1))  