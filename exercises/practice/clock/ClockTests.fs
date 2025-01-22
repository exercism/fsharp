source("./clock.R")
library(testthat)

let ``On the hour`` () =
    clock <- create 8 0
    expect_equal(display clock, "08:00")

let ``Past the hour`` () =
    clock <- create 11 9
    expect_equal(display clock, "11:09")

let ``Midnight is zero hours`` () =
    clock <- create 24 0
    expect_equal(display clock, "00:00")

let ``Hour rolls over`` () =
    clock <- create 25 0
    expect_equal(display clock, "01:00")

let ``Hour rolls over continuously`` () =
    clock <- create 100 0
    expect_equal(display clock, "04:00")

let ``Sixty minutes is next hour`` () =
    clock <- create 1 60
    expect_equal(display clock, "02:00")

let ``Minutes roll over`` () =
    clock <- create 0 160
    expect_equal(display clock, "02:40")

let ``Minutes roll over continuously`` () =
    clock <- create 0 1723
    expect_equal(display clock, "04:43")

let ``Hour and minutes roll over`` () =
    clock <- create 25 160
    expect_equal(display clock, "03:40")

let ``Hour and minutes roll over continuously`` () =
    clock <- create 201 3001
    expect_equal(display clock, "11:01")

let ``Hour and minutes roll over to exactly midnight`` () =
    clock <- create 72 8640
    expect_equal(display clock, "00:00")

let ``Negative hour`` () =
    clock <- create -1 15
    expect_equal(display clock, "23:15")

let ``Negative hour rolls over`` () =
    clock <- create -25 0
    expect_equal(display clock, "23:00")

let ``Negative hour rolls over continuously`` () =
    clock <- create -91 0
    expect_equal(display clock, "05:00")

let ``Negative minutes`` () =
    clock <- create 1 -40
    expect_equal(display clock, "00:20")

let ``Negative minutes roll over`` () =
    clock <- create 1 -160
    expect_equal(display clock, "22:20")

let ``Negative minutes roll over continuously`` () =
    clock <- create 1 -4820
    expect_equal(display clock, "16:40")

let ``Negative sixty minutes is previous hour`` () =
    clock <- create 2 -60
    expect_equal(display clock, "01:00")

let ``Negative hour and minutes both roll over`` () =
    clock <- create -25 -160
    expect_equal(display clock, "20:20")

let ``Negative hour and minutes both roll over continuously`` () =
    clock <- create -121 -5810
    expect_equal(display clock, "22:10")

let ``Add minutes`` () =
    clock <- create 10 0
    expect_equal(add 3 clock |> display, "10:03")

let ``Add no minutes`` () =
    clock <- create 6 41
    expect_equal(add 0 clock |> display, "06:41")

let ``Add to next hour`` () =
    clock <- create 0 45
    expect_equal(add 40 clock |> display, "01:25")

let ``Add more than one hour`` () =
    clock <- create 10 0
    expect_equal(add 61 clock |> display, "11:01")

let ``Add more than two hours with carry`` () =
    clock <- create 0 45
    expect_equal(add 160 clock |> display, "03:25")

let ``Add across midnight`` () =
    clock <- create 23 59
    expect_equal(add 2 clock |> display, "00:01")

let ``Add more than one day (1500 min = 25 hrs)`` () =
    clock <- create 5 32
    expect_equal(add 1500 clock |> display, "06:32")

let ``Add more than two days`` () =
    clock <- create 1 1
    expect_equal(add 3500 clock |> display, "11:21")

let ``Subtract minutes`` () =
    clock <- create 10 3
    expect_equal(subtract 3 clock |> display, "10:00")

let ``Subtract to previous hour`` () =
    clock <- create 10 3
    expect_equal(subtract 30 clock |> display, "09:33")

let ``Subtract more than an hour`` () =
    clock <- create 10 3
    expect_equal(subtract 70 clock |> display, "08:53")

let ``Subtract across midnight`` () =
    clock <- create 0 3
    expect_equal(subtract 4 clock |> display, "23:59")

let ``Subtract more than two hours`` () =
    clock <- create 0 0
    expect_equal(subtract 160 clock |> display, "21:20")

let ``Subtract more than two hours with borrow`` () =
    clock <- create 6 15
    expect_equal(subtract 160 clock |> display, "03:35")

let ``Subtract more than one day (1500 min = 25 hrs)`` () =
    clock <- create 5 32
    expect_equal(subtract 1500 clock |> display, "04:32")

let ``Subtract more than two days`` () =
    clock <- create 2 20
    expect_equal(subtract 3000 clock |> display, "00:20")

let ``Clocks with same time`` () =
    clock1 <- create 15 37
    clock2 <- create 15 37
    expect_equal(clock1 = clock2, true)

let ``Clocks a minute apart`` () =
    clock1 <- create 15 36
    clock2 <- create 15 37
    expect_equal(clock1 = clock2, false)

let ``Clocks an hour apart`` () =
    clock1 <- create 14 37
    clock2 <- create 15 37
    expect_equal(clock1 = clock2, false)

let ``Clocks with hour overflow`` () =
    clock1 <- create 10 37
    clock2 <- create 34 37
    expect_equal(clock1 = clock2, true)

let ``Clocks with hour overflow by several days`` () =
    clock1 <- create 3 11
    clock2 <- create 99 11
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative hour`` () =
    clock1 <- create 22 40
    clock2 <- create -2 40
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative hour that wraps`` () =
    clock1 <- create 17 3
    clock2 <- create -31 3
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative hour that wraps multiple times`` () =
    clock1 <- create 13 49
    clock2 <- create -83 49
    expect_equal(clock1 = clock2, true)

let ``Clocks with minute overflow`` () =
    clock1 <- create 0 1
    clock2 <- create 0 1441
    expect_equal(clock1 = clock2, true)

let ``Clocks with minute overflow by several days`` () =
    clock1 <- create 2 2
    clock2 <- create 2 4322
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative minute`` () =
    clock1 <- create 2 40
    clock2 <- create 3 -20
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative minute that wraps`` () =
    clock1 <- create 4 10
    clock2 <- create 5 -1490
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative minute that wraps multiple times`` () =
    clock1 <- create 6 15
    clock2 <- create 6 -4305
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative hours and minutes`` () =
    clock1 <- create 7 32
    clock2 <- create -12 -268
    expect_equal(clock1 = clock2, true)

let ``Clocks with negative hours and minutes that wrap`` () =
    clock1 <- create 18 7
    clock2 <- create -54 -11513
    expect_equal(clock1 = clock2, true)

let ``Full clock and zeroed clock`` () =
    clock1 <- create 24 0
    clock2 <- create 0 0
    expect_equal(clock1 = clock2, true)

