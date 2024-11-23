~ "react.ua" ~ React

# Input cells have a value
reactor = new Reactor()
input = reactor.createInputCell 10
⍤⤙≍ 10 input.Value

# An input cell's value can be set
reactor = new Reactor()
input = reactor.createInputCell 4
    input.Value <- 20
⍤⤙≍ 20 input.Value

# Compute cells calculate initial value
reactor = new Reactor()
input = reactor.createInputCell 1
output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
⍤⤙≍ 2 output.Value

# Compute cells take inputs in the right order
reactor = new Reactor()
one = reactor.createInputCell 1
two = reactor.createInputCell 2
output = reactor.createComputeCell [one two] (fun values -> values.[0] + values.[1] * 10)
⍤⤙≍ 21 output.Value

# Compute cells update value when dependencies are changed
reactor = new Reactor()
input = reactor.createInputCell 1
output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    input.Value <- 3
⍤⤙≍ 4 output.Value

# Compute cells can depend on other compute cells
reactor = new Reactor()
input = reactor.createInputCell 1
times_two = reactor.createComputeCell [input] (fun values -> values.[0] * 2)
times_thirty = reactor.createComputeCell [input] (fun values -> values.[0] * 30)
output = reactor.createComputeCell [times_two times_thirty] (fun values -> values.[0] + values.[1])
⍤⤙≍ 32 output.Value
    input.Value <- 3
⍤⤙≍ 96 output.Value

# Compute cells fire callbacks
reactor = new Reactor()
input = reactor.createInputCell 1
output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 3
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_4).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

# Callback cells only fire on change
reactor = new Reactor()
input = reactor.createInputCell 1
output = reactor.createComputeCell [input] (fun values -> if values.[0] < 3 then 111 else 222)
callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore
    input.Value <- 4
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_222).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

# Callbacks do not report already reported values
reactor = new Reactor()
input = reactor.createInputCell 1
output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_3).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    input.Value <- 3
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_4).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

# Callbacks can fire from multiple cells
reactor = new Reactor()
input = reactor.createInputCell 1
plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
minus_one = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
callback1Handler = A.Fake<Handler<int>>()
    plus_one.Changed.AddHandler callback1Handler
callback2Handler = A.Fake<Handler<int>>()
    minus_one.Changed.AddHandler callback2Handler
    input.Value <- 10
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_11).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    A.CallTofun() -> callback2Handler.Invoke(A<obj>.``_``_9).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore

# Callbacks can be added and removed
reactor = new Reactor()
input = reactor.createInputCell 11
output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
callback2Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback2Handler
    input.Value <- 31
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_32).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore
    A.CallTofun() -> callback2Handler.Invoke(A<obj>.``_``_32).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    output.Changed.RemoveHandler callback1Handler
callback3Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback3Handler
    input.Value <- 41
    A.CallTofun() -> callback2Handler.Invoke(A<obj>.``_``_42).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    A.CallTofun() -> callback3Handler.Invoke(A<obj>.``_``_42).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback3Handler) |> ignore
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore

# Removing a callback multiple times doesn't interfere with other callbacks
reactor = new Reactor()
input = reactor.createInputCell 1
output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
callback2Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback2Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    input.Value <- 2
    A.CallTofun() -> callback2Handler.Invoke(A<obj>.``_``_3).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback2Handler) |> ignore
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore

# Callbacks should only be called once even if multiple dependencies change
reactor = new Reactor()
input = reactor.createInputCell 1
plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
minus_one1 = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
minus_one2 = reactor.createComputeCell [minus_one1] (fun values -> values.[0] - 1)
output = reactor.createComputeCell [plus_one minus_one2] (fun values -> values.[0] * values.[1])
callback1Handler = A.Fake<Handler<int>>()
    output.Changed.AddHandler callback1Handler
    input.Value <- 4
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_10).MustHaveHappenedOnceExactly() |> ignore
    Fake.ClearRecordedCalls(callback1Handler) |> ignore

# Callbacks should not be called if dependencies change but output value doesn't change
reactor = new Reactor()
input = reactor.createInputCell 1
plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
minus_one = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
always_two = reactor.createComputeCell [plus_one minus_one] (fun values -> values.[0] - values.[1])
callback1Handler = A.Fake<Handler<int>>()
    always_two.Changed.AddHandler callback1Handler
    input.Value <- 2
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore
    input.Value <- 3
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore
    input.Value <- 4
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore
    input.Value <- 5
    A.CallTofun() -> callback1Handler.Invoke(A<obj>.``_``_A<int>.``_``).MustNotHaveHappened() |> ignore

