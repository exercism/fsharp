// This file was auto-generated based on version 1.1.0 of the canonical data.

module ReactTest

open FsUnit.Xunit
open Xunit

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
    let mutable callback1 = []
    let callback1Handler = Handler<int>(fun _ value -> callback1 <- callback1 @ [value])
    output.Changed.AddHandler callback1Handler
    input.Value <- 3
    callback1 |> should equal [4]

[<Fact(Skip = "Remove to run test")>]
let ``Callback cells only fire on change`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> if values.[0] < 3 then 111 else 222)
    let mutable callback1 = []
    let callback1Handler = Handler<int>(fun _ value -> callback1 <- callback1 @ [value])
    output.Changed.AddHandler callback1Handler
    input.Value <- 2
    callback1 |> should equal List.empty<int>
    input.Value <- 4
    callback1 |> should equal [222]

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks can be added and removed`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 11
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let mutable callback1 = []
    let callback1Handler = Handler<int>(fun _ value -> callback1 <- callback1 @ [value])
    output.Changed.AddHandler callback1Handler
    let mutable callback2 = []
    let callback2Handler = Handler<int>(fun _ value -> callback2 <- callback2 @ [value])
    output.Changed.AddHandler callback2Handler
    input.Value <- 31
    output.Changed.RemoveHandler callback1Handler
    let mutable callback3 = []
    let callback3Handler = Handler<int>(fun _ value -> callback3 <- callback3 @ [value])
    output.Changed.AddHandler callback3Handler
    input.Value <- 41
    callback1 |> should equal [32]
    callback2 |> should equal [32; 42]
    callback3 |> should equal [42]

[<Fact(Skip = "Remove to run test")>]
let ``Removing a callback multiple times doesn't interfere with other callbacks`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let output = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let mutable callback1 = []
    let callback1Handler = Handler<int>(fun _ value -> callback1 <- callback1 @ [value])
    output.Changed.AddHandler callback1Handler
    let mutable callback2 = []
    let callback2Handler = Handler<int>(fun _ value -> callback2 <- callback2 @ [value])
    output.Changed.AddHandler callback2Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    output.Changed.RemoveHandler callback1Handler
    input.Value <- 2
    callback1 |> should equal List.empty<int>
    callback2 |> should equal [3]

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks should only be called once even if multiple dependencies change`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let minus_one1 = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    let minus_one2 = reactor.createComputeCell [minus_one1] (fun values -> values.[0] - 1)
    let output = reactor.createComputeCell [plus_one; minus_one2] (fun values -> values.[0] * values.[1])
    let mutable callback1 = []
    let callback1Handler = Handler<int>(fun _ value -> callback1 <- callback1 @ [value])
    output.Changed.AddHandler callback1Handler
    input.Value <- 4
    callback1 |> should equal [10]

[<Fact(Skip = "Remove to run test")>]
let ``Callbacks should not be called if dependencies change but output value doesn't change`` () =
    let reactor = new Reactor()
    let input = reactor.createInputCell 1
    let plus_one = reactor.createComputeCell [input] (fun values -> values.[0] + 1)
    let minus_one = reactor.createComputeCell [input] (fun values -> values.[0] - 1)
    let always_two = reactor.createComputeCell [plus_one; minus_one] (fun values -> values.[0] - values.[1])
    let mutable callback1 = []
    let callback1Handler = Handler<int>(fun _ value -> callback1 <- callback1 @ [value])
    always_two.Changed.AddHandler callback1Handler
    input.Value <- 2
    input.Value <- 3
    input.Value <- 4
    input.Value <- 5
    callback1 |> should equal List.empty<int>

