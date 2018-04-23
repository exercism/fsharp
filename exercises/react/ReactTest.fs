// This file was auto-generated based on version 2.0.0 of the canonical data.

module ReactTest

open FsUnit.Xunit
open Xunit
open FakeItEasy

open React

[<Fact>]
let ``Input cells have a value`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 10
    input.Value |> should equal 10

[<Fact(Skip = "Remove to run test")>]
let ``An input cell's value can be set`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 4
    input.Value <- 20
    input.Value |> should equal 20

[<Fact(Skip = "Remove to run test")>]
let ``Compute cells calculate initial value`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    output.Value |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Compute cells take inputs in the right order`` () =
    let reactor = new Reactor()
    let one = reactor.createInputCell 1
    let two = reactor.createInputCell 2
    let output = reactor.createComputeCell [one; two] (fun values -> values.[0] + values.[1] * 10)
    output.Value |> should equal 21

[<Fact(Skip = "Remove to run test")>]
let ``Compute cells update value when dependencies are changed`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    input.Value <- 3
    output.Value |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``Compute cells can depend on other compute cells`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let times_two = reactor.createComputeCell [input] (fun values -> values.[0] * 2)
    let times_thirty = reactor.createComputeCell [input] (fun values -> values.[0] * 30)
    let output = reactor.createComputeCell [times_two; times_thirty] (fun values -> values.[0] + values.[1])
    output.Value |> should equal 32
    input.Value <- 3
    output.Value |> should equal 96

[<Fact(Skip = "Remove to run test")>]
let ``Compute cells fire callbacks`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 3
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 4)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Callback cells only fire on change`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> if values.[0] < 3 then 111 else 222)
    let callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 4
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 222)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks do not report already reported values`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 3)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    input.Value <- 3
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 4)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks can fire from multiple cells`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let minus_one = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    let callback1Handler = A.Fake<Handler<int>>()
    plus_one.Changed.AddHandler callback1Handler
    let callback2Handler = A.Fake<Handler<int>>()
    minus_one.Changed.AddHandler callback2Handler
    input.Value <- 10
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 11)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 9)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks can be added and removed`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 11
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    let callback2Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback2Handler
    input.Value <- 31
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 32)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 32)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    output.Changed.RemoveHandler callback1Handler
    let callback3Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback3Handler
    input.Value <- 41
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 42)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    A.CallTo(fun() -> callback3Handler.Invoke(A<obj>.``_``, 42)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback3Handler) |> ignore
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Removing a callback multiple times doesn't interfere with other callbacks`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    let callback2Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback2Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 3)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks should only be called once even if multiple dependencies change`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let minus_one1 = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    let minus_one2 = reactor.createComputeCell [minus_one1] (fun values -> values.[0] - 1)
    let output = reactor.createComputeCell [plus_one; minus_one2] (fun values -> values.[0] * values.[1])
    let callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 4
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 10)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks should not be called if dependencies change but output value doesn't change`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let minus_one = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    let always_two = reactor.createComputeCell [plus_one; minus_one] (fun values -> values.[0] - values.[1])
    let callback1Handler = A.Fake<Handler<int>>()
    always_two.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 3
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 4
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 5
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore

