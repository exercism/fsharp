module ClockTest

open System
open NUnit.Framework
open Clock

[<TestCase(8, "08:00")>]
[<TestCase(9, "09:00", Ignore = "Remove to run test case")>]
let ``Prints the hour`` (hours: int, expected: string) =
    let clock = mkClock hours 0
    Assert.That(display clock, Is.EqualTo(expected))

[<TestCase(11, 9, "11:09", Ignore = "Remove to run test case")>]
[<TestCase(11, 19, "11:19", Ignore = "Remove to run test case")>]
let ``Prints past the hour`` (hours: int) (minutes: int) (expected: string) =
    let clock = mkClock hours minutes
    Assert.That(display clock, Is.EqualTo(expected))

[<Test>] 
[<Ignore("Remove to run test")>]     
let ``Can add minutes`` () =
    let clock = mkClock 10 0
    let added = clock |> add 3
    Assert.That(display added, Is.EqualTo("10:03"))

[<Test>] 
[<Ignore("Remove to run test")>]     
let ``Can add over an hour`` () =
    let clock = mkClock 10 0
    let added = clock |> add 63
    Assert.That(display added, Is.EqualTo("11:03"))

[<Test>]   
[<Ignore("Remove to run test")>]   
let ``Can add over more than one day`` () =
    let clock = mkClock 10 0
    let added = clock |> add 7224
    Assert.That(display added, Is.EqualTo("10:24"))

[<Test>]   
[<Ignore("Remove to run test")>]   
let ``Can subtract minutes`` () =
    let clock = mkClock 10 3
    let subtracted = clock |> subtract 3
    Assert.That(display subtracted, Is.EqualTo("10:00"))

[<Test>]   
[<Ignore("Remove to run test")>]   
let ``Can subtract to previous hour`` () =
    let clock = mkClock 10 3
    let subtracted = clock |> subtract 30
    Assert.That(display subtracted, Is.EqualTo("09:33"))

[<Test>]  
[<Ignore("Remove to run test")>]    
let ``Can subtract over an hour`` () =
    let clock = mkClock 10 3
    let subtracted = clock |> subtract 70
    Assert.That(display subtracted, Is.EqualTo("08:53"))

[<Test>]    
[<Ignore("Remove to run test")>]  
let ``Wraps around midnight`` () =
    let clock = mkClock 23 59
    let added = clock |> add 2
    Assert.That(display added, Is.EqualTo("00:01"))

[<Test>]  
[<Ignore("Remove to run test")>]    
let ``Wraps around midnight backwards`` () =
    let clock = mkClock 0 1
    let subtracted = clock |> subtract 2
    Assert.That(display subtracted, Is.EqualTo("23:59"))

[<Test>]   
[<Ignore("Remove to run test")>]   
let ``Midnight is zero hundred hours`` () =
    let clock = mkClock 24 0
    Assert.That(display clock, Is.EqualTo("00:00"))

[<Test>]    
[<Ignore("Remove to run test")>]  
let ``Sixty minutes is next hour`` () =
    let clock = mkClock 1 60
    Assert.That(display clock, Is.EqualTo("02:00"))

[<Test>]   
[<Ignore("Remove to run test")>]   
let ``Clocks with same time are equal`` () =
    let clock1 = mkClock 14 30
    let clock2 = mkClock 14 30
    Assert.That(clock1, Is.EqualTo(clock2))

[<Test>]   
[<Ignore("Remove to run test")>]   
let ``Overflown clocks with same time are equal`` () =
    let clock1 = mkClock 14 30
    let clock2 = mkClock 38 30
    Assert.That(clock1, Is.EqualTo(clock2))