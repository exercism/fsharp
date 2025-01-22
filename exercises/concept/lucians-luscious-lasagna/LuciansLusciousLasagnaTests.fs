source("./lucians-luscious-lasagna.R")
library(testthat)

[<Task(1)>]
    expect_equal(let ``Expected minutes in oven`` () = expectedMinutesInOven, 40)

[<Task(2)>]
let ``Remaining minutes in oven`` () =
    expect_equal(remainingMinutesInOven 25, 15)

[<Task(3)>]
let ``Preparation time in minutes for one layer`` () =
    expect_equal(preparationTimeInMinutes 1, 2)

[<Task(3)>]
let ``Preparation time in minutes for multiple layers`` () =
    expect_equal(preparationTimeInMinutes 4, 8)

[<Task(4)>]
let ``Elapsed time in minutes for one layer`` () =
    expect_equal(elapsedTimeInMinutes 1 30, 32)

[<Task(4)>]
let ``Elapsed time in minutes for multiple layers`` () =
    expect_equal(elapsedTimeInMinutes 4 8, 16)
