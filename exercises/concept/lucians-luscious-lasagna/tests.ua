

[<Task(1)>]
let ``Expected minutes in oven`` () = expectedMinutesInOven |> should equal 40

[<Task(2)>]
let ``Remaining minutes in oven`` () =
    remainingMinutesInOven 25 |> should equal 15

[<Task(3)>]
let ``Preparation time in minutes for one layer`` () =
    preparationTimeInMinutes 1 |> should equal 2

[<Task(3)>]
let ``Preparation time in minutes for multiple layers`` () =
    preparationTimeInMinutes 4 |> should equal 8

[<Task(4)>]
let ``Elapsed time in minutes for one layer`` () =
    elapsedTimeInMinutes 1 30 |> should equal 32

[<Task(4)>]
let ``Elapsed time in minutes for multiple layers`` () =
    elapsedTimeInMinutes 4 8 |> should equal 16
