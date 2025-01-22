source("./react.R")
library(testthat)

let ``Input cells have a value`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 10
    expect_equal(input.Value, 10)

let ``An input cell's value can be set`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 4
    input.Value <- 20
    expect_equal(input.Value, 20)

let ``Compute cells calculate initial value`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    output <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    expect_equal(output.Value, 2)

let ``Compute cells take inputs in the right order`` () =
    reactor <- new Reactor()
    one <- reactor.createInputCell 1
    two <- reactor.createInputCell 2
    output <- reactor.createComputeCell [one; two] (fun values -> values.[0] + values.[1] * 10)
    expect_equal(output.Value, 21)

let ``Compute cells update value when dependencies are changed`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    output <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    input.Value <- 3
    expect_equal(output.Value, 4)

let ``Compute cells can depend on other compute cells`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    times_two <- reactor.createComputeCell [input] (fun values -> values.[0] * 2)
    times_thirty <- reactor.createComputeCell [input] (fun values -> values.[0] * 30)
    output <- reactor.createComputeCell [times_two; times_thirty] (fun values -> values.[0] + values.[1])
    expect_equal(output.Value, 32)
    input.Value <- 3
    expect_equal(output.Value, 96)

let ``Compute cells fire callbacks`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    output <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    callback1Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 3
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 4)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

let ``Callback cells only fire on change`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    output <- reactor.createComputeCell [input] (fun values -> if values.[0] < 3 then 111 else 222)
    callback1Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 4
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 222)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

let ``Callbacks do not report already reported values`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    output <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    callback1Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 3)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    input.Value <- 3
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 4)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

let ``Callbacks can fire from multiple cells`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    plus_one <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    minus_one <- reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    callback1Handler <- A.Fake<Handler<int>>()
    plus_one.Changed.AddHandler callback1Handler
    callback2Handler <- A.Fake<Handler<int>>()
    minus_one.Changed.AddHandler callback2Handler
    input.Value <- 10
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 11)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 9)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore

let ``Callbacks can be added and removed`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 11
    output <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    callback1Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    callback2Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback2Handler
    input.Value <- 31
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 32)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 32)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    output.Changed.RemoveHandler callback1Handler
    callback3Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback3Handler
    input.Value <- 41
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 42)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    A.CallTo(fun() -> callback3Handler.Invoke(A<obj>.``_``, 42)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback3Handler) |> ignore
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore

let ``Removing a callback multiple times doesn't interfere with other callbacks`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    output <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    callback1Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    callback2Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback2Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback2Handler.Invoke(A<obj>.``_``, 3)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore

let ``Callbacks should only be called once even if multiple dependencies change`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    plus_one <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    minus_one1 <- reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    minus_one2 <- reactor.createComputeCell [minus_one1] (fun values -> values.[0] - 1)
    output <- reactor.createComputeCell [plus_one; minus_one2] (fun values -> values.[0] * values.[1])
    callback1Handler <- A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 4
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, 10)).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

let ``Callbacks should not be called if dependencies change but output value doesn't change`` () =
    reactor <- new Reactor()
    input <- reactor.createInputCell 1
    plus_one <- reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    minus_one <- reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    always_two <- reactor.createComputeCell [plus_one; minus_one] (fun values -> values.[0] - values.[1])
    callback1Handler <- A.Fake<Handler<int>>()
    always_two.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 3
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 4
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore
    input.Value <- 5
    A.CallTo(fun() -> callback1Handler.Invoke(A<obj>.``_``, A<int>.``_``)).MustNotHaveHappened() |> ignore

