module LuciansLusciousLasagnaTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open LuciansLusciousLasagna

[<Fact>]
[<Task(1)>]
let ``Expected minutes in oven`` () = expectedMinutesInOven |> should equal 40

[<Fact>]
[<Task(2)>]
let ``Remaining minutes in oven`` () =
    remainingMinutesInOven 25 |> should equal 15

[<Fact>]
[<Task(3)>]
let ``Preparation time in minutes for one layer`` () =
    preparationTimeInMinutes 1 |> should equal 2

[<Fact>]
[<Task(3)>]
let ``Preparation time in minutes for multiple layers`` () =
    preparationTimeInMinutes 4 |> should equal 8

[<Fact>]
[<Task(4)>]
let ``Elapsed time in minutes for one layer`` () =
    elapsedTimeInMinutes 1 30 |> should equal 32

[<Fact>]
[<Task(4)>]
let ``Elapsed time in minutes for multiple layers`` () =
    elapsedTimeInMinutes 4 8 |> should equal 16
