source("./guessing-game.R")
library(testthat)

[<Task(1)>]
    expect_equal(let ``Give hint for 42``() = reply 42, "Correct")

[<Task(2)>]
    expect_equal(let ``Give hint for 41``() = reply 41, "So close")

[<Task(2)>]
    expect_equal(let ``Give hint for 43``() = reply 43, "So close")

[<Task(3)>]
    expect_equal(let ``Give hint for 40``() = reply 40, "Too low")

[<Task(3)>]
    expect_equal(let ``Give hint for 1``() = reply 1, "Too low")

[<Task(4)>]
    expect_equal(let ``Give hint for 44``() = reply 44, "Too high")

[<Task(4)>]
    expect_equal(let ``Give hint for 100``() = reply 100, "Too high")
