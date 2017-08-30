module ClockTest

open System
open Xunit
open FsUnit.Xunit
open Clock

[<Fact>]
let ``Prints 8 o'clock`` () =
    let clock = mkClock 8 0
    display clock |> should equal "08:00"

[<Fact(Skip = "Remove to run test")>]     
let ``Prints 9 o'clock`` () =
    let clock = mkClock 9 0
    display clock |> should equal "09:00"

[<Fact(Skip = "Remove to run test")>]     
let ``Can print single-digit minutes`` () =
    let clock = mkClock 11 9
    display clock |> should equal "11:09"

[<Fact(Skip = "Remove to run test")>]
let ``Can print double-digit minutes`` () =
    let clock = mkClock 11 19
    display clock |> should equal "11:19"

[<Fact(Skip = "Remove to run test")>]
let ``Can add minutes`` () =
    let clock = mkClock 10 0
    let added = clock |> add 3
    display added |> should equal "10:03"

[<Fact(Skip = "Remove to run test")>]
let ``Can add over an hour`` () =
    let clock = mkClock 10 0
    let added = clock |> add 63
    display added |> should equal "11:03"

[<Fact(Skip = "Remove to run test")>]
let ``Can add over more than one day`` () =
    let clock = mkClock 10 0
    let added = clock |> add 7224
    display added |> should equal "10:24"

[<Fact(Skip = "Remove to run test")>]
let ``Can subtract minutes`` () =
    let clock = mkClock 10 3
    let subtracted = clock |> subtract 3
    display subtracted |> should equal "10:00"

[<Fact(Skip = "Remove to run test")>]
let ``Can subtract to previous hour`` () =
    let clock = mkClock 10 3
    let subtracted = clock |> subtract 30
    display subtracted |> should equal "09:33"

[<Fact(Skip = "Remove to run test")>]
let ``Can subtract over an hour`` () =
    let clock = mkClock 10 3
    let subtracted = clock |> subtract 70
    display subtracted |> should equal "08:53"

[<Fact(Skip = "Remove to run test")>]
let ``Wraps around midnight`` () =
    let clock = mkClock 23 59
    let added = clock |> add 2
    display added |> should equal "00:01"

[<Fact(Skip = "Remove to run test")>]
let ``Wraps around midnight backwards`` () =
    let clock = mkClock 0 1
    let subtracted = clock |> subtract 2
    display subtracted |> should equal "23:59"

[<Fact(Skip = "Remove to run test")>]
let ``Midnight is zero hundred hours`` () =
    let clock = mkClock 24 0
    display clock |> should equal "00:00"

[<Fact(Skip = "Remove to run test")>]
let ``Sixty minutes is next hour`` () =
    let clock = mkClock 1 60
    display clock |> should equal "02:00"

[<Fact(Skip = "Remove to run test")>]
let ``Clocks with same time are equal`` () =
    let clock1 = mkClock 14 30
    let clock2 = mkClock 14 30
    clock1 |> should equal clock2

[<Fact(Skip = "Remove to run test")>]
let ``Overflown clocks with same time are equal`` () =
    let clock1 = mkClock 14 30
    let clock2 = mkClock 38 30
    clock1 |> should equal clock2